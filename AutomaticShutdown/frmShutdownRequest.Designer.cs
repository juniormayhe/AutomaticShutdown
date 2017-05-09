namespace AutomaticShutdown
{
    partial class frmShutdownRequest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShutdownRequest));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNao = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.userInactivityTimer = new System.Windows.Forms.Timer(this.components);
            this.postponeTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 82);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(131, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Automatic shutdown";
            // 
            // lblAviso
            // 
            this.lblWarning.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.DimGray;
            this.lblWarning.Location = new System.Drawing.Point(31, 103);
            this.lblWarning.Name = "lblAviso";
            this.lblWarning.Size = new System.Drawing.Size(556, 87);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "Your company has scheduled an energy cost reduction starting at [HOUR].";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(31, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(556, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Can we shutdown your computer now?";
            // 
            // btnSim
            // 
            this.btnYes.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnYes.Location = new System.Drawing.Point(31, 260);
            this.btnYes.Name = "btnSim";
            this.btnYes.Size = new System.Drawing.Size(255, 78);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "Yes, turn it off";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNao
            // 
            this.btnNao.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNao.Font = new System.Drawing.Font("Verdana", 12F);
            this.btnNao.Location = new System.Drawing.Point(326, 260);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(255, 78);
            this.btnNao.TabIndex = 3;
            this.btnNao.Text = "Do not turn off";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // timer2
            // 
            this.userInactivityTimer.Interval = 1000;
            this.userInactivityTimer.Tick += new System.EventHandler(this.userInactivityTimer_Tick);
            // 
            // timer3
            // 
            this.postponeTimer.Interval = 1000;
            this.postponeTimer.Tick += new System.EventHandler(this.postponeTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnNao;
            this.ClientSize = new System.Drawing.Size(613, 369);
            this.Controls.Add(this.btnNao);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shutdown request";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer userInactivityTimer;
        private System.Windows.Forms.Timer postponeTimer;
    }
}

