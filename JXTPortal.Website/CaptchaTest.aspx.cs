using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace JXTPortal.Website
{
    public partial class CaptchaTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
            }


            //if (IsPostBack) return;
            ////Fill controls with Captcha defaults
            //txtCtlWidth.Text = CaptchaControl1.Width.Value.ToString();
            //txtCtlHeight.Text = CaptchaControl1.Height.Value.ToString();
            //chArithmetic.Checked = CaptchaControl1.Arithmetic;
            //ddlFunction.Text = CaptchaControl1.ArithmeticFunction.ToString();
            ////Color list
            //string[] colors = Enum.GetNames(typeof(System.Drawing.KnownColor));
            //ListItem[] colorItems = new ListItem[colors.Length];
            //for (int i = 0; i < colors.Length; i++)
            //{
            //    colorItems[i] = new ListItem(colors[i]);
            //}
            //ddlBackColor.Items.AddRange(colorItems);
            //ddlFontColor.Items.AddRange(colorItems);
            //ddlLineColor.Items.AddRange(colorItems);
            //ddlNoiseColor.Items.AddRange(colorItems);
            ////Select colors
            //ddlBackColor.Text = CaptchaControl1.BackColor.Name;
            //ddlFontColor.Text = CaptchaControl1.FontColor.Name;
            //ddlLineColor.Text = CaptchaControl1.LineColor.Name;
            //ddlNoiseColor.Text = CaptchaControl1.NoiseColor.Name;
            ////Other properties
            //ddlBackNoise.Text = CaptchaControl1.CaptchaBackgroundNoise.ToString();
            //ddlLineNoise.Text = CaptchaControl1.CaptchaLineNoise.ToString();
            //txtChars.Text = CaptchaControl1.CaptchaChars;
            //ddlFontWarp.Text = CaptchaControl1.CaptchaFontWarping.ToString();
            //txtCapLength.Text = CaptchaControl1.CaptchaLength.ToString();
            //txtImageTag.Text = CaptchaControl1.ImageTag;
            //txtCapHeight.Text = CaptchaControl1.CaptchaHeight.ToString();
            //txtCapWidth.Text = CaptchaControl1.CaptchaWidth.ToString();
        }

//        protected void cmdApply_Click(object sender, EventArgs e)
//        {
//            CaptchaControl1.BackColor = System.Drawing.Color.FromName(ddlBackColor.Text);
//            CaptchaControl1.FontColor = System.Drawing.Color.FromName(ddlFontColor.Text);
//            CaptchaControl1.LineColor = System.Drawing.Color.FromName(ddlLineColor.Text);
//            CaptchaControl1.NoiseColor = System.Drawing.Color.FromName(ddlNoiseColor.Text);
//            //CaptchaControl1.CaptchaBackgroundNoise = (MSCaptcha.CaptchaImage.backgroundNoiseLevel)Enum.Parse(typeof(MSCaptcha.CaptchaImage.backgroundNoiseLevel), ddlBackNoise.Text);
//            //CaptchaControl1.CaptchaLineNoise = (MSCaptcha.CaptchaImage.lineNoiseLevel)Enum.Parse(typeof(MSCaptcha.CaptchaImage.lineNoiseLevel), ddlLineNoise.Text);
//            //CaptchaControl1.CaptchaFontWarping = (MSCaptcha.CaptchaImage.fontWarpFactor)Enum.Parse(typeof(MSCaptcha.CaptchaImage.fontWarpFactor), ddlFontWarp.Text);
//            CaptchaControl1.CaptchaChars = txtChars.Text;
//            CaptchaControl1.CaptchaLength = Convert.ToInt32(txtCapLength.Text);
//            CaptchaControl1.ImageTag = txtImageTag.Text;
//            CaptchaControl1.CaptchaHeight = Convert.ToInt32(txtCapHeight.Text);
//            CaptchaControl1.CaptchaWidth = Convert.ToInt32(txtCapWidth.Text);
//            CaptchaControl1.Width = Convert.ToInt32(txtCtlWidth.Text);
//            CaptchaControl1.Height = Convert.ToInt32(txtCtlHeight.Text);
//            CaptchaControl1.CaptchaWidth = Convert.ToInt32(txtCapWidth.Text);
//            CaptchaControl1.CaptchaMaxTimeout = Convert.ToInt32(txtMaxTimeout.Text);
//            CaptchaControl1.CaptchaMinTimeout = Convert.ToInt32(txtMinTimeout.Text);
//            //Always assign ArithmeticFunction BEFORE the Arithmetic itself. Setting Arithmetic property redraws the captcha.
////            CaptchaControl1.ArithmeticFunction = (MSCaptcha.CaptchaControl.arithmeticOperation)Enum.Parse(typeof(MSCaptcha.CaptchaControl.arithmeticOperation), ddlFunction.Text);
//            if (CaptchaControl1.Arithmetic != chArithmetic.Checked) CaptchaControl1.Arithmetic = chArithmetic.Checked;//This changes max length in characters. Make sure your control length supports 7 characters, although there could be less.
//        }

//        protected void cmdCheck_Click(object sender, EventArgs e)
//        {
//            CaptchaControl1.ValidateCaptcha(txtAnswer.Text);

//            if (CaptchaControl1.UserValidated)
//            {
//                txtAnswer.Text = "CORRECT!";
//            }
//            else
//            {
//                txtAnswer.Text = "WRONG!";
//            }
//            cmdApply_Click(sender, e);
//        }
    }
}