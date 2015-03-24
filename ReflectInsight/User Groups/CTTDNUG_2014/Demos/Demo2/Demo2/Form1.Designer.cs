namespace Demo2
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
            this.BtnAOPTest1 = new System.Windows.Forms.Button();
            this.BntClearView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Location = new System.Drawing.Point(139, 178);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnAOPTest1
            // 
            this.BtnAOPTest1.Location = new System.Drawing.Point(13, 13);
            this.BtnAOPTest1.Name = "BtnAOPTest1";
            this.BtnAOPTest1.Size = new System.Drawing.Size(104, 23);
            this.BtnAOPTest1.TabIndex = 1;
            this.BtnAOPTest1.Text = "Test";
            this.BtnAOPTest1.UseVisualStyleBackColor = true;
            this.BtnAOPTest1.Click += new System.EventHandler(this.BtnTest1_Click);
            // 
            // BntClearView
            // 
            this.BntClearView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BntClearView.Location = new System.Drawing.Point(12, 178);
            this.BntClearView.Name = "BntClearView";
            this.BntClearView.Size = new System.Drawing.Size(75, 23);
            this.BntClearView.TabIndex = 4;
            this.BntClearView.Text = "Clear View";
            this.BntClearView.UseVisualStyleBackColor = true;
            this.BntClearView.Click += new System.EventHandler(this.BntClearView_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 213);
            this.Controls.Add(this.BntClearView);
            this.Controls.Add(this.BtnAOPTest1);
            this.Controls.Add(this.BtnClose);
            this.Name = "Form1";
            this.Text = "Extension Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnAOPTest1;        
        private System.Windows.Forms.Button BntClearView;
    }
}

