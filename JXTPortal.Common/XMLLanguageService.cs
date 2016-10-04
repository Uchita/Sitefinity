using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Reflection;


namespace JXTPortal
{
    public static class XMLLanguageService
    {
        public static List<T> Translate<T>(List<T> DataSource, string PrimaryKeyColumn, string DisplayColumn, string XMLSource) where T : new()
        {
            List<T> NewList = new List<T>();
            NewList = DataSource;

            string url = string.Format(XMLSource);

            if (File.Exists(url))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(url);

                foreach (T _object in DataSource)
                {
                    foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                    {
                        string roleid = xmlnode.ChildNodes[0].InnerText;
                        string rolename = xmlnode.ChildNodes[1].InnerText;

                        PropertyInfo piPrimaryKeyField = _object.GetType().GetProperty(PrimaryKeyColumn);
                        int primaryKey = (int)(piPrimaryKeyField.GetValue(_object, null));

                        if (primaryKey == Convert.ToInt32(roleid))
                        {
                            PropertyInfo piDisplayField = _object.GetType().GetProperty(DisplayColumn);
                            piDisplayField.SetValue(_object, rolename, null);
                            break;
                        }
                    }
                }
            }


            return NewList;
        }

        public static List<T> Translate<T>(List<T> DataSource, string PrimaryKeyColumn, string DisplayColumn, XmlDocument xmldoc) where T : new()
        {
            List<T> NewList = new List<T>();
            NewList = DataSource;

            foreach (T _object in DataSource)
            {
                foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                {
                    string roleid = xmlnode.ChildNodes[0].InnerText;
                    string rolename = xmlnode.ChildNodes[1].InnerText;

                    PropertyInfo piPrimaryKeyField = _object.GetType().GetProperty(PrimaryKeyColumn);
                    int primaryKey = (int)(piPrimaryKeyField.GetValue(_object, null));

                    if (primaryKey == Convert.ToInt32(roleid))
                    {
                        PropertyInfo piDisplayField = _object.GetType().GetProperty(DisplayColumn);
                        piDisplayField.SetValue(_object, rolename, null);
                        break;
                    }
                }
            }

            return NewList;
        }

        public static T Translate<T>(T DataSource, string PrimaryKeyColumn, string DisplayColumn, string XMLSource) where T : new()
        {
            string url = string.Format(XMLSource);

            if (File.Exists(url))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(url);

                foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                {
                    string roleid = xmlnode.ChildNodes[0].InnerText;
                    string rolename = xmlnode.ChildNodes[1].InnerText;

                    PropertyInfo piPrimaryKeyField = DataSource.GetType().GetProperty(PrimaryKeyColumn);
                    int primaryKey = (int)(piPrimaryKeyField.GetValue(DataSource, null));

                    if (primaryKey == Convert.ToInt32(roleid))
                    {
                        PropertyInfo piDisplayField = DataSource.GetType().GetProperty(DisplayColumn);
                        piDisplayField.SetValue(DataSource, rolename, null);
                        break;
                    }
                }
            }

            return DataSource;
        }

        public static string TranslateString(int PrimaryKeyID, string PrimaryKeyColumn, string DisplayColumn, string XMLSource)
        {
            string url = string.Format(XMLSource);
            string translatedString = string.Empty;

            if (File.Exists(url))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(url);

                foreach (XmlNode xmlnode in xmldoc.GetElementsByTagName("item"))
                {
                    string id = xmlnode.ChildNodes[0].InnerText;
                    string name = xmlnode.ChildNodes[1].InnerText;

                    if (PrimaryKeyID == Convert.ToInt32(id))
                    {
                        translatedString = name;
                        break;
                    }
                }
            }

            return translatedString;
        }
    }
}
