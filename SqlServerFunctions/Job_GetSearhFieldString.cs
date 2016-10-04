using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Web;
using System.Text.RegularExpressions;

public partial class UserDefinedFunctions
{

    public static string SpecialCharsSearchField(string text)
    {
        foreach (char c in text.ToCharArray())
        {
            System.Globalization.UnicodeCategory cat = Char.GetUnicodeCategory(c);

            if (cat == System.Globalization.UnicodeCategory.OtherLetter)
            {
                text = text.Replace(c.ToString(), c.ToString() + " ");
            }
        }

        text = text.Replace("  ", " ");

        return text;
    }

    public static string CleanStringSpaces(string inputString)
    {
        if (!String.IsNullOrEmpty(inputString))
        {
            inputString = inputString.Replace("&nbsp;", " ");
            return Regex.Replace(inputString, @"\s+", " ");
        }
        else
            return string.Empty;

    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlChars Job_GetSearhFieldString(string Text)
    {
        // Put your code here

        return new SqlChars(CleanStringSpaces(SpecialCharsSearchField(Text)).ToCharArray());
    }
};

