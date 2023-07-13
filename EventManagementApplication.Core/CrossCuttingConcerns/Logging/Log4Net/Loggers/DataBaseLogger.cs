using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DataBaseLogger : LoggerService
    {
        public DataBaseLogger(ILog log) : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }


    }
}
