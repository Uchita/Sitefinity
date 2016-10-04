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
#endregion

public partial class KnowledgeBaseCategoryEdit : System.Web.UI.Page
{
    #region Properties

    public IKnowledgeBaseCategoryRepository KnowledgeBaseCategoryRepository { get; set; }

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

    protected void LoadForm()
    {
        LoadCategory();

        if (Id > 0)
        {
            var entity = KnowledgeBaseCategoryRepository.Select(Id);
            if (entity != null)
            {
                txtCategoryName.Text = entity.KnowledgeBaseCategoryName;
                txtSequence.Text = entity.Sequence.ToString();
                chkBoxValid.Checked = entity.Valid;
                ddlCategory.SelectedValue = entity.ParentId.ToString();
            }
            else
            {
                Response.Redirect("KnowledgeBaseCategories.aspx");
            }
        }
    }

    protected void LoadCategory()
    {
        ddlCategory.DataSource = KnowledgeBaseCategoryRepository.SelectAll().Where(x => x.Id != Id);
        ddlCategory.DataValueField = "Id";
        ddlCategory.DataTextField = "KnowledgeBaseCategoryName";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
    }

    #endregion

    #region Click Event handlers

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                var entity = new KnowledgeBaseCategoryEntity
                {
                    Id = Id,
                    KnowledgeBaseCategoryName = txtCategoryName.Text,
                    Sequence = Convert.ToInt32(txtSequence.Text),
                    Valid = chkBoxValid.Checked,
                    LastModified = DateTime.Now,
                    LastModifiedBy = SessionData.AdminUser.AdminUserId,
                    ParentId = Convert.ToInt32(ddlCategory.SelectedValue)
                };

                if (Id > 0)
                {
                    KnowledgeBaseCategoryRepository.Update(entity);
                }
                else
                {
                    KnowledgeBaseCategoryRepository.Insert(entity);
                }
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }

            Response.Redirect("KnowledgeBaseCategories.aspx");
        }
    }



    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("knowledgebaseCategories.aspx");
    }


    #endregion
}