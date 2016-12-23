using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectionIO
{
    public interface ICacheFlusher
    {
        void FlushByUrl(string pageUrl);
        void FlushAssetType(AssetClass assetToFlush, string siteBaseUri);
    }
    [Flags]
    public enum AssetClass
    {
        Javascript = 1,
        Css = 2,
        Images = 4,

        All = 7
    }
}
