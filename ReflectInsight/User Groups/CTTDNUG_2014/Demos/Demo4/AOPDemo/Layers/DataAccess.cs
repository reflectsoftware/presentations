using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Extensions.PostSharp;

namespace AOPDemo.Layers
{
    public class DataAccess
    {
        //---------------------------------------------------------------------
        [RITrace("tracer.dataAccess")]
        public void UpateRecord(String name, Int32 age)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();
            ReflectInsight ri = RITraceManager.ActiveLogger;

            ri.AddCheckpoint();
            ri.SendMsg("This is message one in: {0}", mb.Name);
            ri.SendNote("This is message two in: {0}", mb.Name);

            if (age <= 0)
                throw new Exception("Age must be greater than zero.");
            
            ri.SendDebug("This is message three in: {0}", mb.Name);
            ri.SendWarning("This is message four in: {0}", mb.Name);
        }
    }
}
