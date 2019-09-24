using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiSample.Utility
{
    public class Log
    {
        public static string LogFolder = Startup.LogFolder;
        public static string LogFile = Startup.LogFile;
        public static string FullFile = LogFolder + LogFile;

        public static void CreateLog()
        {
            if (!Directory.Exists(LogFolder))
                Directory.CreateDirectory(LogFolder);                      

            if (!File.Exists(FullFile))
                File.Create(FullFile).Close();
        }

        public static void ErrorToFile(string exMesg)
        {
            CreateLog();

            using (StreamWriter sw = File.AppendText(FullFile))
            {
                TextWriter tw = sw;
                tw.Write("\r\n");
                tw.WriteLine("Error on {0} :- {1}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), exMesg);
            }

        }

        public static void ErrorToFile(Exception exStack)
        {
            CreateLog(); 

            using (StreamWriter sw = File.AppendText(FullFile))
            {
                TextWriter tw = sw;
                tw.Write("\r\n");
                tw.WriteLine("Error on {0} :- {1}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), exStack.ToString());
            }
        }

        public static void ErrorToFile(string exMesg, string FileName)
        {
            if (!Directory.Exists(LogFolder))
                Directory.CreateDirectory(LogFolder);

            string FullFileName = LogFolder + "\\" + FileName + ".txt";

            if (!File.Exists(FullFileName))
                File.Create(FullFileName).Close();


            using (StreamWriter sw = File.AppendText(FullFileName))
            {
                TextWriter tw = sw;
                tw.Write("\r\n");
                tw.WriteLine("Error on {0} :- {1}", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), exMesg);
            }

        }
    }
}
