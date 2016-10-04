using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JXTPortal.Entities
{
    [Serializable]
    public class JobSearch
    {
        #region Declare variables

        int _pageIndex;

        string _keywords;
        string _professionID;
        string _roleIDs;
        int? _countryID;
        string _locationID;
        string _areaIDs;
        DateTime? _dateFrom;
        int? _currencyID;
        int? _workTypeID;
        int? _salaryTypeID;
        decimal? _salaryLowerBand;
        decimal? _salaryUpperBand;
        int? _advertiserID;

        #endregion

        #region Properties

        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }
        
        public string Keywords
        {
            get
            {
                if (String.IsNullOrEmpty(_keywords))
                    return string.Empty;
                else
                    return _keywords;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _keywords = value;
                else
                    _keywords = string.Empty;
            }
        }

        public string ProfessionID
        {
            get
            {
                if (String.IsNullOrEmpty(_professionID))
                    return string.Empty;
                else
                    return _professionID;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _professionID = value;
                else
                    _professionID = string.Empty;
            }
        }

        public string RoleIDs
        {
            get
            {
                if (String.IsNullOrEmpty(_roleIDs))
                    return string.Empty;
                else
                    return _roleIDs;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _roleIDs = value;
                else
                    _roleIDs = string.Empty;
            }
        }


        public int? CountryID
        {
            get
            {
                if (_countryID.HasValue)
                    return _countryID.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _countryID = value.Value;
                else
                    _countryID = null;
            }
        }

        public string LocationID
        {
            get
            {
                if (String.IsNullOrEmpty(_locationID))
                    return string.Empty;
                else
                    return _locationID;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _locationID = value;
                else
                    _locationID = string.Empty;
            }
        }

        public string AreaIDs
        {
            get
            {
                if (String.IsNullOrEmpty(_areaIDs))
                    return string.Empty;
                else
                    return _areaIDs;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _areaIDs = value;
                else
                    _areaIDs = string.Empty;
            }
        }

        public DateTime? DateFrom
        {
            get
            {
                if (_dateFrom.HasValue)
                    return _dateFrom.Value;

                return null;
            }
            set
            {
                if (value.HasValue)
                    _dateFrom = value.Value;
                else
                    _dateFrom = null;
            }
        }

        public int? CurrencyID
        {
            get
            {
                if (_currencyID.HasValue)
                    return _currencyID.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _currencyID = value.Value;
                else
                    _currencyID = null;
            }
        }


        public int? WorkTypeID
        {
            get
            {
                if (_workTypeID.HasValue)
                    return _workTypeID.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _workTypeID = value.Value;
                else
                    _workTypeID = null;
            }
        }

        public int? SalaryTypeID
        {
            get
            {
                if (_salaryTypeID.HasValue)
                    return _salaryTypeID.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _salaryTypeID = value.Value;
                else
                    _salaryTypeID = null;
            }
        }

        public decimal? SalaryLowerBand
        {
            get
            {
                if (_salaryLowerBand.HasValue)
                    return _salaryLowerBand.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _salaryLowerBand = value.Value;
                else
                    _salaryLowerBand = null;
            }
        }

        public decimal? SalaryUpperBand
        {
            get
            {
                if (_salaryUpperBand.HasValue)
                    return _salaryUpperBand.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _salaryUpperBand = value.Value;
                else
                    _salaryUpperBand = null;
            }
        }


        public int? AdvertiserID
        {
            get
            {
                if (_advertiserID.HasValue)
                    return _advertiserID.Value;

                return null;
            }
            set
            {
                if (value.HasValue && value.Value > 0)
                    _advertiserID = value.Value;
                else
                    _advertiserID = null;
            }
        }

        #endregion

        #region Methods

        public void ClearAllValues()
        {
            PageIndex = 0;
            Keywords = string.Empty;
            ProfessionID = null;
            RoleIDs = String.Empty;
            LocationID = null;
            AreaIDs = String.Empty;
            DateFrom = null;
            CurrencyID = null;
            SalaryLowerBand = null;
            SalaryUpperBand = null;
            WorkTypeID = null;
            AdvertiserID = null;
        }
        
        #endregion



    }
}
