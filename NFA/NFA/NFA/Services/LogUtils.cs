using System;
using System.Collections.Generic;
using System.Text;

namespace NFA.Services
{
    class LogUtils
    {
        string logFilePath = null;

        public LogUtils()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            logFilePath = System.IO.Path.Combine(path, "log.txt");
            if(!System.IO.File.Exists(logFilePath))
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilePath, true))
                {
                    writer.WriteLine("Starting logging at " + DateTime.Now.ToString());
                }
            }
        }

        public void Log(String message)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilePath, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " : " + message);
            }
        }
    }
}
