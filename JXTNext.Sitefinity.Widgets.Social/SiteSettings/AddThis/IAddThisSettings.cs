namespace JXTNext.Sitefinity.Widgets.Social.SiteSettings.AddThis
{
    public interface IAddThisSettings
    {
        string PublisherId { get; set; }

        bool FacebookEnabled { get; set; }
        string FacebookIcon { get; set; }
        string FacebookImage { get; set; }
        int FacebookPosition { get; set; }

        bool TwitterEnabled { get; set; }
        string TwitterIcon { get; set; }
        string TwitterImage { get; set; }
        int TwitterPosition { get; set; }

        bool LinkedInEnabled { get; set; }
        string LinkedInIcon { get; set; }
        string LinkedInImage { get; set; }
        int LinkedInPosition { get; set; }

        bool WeChatEnabled { get; set; }
        string WeChatIcon { get; set; }
        string WeChatImage { get; set; }
        int WeChatPosition { get; set; }

        string CssClass { get; set; }
    }
}
