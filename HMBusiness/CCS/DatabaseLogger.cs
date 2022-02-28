using System;

namespace HMBusiness.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Database loglandı.");
        }
    }

}
