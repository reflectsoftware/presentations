using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectSoftware.Insight;

namespace Demo5_Configuration
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSample();
        }

        static void RunSample()
        {
            ReflectInsight ri = new ReflectInsight();

            while (true)
            {
                Console.WriteLine("Press any key to run test or press 'q' to quit...");

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                ri.SendMsg("Message");
                ri.SendDebug("Debug");
                ri.SendTrace("Trace");                
                ri.SendInformation("Information");
                ri.SendWarning("Warning");                
                ri.SendError("Error");
                ri.SendFatal("Fatal");
                ri.SendException("Exception", new Exception("Look at inner exception for more details", new Exception("Some major exception occurred")));

                ri.Send(ReflectSoftware.Insight.Common.MessageType.SendError, "Error with details", "These are the details of this error");
                ri.Send(ReflectSoftware.Insight.Common.MessageType.SendTrace, "Trace with details", "These are the details of this trace");

                using (DataSet DataSet1 = new DataSet())
                {
                    DataSet1.ReadXml(String.Format(@"{0}Samples\dataset.xml", AppDomain.CurrentDomain.BaseDirectory), XmlReadMode.Auto);

                    ri.SendDataTable("Data Table", DataSet1.Tables[3]);
                }

                ri.SendImage("Hello, World", String.Format(@"{0}Samples\earth.jpg", AppDomain.CurrentDomain.BaseDirectory));
                ri.SendStream("Some Stream", String.Format(@"{0}Samples\Earth.jpg", AppDomain.CurrentDomain.BaseDirectory));     
            }
        }
    }
}
