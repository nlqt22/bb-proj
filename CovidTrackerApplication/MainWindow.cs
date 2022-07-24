using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using CovidTrackerApplication.utils;
using CovidTrackerApplication.entity;


namespace CovidTrackerApplication
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Display_DataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tỉnh/ Thành phố");
            dt.Columns.Add("Số ca nhiễm trong 24 giờ");
            DailyReport daily = DataTracker.readDailyReport();
            for(int i = 0; i < daily.Locations.Count; i++)
            {
                dt.Rows.Add(daily.Locations[i].Name, daily.Locations[i].CasesToday);
            }
            dataGridView1.DataSource = dt;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (DataTracker.getSaveFileInfo() == null)
            {
                MessageBox.Show("Vui lòng ấn nút cập nhật !");
                updateButton.Text = "Cập nhật dữ liệu mới nhất";
            } else
            {
                updateButton.Text = DataTracker.getSaveFileInfo();
                Display_DataTable();
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTracker.updateDailyReport();
                updateButton.Text = DataTracker.getSaveFileInfo();
                MainWindow_Load(sender, e);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
