using System;
using System.Collections.Generic;
using System.Linq;

using ReflectSoftware.Insight;

namespace Demo5_HeadlessConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            RunHeadlessConfiguration();
        }

        static void RunHeadlessConfiguration()
        {
            while (true)
            {
                Console.WriteLine("Press any key to run test or press 'q' to quit...");

                ConsoleKeyInfo k = Console.ReadKey();
                if (k.KeyChar == 'q')
                    break;

                // Load the configuration file in the root of the application
                ReflectInsightConfig.SetDeveloperConfigurationMode(String.Format(@"{0}ReflectInsight.config", AppDomain.CurrentDomain.BaseDirectory));
                RILogManager.Get("Common").SendMsg("Testing developer configuration mode...");
                RILogManager.Get("Common").SendMsg("Configuration full path: {0}", ReflectInsightConfig.LastConfigFullPath);
                
                // Load in the configuration file located in the sub-folder "Other Config". Before loading in the configuration, you want to clear the developer configuration mode
                ReflectInsightConfig.SetDeveloperConfigurationMode(String.Format(@"{0}\Other Config\ReflectInsight2.config", AppDomain.CurrentDomain.BaseDirectory));
                RILogManager.Get("Common").SendMsg("Testing developer configuration mode...");
                RILogManager.Get("Common").SendMsg("Configuration full path: {0}", ReflectInsightConfig.LastConfigFullPath);
            }
        }
    }
}
