using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JXTCountryLocationAreaMapping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadLocations();
        }

        private void LoadLocations()
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems[0].Text = "aaa";
            lvi.SubItems.Add("bbb");

            locationView1.Items.Add(lvi);
        }
    }
}
