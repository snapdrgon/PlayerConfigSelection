using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerConfigSelection.Utilities
{
    public class Utilities
    {
        public static readonly log4net.ILog log =
              log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string GetExceptionMessage(Exception e)
        {
            var emsg = e.Message;
            while (e.InnerException != null)
            {
                e = e.InnerException;
                emsg += string.Format("; {0}", e.Message);
            }
            return emsg;
        }
    }
}
