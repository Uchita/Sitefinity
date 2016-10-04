using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using System.IO;

using JXTPortal.Common;
using JXTPortal.Entities;
using JXTPortal;

using System.Data.OleDb;

namespace JXTAdvertiserImport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadAdvertiserExcel();
        }

        private static void LoadAdvertiserExcel()
        {

            try
            {
                string path = ConfigurationManager.AppSettings["AdvertiserExcelLocation"];
                string strConn = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;data source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES""", path);
                OleDbConnection objConn = new OleDbConnection(strConn);

                string strSQL = "SELECT * FROM [Sheet1$]";
                OleDbCommand objCmd = new OleDbCommand(strSQL, objConn);

                objConn.Open();

                OleDbDataReader dbReader = objCmd.ExecuteReader();

                List<AdvertiserInfo> miniCountryList = new List<AdvertiserInfo>();
                while (dbReader.Read())
                {
                    AdvertiserInfo mci = new AdvertiserInfo();

                    mci.ID = dbReader.GetValue(8).ToString();
                    mci.Country = dbReader.GetValue(9).ToString();
                    mci.Currency = dbReader.GetValue(4).ToString();
                    mci.Action = dbReader.GetValue(12).ToString();

                    miniCountryList.Add(mci);
                }

            }
            catch (Exception ex)
            {

            }


        }

        private class AdvertiserInfo
        {
            public string ID { get; set; }
            public string Country { get; set; }
            public string Currency { get; set; }
            public string Action { get; set; }
        }
    }
}
