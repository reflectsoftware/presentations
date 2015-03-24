using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Extensions.PostSharp;

namespace AOPDemo.Layers
{
    [RITrace("tracer.business")]
    public class Business
    {
        //---------------------------------------------------------------------
        [RITraceAttribute(AttributeExclude = true)]
        public Business()
        {
        }
        //---------------------------------------------------------------------
        public void ProcessRecord(String name, DateTime DOB)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            ReflectInsight ri = RITraceManager.ActiveLogger;

            ri.AddCheckpoint();
            ri.SendMsg("This is message one in: {0}", mb.Name);
            ri.SendNote("This is message two in: {0}", mb.Name);

            DataAccess da = new DataAccess();
            da.UpateRecord(name, DateTime.Now.Year - DOB.Year);
            
            ri.SendDebug("This is message three in: {0}", mb.Name);
            ri.SendWarning("This is message four in: {0}", mb.Name);
        }
    }
}
