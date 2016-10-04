using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Collections;

using System.IO;

using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal;

using System.Data.OleDb;

namespace JXTCLAMapper
{
    class Program
    {
        private static CountriesService _countriesservice;
        public static CountriesService CountriesService
        {
            get
            {
                if (_countriesservice == null)
                {
                    _countriesservice = new CountriesService();
                }
                return _countriesservice;
            }
        }

        private static LocationService _locationservice;
        public static LocationService LocationService
        {
            get
            {
                if (_locationservice == null)
                {
                    _locationservice = new LocationService();
                }
                return _locationservice;
            }
        }

        private static AreaService _areaservice;
        public static AreaService AreaService
        {
            get
            {
                if (_areaservice == null)
                {
                    _areaservice = new AreaService();
                }
                return _areaservice;
            }
        }

        static StreamWriter sw = null;

        static void Main(string[] args)
        {

            if (!File.Exists(ConfigurationManager.AppSettings["LogLocation"]))
            {
                FileStream fs = File.Create(ConfigurationManager.AppSettings["LogLocation"]);
                fs.Close();
            }

            sw = new StreamWriter(new FileStream(ConfigurationManager.AppSettings["LogLocation"], FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
            sw.WriteLine("======================================================================================");
            sw.WriteLine("Start importing Country Location Area {0}", DateTime.Now);

            LoadCountryExcel();
            LoadExcel();

            sw.WriteLine("Finished {0}", DateTime.Now);
            sw.WriteLine("======================================================================================");
            sw.Close();
        }

        private static void LoadCountryExcel()
        {

            try
            {
                string path = ConfigurationManager.AppSettings["CountryExcelLocation"];
                string strConn = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;data source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", path);
                OleDbConnection objConn = new OleDbConnection(strConn);

                string strSQL = "SELECT * FROM [Comparison$]";
                OleDbCommand objCmd = new OleDbCommand(strSQL, objConn);

                objConn.Open();

                OleDbDataReader dbReader = objCmd.ExecuteReader();


                List<MiniCountryInfo> miniCountryList = new List<MiniCountryInfo>();
                while (dbReader.Read())
                {
                    MiniCountryInfo mci = new MiniCountryInfo();

                    mci.ID = dbReader.GetValue(8).ToString();
                    mci.Country = dbReader.GetValue(9).ToString();
                    mci.Currency = dbReader.GetValue(4).ToString();
                    mci.Action = dbReader.GetValue(12).ToString();

                    miniCountryList.Add(mci);
                }

                using (TList<Countries> countries = CountriesService.GetAll())
                {
                    int maxid = countries.Count;

                    foreach (MiniCountryInfo mci in miniCountryList)
                    {

                        bool found = false;

                        foreach (Countries c in countries)
                        {
                            if ((!string.IsNullOrEmpty(mci.ID) && Convert.ToInt32(mci.ID) == c.CountryId) || c.CountryName == mci.Country)
                            {
                                found = true;
                                bool updated = false;

                                if (mci.Action.ToLower() == "edit" || mci.Action.ToLower() == "change")
                                {
                                    c.CountryName = mci.Country;
                                    updated = true;
                                }
                                if (mci.Currency != "#N/A" && mci.Currency.Length <= 5 && c.Currency != mci.Currency)
                                {
                                    c.Currency = mci.Currency;
                                    updated = true;
                                }

                                CountriesService.Update(c);

                                if (updated)
                                {
                                    sw.WriteLine(string.Format("Upated Country {0}", c.CountryName));
                                }

                                break;
                            }
                        }

                        if (!found && mci.Action.ToLower() == "add")
                        {
                            maxid++;
                            Countries newCountry = new Countries();
                            newCountry.CountryName = mci.Country;
                            newCountry.Abbr = "";
                            newCountry.Valid = true;
                            newCountry.Sequence = maxid;
                            if (mci.Currency != "#N/A" && mci.Currency.Length <= 5)
                            {
                                newCountry.Currency = mci.Currency;
                            }

                            CountriesService.Insert(newCountry);
                            sw.WriteLine(string.Format("Added Country {0}", newCountry.CountryName));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                sw.WriteLine("Error: " + ex.Message);
            }
        }

        private static void LoadExcel()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["ExcelLocation"];
                string strConn = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;data source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", path);
                OleDbConnection objConn = new OleDbConnection(strConn);

                string strSQL = "SELECT * FROM [Jobx - Country - Location Area$]";
                OleDbCommand objCmd = new OleDbCommand(strSQL, objConn);

                objConn.Open();

                OleDbDataReader dbReader = objCmd.ExecuteReader();

                List<CountryInfo> masterList = new List<CountryInfo>();
                List<CountryInfo> distinctCountry = new List<CountryInfo>();
                List<CountryInfo> distinctLocation = new List<CountryInfo>();
                List<CountryInfo> distinctArea = new List<CountryInfo>();

                CountryInfo previousCountry = null;
                CountryInfo previousLocation = null;
                CountryInfo previousArea = null;

                while (dbReader.Read())
                {
                    CountryInfo ci = new CountryInfo();

                    ci.CountryID = dbReader.GetValue(0).ToString();
                    ci.Country = dbReader.GetValue(1).ToString();
                    ci.ProperName = dbReader.GetValue(2).ToString();
                    ci.SuburbLocationID = dbReader.GetValue(3).ToString();
                    ci.Location = dbReader.GetValue(4).ToString();
                    ci.SuburbLocationAreaID = dbReader.GetValue(5).ToString();
                    ci.Area = dbReader.GetValue(6).ToString();
                    ci.Action = dbReader.GetValue(7).ToString();

                    masterList.Add(ci);

                    if (previousCountry != null)
                    {
                        if (ci.CountryID != previousCountry.CountryID && ci.Country != previousCountry.Country)
                        {
                            distinctCountry.Add(ci);
                        }
                    }
                    else
                    {
                        distinctCountry.Add(ci);
                    }

                    if (previousLocation != null)
                    {
                        if (ci.Location != previousLocation.Location && string.IsNullOrEmpty(ci.Location) == false)
                        {
                            distinctLocation.Add(ci);
                        }
                    }
                    else
                    {
                        distinctLocation.Add(ci);
                    }

                    if (previousArea != null)
                    {
                        if (ci.Area != previousArea.Area && string.IsNullOrEmpty(ci.Area) == false)
                        {
                            distinctArea.Add(ci);
                        }
                    }

                    masterList.Add(ci);

                    previousCountry = ci;
                    previousLocation = ci;
                    previousArea = ci;
                }


                foreach (CountryInfo ci in distinctLocation)
                {

                    using (TList<Location> locations = LocationService.GetAll())
                    {
                        bool found = false;
                        bool updated = false;

                        using (TList<Countries> countries = CountriesService.GetAll())
                        {
                            foreach (Countries c in countries)
                            {
                                if (c.CountryName == ci.ProperName)
                                {
                                    foreach (Location l in locations)
                                    {
                                        if (l.LocationName.ToLower() == ci.Location.ToLower() && l.CountryId == c.CountryId)
                                        {

                                            found = true;


                                            if (l.LocationName != ci.Location)
                                            {
                                                l.LocationName = ci.Location;
                                                updated = true;
                                            }

                                            if (l.CountryId != c.CountryId)
                                            {
                                                l.CountryId = c.CountryId;
                                                updated = true;
                                            }
                                            LocationService.Update(l);

                                            if (updated && (ci.Action.ToLower() == "change" || ci.Action.ToLower() == "edit"))
                                            {
                                                sw.WriteLine(string.Format("Updated Location {0}", l.LocationName));
                                            }
                                            break;
                                        }
                                    }

                                    if (found) break;
                                }
                            }
                        }

                        if (!found)
                        {
                            Location newLocation = new Location();
                            newLocation.LocationName = ci.Location;
                            newLocation.Valid = true;

                            using (TList<Countries> countries = CountriesService.GetAll())
                            {
                                foreach (Countries c in countries)
                                {
                                    if (c.CountryName == ci.ProperName && ci.Action.ToLower() == "add")
                                    {
                                        newLocation.CountryId = c.CountryId;

                                        LocationService.Insert(newLocation);
                                        sw.WriteLine(string.Format("Added Location {0}", newLocation.LocationName));
                                        break;
                                    }
                                }
                            }

                        }
                    }
                }


                foreach (CountryInfo ci in distinctArea)
                {
                    using (TList<Area> areas = AreaService.GetAll())
                    {
                        bool found = false;
                        bool updated = false;
                        Area foundarea = null;

                        using (TList<Countries> countries = CountriesService.GetAll())
                        {
                            foreach (Countries c in countries)
                            {
                                if (ci.ProperName == c.CountryName)
                                {

                                    using (TList<Location> locations = LocationService.GetByCountryId(c.CountryId))
                                    {
                                        foreach (Location l in locations)
                                        {
                                            if (l.LocationName == ci.Location && l.CountryId == c.CountryId)
                                            {
                                                foreach (Area a in areas)
                                                {
                                                    if (a.AreaName.ToLower() == ci.Area.ToLower() && a.LocationId == l.LocationId)
                                                    {

                                                        a.LocationId = l.LocationId;
                                                        foundarea = a;

                                                        found = true;

                                                        break;
                                                    }
                                                }
                                                if (found)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    if (found)
                                    {
                                        break;
                                    }

                                }
                            }

                            if (found)
                            {
                                if (foundarea.AreaName != ci.Area)
                                {
                                    foundarea.AreaName = ci.Area;
                                    updated = true;
                                }

                                if (AreaService.Update(foundarea))
                                {
                                    if (updated && (ci.Action.ToLower() == "change" || ci.Action.ToLower() == "edit"))
                                    {
                                        sw.WriteLine(string.Format("Updated Area {0}", foundarea.AreaName));
                                    }
                                }
                            }
                        }

                        if (!found)
                        {
                            Area newArea = new Area();
                            newArea.AreaName = ci.Area;
                            newArea.Valid = true;

                            bool inserted = false;

                            // Console.WriteLine("Not Found: {0}, {1}, {2}", ci.ProperName, ci.Location, ci.Area);

                            using (TList<Countries> countries = CountriesService.GetAll())
                            {
                                foreach (Countries c in countries)
                                {

                                    if (ci.ProperName == c.CountryName)
                                    {

                                        using (TList<Location> locations = LocationService.GetByCountryId(c.CountryId))
                                        {
                                            foreach (Location l in locations)
                                            {
                                                if (l.LocationName == ci.Location && ci.Action.ToLower() == "add" && l.CountryId == c.CountryId)
                                                {
                                                    newArea.LocationId = l.LocationId;

                                                    AreaService.Insert(newArea);
                                                    sw.WriteLine(string.Format("Added Area {0}", newArea.AreaName));

                                                    inserted = true;
                                                    break;
                                                }
                                            }
                                        }

                                        if (inserted) break;
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sw.WriteLine("Error: " + ex.Message);
            }

        }

        private class CountryInfo
        {
            public string CountryID { get; set; }
            public string Country { get; set; }
            public string ProperName { get; set; }
            public string SuburbLocationID { get; set; }
            public string Location { get; set; }
            public string SuburbLocationAreaID { get; set; }
            public string Area { get; set; }
            public string Action { get; set; }

            public CountryInfo() { }
        }

        private class MiniCountryInfo
        {
            public string ID { get; set; }
            public string Country { get; set; }
            public string Currency { get; set; }
            public string Action { get; set; }
        }
    }
}
