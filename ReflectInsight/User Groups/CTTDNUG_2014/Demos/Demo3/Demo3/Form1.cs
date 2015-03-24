using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using ReflectSoftware.Insight;

namespace Demo3
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------
        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            GReflectInsight.ViewerClearAll();
            LbThreadTime.Text = String.Empty;
            LbThreadTime2.Text = String.Empty;
        }
        //---------------------------------------------------------------------
        private void BtnTest_Click(object sender, EventArgs e)
        {
            AppTier.WebApi api = new AppTier.WebApi();
            api.Process("ReflectInsight", DateTime.Now.AddYears(-15), "123-456-789");
        }
        //---------------------------------------------------------------------
        private void BtnTestWithException_Click(object sender, EventArgs e)
        {
            try
            {
                AppTier.WebApi api = new AppTier.WebApi();
                api.Process("ReflectInsight", DateTime.Now.AddYears(15), "123-456-789");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------
        private void BtnBulkSend_Click(object sender, EventArgs e)
        {
            ReflectInsight ri = RILogManager.Default;
            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (Int32 i = 0; i < (Int32)nsSendNumber.Value; i++)
            {
                ri.SendMsg("Message: {0}", i);
            }

            sw.Stop();
            LbThreadTime2.Text = String.Format("{0} msecs", sw.ElapsedMilliseconds);
            LbThreadTime2.Visible = true;
        }
        //---------------------------------------------------------------------
        private void ThreadTestThread(Object data)
        {
            ThreadTestData tData = (ThreadTestData)data;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (tData.RI.TraceMethod("Thread: {0}", tData.ThreadId))
            {
                for (Int32 i = 0; i < tData.MessageCount; i++)
                {
                    tData.RI.SendMsg("Sent by thread {0}: {1}", tData.ThreadId, i + 1);
                }
            }

            sw.Stop();
            tData.TotalTime = sw.ElapsedMilliseconds;
        }
        //---------------------------------------------------------------------
        private void BtnGoThreadTest_Click(object sender, EventArgs e)
        {
            LbThreadTime.Visible = false;
            ThreadTestData[] threads = new ThreadTestData[(Int32)numThreads.Value];
            for (Int32 i = 0; i < threads.Length; i++)
            {
                threads[i] = new ThreadTestData();
                threads[i].TotalTime = 0;
                threads[i].ThreadId = i + 1;
                threads[i].MessageCount = (Int32)numThreadMessages.Value;
                threads[i].RI = RILogManager.Default;
                threads[i].TheThread = new Thread(ThreadTestThread);
                threads[i].TheThread.Start(threads[i]);
            }

            Int64 totalTime = 0;
            for (Int32 i = 0; i < threads.Length; i++)
            {
                threads[i].TheThread.Join();
                totalTime += threads[i].TotalTime;
            }

            LbThreadTime.Text = String.Format("{0} msecs", totalTime);
            LbThreadTime.Visible = true;
        }

        class ThreadTestData
        {
            public ReflectInsight RI;
            public Int32 ThreadId;
            public Int32 MessageCount;
            public Thread TheThread;
            public Int64 TotalTime;
        }
    }
}
