using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Newtonsoft.Json;

namespace JXTNext.Sitefinity.Widgets.Social.Mvc.Models
{
    public class SocialLinkModel
    {
        public SocialLinkModel()
        {
            if (string.IsNullOrWhiteSpace(this.SerializedSocialLinks))
            {
                var socialLinks = new List<SocialViewModel>();
                socialLinks.Add(new SocialViewModel() { Id = 1, Selected = false, Url = "", Title = "Facebook" });
                socialLinks.Add(new SocialViewModel() { Id = 2, Selected = false, Url = "", Title = "Twitter" });
                socialLinks.Add(new SocialViewModel() { Id = 3, Selected = false, Url = "", Title = "LinkedIn" });
                socialLinks.Add(new SocialViewModel() { Id = 4, Selected = false, Url = "", Title = "Google+" });
                socialLinks.Add(new SocialViewModel() { Id = 5, Selected = false, Url = "", Title = "YouTube" });
                socialLinks.Add(new SocialViewModel() { Id = 6, Selected = false, Url = "", Title = "Instagram" });
                socialLinks.Add(new SocialViewModel() { Id = 7, Selected = false, Url = "", Title = "MailTo" });

                this.SerializedSocialLinks = JsonConvert.SerializeObject(socialLinks);
            }
        }

        public List<SocialViewModel> GetViewModel()
        {
            var socialLinks = JsonConvert.DeserializeObject<List<SocialViewModel>>(this.SerializedSocialLinks);
            var selectedLinks = socialLinks.Where(l => l.Selected == true).ToList();

            return selectedLinks;
        }

        public virtual string SerializedSocialLinks { get; set; }
    }
}