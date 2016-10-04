using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    [Serializable]
    public class SessionAdvertiserUser
    {
        public int AdvertiserId { get; set; }

        public int AdvertiserUserId { get; set; }

        public bool PrimaryAccount { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public PortalEnums.Advertiser.AccountType AccountType { get; set; }
        //public string DownloadZipFile { get; set; }
        public List<CartItem> CartItems { get; set; }

        public DateTime? LastTermsAndConditionsDate { get; set; }
    }

    [Serializable]
    public class CartItem
    {
        public int JobItemsTypeID { get; set; }
        public PortalEnums.Jobs.JobItemType JobItemType { get; set; }
        public string ProductDescription { get; set; }
        public decimal TotalAmount { get; set; }
        public int Number { get; set; } //qty of this item
        public int JobsCountInclude { get; set; } //qty of jobs included in this item

        public CartItem()
        {

        }
    }
}
