using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectionIO
{
    public interface ICacheFlusher
    {
        /// <summary>
        /// This method build the banexpression that needs to be passed into "API_Proxy_State_Post()" in order to clear cached dynamic pages in Section.IO
        /// </summary>
        /// <param name="uri">the uri to flush</param>
        void FlushByUrl(Uri uri);

        /// <summary>
        /// This method builds the banexpression that needs to be passed into "API_Proxy_State_Post()"
        /// </summary>
        /// <param name="asset">Asset type that was passed into the method from SitesEdit.aspx button click</param>
        /// <param name="site">The format of the uri <example>"https://www.example.com/http_imagesjxtnetau/jxt-solutions"</example></param>
        /// <param name="folderName">Passes global FTP folder name</param>
        void FlushAssetType(AssetClass asset, string site, string folderName);

        /// <summary>
        /// This Method builds the banexpression that needs to be passed into "API_Proxy_State_Post()" inorder to clear cached Images
        /// </summary>
        /// <param name="siteUrl">This parameter contains first bit of the URL (before /media)<example>"http(s)://wwww.example.com"</example></param>
        /// <param name="imagepath">This parameter contains folderpath that comes after "/media"</param>
        /// <param name="imageName">This parameter passes name of the image that needs to be cleared from SEctionIO cache</param>
        void FlushImage(string siteUrl, string imagepath, string imageName);
    }

    public enum AssetClass
    {
        js,
        css,
        all
    }
}

