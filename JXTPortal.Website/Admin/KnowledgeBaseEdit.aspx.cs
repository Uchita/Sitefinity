#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal.Website;
using JXTPortal;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using JXTPortal.Data.Dapper.Repositories;
using JXTPortal.Data.Dapper.Entities.KnowledgeBase;
using System.Linq;
using JXTPortal.Service.Dapper;
#endregion

public partial class KnowledgeBaseEdit : System.Web.UI.Page
{
    #region Properties

    public IKnowledgeBaseCategoryService KnowledgeBaseCategoryService { get; set; }
    
    public IKnowledgeBaseService KnowledgeBaseService { get; set; }

    private int Id
    {
        get
        {
            int _id = 0;
            if ((Request.QueryString["Id"] != null))
            {
                if (int.TryParse((Request.QueryString["Id"].Trim()), out _id))
                {
                    _id = Convert.ToInt32(Request.QueryString["Id"]);
                }
                return _id;
            }
            return _id;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.AdminUser == null)
        {
            Response.Redirect("~/admin/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.PathAndQuery));
            return;
        }

        if (!IsPostBack)
        {
            LoadForm();
        }
    }

    #endregion

    #region Methods

    protected void LoadCategory()
    {
        if (!KnowledgeBaseCategoryService.SelectAll().Any())
        {
            phKnowledgeBaseEdit.Visible = false;
            ltlMessage.Text = string.Format("<h3>Parent Category does not exist. Click {0} to create one</h3>", "<a href=\"/admin/KnowledgeBaseCategoryEdit.aspx\">here</a>");
        }
        else
        {
            var parentCategory = KnowledgeBaseCategoryService.SelectAll().Where(x => x.ParentId != 0).ToList();

            if (parentCategory.Any())
            {
                ddlCategory.DataSource = parentCategory;
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "KnowledgeBaseCategoryName";
                ddlCategory.DataBind();
            }
            else
            {
                phKnowledgeBaseEdit.Visible = false;
                ltlMessage.Text = string.Format("<h3>Child Category does not exist. Click {0} to create one</h3>", "<a href=\"/admin/KnowledgeBaseCategoryEdit.aspx\">here</a>");
            }            
        }
    }

    protected void LoadForm()
    {
        LoadCategory();

        if (Id > 0)
        {
            var entity = KnowledgeBaseService.Select(Id);
            if (entity != null)
            {
                txtSubject.Text = entity.Subject;
                chkBoxValid.Checked = entity.Valid;
                ddlCategory.SelectedValue = entity.KnowledgeBaseCategoryID.ToString();
                txtSequence.Text = entity.Sequence.ToString();
                txtKnowledgeBaseContent.Text = entity.Content;
                txtTags.Text = entity.Tags;
            }
            else
            {
                Response.Redirect("KnowledgeBase.aspx");
            }
        }
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                var entity = new KnowledgeBaseEntity
                {
                    Id = Id,
                    Subject = txtSubject.Text,
                    Sequence = Convert.ToInt32(txtSequence.Text),
                    Valid = chkBoxValid.Checked,
                    LastModified = DateTime.Now,
                    LastModifiedBy = SessionData.AdminUser.AdminUserId,
                    KnowledgeBaseCategoryID = int.Parse(ddlCategory.SelectedValue),
                    Content = txtKnowledgeBaseContent.Text,
                    Tags = txtTags.Text
                };

                if (Id > 0)
                {
                    KnowledgeBaseService.Update(entity);
                }
                else
                {
                    KnowledgeBaseService.Insert(entity);
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }

            Response.Redirect("KnowledgeBase.aspx");
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("knowledgebase.aspx");
    }

    #endregion
}