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
        public static DailyReport readDailyReport()
        {
            DailyReport dailyReport = new DailyReport();

            string fileName = "Lastest_Daily_Report.json";
            string folderName = "CovidTrackerApplication";
            var saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName, fileName);

            bool fileExists = File.Exists(saveFilePath);

            if (!fileExists) return null;
            using (StreamReader sr = new StreamReader(saveFilePath))
            {
                string data = sr.ReadToEnd();
                dailyReport = JsonConvert.DeserializeObject<DailyReport>(data);
            }
            return dailyReport;
        }

        public static string getSaveFileInfo()
        {
            string fileName = "Lastest_Daily_Report.json";
            string folderName = "CovidTrackerApplication";
            var saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName, fileName);
            bool fileExists = File.Exists(saveFilePath);
            if (!fileExists) return null;

            FileInfo fileInfo = new FileInfo(saveFilePath);
            return fileInfo.LastWriteTime.ToString();
        }

        public static void updateDailyReport()
        {
            string folderName = "CovidTrackerApplication";

            string fileName = "Lastest_Daily_Report.json";
            string fileNameTemp = "Lastest_Daily_Report_Temp.json";


            var saveFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName);

            bool folderExists = Directory.Exists(saveFolderPath);
            if(!folderExists)
            {
                Directory.CreateDirectory(saveFolderPath);
            }

            var saveFilePath = Path.Combine(saveFolderPath, fileName);
            var saveFileTempPath = Path.Combine(saveFolderPath, fileNameTemp);

            try
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFile("https://static.pipezero.com/covid/data.json", saveFileTempPath);
            } catch
            {
                throw;
            }
            File.Copy(saveFileTempPath, saveFilePath, true);
            File.Delete(saveFileTempPath);
            return ;
        }
    }
}
