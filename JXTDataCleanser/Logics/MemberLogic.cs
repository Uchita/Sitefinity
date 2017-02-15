using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTDataCleanser.Intefaces;
using log4net;
using JXTPortal.Entities;
using JXTPortal;
using JXTDataCleanser.Models;

namespace JXTDataCleanser.Logics
{
    public class MemberLogic : IDataCleanserLogic
    {
        ILog _logger;

        public MemberLogic()
        {
            _logger = LogManager.GetLogger(typeof(MemberLogic));
        }

        public bool CanHandle(string[] args)
        {
            string requestedAction = args.ElementAtOrDefault(0);
            if (requestedAction == null)
                return false;

            //check 
            DataCleanAction thisAction;
            bool actionValid = Enum.TryParse<DataCleanAction>(requestedAction, true, out thisAction);
            if (!actionValid || (thisAction != DataCleanAction.Member && thisAction != DataCleanAction.AllMembers))
                return false;

            if (thisAction == DataCleanAction.Member)
            {
                int temp;
                bool siteIDArg = int.TryParse(args.ElementAtOrDefault(1), out temp);
                bool memberIDArg = int.TryParse(args.ElementAtOrDefault(2), out temp);

                if (siteIDArg && memberIDArg)
                    return true;
                return false;
            }
            else if (thisAction == DataCleanAction.AllMembers)
            {
                int temp;
                bool siteIDArg = int.TryParse(args.ElementAtOrDefault(1), out temp);

                if (siteIDArg)
                    return true;
                return false;
            }

            return false;
        }

        public void Process(string[] args)
        {
            //given the "CanHandle" method should have checked, we can assume args data are clean
            DataCleanAction thisAction = (DataCleanAction) Enum.Parse(typeof(DataCleanAction), args[0], true);

            if (thisAction == DataCleanAction.AllMembers)
                CleanBySiteId(int.Parse(args[1]));

            if( thisAction == DataCleanAction.Member)
                CleanById(int.Parse(args[1]), int.Parse(args[2]));
        }

        public void CleanById(int siteId, int id)
        {
            _logger.DebugFormat("Start member removal request, target siteID({0}) memberID({1})", siteId, id);

            try
            {
                JobApplicationNotesService _jobAppNoteService = new JobApplicationNotesService();
                JobApplicationService _jobAppService = new JobApplicationService();
                MemberLanguagesService _memLangService = new MemberLanguagesService();
                MemberQualificationService _memQualService = new MemberQualificationService();
                JobAlertsService _jobAlertService = new JobAlertsService();
                MemberPositionsService _memPositionService = new MemberPositionsService();
                MemberCertificateMembershipsService _memCertService = new MemberCertificateMembershipsService();
                JobsSavedService _jobSavedService = new JobsSavedService();
                MemberFilesService _memberFileService = new MemberFilesService();
                MemberReferencesService _memRefService = new MemberReferencesService();
                MemberLicensesService _memLicenceService = new MemberLicensesService();
                MembersService _memberService = new MembersService();

                //check member success
                Members thisMember = _memberService.GetByMemberId(id);
                if (thisMember != null && thisMember.SiteId == siteId)
                {
                    _logger.DebugFormat("Member found. Attempting delete process");

                    #region Job Application Notes
                    _logger.DebugFormat("Deleting Job Application Notes...");
                    int jobAppNotesCount = 0;
                    TList<JobApplicationNotes> notes = _jobAppNoteService.GetByMemberId(thisMember.MemberId);
                    jobAppNotesCount = notes.Count();
                    _jobAppNoteService.Delete(notes);
                    _logger.DebugFormat("Deleted {0} Job Application Notes", jobAppNotesCount);
                    #endregion

                    #region Job Applications
                    _logger.DebugFormat("Deleting Job Applications...");
                    int jobAppCount = 0;
                    TList<JobApplication> jobApplications = _jobAppService.GetByMemberId(thisMember.MemberId);
                    jobAppCount = jobApplications.Count();
                    _jobAppService.Delete(jobApplications);
                    _logger.DebugFormat("Deleted {0} Job Application", jobAppCount);
                    #endregion

                    #region Member Languages
                    _logger.DebugFormat("Deleting Member Languages...");
                    int memberLanguagesCount = 0;
                    TList<MemberLanguages> memberLanguages = _memLangService.GetByMemberId(thisMember.MemberId);
                    memberLanguagesCount = memberLanguages.Count();
                    _memLangService.Delete(memberLanguages);
                    _logger.DebugFormat("Deleted {0} Member Languages", memberLanguagesCount);
                    #endregion

                    #region Member Qualifications
                    _logger.DebugFormat("Deleting Member Qualifications...");
                    TList<MemberQualification> memberQuals = _memQualService.GetByMemberId(thisMember.MemberId);
                    int memberQualCount = memberQuals.Count();
                    _memQualService.Delete(memberQuals);
                    _logger.DebugFormat("Deleted {0} Member Qualifications", memberQualCount);
                    #endregion

                    #region Job Alerts
                    _logger.DebugFormat("Deleting Job Alerts...");
                    TList<JobAlerts> memberJobAlerts = _jobAlertService.GetByMemberId(thisMember.MemberId);
                    int memberJobAlertsCount = memberJobAlerts.Count();
                    _jobAlertService.Delete(memberJobAlerts);
                    _logger.DebugFormat("Deleted {0} Member Job Alerts", memberJobAlertsCount);
                    #endregion

                    #region Member Positions
                    _logger.DebugFormat("Deleting Member Positions...");
                    TList<MemberPositions> memberPositions = _memPositionService.GetByMemberId(thisMember.MemberId);
                    int memberPosCount = memberPositions.Count();
                    _memPositionService.Delete(memberPositions);
                    _logger.DebugFormat("Deleted {0} Member Positions", memberPosCount);
                    #endregion

                    #region Member Certificate Memberships
                    _logger.DebugFormat("Deleting Certificate Memberships...");
                    TList<MemberCertificateMemberships> memberCert = _memCertService.GetByMemberId(thisMember.MemberId);
                    int memberCertCount = memberCert.Count();
                    _memCertService.Delete(memberCert);
                    _logger.DebugFormat("Deleted {0} Member Certificate Memberships", memberCertCount);
                    #endregion

                    #region Member Jobs Saved
                    _logger.DebugFormat("Deleting Jobs Saved...");
                    TList<JobsSaved> memberJobsSaved = _jobSavedService.GetByMemberId(thisMember.MemberId);
                    int memberJobsSavedCount = memberJobsSaved.Count();
                    _jobSavedService.Delete(memberJobsSaved);
                    _logger.DebugFormat("Deleted {0} Member Jobs Saved", memberJobsSavedCount);
                    #endregion

                    #region Member Files
                    _logger.DebugFormat("Deleting Member Files...");
                    TList<MemberFiles> memberFiles = _memberFileService.GetByMemberId(thisMember.MemberId);
                    int memberFilesCount = memberFiles.Count();
                    _memberFileService.Delete(memberFiles);
                    _logger.DebugFormat("Deleted {0} Member Files", memberFilesCount);
                    #endregion

                    #region Member References
                    _logger.DebugFormat("Deleting Member References...");
                    TList<MemberReferences> memberReferences = _memRefService.GetByMemberId(thisMember.MemberId);
                    int memberReferencesCount = memberReferences.Count();
                    _memRefService.Delete(memberReferences);
                    _logger.DebugFormat("Deleted {0} Member References", memberReferencesCount);
                    #endregion

                    #region Member License
                    _logger.DebugFormat("Deleting Member Licenses...");
                    TList<MemberLicenses> memberLicenses = _memLicenceService.GetByMemberId(thisMember.MemberId);
                    int memberLicensesCount = memberLicenses.Count();
                    _memLicenceService.Delete(memberLicenses);
                    _logger.DebugFormat("Deleted {0} Member Licenses", memberLicensesCount);
                    #endregion
                    
                    _logger.DebugFormat("Deleting Member Record...");
                    _memberService.Delete(thisMember);
                    _logger.DebugFormat("Deleted Member Record");

                    _logger.DebugFormat("Member record successfully deleted");
                }
                else
                {
                    _logger.DebugFormat("Member not found. No action taken."); 
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.DebugFormat("Finished candidate removal request, target siteID({0}) memberID({1})", siteId, id);
        }

        public void CleanBySiteId(int siteId)
        {
            _logger.DebugFormat("Start members removal for site request, target siteID({0})", siteId);

            try
            {
                MembersService _ms = new MembersService();
                IEnumerable<Members> siteMembers = _ms.GetBySiteId(siteId);

                if (siteMembers.Count() == 0)
                {
                    _logger.DebugFormat("No members found for site. No action taken.");
                }
                else
                {
                    _logger.DebugFormat("Member removal starts - Total members count {0}", siteMembers.Count());
                    int success = 0;
                    List<int> failedMembers = new List<int>();
                    foreach (Members thisMember in siteMembers)
                    {
                        try
                        {
                            CleanById(siteId, thisMember.MemberId);
                            success++;
                        }
                        catch (Exception e)
                        {
                            _logger.ErrorFormat("Failed to remove member({0}). Continue.", thisMember.MemberId);
                            _logger.Error(e);
                            failedMembers.Add(thisMember.MemberId);
                        }
                    }
                    _logger.DebugFormat("Member removal finished - Success({0}) Failed({1})", success, failedMembers.Count);
                    if (failedMembers.Any())
                    {
                        _logger.Debug("Failed member ids:");
                        _logger.Debug(string.Join(Environment.NewLine, failedMembers));
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.DebugFormat("Finished candidate removal for site request, target siteID({0})", siteId);

        }
    }
}
