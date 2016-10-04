using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    [Serializable]
    public class WebServiceSearch
    {
        #region Declare variables

        int _pageIndex;

        int _siteId;
        int? _advertiserId;
        string _datefrom;
        string _dateto;
        bool _showOnlyFails = false;
        #endregion

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        public int SiteID
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        public int? AdvertiserID
        {
            get { return _advertiserId; }
            set
            {
                if (value.HasValue && value.Value > 0)
                {
                    _advertiserId = value;
                }
            }
        }

        public string DateFrom
        {
            get { return _datefrom; }
            set
            {
                _datefrom = value;
            }
        }

        public string DateTo
        {
            get { return _dateto; }
            set
            {
                _dateto = value;

            }
        }

        public bool ShowOnlyFails
        {
            get { return _showOnlyFails; }
            set
            {
                _showOnlyFails = value;
            }
        }

        #region Methods

        public void ClearAllValues()
        {
            PageIndex = 0;
            SiteID = 0;
            AdvertiserID = null;
            DateFrom = null;
            DateTo = null;
            ShowOnlyFails = false;
        }

        #endregion
    }
}
