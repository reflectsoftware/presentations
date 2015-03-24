using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace DataAccess.EntLibDemo
{
    public class DataAccess
    {
        //---------------------------------------------------------------------
        private static XmlDocument GetSampleXmlDocumet()
        {
            XmlDocument xDoc = new XmlDocument() { PreserveWhitespace = true };
            xDoc.Load(String.Format(@"{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Sample.xml"));
            return xDoc;
        }                
        //---------------------------------------------------------------------
        public void UpateRecord(String name, Int32 age)
        {
            MethodBase mb = MethodBase.GetCurrentMethod();

            Logger.Write(String.Format("[Enter]{0}", mb.Name));
            try
            {
                Logger.Write(String.Format("Message1: {0} - {1}", name, age));
                Logger.Write("Information", "General", 0, 0, TraceEventType.Information);
                Logger.Write("Critical", "General", 0, 0, TraceEventType.Critical);
                Logger.Write("Error", "General", 0, 0, TraceEventType.Error);
                Logger.Write("Warning", "General", 0, 0, TraceEventType.Warning);

                // send an XML log
                XmlLogEntry xmlEntry = new XmlLogEntry();
                xmlEntry.Categories.Add("General");
                xmlEntry.Severity = TraceEventType.Information;
                xmlEntry.Message = "Sample XML";
                xmlEntry.Xml = GetSampleXmlDocumet().CreateNavigator();
                Logger.Write(xmlEntry);

                // message with extension
                LogEntry lEntry = new LogEntry();
                lEntry.Categories.Add("General");
                lEntry.Severity = TraceEventType.Information;
                lEntry.Message = "message with extended properties.";
                lEntry.ExtendedProperties["ClientId"] = 1234;
                lEntry.ExtendedProperties["CompanyId"] = 7895;
                lEntry.ExtendedProperties["State"] = "CA";
                Logger.Write(lEntry);
            }
            finally
            {
                Logger.Write(String.Format("[Exit]{0}", mb.Name));
            }
        }
    }
}
