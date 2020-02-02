using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

namespace Scheduler
{
    static class LoggingUtils
    {
        // For some reason, the app runs in the bin/Debug folder at run time, so the two double-dots are necessary for this relative path to work
        // not really sure why, this was just my workaround after much debugging. 
        private const string ERROR_LOG = @"..\\..\\Resources\\errorLog.txt";
        
        /**
         * Appends a supplied error message to the error log
         */
        public static void LogErrors(string s)
        {
            // Open log file for appending
            FileStream log = new FileStream(ERROR_LOG, FileMode.Append, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(log))
            {
                // Log the error with the current time
                DateTime currentTime = DateTime.Now;
                // add the time and string together
                string logMessage = currentTime.ToString() + " " + s;
                writer.WriteLine(logMessage);
                writer.Close();
            }
            
            // clean up
            log.Close();
        }
    }
}
