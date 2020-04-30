using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAdmin
{
    class WriteLogFile
    {
        public static bool WriteLog(string strFileName, string strMessage)
        {
            Stream stream = null;
            try
            {
                stream = new FileStream(string.Format("{0}\\{1}", Path.GetTempPath(), strFileName), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter(stream);
                objStreamWriter.WriteLine(strMessage + String.Format(" {0} {1}", Properties.strings.Date, DateTime.Now));
                objStreamWriter.Close();
                stream = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }
    }
}
