using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RapidPay.Core
{
    public class ErrorLogger
    {
        private static readonly object _LockObj = new object();
        public static void WriteToErrorLog(string msg, string stkTrace)
        {
            try
            {
                System.DateTime l_ServerDate = DateTime.Now;
                string l_FileName = l_ServerDate.Month + "-" + l_ServerDate.Day + "-" + l_ServerDate.Year + "-" + GlobalDeclarations.UserID;
                string l_Path   = Path.Combine(GlobalDeclarations.ApplicationPath, "Errors");

                lock (_LockObj)
                {
                    if (!Directory.Exists(l_Path))
                    {
                        System.IO.Directory.CreateDirectory(l_Path);
                    }

                    StreamWriter s1 = new StreamWriter(new FileStream(Path.Combine(l_Path, l_FileName + "_Errors.txt"), FileMode.Append, FileAccess.Write));

                    s1.Write("Date/Time: " + DateTime.Now.ToString() + Environment.NewLine);
                    s1.Write("Message: " + msg + Environment.NewLine);
                    s1.Write("StackTrace: " + stkTrace + Environment.NewLine);
                    s1.Write("===========================================================================================" + Environment.NewLine);

                    s1.Close();
                }
            }
            catch (Exception)
            {
                
                
            }
            
        }
    }
}
