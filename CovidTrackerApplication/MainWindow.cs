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

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;

using Brushes = System.Windows.Media.Brushes;

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

        private void Display_CasesChart(Button button)
        {
            casesChart.Series.Clear();
            DailyReport daily = DataTracker.readDailyReport();

            string[] days = new string[7];

            var caseValues = new ChartValues<int>();
            var deathValues = new ChartValues<int>();
            var recoverValues = new ChartValues<int>();

            var avgCase7DayValues = new ChartValues<int>();
            var avgDeath7DayValues = new ChartValues<int>();
            var avgRecover7DayValues = new ChartValues<int>();

            for (int i = 0; i < 7; i++)
            {
                days[i] = daily.Overview[i].Date.ToString();
                caseValues.Add(daily.Overview[i].Cases);
                avgCase7DayValues.Add(daily.Overview[i].AvgCases7day);
                deathValues.Add(daily.Overview[i].Death);
                avgDeath7DayValues.Add(daily.Overview[i].AvgDeath7day);
                recoverValues.Add(daily.Overview[i].Recovered);
                avgRecover7DayValues.Add(daily.Overview[i].AvgRecovered7day);
            }

            var columnValues = new ChartValues<int>();
            var lineValues = new ChartValues<int>();

            if (button.Text.Equals("Số ca nhiễm"))
            {
                columnValues = caseValues;
                lineValues = avgCase7DayValues;
            }
            else if (button.Text.Equals("Số ca tử vong"))
            {
                lineValues = avgDeath7DayValues;
                columnValues = deathValues;
            }
            else if (button.Text.Equals("Số ca khỏi"))
            {
                lineValues = avgRecover7DayValues;
                columnValues = recoverValues;
            }


            ColumnSeries casesColumnSeries = new ColumnSeries
            {
                Values = columnValues,
                DataLabels = true,
                Title = button.Text
            };
            LineSeries avgLineSeries = new LineSeries
            {
                Values = avgCase7DayValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                Title = "Trong 7 ngày"
            };
            casesChart.Series.Add(casesColumnSeries);
            casesChart.Series.Add(avgLineSeries);
            casesChart.AxisX.Clear();
            casesChart.AxisX.Add(new Axis
            {
                Labels = days,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = true
                }
            });
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
                Display_CasesChart(showCasesBT);
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

        private void showCasesBT_Click(object sender, EventArgs e)
        {
            Display_CasesChart(showCasesBT);
        }
    }
}
