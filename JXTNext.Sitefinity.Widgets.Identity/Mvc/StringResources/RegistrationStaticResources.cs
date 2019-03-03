using Telerik.Sitefinity.Localization;


namespace JXTNext.Sitefinity.Widgets.Identity.Mvc.StringResources
{
    public static class RegistrationStaticResources
    {
        public static string Email
        {
            get
            {
                return Res.Get<RegistrationResources>().Email;
            }
        }

        public static string Password
        {
            get
            {
                return Res.Get<RegistrationResources>().Password;
            }
        }

        public static string ReTypePassword
        {
            get
            {
                return Res.Get<RegistrationResources>().ReTypePassword;
            }
        }

        public static string Question
        {
            get
            {
                return Res.Get<RegistrationResources>().Question;
            }
        }

        public static string Answer
        {
            get
            {
                return Res.Get<RegistrationResources>().Answer;
            }
        }
    }
}