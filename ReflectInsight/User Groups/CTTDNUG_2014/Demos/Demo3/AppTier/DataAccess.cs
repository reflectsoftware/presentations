using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AppTier.Models;

using ReflectSoftware.Insight;

namespace AppTier
{
    public class DataAccess
    {
        //---------------------------------------------------------------------
        public void UpateRecord(String name, Int32 age)
        {
            ReflectInsight ri = RILogManager.Get("DataAccess");

            using (ri.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                try
                {
                    ri.SendMsg("I'm somewhere inside the DataAccess.UpateRecord method");
                    ri.SendNote("name: {0}", name);
                    ri.SendNote("age: {0}", age);

                    if (age <= 0)
                        throw new Exception("Invalid age. Age must be greater than 0 (zero)");

                    using (DataSet ds = new DataSet())
                    {
                        ds.ReadXml(String.Format(@"{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "dataset.xml"), XmlReadMode.Auto);
                        ri.SendDataSet("DataSet with 4 tables", ds);
                        ri.SendDataTable("Showing only one table (the last one)", ds.Tables[ds.Tables.Count - 1]);
                    }
                    
                    using(var db = new NorthwindContext())
                    {
                        var orders = (from order in db.Orders select order).ToList();
                        var details = (from order_details in db.Order_Details select order_details).ToList();

                        ri.SendEnumerable("EF Dataset", new IEnumerable[] {orders, details} );
                    }
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
