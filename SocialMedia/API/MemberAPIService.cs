using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JXTPortal.Data;
using JXTPortal.Data.SqlClient;
using JXTPortal;
using JXTPortal.Common;
using JXTPortal.Entities;

namespace SocialMedia.API
{
    public class MemberAPIService
    {
        public bool MemberSocialMediaLogin(int siteid, string firstname, string surname, string emailaddress, string source, ref int memberid, ref string errormsg, string accessToken = "", bool validated = true)
        {
            MembersService service = new MembersService();
            GlobalSettingsService gservice = new GlobalSettingsService();

            using (JXTPortal.Entities.Members member = service.GetBySiteIdEmailAddress(siteid, emailaddress))
            {
                if (member != null)
                {
                    // Login Orgin is missing
                    member.Valid = validated;
                    member.RequiredPasswordChange = false;
                    member.FirstName = firstname;
                    member.Surname = surname;
                    member.LinkedInAccessToken = accessToken;
                    member.Validated = validated;
                    memberid = member.MemberId;
                    service.Update(member);

                    SessionService.RemoveAdvertiserUser();
                    SessionService.SetMember(member);

                    return true;
                }
                else
                {
                    // Create Member
                    int countryid = 1;
                    int languageid = 1;

                    TList<GlobalSettings> gslist = gservice.GetBySiteId(siteid);
                    if (gslist.Count > 0)
                    {
                        if (gslist[0].DefaultCountryId.HasValue)
                        {
                            countryid = gslist[0].DefaultCountryId.Value;
                            languageid = gslist[0].DefaultLanguageId;
                        }
                    }

                    using (JXTPortal.Entities.Members objMembers = new JXTPortal.Entities.Members())
                    {
                        objMembers.SiteId = siteid;
                        objMembers.FirstName = firstname;
                        objMembers.Surname = surname;
                        objMembers.EmailAddress = emailaddress;
                        objMembers.EmailFormat = (int)PortalEnums.Email.EmailFormat.HTML;
                        objMembers.Username = emailaddress;
                        objMembers.LinkedInAccessToken = accessToken;
                        objMembers.CountryId = countryid;
                        objMembers.DefaultLanguageId = languageid;
                        string newpassword = System.Web.Security.Membership.GeneratePassword(10, 0);
                        objMembers.Validated = validated;
                        objMembers.Password = CommonService.EncryptMD5(newpassword);
                        objMembers.ValidateGuid = Guid.NewGuid();
                        objMembers.SearchField = String.Format("{0} {1}",
                                                   objMembers.FirstName,
                                                   objMembers.Surname);
                        objMembers.Valid = validated;
                        objMembers.RequiredPasswordChange = false;
                        DynamicContentService dcservice = new DynamicContentService();
                        using (TList<DynamicContent> dynamiccontents = dcservice.GetBySiteId(SessionData.Site.SiteId))
                        {
                            foreach (DynamicContent dynamiccontent in dynamiccontents)
                            {
                                if (dynamiccontent.DynamicContentType == ((int)PortalEnums.DynamicContent.DynamicContentType.MemberTermsAndConditions) && dynamiccontent.Active)
                                {
                                    objMembers.LastTermsAndConditionsDate = DateTime.Now;
                                }
                            }
                        }

                        if (service.Insert(objMembers))
                        {
                            //Send confirmation email
                            MailService.SendMemberRegistration(objMembers, newpassword);

                            SessionService.RemoveAdvertiserUser();
                            SessionService.SetMember(objMembers);

                            memberid = objMembers.MemberId;
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
