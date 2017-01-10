using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.ScreeningQuestions;
using JXTPortal.Data.Dapper.Entities.Core;
using JXTPortal.Service.Dapper.Models;

namespace JXTPortal.Service.Dapper
{
    public interface IScreeningQuestionsTemplatesService
    {
        int Insert(ScreeningQuestionsTemplatesEntity entity);
        void Update(ScreeningQuestionsTemplatesEntity entity);
        ScreeningQuestionsTemplatesEntity Select(int id);

        List<ScreeningQuestionsTemplatesEntity> SelectBySiteId(int siteId);
        ScreeningQuestionsTemplateDetail GetPaged(int siteId, int pageIndex, int pageSize);
        int GetSiteCount(int siteId);
        List<ScreeningQuestionsTemplatesEntity> SelectByAdvertiserId(int advertiserId);
    }

    public class ScreeningQuestionsTemplatesService : IScreeningQuestionsTemplatesService
    {
        IScreeningQuestionsTemplatesRepository screeningQuestionsTemplatesRepository;
        IAdminUsersRepository adminUsersRepository;

        public ScreeningQuestionsTemplatesService(IScreeningQuestionsTemplatesRepository screeningQuestionsTemplatesRepository, IAdminUsersRepository adminUsersRepository)
        {
            this.screeningQuestionsTemplatesRepository = screeningQuestionsTemplatesRepository;
            this.adminUsersRepository = adminUsersRepository;
        }

        public int Insert(ScreeningQuestionsTemplatesEntity entity)
        {
            return screeningQuestionsTemplatesRepository.Insert(entity);
        }

        public void Update(ScreeningQuestionsTemplatesEntity entity)
        {
            screeningQuestionsTemplatesRepository.Update(entity);
        }

        public void Delete(int id)
        {
            screeningQuestionsTemplatesRepository.Delete(id);
        }

        public ScreeningQuestionsTemplatesEntity Select(int id)
        {
            return screeningQuestionsTemplatesRepository.Select(id);
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectAll()
        {
            return screeningQuestionsTemplatesRepository.SelectAll();
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectBySiteId(int siteId)
        {
            return screeningQuestionsTemplatesRepository.SelectBySiteId(siteId);
        }

        public int GetSiteCount(int siteId)
        {
            return screeningQuestionsTemplatesRepository.GetSiteCount(siteId);
        }

        public ScreeningQuestionsTemplateDetail GetPaged(int siteId, int pageIndex, int pageSize)
        {
            int rowFrom = (pageIndex * pageSize) + 1;
            int rowTo = ((pageIndex + 1) * pageSize) + 1;

            List<int> adminUserIds = new List<int>();

            List<ScreeningQuestionsTemplatesEntity> screeningQuestionsTemplates = screeningQuestionsTemplatesRepository.GetPaged(siteId, rowFrom, rowTo, "ScreeningQuestionsTemplateId");
            foreach (ScreeningQuestionsTemplatesEntity screeningQuestion in screeningQuestionsTemplates)
            {
                if (!adminUserIds.Contains(screeningQuestion.LastModifiedBy))
                {
                    adminUserIds.Add(screeningQuestion.LastModifiedBy);
                }
            }

            List<AdminUsersEntity> adminUsers = adminUsersRepository.SelectByAdminUserIDs(adminUserIds);

            ScreeningQuestionsTemplateDetail screeningQuestionsTemplateDetail = new ScreeningQuestionsTemplateDetail();
            screeningQuestionsTemplateDetail.SiteId = siteId;
            screeningQuestionsTemplateDetail.ScreeningQuestionsTemplates = new List<ScreeningQuestionsTemplate>();

            foreach (ScreeningQuestionsTemplatesEntity screeningQuestionTemplate in screeningQuestionsTemplates)
            {
                foreach (AdminUsersEntity adminUser in adminUsers)
                {
                    if (adminUser.AdminUserID == screeningQuestionTemplate.LastModifiedBy)
                    {
                        screeningQuestionsTemplateDetail.ScreeningQuestionsTemplates.Add(new ScreeningQuestionsTemplate
                        {
                            ScreeningQuestionsTemplateId = screeningQuestionTemplate.ScreeningQuestionsTemplateId,
                            TemplateName = screeningQuestionTemplate.TemplateName,
                            SiteId = screeningQuestionTemplate.SiteId,
                            Visible = screeningQuestionTemplate.Visible,
                            LastModified = screeningQuestionTemplate.LastModified,
                            LastModifiedBy = screeningQuestionTemplate.LastModifiedBy,
                            LastModifiedByName = adminUser.UserName
                        });

                        break;
                    }
                }
            }

            return screeningQuestionsTemplateDetail;
        }

        public List<ScreeningQuestionsTemplatesEntity> SelectByAdvertiserId(int advertiserId)
        {
            return screeningQuestionsTemplatesRepository.SelectByAdvertiserId(advertiserId);
        }
    }
}
