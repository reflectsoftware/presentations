using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using NLog;

namespace Business.NLogDemo
{  
    public class Business
    {
        //---------------------------------------------------------------------
        public void ProcessRecord(String name, DateTime DOB)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            Logger log = LogManager.GetLogger("ReflectInsight");

            log.Info("[Enter]{0}", mb.Name);
            try
            {
                log.Info("This is message one in: {0}", mb.Name);
                log.Info("This is message two in: {0}", mb.Name);

                DataAccess.EntLibDemo.DataAccess da = new DataAccess.EntLibDemo.DataAccess();
                da.UpateRecord(name, DateTime.Now.Year - DOB.Year);

                log.Debug("This is message three in: {0}", mb.Name);
                log.Warn("This is message four in: {0}", mb.Name);
            }
            finally
            {
                log.Info("[Exit]{0}", mb.Name);
            }
        }
    }
}
