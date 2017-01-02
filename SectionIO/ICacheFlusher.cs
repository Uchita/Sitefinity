using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectionIO
{
    public interface ICacheFlusher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageUrl"></param>
        void FlushByUrl(string pageUrl);

        /// <summary>
        /// this is what I do
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="siteBaseUriFormat">The format of the uri <example>"://www.example.com/http_imagesjxtnetau/{0}"</example></param>
        void FlushAssetType(AssetClass assetToFlush, string siteBaseUriFormat);
    }

    public enum AssetClass
    {
        js,
        css,
        all
    }
}

