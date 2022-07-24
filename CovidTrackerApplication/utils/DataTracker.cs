using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using CovidTrackerApplication.entity;

namespace CovidTrackerApplication.utils
{
    internal class DataTracker
    {
        public static void updateDailyReport()
        {
            string fileName = "Lastest_Daily_Report.json";
            var saveFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile("https://static.pipezero.com/covid/data.json", saveFile);
        }
    }
}
