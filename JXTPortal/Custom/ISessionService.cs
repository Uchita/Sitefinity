using System;
namespace JXTPortal.Custom
{
    public interface ISessionService
    {
        string GenerateAuthToken();
        string GetCurrentWhitelabelUrl();
        bool IsAuthTokenValid();
        void RemoveAdminUser();
        void RemoveAdvertiserUser();
        void RemoveMember();
        void RemoveMemberAndAdvertiser();
        void SessionAbandon();
        void SessionMobileSetup();
        void SessionSetup();
        void SessionVerify();
        void SetAdminUser(global::JXTPortal.Entities.AdminUsers adminUser);
        void SetAdvertiserUser(global::JXTPortal.Entities.AdvertiserUsers advertiserUser);
        void SetLanguage(global::JXTPortal.Entities.Languages language);
        void SetMember(global::JXTPortal.Entities.Members member);
        void SetMobileSite(global::JXTPortal.Entities.Sites site);
        void SetSite(global::System.Data.DataSet dsSite);
    }
}
