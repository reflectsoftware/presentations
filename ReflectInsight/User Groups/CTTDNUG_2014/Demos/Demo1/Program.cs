using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;
using ReflectSoftware.Insight.Common.Data;

/***
    ..Memory 
    ..Loaded Assemblies    
    ..ThreadInfo
    ..Processes
    Threads

    Rich Message Details:
        Syntax highlighting like XML, SQL, HTML
        ...Datasets (grids) and remembering of states
        Collection/Enumeration
        ..Images
        
        ..Hex Editor
        ..Colors
          Custom Data
         
    
    Traceability 
        ..Enter/Exit

    ..Message Properties / Extended Properties
    - Inserting/Adding messages/notes/comments/checkmarks (bookmark msg after insert)
 ***/

namespace Demo1
{
    class Program
    {
        readonly static String[] Sources = new String[] { "New York", "California", "Minnesota", "Florida", "Illinois", "Georgia", "Iowa", "Arizona", "Maine", "Indiana", "Michigan" };
        static DataSet DataSet1;
        
        static void ThreadDemoBackorder(Object state)
        {            
            // Attach Request Extended data            
            Random rnd1 = new Random((Int32)DateTime.Now.Ticks + (Int32)state);
            
            String source = Sources[rnd1.Next(Sources.Length)];
            RIExtendedMessageProperty.AttachToRequest("Company Information", "ClientID", String.Format("{0:D4}", rnd1.Next(10000)));
            RIExtendedMessageProperty.AttachToRequest("Company Information", "CompanyID", String.Format("{0:D5}", rnd1.Next(100000)));
            RIExtendedMessageProperty.AttachToRequest("Company Information", "Source", source);

            ReflectInsight ri = RILogManager.Get("Backorder");           

            using (ri.TraceMethod("Starting Backorder thread block"))
            {
                try
                {
                    ri.SendThreadInformation();
                    Thread.Sleep(500);

                    Int32 poNumber = rnd1.Next(100000);

                    using (ri.TraceMethod("Initiating purchase order: {0}", String.Format("{0:D5}", poNumber)))
                    {
                        ri.SendDataSet("Customer order information loaded", DataSet1);
                        Thread.Sleep(500);

                        using (ri.TraceMethod("Validate Customer"))
                        {
                            ri.SendCheckmark("Customer certificate validation successfully", Checkmark.Green);
                            ri.SendCheckmark("Customer threshold is within fair standings", Checkmark.Yellow);

                            Thread.Sleep(500);
                            using (ri.TraceMethod("Validate Customer Backorders"))
                            {
                                ri.SendInformation("Backorders detected: {0}", rnd1.Next(20));
                                ri.SendMsg("Processing {0} records", rnd1.Next(21, 200));
                            }

                            using (ri.TraceMethod("Preparing source configuration data for state: '{0}'", source))
                            {
                                ri.SendMsg("Reading source configuration data");

                                if (source == "Georgia")
                                {
                                    ri.SendError("Unable to retrieve source data for state: '{0}'. Source data is either missing or isn't properly configured.", source);
                                    Thread.Sleep(1000);
                                    ri.SendXMLFile("See failed configuration", String.Format(@"{0}Samples\state_config.xml", AppDomain.CurrentDomain.BaseDirectory));

                                    // show dummy configuration file
                                    using (ri.TraceMethod("Requeuing order: {0}", poNumber))
                                    {
                                        ri.SendMsg("Recoil start indicators");
                                        ri.SendTimestamp("Requeued Timestamp");
                                    }

                                    return;
                                }

                                Thread.Sleep(500);
                                ri.SendCheckmark("Source configuration data was successfully loaded", Checkmark.Green);
                            }
                        }

                        using (ri.TraceMethod("Processing order: {0}", poNumber))
                        {
                            try
                            {
                                if (source == "Minnesota")
                                {
                                    ri.SendError("item 3 'Quantity' value exceeds customer's threshold limit of 20, for PartNumber: '872-AX'");
                                    ri.SendWarning("Order: {0} was not processed due to exceeding threshold limit: 'Quantity'", poNumber);
                                    Thread.Sleep(1000);
                                    ri.SendXMLFile(String.Format("See failed order: {0}", poNumber), String.Format(@"{0}Samples\purchase_order.xml", AppDomain.CurrentDomain.BaseDirectory));

                                    Thread.Sleep(100);
                                    using (ri.TraceMethod("Prepare CRM failed compensation report workflow"))
                                    {
                                        ri.SendMsg("Establish CRM connection");
                                        Thread.Sleep(100);
                                        ri.SendCheckmark("CRM connection successfully establised", Checkmark.Green);

                                        Thread.Sleep(100);
                                        using (ri.TraceMethod("Insert CRM failed compensation report"))
                                        {
                                            ri.SendMsg("Insert compensation");
                                            ri.SendMsg("Insert item status");
                                            ri.SendMsg("CRM record id: {0}", rnd1.Next(10000, 100000));
                                            ri.SendTimestamp("CRM Timestamp");
                                        }
                                    }

                                    return;
                                }

                                ri.SendCheckmark(String.Format("Successfully processed {0} order items", rnd1.Next(1, 50)), Checkmark.Green);
                                ri.SendMsg("Preparing reciept");
                                ri.SendMsg("Preparing client processed notification");
                                ri.SendMsg("Preparing dispatch record");

                                Thread.Sleep(500);
                                using (ri.TraceMethod("Prepare CRM reciept workflow"))
                                {
                                    ri.SendMsg("Establish CRM connection");                                 
                                    Thread.Sleep(100);
                                    if (source == "Michigan")
                                    {
                                        SecurityException e1 = new SecurityException("Account is disabled. Please contact IT Support.");
                                        ri.SendException(new Exception("Unable to connect to client's CRM system. Please see inner exception for more details", e1));
                                        return;
                                    }

                                    Thread.Sleep(500);
                                    ri.SendCheckmark("CRM connection successfully establised", Checkmark.Green);
                                    
                                    using (ri.TraceMethod("Insert CRM order process completion"))
                                    {
                                        ri.SendMsg("Insert reciept");
                                        ri.SendMsg("Insert dispatch record");
                                        ri.SendMsg("CRM record id: {0}", rnd1.Next(10000, 100000));
                                        ri.SendTimestamp("CRM Timestamp");
                                    }
                                }

                                ri.SendCheckmark(String.Format("Order: {0} was successfully processed", poNumber), Checkmark.Green);
                            }
                            catch(Exception)
                            {
                                using (ri.TraceMethod("Reverting order: {0} due to fatal error.", poNumber))
                                {
                                    ri.SendCheckmark("Order successfuly reverted", Checkmark.Green);
                                    using (ri.TraceMethod("Requeuing order: {0}", poNumber))
                                    {
                                        ri.SendMsg("Recoil start indicators");
                                        ri.SendTimestamp("Requeued Timestamp");
                                    }
                                }
                                
                                throw;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    ri.SendException(ex);
                }
            }
        }

        //---------------------------------------------------------------------
        static RICustomData GetCustomData1()
        {
            Random rnd = new Random((Int32)DateTime.Now.Ticks);

            List<RICustomDataColumn> columns = new List<RICustomDataColumn>();
            columns.Add(new RICustomDataColumn("Column1"));
            columns.Add(new RICustomDataColumn("Column2"));
            columns.Add(new RICustomDataColumn("Column3"));
            columns.Add(new RICustomDataColumn("Column4"));

            RICustomData cData = new RICustomData("My Custom Data", columns, true, false);
            cData.AddRow("Ross", "Test");

            RICustomDataCategory cat = cData.AddCategory("Category1");
            for (Int32 i = 0; i < 3; i++)
            {
                const String crap = "a";
                cat.AddRow(String.Format("field1{0}{1}", i, crap), String.Format("field2{0}{1}", i, crap), String.Format("field3{0}", i));
            }

            cat = cat.AddCategory("Category2");
            RICustomDataCategory cat2 = cat;
            for (Int32 i = 0; i < 3; i++)
            {
                const String crap = "b";
                cat.AddRow(String.Format("field1{0}{1}", i, crap), String.Format("field2{0}", i), String.Format("field3{0}", i), String.Format("field4{0}", i));
            }

            cat = cat.AddCategory("Category3");
            RICustomDataCategory cat3 = cat.AddCategory("Category3b");
            cat3.AddRow("Ross", "Test");

            for (Int32 i = 0; i < 3; i++)
            {
                const String crap = "c";
                cat.AddRow(String.Format("field1{0}{1}", i, crap), String.Format("field2{0}", i), String.Format("field3{0}", i), String.Format("field4{0}", i));
            }

            for (Int32 i = 0; i < 3; i++)
            {
                const String crap = "bx";
                cat2.AddRow(String.Format("field1{0}{1}", i, crap), String.Format("field2{0}", i), String.Format("field3{0}{1}", i, crap));
            }

            cat = cData.AddCategory("Category1a");
            for (Int32 i = 0; i < 3; i++)
            {
                const String crap = "a1";
                cat.AddRow(String.Format("field1{0}{1}", i, crap), String.Format("field2{0}{1}", i, crap), String.Format("field3{0}", i));
            }

            for (Int32 i = 0; i < 3; i++)
            {
                const String crap = "d";
                cData.AddRow(String.Format("field1{0}{1}", i, crap), String.Format("field2{0}", i), String.Format("field3{0}{1}", i, crap));
            }

            return cData;
        }

        static void MiscellaneousSample()
        {
            ReflectInsight ri = RILogManager.Get("Miscellaneous");

            using (ri.TraceMethod("Starting Miscellaneous thread block"))
            {
                ri.SendThreadInformation();
                Thread.Sleep(500);

                ri.SendImage("Hello, World", String.Format(@"{0}Samples\earth.jpg", AppDomain.CurrentDomain.BaseDirectory));
                ri.SendStream("Some Stream", String.Format(@"{0}Samples\Earth.jpg", AppDomain.CurrentDomain.BaseDirectory));                
                ri.SendCustomData("Sample Custom Data", GetCustomData1());                
                ri.SendColor("Some Color", Color.Aquamarine);
            }
        }
        
        static void PrimeThread()
        {
            ReflectInsight ri = RILogManager.Default;
            
            using (ri.TraceMethod(MethodBase.GetCurrentMethod(), true))
            {
                using (DataSet1 = new DataSet())
                {
                    DataSet1.ReadXml(String.Format(@"{0}Samples\dataset.xml", AppDomain.CurrentDomain.BaseDirectory), XmlReadMode.Auto);

                    ri.SendMemoryStatus("Before thread launch memory status");
                    ri.SendLoadedAssemblies("Before thread launch loaded assemblies");
                    ri.SendLoadedProcesses("Before thread launch loaded processes");

                    ri.SendInformation("Preparing thread launch");

                    List<Thread> threadIds = new List<Thread>();
                    for (Int32 i = 0; i < 30; i++)
                    {
                        Thread t = new Thread(ThreadDemoBackorder);
                        t.Start(i);
                        threadIds.Add(t);

                        Thread.Sleep(500 + (10 * i));
                    }

                    ri.SendInformation("Waiting on threads to complete");
                    foreach (Thread t in threadIds)
                    {
                        t.Join();
                    }

                    ri.AddSeparator();
                    MiscellaneousSample();
                }

                ri.SendCheckmark("All threads completed successfully", Checkmark.Green);

                ri.SendMemoryStatus("After thread launch memory status");
                ri.SendLoadedAssemblies("After thread launch loaded assemblies");
                ri.SendLoadedProcesses("After thread launch loaded processes");
            }
        }
        
        static void Main(string[] args)
        {
            PrimeThread();
        }
    }
}
