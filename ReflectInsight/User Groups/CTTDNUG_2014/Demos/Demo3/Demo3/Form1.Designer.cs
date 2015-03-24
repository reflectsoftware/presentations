namespace Demo3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnTest = new System.Windows.Forms.Button();
            this.LbThreadTime = new System.Windows.Forms.Label();
            this.numThreadMessages = new System.Windows.Forms.NumericUpDown();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGoThreadTest = new System.Windows.Forms.Button();
            this.LbThreadTime2 = new System.Windows.Forms.Label();
            this.nsSendNumber = new System.Windows.Forms.NumericUpDown();
            this.BtnBulkSend = new System.Windows.Forms.Button();
            this.BtnClearAll2 = new System.Windows.Forms.Button();
            this.BtnTestWithException = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThreadMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nsSendNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(265, 258);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(12, 12);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(148, 23);
            this.BtnTest.TabIndex = 2;
            this.BtnTest.Text = "Test";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // LbThreadTime
            // 
            this.LbThreadTime.AutoSize = true;
            this.LbThreadTime.Location = new System.Drawing.Point(22, 206);
            this.LbThreadTime.Name = "LbThreadTime";
            this.LbThreadTime.Size = new System.Drawing.Size(46, 13);
            this.LbThreadTime.TabIndex = 17;
            this.LbThreadTime.Text = "0 msecs";
            this.LbThreadTime.Visible = false;
            // 
            // numThreadMessages
            // 
            this.numThreadMessages.Location = new System.Drawing.Point(76, 143);
            this.numThreadMessages.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numThreadMessages.Name = "numThreadMessages";
            this.numThreadMessages.Size = new System.Drawing.Size(84, 20);
            this.numThreadMessages.TabIndex = 16;
            this.numThreadMessages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThreadMessages.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(76, 116);
            this.numThreads.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(84, 20);
            this.numThreads.TabIndex = 15;
            this.numThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThreads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Messages:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Threads:";
            // 
            // BtnGoThreadTest
            // 
            this.BtnGoThreadTest.Location = new System.Drawing.Point(16, 169);
            this.BtnGoThreadTest.Name = "BtnGoThreadTest";
            this.BtnGoThreadTest.Size = new System.Drawing.Size(144, 23);
            this.BtnGoThreadTest.TabIndex = 12;
            this.BtnGoThreadTest.Text = "Go";
            this.BtnGoThreadTest.UseVisualStyleBackColor = true;
            this.BtnGoThreadTest.Click += new System.EventHandler(this.BtnGoThreadTest_Click);
            // 
            // LbThreadTime2
            // 
            this.LbThreadTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbThreadTime2.AutoSize = true;
            this.LbThreadTime2.Location = new System.Drawing.Point(246, 172);
            this.LbThreadTime2.Name = "LbThreadTime2";
            this.LbThreadTime2.Size = new System.Drawing.Size(46, 13);
            this.LbThreadTime2.TabIndex = 52;
            this.LbThreadTime2.Text = "0 msecs";
            this.LbThreadTime2.Visible = false;
            // 
            // nsSendNumber
            // 
            this.nsSendNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsSendNumber.Location = new System.Drawing.Point(240, 113);
            this.nsSendNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nsSendNumber.Name = "nsSendNumber";
            this.nsSendNumber.Size = new System.Drawing.Size(100, 20);
            this.nsSendNumber.TabIndex = 51;
            this.nsSendNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nsSendNumber.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // BtnBulkSend
            // 
            this.BtnBulkSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBulkSend.Location = new System.Drawing.Point(240, 139);
            this.BtnBulkSend.Name = "BtnBulkSend";
            this.BtnBulkSend.Size = new System.Drawing.Size(100, 23);
            this.BtnBulkSend.TabIndex = 50;
            this.BtnBulkSend.Text = "Send";
            this.BtnBulkSend.UseVisualStyleBackColor = true;
            this.BtnBulkSend.Click += new System.EventHandler(this.BtnBulkSend_Click);
            // 
            // BtnClearAll2
            // 
            this.BtnClearAll2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClearAll2.Location = new System.Drawing.Point(16, 258);
            this.BtnClearAll2.Name = "BtnClearAll2";
            this.BtnClearAll2.Size = new System.Drawing.Size(100, 23);
            this.BtnClearAll2.TabIndex = 60;
            this.BtnClearAll2.Text = "ClearAll";
            this.BtnClearAll2.UseVisualStyleBackColor = true;
            this.BtnClearAll2.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // BtnTestWithException
            // 
            this.BtnTestWithException.Location = new System.Drawing.Point(12, 41);
            this.BtnTestWithException.Name = "BtnTestWithException";
            this.BtnTestWithException.Size = new System.Drawing.Size(148, 23);
            this.BtnTestWithException.TabIndex = 61;
            this.BtnTestWithException.Text = "Test with Exception";
            this.BtnTestWithException.UseVisualStyleBackColor = true;
            this.BtnTestWithException.Click += new System.EventHandler(this.BtnTestWithException_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 300);
            this.Controls.Add(this.BtnTestWithException);
            this.Controls.Add(this.BtnClearAll2);
            this.Controls.Add(this.LbThreadTime2);
            this.Controls.Add(this.nsSendNumber);
            this.Controls.Add(this.BtnBulkSend);
            this.Controls.Add(this.LbThreadTime);
            this.Controls.Add(this.numThreadMessages);
            this.Controls.Add(this.numThreads);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGoThreadTest);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.BtnClose);
            this.Name = "Form1";
            this.Text = "Demo3";
            ((System.ComponentModel.ISupportInitialize)(this.numThreadMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nsSendNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Label LbThreadTime;
        private System.Windows.Forms.NumericUpDown numThreadMessages;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGoThreadTest;
        private System.Windows.Forms.Label LbThreadTime2;
        private System.Windows.Forms.NumericUpDown nsSendNumber;
        private System.Windows.Forms.Button BtnBulkSend;
        private System.Windows.Forms.Button BtnClearAll2;
        private System.Windows.Forms.Button BtnTestWithException;
    }
}

