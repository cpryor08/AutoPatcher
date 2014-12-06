namespace Designer
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
            this.overallProgressBar = new System.Windows.Forms.ProgressBar();
            this.overallLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clientVersionLbl = new System.Windows.Forms.Label();
            this.serverVersionLbl = new System.Windows.Forms.Label();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.dlProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // overallProgressBar
            // 
            this.overallProgressBar.Location = new System.Drawing.Point(12, 78);
            this.overallProgressBar.Name = "overallProgressBar";
            this.overallProgressBar.Size = new System.Drawing.Size(477, 17);
            this.overallProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.overallProgressBar.TabIndex = 0;
            // 
            // overallLabel
            // 
            this.overallLabel.AutoSize = true;
            this.overallLabel.ForeColor = System.Drawing.Color.White;
            this.overallLabel.Location = new System.Drawing.Point(12, 61);
            this.overallLabel.Name = "overallLabel";
            this.overallLabel.Size = new System.Drawing.Size(52, 13);
            this.overallLabel.TabIndex = 2;
            this.overallLabel.Text = "Initializing";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(376, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Version:";
            // 
            // clientVersionLbl
            // 
            this.clientVersionLbl.AutoSize = true;
            this.clientVersionLbl.ForeColor = System.Drawing.Color.White;
            this.clientVersionLbl.Location = new System.Drawing.Point(317, 9);
            this.clientVersionLbl.Name = "clientVersionLbl";
            this.clientVersionLbl.Size = new System.Drawing.Size(31, 13);
            this.clientVersionLbl.TabIndex = 6;
            this.clientVersionLbl.Text = "1000";
            // 
            // serverVersionLbl
            // 
            this.serverVersionLbl.AutoSize = true;
            this.serverVersionLbl.ForeColor = System.Drawing.Color.White;
            this.serverVersionLbl.Location = new System.Drawing.Point(461, 9);
            this.serverVersionLbl.Name = "serverVersionLbl";
            this.serverVersionLbl.Size = new System.Drawing.Size(31, 13);
            this.serverVersionLbl.TabIndex = 7;
            this.serverVersionLbl.Text = "1000";
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadLabel.ForeColor = System.Drawing.Color.White;
            this.downloadLabel.Location = new System.Drawing.Point(12, 21);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(172, 13);
            this.downloadLabel.TabIndex = 3;
            this.downloadLabel.Text = "Connecting To Autopatch Server...";
            // 
            // dlProgressBar
            // 
            this.dlProgressBar.Location = new System.Drawing.Point(12, 39);
            this.dlProgressBar.Name = "dlProgressBar";
            this.dlProgressBar.Size = new System.Drawing.Size(477, 17);
            this.dlProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.dlProgressBar.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(501, 118);
            this.Controls.Add(this.serverVersionLbl);
            this.Controls.Add(this.clientVersionLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.overallLabel);
            this.Controls.Add(this.dlProgressBar);
            this.Controls.Add(this.overallProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unidentified CO Autopatcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar overallProgressBar;
        public System.Windows.Forms.Label overallLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label clientVersionLbl;
        public System.Windows.Forms.Label serverVersionLbl;
        public System.Windows.Forms.Label downloadLabel;
        public System.Windows.Forms.ProgressBar dlProgressBar;
    }
}