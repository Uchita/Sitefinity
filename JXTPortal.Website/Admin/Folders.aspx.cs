

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal;
using JXTPortal.Entities;
using JXTPortal.Web.UI;
#endregion

public partial class Folders : System.Web.UI.Page
{
    #region Declare variables

    private FoldersService _foldersService;
    private int _folderid = -1;

    #endregion

    #region Properties
    
    private FoldersService FoldersService
    {
        get
        {
            if (_foldersService == null)
                _foldersService = new FoldersService();
            return _foldersService;
        }
    }

    private int FolderId
    {
        get
        {

            if ((Request.QueryString["FolderId"] != null))
            {
                if (int.TryParse((Request.QueryString["FolderId"].Trim()), out _folderid))
                {
                    _folderid = Convert.ToInt32(Request.QueryString["FolderId"]);
                }
                return _folderid;
            }

            return _folderid;
        }
    }

    #endregion

    #region Page Event handlers

    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterUpdate(GridView1, "Files.aspx?page={0}");
        FormUtil.SetPageIndex(GridView1, "page");
        //FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
        
        // To display only per Site
        FoldersDataSource.Parameters.Add("SiteId", JXTPortal.Entities.SessionData.Site.SiteId.ToString());

        if (!Page.IsPostBack)
        {
            txtFolderName.Text = String.Empty;

            if (FolderId > 0)
            {
                LoadFolder();
            }
        }

    }

    #endregion

    #region Click Event handlers

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtFolderName.Text.Trim().Length > 0)
        {

            if (FolderId > 0)
            {
                using (JXTPortal.Entities.Folders objFolders = FoldersService.GetByFolderId(FolderId))
                {
                    objFolders.FolderName = txtFolderName.Text.Trim();
                    objFolders.ParentFolderId = 0;

                    FoldersService.Update(objFolders);
                }
            }
            else
            {
                using (JXTPortal.Entities.Folders objFolders = new JXTPortal.Entities.Folders())
                {
                    objFolders.FolderName = txtFolderName.Text.Trim();
                    objFolders.ParentFolderId = 0;

                    FoldersService.Insert(objFolders);
                }
            }

            Response.Redirect("folders.aspx");

        }
    }

    #endregion


    #region Methods
    
    protected void LoadFolder()
    {
        using (JXTPortal.Entities.Folders objFolder = FoldersService.GetByFolderId(FolderId))
        {
            if (objFolder != null)
            {
                txtFolderName.Text = objFolder.FolderName;
                btnSave.Text = "Update";
            }
        }

    }

    #endregion
}


