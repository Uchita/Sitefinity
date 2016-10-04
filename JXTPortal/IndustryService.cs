	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using JXTPortal.Entities;
using JXTPortal.Entities.Validation;

using JXTPortal.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace JXTPortal
{		
	/// <summary>
	/// An component type implementation of the 'Industry' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class IndustryService : JXTPortal.IndustryServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the IndustryService class.
		/// </summary>
		public IndustryService() : base()
		{
		}
		#endregion Constructors

        public TList<Industry> GetBySiteIdIndustryIdList(System.Int32 _siteId, string _industryIdlist)
        {
            TList<Industry> list = GetBySiteId(_siteId);
            TList<Industry> filteredlist = new TList<Industry>();
            if (!string.IsNullOrWhiteSpace(_industryIdlist))
            {
                string[] industrysplit = _industryIdlist.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string sindustry in industrysplit)
                {
                    foreach (Industry industry in list)
                    {
                        if (industry.IndustryId.ToString() == sindustry)
                        {
                            filteredlist.Add(industry);
                        }
                    }
                }
            }

            return filteredlist;
        }


        public string UpdateIndustryIDBySiteId(System.Int32 _siteId, string _industryNamelist)
        {
            TList<Industry> list = GetBySiteId(_siteId);
            string filteredlist = string.Empty;
            if (!string.IsNullOrWhiteSpace(_industryNamelist))
            {
                string[] industrysplit = _industryNamelist.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Currently only updates one industry - in future multiple.
                foreach (string sindustry in industrysplit)
                {
                    foreach (Industry industry in list)
                    {
                        if (industry.IndustryName.ToLower() == sindustry.ToLower())
                        {
                            if (!string.IsNullOrWhiteSpace(filteredlist))
                                filteredlist = industry.IndustryId.ToString();
                            /*else
                                filteredlist = filteredlist + "," + industry.IndustryId.ToString();*/
                        }
                    }
                }
                /*
                if (!string.IsNullOrWhiteSpace(filteredlist))
                {
                    Industry industry = GetByIndustryId(int.Parse(filteredlist));

                    Update(industry);

                }*/
            }

            return filteredlist;
        }

        public string GetIndustryIDsBySiteId(System.Int32 _siteId, string _industryNamelist)
        {
            TList<Industry> list = GetBySiteId(_siteId);
            string filteredlist = string.Empty;
            if (!string.IsNullOrWhiteSpace(_industryNamelist))
            {
                string[] industrysplit = _industryNamelist.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // TODO - Currently only updates one industry - in future multiple.
                foreach (string sindustry in industrysplit)
                {
                    foreach (Industry industry in list)
                    {
                        if (industry.IndustryName.ToLower() == sindustry.ToLower())
                        {
                            if (string.IsNullOrWhiteSpace(filteredlist))
                                filteredlist = industry.IndustryId.ToString();
                            /*else
                                filteredlist = filteredlist + "," + industry.IndustryId.ToString();*/
                        }
                    }
                }
            }

            return filteredlist;
        }
		

	}//End Class

} // end namespace
