using JXTNext.Sitefinity.Common.Helpers;
using JXTNext.Sitefinity.Connector.BusinessLogics;
using JXTNext.Sitefinity.Connector.BusinessLogics.Models.Member;
using JXTNext.Sitefinity.Services.Intefaces;
using JXTNext.Sitefinity.Services.Intefaces.Models.JobApplication;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.Models.JXTNextResume;
using JXTNext.Sitefinity.Widgets.Authentication.Mvc.StringResources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Mvc;

namespace JXTNext.Sitefinity.Widgets.Authentication.Mvc.Controllers
{
    [Localization(typeof(JXTNextResumeResources))]
    [ControllerToolboxItem(Name = "JXTNextResume_MVC", Title = "JXTNext Resumes", SectionName = "JXTNext.Users", CssClass = JXTNextResumeController.WidgetIconCssClass)]
    public class JXTNextResumeController : Controller
    {
        IJobApplicationService _jobApplicationService;
        IBusinessLogicsConnector _blConnector;
        List<ProfileResumeJsonModel> resumeList = null;
        //MemberModel member = null;
        string Email = null;

        public string TemplateName
        {
            get
            {
                return this.templateName;
            }

            set
            {
                this.templateName = value;
            }
        }

        public string ProfileResumes { get; set; }

        

        public JXTNextResumeController(IJobApplicationService jobApplicationService, IBusinessLogicsConnector blConnector)
        {

            _jobApplicationService = jobApplicationService;
            _blConnector = blConnector;
            resumeList = new List<ProfileResumeJsonModel>();
            

            Email = SitefinityHelper.GetLoggedInUserEmail();

        }

        private List<JobApplicationAttachmentUploadItem> GetLoginUserResumeFilesByEmail(string email)
        {
            try
            {
                List<JobApplicationAttachmentUploadItem> attachments = new List<JobApplicationAttachmentUploadItem>();
                foreach (var resume in resumeList)
                {
                    attachments.Add(new JobApplicationAttachmentUploadItem()
                    {
                        Id = resume.Id.ToString(),
                        FileName = resume.FileName,
                        AttachmentType = JobApplicationAttachmentType.ProfileResume
                    });
                }

                attachments = _jobApplicationService.GetFiles(attachments);

                return attachments;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult Index()
        {
            ProfileResumeViewModel VM = new ProfileResumeViewModel();
            try
            {
                var res = _blConnector.GetMemberByEmail(Email);
                if (res.Member != null && res.Member.ResumeFiles != null)
                {
                    this.resumeList = JsonConvert.DeserializeObject<List<ProfileResumeJsonModel>>(res.Member.ResumeFiles);
                    List<JobApplicationAttachmentUploadItem> attachments = this.GetLoginUserResumeFilesByEmail(this.Email);
                }
            }
            catch (Exception)
            {
                VM.FetchError = true;
                //throw ex;
            }

            VM.ResumeList = this.resumeList;
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            VM.JsonData = JsonConvert.SerializeObject(VM);
            return View(fullTemplateName,VM);
        }


        
        [HttpPost]
        public JsonResult DownloadResume(string fileName)
        {
            
            dynamic VM = new ExpandoObject();
            VM.FileFound = false;
            try
            {
                if (string.IsNullOrEmpty(Request.QueryString["fileName"]))
                {
                    VM.DownloadError = true;
                    return new JsonResult { Data = VM };
                }
                VM.FileName = Request.QueryString["fileName"];
                var fileStream = _jobApplicationService.GetFileStreamFromAmazonS3(JobApplicationAttachmentSettings.PROFILE_RESUME_UPLOAD_KEY, 1, Request.QueryString["fileName"]);
                if(fileStream != null)
                {
                    byte[] output = new byte[fileStream.Length];
                    int bytesRead = fileStream.Read(output, 0, output.Length);
                    VM.FileStreamBytes = output;
                    VM.FileFound = true;
                }
                
            }
            catch (Exception)
            {
                VM.DownloadError = true;
                //throw ex;
            }

            
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            return new JsonResult { Data = VM };
        }

        [HttpPost]
        public JsonResult DeleteResume(Guid resumeId)
        {
            ProfileResumeViewModel VM = new ProfileResumeViewModel();
            try
            {
                JobApplicationAttachmentUploadItem deleteResumeFileItem = new JobApplicationAttachmentUploadItem();
                var res = _blConnector.GetMemberByEmail(this.Email);

                if (res.Member != null && res.Member.ResumeFiles != null)
                {
                    this.resumeList = JsonConvert.DeserializeObject<List<ProfileResumeJsonModel>>(res.Member.ResumeFiles);
                    var temp = resumeList.Where(x => x.Id == resumeId).FirstOrDefault();
                    if (temp != null)
                    {
                        deleteResumeFileItem.Id = resumeId.ToString();
                        deleteResumeFileItem.AttachmentType = JobApplicationAttachmentType.ProfileResume;
                        deleteResumeFileItem.FileName = temp.FileName;
                        deleteResumeFileItem.PathToAttachment = temp.UploadPathToAttachment;
                        if (_jobApplicationService.DeleteFile(deleteResumeFileItem))
                        {

                            this.resumeList.Remove(temp);

                            res.Member.ResumeFiles = JsonConvert.SerializeObject(this.resumeList);

                            _blConnector.UpdateMember(res.Member);
                        }
                    }
                }


            }
            catch (Exception)
            {
                VM.DeleteError = true;
                //throw ex;
            }

            VM.ResumeList = this.resumeList;
            VM.JsonData = JsonConvert.SerializeObject(VM);
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            return new JsonResult { Data = VM };
        }

        

        [HttpPost]
        public JsonResult UploadResume()
        {
            var list = ViewBag.ResumeList;
            HttpPostedFileBase file = null;
            ProfileResumeViewModel VM = new ProfileResumeViewModel();
            try
            {
                var res = _blConnector.GetMemberByEmail(Email);

                if (res.Member != null && res.Member.ResumeFiles != null)
                    this.resumeList = JsonConvert.DeserializeObject<List<ProfileResumeJsonModel>>(res.Member.ResumeFiles);

                if (ModelState.IsValid)
                {

                    if (Request.Files.Count != 0)
                    {
                        // process each file
                        file = Request.Files[0];
                        var fileExtension = file.FileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                        List<string> extensionList = new List<string>() { "pdf", "doc", "docx", "txt", "xls", "xlsx", "rtf" };

                        if (!extensionList.Contains(fileExtension.ToLower()))
                        {
                            throw new Exception("File extension is not valid.");
                        }

                        Guid identifier = Guid.NewGuid();
                        List<JobApplicationAttachmentUploadItem> attachments = new List<JobApplicationAttachmentUploadItem>();
                        attachments.Add(new JobApplicationAttachmentUploadItem()
                        {
                            Id = identifier.ToString(),
                            FileStream = file.InputStream,
                            FileName = file.FileName,
                            AttachmentType = JobApplicationAttachmentType.ProfileResume,
                            Status = "Ready",
                            PathToAttachment = identifier.ToString() + "_" + file.FileName
                        });


                        _jobApplicationService.UploadFiles(attachments);


                        ProfileResumeJsonModel resumeJson = new ProfileResumeJsonModel()
                        {
                            Id = identifier,
                            UploadDate = DateTime.Now,
                            FileName = file.FileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).First(),
                            UploadPathToAttachment = identifier.ToString() + "_" + file.FileName,
                            FileExtension = file.FileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last(),
                            FileUrl = attachments.FirstOrDefault().FileUrl
                        };

                        this.resumeList.Add(resumeJson);
                        res.Member.ResumeFiles = JsonConvert.SerializeObject(this.resumeList);
                        _blConnector.UpdateMember(res.Member);
                        ViewBag.ResumeList = this.resumeList;

                    }
                }
            }
            catch (Exception)
            {
                VM.UploadError = true;
                //throw ex;
            }
            VM.ResumeList = this.resumeList;
            VM.JsonData = JsonConvert.SerializeObject(VM);
            var fullTemplateName = this.templateNamePrefix + this.TemplateName;
            return new JsonResult { Data = VM };
        }


        internal const string WidgetIconCssClass = "sfProfilecn sfMvcIcn";
        private string templateName = "Simple";
        private string templateNamePrefix = "Resume.";
    }
}
