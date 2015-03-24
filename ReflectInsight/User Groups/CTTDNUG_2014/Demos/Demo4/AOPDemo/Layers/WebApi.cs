using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Extensions.PostSharp;

namespace AOPDemo.Layers
{
    [RITrace("tracer.webApi")]
    public class WebApi
    {
        //---------------------------------------------------------------------
        public String Method1(String name, DateTime DOB, String SIN)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            ReflectInsight ri = RITraceManager.ActiveLogger;

            ri.AddCheckpoint();
            ri.SendMsg("This is message one in: {0}", mb.Name);
            ri.SendNote("This is message two in: {0}", mb.Name);
            ri.SendInformation("SIN: {0}", SIN);

            Business bus = new Business();
            bus.ProcessRecord(name, DOB);
            
            ri.SendDebug("This is message three in: {0}", mb.Name);
            ri.SendWarning("This is message four in: {0}", mb.Name);
            
            return Guid.NewGuid().ToString();
        }
    }
}
