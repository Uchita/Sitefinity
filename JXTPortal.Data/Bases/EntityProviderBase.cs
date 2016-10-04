#region Using Directives
using System;
using JXTPortal.Entities;
using System.Reflection;
#endregion

namespace JXTPortal.Data.Bases
{
	/// <summary>
	/// Serves as the base class for objects that provide data access functionality.
	/// Provides a default implementation of the IEntityProvider&lt;Entity, EntityKey&gt; interface.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the EntityId
	/// property of the specified business object class.</typeparam>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>
	[Serializable]
	[CLSCompliant(true)]
	public abstract partial class EntityProviderBase<Entity, EntityKey> : EntityProviderBaseCore<Entity, EntityKey>
		where Entity : IEntityId<EntityKey>, new()
		where EntityKey : IEntityKey, new()
	{
        protected override void OnDataRequesting(CommandEventArgs e)
        {

            base.OnDataRequesting(e); if (e.MethodName.Equals("Insert", StringComparison.CurrentCultureIgnoreCase))
            {
                UpdateUpdatedData(e.CurrentEntity, e);
            }
            else if (e.MethodName.Equals("Update", StringComparison.CurrentCultureIgnoreCase))
            {
                UpdateUpdatedData(e.CurrentEntity, e);
            }
        }

      
        private void UpdateUpdatedData(Object entity, CommandEventArgs e)
        {
            if (entity != null)
            {
                Type type = entity.GetType();
                PropertyInfo createdProp = type.GetProperty("LastModified");
                if (createdProp != null && createdProp.CanWrite)
                {
                    DateTime now = DateTime.Now;
                    createdProp.SetValue(entity, now, null);
                    e.Command.Parameters["@LastModified"].Value = DateTime.Now;
                }

                createdProp = type.GetProperty("LastModifiedBy");
                if (createdProp != null && createdProp.CanWrite)
                {
                    if (SessionData.AdminUser != null)
                    {
                        createdProp.SetValue(entity, SessionData.AdminUser.AdminUserId, null);
                        e.Command.Parameters["@LastModifiedBy"].Value = SessionData.AdminUser.AdminUserId;
                    }
                }

                createdProp = type.GetProperty("SiteId");
                if (createdProp != null && createdProp.CanWrite)
                {
                    //if (SessionData.Site != null)
                    //{
                    //    if (SessionData.AdminUser != null && SessionData.AdminUser.isAdminUser)
                    //    {
                    //        //Don't do anything     
                    //    }
                    //    else
                    //    {
                    //        createdProp.SetValue(entity, SessionData.Site.SiteId, null);
                    //        e.Command.Parameters["@SiteId"].Value = SessionData.Site.SiteId;
                    //    }
                    //}


                    //TODO: To fix this one //SessionData.Site.SiteIdAlias 
                    // Daniel Naveen
                    if (System.Web.HttpContext.Current != null && SessionData.Site != null && !type.FullName.Equals("JXTPortal.Entities.Sites")
                        && !type.FullName.Equals("JXTPortal.Entities.Advertisers") && !type.FullName.Equals("JXTPortal.Entities.GlobalSettings")
                        && !type.FullName.Equals("JXTPortal.Entities.AdvertiserBusinessType")
                        && !type.FullName.Equals("JXTPortal.Entities.NewsType")
                        && !type.FullName.Equals("JXTPortal.Entities.NewsIndustry")
                        && !type.FullName.Equals("JXTPortal.Entities.Integrations")
                        && System.Web.HttpContext.Current.Request.RawUrl.ToLower() != "/admin/copysystempage.aspx"
                        && System.Web.HttpContext.Current.Request.RawUrl.ToLower().StartsWith("/admin/login.aspx") == false)
                    {
                        if (System.Web.HttpContext.Current.Request.RawUrl.ToLower() == "/admin/sitecopy.aspx" ||
                            System.Web.HttpContext.Current.Request.RawUrl.ToLower() == "/admin/adminloginpageedit.aspx")
                        {
                            return;
                        }
                        // following objects will be forced to use mastersiteid
                        if (type.FullName.Equals("JXTPortal.Entities.Members") ||
                            type.FullName.Equals("JXTPortal.Entities.MemberFiles") ||
                            type.FullName.Equals("JXTPortal.Entities.JobAlerts") ||
                            type.FullName.Equals("JXTPortal.Entities.JobApplication") ||
                            type.FullName.Equals("JXTPortal.Entities.MemberMemberships") ||
                            type.FullName.Equals("JXTPortal.Entities.MemberStatus") ||
                            type.FullName.Equals("JXTPortal.Entities.MemberWizard"))
                        {

                            createdProp.SetValue(entity, SessionData.Site.MasterSiteId, null);
                            e.Command.Parameters["@SiteId"].Value = SessionData.Site.MasterSiteId;
                        }
                        else
                        {
                            createdProp.SetValue(entity, SessionData.Site.SiteId, null);
                            e.Command.Parameters["@SiteId"].Value = SessionData.Site.SiteId;
                        }
                    }
                }
            }
        }
	}
}
