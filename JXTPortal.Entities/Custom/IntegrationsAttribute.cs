using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Entities
{
    public class IncludeButtonAttribute : System.Attribute
    {
        private string _cssClass;
        private string _buttonText;
        private string _buttonOnClick;

        public string CssClass { get { return _cssClass; } }
        public string ButtonText { get { return _buttonText; } }
        public string ButtonOnClick { get { return _buttonOnClick; } }


        public IncludeButtonAttribute(string css, string text, string onclick)
        {
            this._cssClass = css;
            this._buttonText = text;
            this._buttonOnClick = onclick;
        }

    }
}
