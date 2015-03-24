using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ReflectSoftware.Insight;

namespace AppTier
{
    public class Business
    {
        //---------------------------------------------------------------------
        public void ProcessRecord(String name, DateTime DOB)
        {
            ReflectInsight ri = RILogManager.Get("Business");

            using (ri.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                try
                {
                    ri.SendMsg("I'm somewhere inside the Business.ProcessRecord method");
                    ri.SendNote("name: {0}", name);
                    ri.SendNote("DOB: {0}", DOB);

                    DataAccess bus = new DataAccess();
                    bus.UpateRecord(name, DateTime.Now.Year - DOB.Year);

                    ri.SendInformation("Just got back from calling the DataAccess Layer");
                }
                catch (Exception ex)
                {
                    ri.SendException(ex);
                    throw;
                }
            }
        }
    }
}
