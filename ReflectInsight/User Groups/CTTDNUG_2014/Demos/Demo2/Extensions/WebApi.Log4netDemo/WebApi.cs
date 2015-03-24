using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;

namespace WebApi.Log4netDemo
{
    public class WebApi
    {
        //---------------------------------------------------------------------
        public String Process(String name, DateTime DOB, String SIN)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            ILog log = LogManager.GetLogger(mb.DeclaringType);

            log.InfoFormat("[Enter]{0}", mb.Name);
            try
            {
                log.InfoFormat("This is message one in: {0}", mb.Name);
                log.InfoFormat("This is message two in: {0}", mb.Name);
                log.InfoFormat("SIN: {0}", SIN);

                Business.NLogDemo.Business bus = new Business.NLogDemo.Business();
                bus.ProcessRecord(name, DOB);

                log.DebugFormat("This is message three in: {0}", mb.Name);
                log.WarnFormat("This is message four in: {0}", mb.Name);

                return Guid.NewGuid().ToString();
            }
            finally
            {
                log.InfoFormat("[Exit]{0}", mb.Name);
            }
        }
    }
}
