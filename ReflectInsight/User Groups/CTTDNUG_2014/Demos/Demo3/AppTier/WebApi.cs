using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ReflectSoftware.Insight;

namespace AppTier
{
    public class WebApi
    {
        //---------------------------------------------------------------------
        public String Process(String name, DateTime DOB, String SIN)
        {
            // assume we got these customer values from the identity object.
            Random rnd = new Random();
            RIExtendedMessageProperty.AttachToRequest("Company Information", "ClientID", String.Format("{0:D4}", rnd.Next(10000)));
            RIExtendedMessageProperty.AttachToRequest("Company Information", "CompanyID", String.Format("{0:D5}", rnd.Next(100000)));                       
            
            ReflectInsight ri = RILogManager.Get("WebApi");

            using (ri.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                try
                {
                    ri.SendMsg("I'm somewhere inside the WebApi.Process method");
                    ri.SendNote("name: {0}", name);
                    ri.SendNote("DOB: {0}", DOB);
                    
                    Business bus = new Business();
                    bus.ProcessRecord(name, DOB);

                    ri.SendInformation("Just got back from calling the Business Layer");

                    return Guid.NewGuid().ToString();
                }
                catch(Exception ex)
                {
                    ri.SendException(ex);
                    throw;
                }
            }
        }
    }
}
