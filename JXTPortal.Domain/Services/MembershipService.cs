using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using JXTPortal.Domain.ViewModel;
using JXTPortal;
using JXTPortal.Entities;

namespace JXTPortal.Domain.Services
{
    public class MembershipService
    {
        public JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus Register(MemberModel.RegistrationModel model)
        {
            JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus status = JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus.ProviderError;

            if (model.Email.Trim().Length > 0 && MembersService.GetBySiteIdEmailAddress(SessionData.Site.SiteId, model.Email) != null)
            {
                status = JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus.DuplicateEmail;
                return status;
            }

            if (model.UserName.Trim().Length > 0 && MembersService.GetBySiteIdUsername(SessionData.Site.SiteId, model.UserName) != null)
            {
                status = JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus.DuplicateUserName;
                return status;
            }

            Entities.Members member = new Entities.Members()
            {
                Username = model.UserName,
                SiteId = SessionData.Site.SiteId,
                Password = CommonService.EncryptMD5(model.Password),
                FirstName = string.Empty,
                Surname = string.Empty,
                Valid = true,
                Validated = true,
                ValidateGuid = new Guid(),
                EmailAddress = model.Email,
                CountryId = 1,
                EmailFormat = 1,
                ReferringSiteId = SessionData.Site.SiteId,
            };
            
            MembersService.Insert(member);
            status = JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus.Success;
            return status;
        }

        public JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus Login(MemberModel.LoginModel model, bool encryptedPassword = false)
        {
            JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus status = JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus.InvalidPasswordOrUserName;
            Entities.Members member = MembersService.GetBySiteIdUsername(SessionData.Site.SiteId, model.UserName);
            string password = model.Password;
            if (!encryptedPassword) password = CommonService.EncryptMD5(model.Password);
            if (member != null)
            {
                if (member.Password == password)
                {
                    status = JXTPortal.Domain.ViewModel.Common.JXTMembershipStatus.Success;
                }
            }

            return status;
        }

        public Entities.Members Convert(MemberModel.RegistrationModel model)
        {
            return MembersService.GetBySiteIdUsername(SessionData.Site.SiteId, model.UserName);
        }

        public Entities.Members Convert(MemberModel.LoginModel model)
        {
            return MembersService.GetBySiteIdUsername(SessionData.Site.SiteId, model.UserName);
        }

        /// <summary>
        /// get the member files
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public MemberModel.MemberFilesModel MemberFiles(int MemberId)
        {
            MemberModel.MemberFilesModel model = new MemberModel.MemberFilesModel();
            var files = MemberFilesService.GetByMemberId(MemberId);

            model.Resumes = (from f in files
                             where f.DocumentTypeId == (int)PortalEnums.Members.MemberFileTypes.Resume
                             select f).ToList();
            model.CoverLetters = (from f in files
                                  where f.DocumentTypeId == (int)PortalEnums.Members.MemberFileTypes.CoverLetter
                                  select f).ToList();

            return model;
        }

        public MemberModel.ApplyJobModel LoadApplyJobModel(int SiteId, int JobId, int MemberId)
        {
            MemberModel.ApplyJobModel model = new MemberModel.ApplyJobModel();
            JobsService jobsService = new JobsService();
            model.IsValidJob = (jobsService.GetByJobId(JobId).SiteId == SiteId);

            if (model.IsValidJob && MemberId > 0)
            {
                Members member = MembersService.GetByMemberId(MemberId);
                model.FirstName = member.FirstName != null ? member.FirstName : "" ;
                model.Surname = member.Surname != null ? member.Surname : "";
                model.ContactNo = (member.MobilePhone != null && member.MobilePhone.Length > 0 ? member.MobilePhone : member.HomePhone != null ? member.HomePhone : "");
                model.Email = member.EmailAddress;

                var appliedJobs = new JobApplicationService().GetByMemberId(SessionData.Member.MemberId).Where(x => x.JobId == JobId);

                model.IsValidJob = true;
                model.IsApplied = (appliedJobs.Count() > 0);
                var files = MemberFilesService.GetByMemberId(MemberId);

                model.Resumes = (from f in files
                                 where f.DocumentTypeId == (int)PortalEnums.Members.MemberFileTypes.Resume
                                 select f).ToList();
                model.CoverLetters = (from f in files
                                      where f.DocumentTypeId == (int)PortalEnums.Members.MemberFileTypes.CoverLetter
                                      select f).ToList();
            }

            return model;
        }

        /// <summary>
        /// this is used to verify the old password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool VerifyPassword(MemberModel.ChangePasswordModel model)
        {
            var member = MembersService.GetByMemberId(SessionData.Member.MemberId);

            return (member.Password == CommonService.EncryptMD5(model.OldPassword));
        }

        /// <summary>
        /// this function is used to change the password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void ChangePassword(MemberModel.ChangePasswordModel model)
        {
            var member = MembersService.GetByMemberId(SessionData.Member.MemberId);
            member.Password = CommonService.EncryptMD5(model.NewPassword);
            MembersService.Update(member);
        }
        
        /// <summary>
        /// forgotten password
        /// </summary>
        /// <param name="SiteId"></param>
        /// <param name="EmailOrUserName"></param>
        /// <returns></returns>
        public bool ForgetPassword(MemberModel.ForgetPasswordModel model)
        {
            bool success = false;

            var member = MembersService.GetBySiteIdEmailAddressOrUserName(SessionData.Site.SiteId, model.UserNameEmail);
            
            //return false when there is no member is found
            success = (member != null);

            if (success)
            { 
                 member.ValidateGuid = Guid.NewGuid();

                 if (MembersService.Update(member))
                 {
                     MailService.SendMemberForgottenPasswordEmail(member);
                 }
            }

            return success;
        }

        #region "Properties"

        private MembersService _membersService;

        private MembersService MembersService
        {
            get
            {
                if (_membersService == null)
                    _membersService = new MembersService();

                return _membersService;
            }
        }

        private MemberFilesService _memberFilesService;

        private MemberFilesService MemberFilesService
        {
            get
            {
                if (_memberFilesService == null)
                    _memberFilesService = new MemberFilesService();

                return _memberFilesService;
            }
        }

        #endregion
    }
}
