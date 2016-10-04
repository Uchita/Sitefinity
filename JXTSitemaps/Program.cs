using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;

using JXTPortal.Data;
using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal;

namespace JXTSitemaps
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSiteMaps();
        }

        private static void GenerateSiteMaps()
        {
            int CampaignSequenceNumber = -99999;

            // Retrieve all valid site

            GlobalSettingsService gsService = new GlobalSettingsService();

            string sitemapfolder = ConfigurationManager.AppSettings["SitemapFolder"];
            SitesService ss = new SitesService();
            TList<Sites> ls = ss.GetAll();
            ls.Filter = "Live = true";
            foreach (Sites s in ls)
            {
                try
                {

                    Console.WriteLine(string.Format("Generating {0} Sitemap...", s.SiteName));
                    ArrayList alFileName = new ArrayList();
                    //Get first Site Language
                    SiteLanguagesService sls = new SiteLanguagesService();
                    TList<SiteLanguages> lsl = sls.GetBySiteId(s.SiteId);
                    GlobalSettings gs = gsService.GetBySiteId(s.SiteId).FirstOrDefault();
                    if (lsl.Count > 0)
                    {
                        int languageid = lsl[0].LanguageId;
                        // XML for Dynamic Pages
                        StringBuilder sbdp = new StringBuilder();
                        sbdp.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                        sbdp.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

                        DynamicPagesService dps = new DynamicPagesService();
                        TList<DynamicPages> ldp = dps.GetHierarchy(s.SiteId, languageid, 0, null, true, false);  

                        string strDynamicUrl = string.Empty;
                        foreach (DynamicPages dp in ldp)
                        {
                            if (dp.ParentDynamicPageId == 0 && dp.Sequence == CampaignSequenceNumber)
                            { }
                            else
                            {
                                // Only if checked to display on Sitemap.
                                if (dp.OnSiteMap)
                                {
                                    strDynamicUrl = dps.GetDynamicPageFullUrl(s.SiteUrl, dp, gs.WwwRedirect, gs.EnableSsl).ToLower();

                                    sbdp.AppendLine(string.Format("<url>\n<loc><![CDATA[{0}]]></loc>\n<priority>{1}</priority>\n<changefreq>weekly</changefreq></url>",
                                                                    strDynamicUrl,
                                                                    (dp.PageName != null && dp.PageName.ToLower().Equals("homepage") ? "1" : "0.7")));
                                }
                            }
                        }

                        sbdp.AppendLine("</urlset>");
                        XmlDocument xddp = new XmlDocument();
                        
                        //File.WriteAllText(string.Format("{0}\\{1}.sitemap.txt", sitemapfolder, s.SiteUrl), sbdp.ToString());

                        xddp.LoadXml(sbdp.ToString());
                        alFileName.Add(string.Format("{0}.sitemap.xml", s.SiteUrl));
                        //xddp.Save(string.Format("{0}\\{1}.sitemap.xml", sitemapfolder, s.SiteUrl));

                        ParameterizedThreadStart pts = new ParameterizedThreadStart(SaveXML);
                        Thread t = new Thread(pts);
                        t.Start(new XmlSaveType(xddp, string.Format("{0}\\{1}.sitemap.xml", sitemapfolder, s.SiteUrl)));

                    }

                    // Retrieve all Valid Site Professions
                    SiteProfessionService sps = new SiteProfessionService();
                    TList<SiteProfession> lsp = sps.GetBySiteId(s.SiteId);
                    lsp.Filter = "Valid = true";

                    foreach (SiteProfession sp in lsp)
                    {
                        ViewJobSearchService vjss = new ViewJobSearchService();
                        VList<JXTPortal.Entities.ViewJobSearch> lvjs = vjss.GetBySearchFilter(
                                                    string.Empty,
                                                    s.SiteId, null,
                                                    null, null, null, null, null,
                                                    sp.ProfessionId, string.Empty,
                                                    null, null, string.Empty, null,
                                                    0, Int16.MaxValue, string.Empty, null);
                        if (lvjs.Count > 0)
                        {
                            StringBuilder sbjob = new StringBuilder();
                            sbjob.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                            sbjob.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

                            foreach (ViewJobSearch vjs in lvjs)
                            {
                                sbjob.AppendLine(string.Format("<url>\n<loc>{0}</loc>\n<priority>0.6</priority>\n<changefreq>weekly</changefreq></url>", vjss.GetJobFullUrl(s.SiteUrl, vjs, gs.WwwRedirect, gs.EnableSsl).ToLower()));
                            }

                            sbjob.AppendLine("</urlset>");
                            XmlDocument xdjob = new XmlDocument();
                            xdjob.LoadXml(sbjob.ToString());
                            alFileName.Add(string.Format("{0}.{1}.sitemap.xml", s.SiteUrl, sp.SiteProfessionFriendlyUrl.ToLower()));

                            ParameterizedThreadStart pts = new ParameterizedThreadStart(SaveXML);
                            Thread t = new Thread(pts);
                            t.Start(new XmlSaveType(xdjob, string.Format("{0}\\{1}.{2}.sitemap.xml", sitemapfolder, s.SiteUrl, sp.SiteProfessionFriendlyUrl.ToLower())));
                        }
                    }

                    // Write Sitemap Index xml - https://support.google.com/webmasters/answer/71453?hl=en
                    string webfolder = ConfigurationManager.AppSettings["SitemapWebFolder"];
                    StringBuilder sbindex = new StringBuilder();
                    sbindex.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sbindex.AppendLine("<sitemapindex xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
                    foreach (string filename in alFileName)
                    {
                        sbindex.AppendLine(string.Format("<sitemap>\n<loc>{3}://{0}/{1}/{2}</loc>\n</sitemap>", (gs.WwwRedirect ? "www." : string.Empty) + s.SiteUrl, webfolder, filename,
                                                            (gs.EnableSsl ? "https" : "http")));
                    }
                    sbindex.AppendLine("</sitemapindex>");
                    XmlDocument xdindex = new XmlDocument();
                    xdindex.LoadXml(sbindex.ToString());

                    ParameterizedThreadStart ptsindex = new ParameterizedThreadStart(SaveXML);
                    Thread tindex = new Thread(ptsindex);
                    tindex.Start(new XmlSaveType(xdindex, string.Format("{0}\\{1}.sitemapindex.xml", sitemapfolder, s.SiteUrl)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}\n{1}", ex.Message, ex.StackTrace);
                    //Console.ReadLine();
                }
            }


            Console.WriteLine("Finished.");
        }

        private static void SaveXML(object obj)
        {
            XmlSaveType xst = (XmlSaveType)obj;
            xst.XMLDoc.Save(xst.Path);
        }

        internal class XmlSaveType
        {
            public XmlDocument XMLDoc { get; set; }
            public string Path { get; set; }

            public XmlSaveType(XmlDocument xmldoc, string path)
            {
                XMLDoc = xmldoc;
                Path = path;
            }
        }
    }
}
