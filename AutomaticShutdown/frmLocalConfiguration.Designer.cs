namespace AutomaticShutdown
{
    partial class frmLocalConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalConfiguration));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAnswerBeforeShutdown = new System.Windows.Forms.NumericUpDown();
            this.nudWarnAgain = new System.Windows.Forms.NumericUpDown();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dtpLimitHour = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlLocalConfig = new System.Windows.Forms.Panel();
            this.chkEnableShutdown = new System.Windows.Forms.CheckBox();
            this.chkUseLocalConfig = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswerBeforeShutdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarnAgain)).BeginInit();
            this.pnlLocalConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local configuration";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 70);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time to wait for user confirmation before running shutdown:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(496, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "If user postpone, time to wait before asking for a new shutdown:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(104, 481);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(173, 70);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Save";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(105, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(105, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "minutes";
            // 
            // nudAnswerBeforeShutdown
            // 
            this.nudAnswerBeforeShutdown.Font = new System.Drawing.Font("Verdana", 11F);
            this.nudAnswerBeforeShutdown.Location = new System.Drawing.Point(21, 192);
            this.nudAnswerBeforeShutdown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAnswerBeforeShutdown.Name = "nudAnswerBeforeShutdown";
            this.nudAnswerBeforeShutdown.Size = new System.Drawing.Size(78, 25);
            this.nudAnswerBeforeShutdown.TabIndex = 11;
            this.nudAnswerBeforeShutdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudWarnAgain
            // 
            this.nudWarnAgain.Font = new System.Drawing.Font("Verdana", 11F);
            this.nudWarnAgain.Location = new System.Drawing.Point(21, 288);
            this.nudWarnAgain.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudWarnAgain.Name = "nudWarnAgain";
            this.nudWarnAgain.Size = new System.Drawing.Size(78, 25);
            this.nudWarnAgain.TabIndex = 12;
            this.nudWarnAgain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(345, 481);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(173, 70);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Close";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // dtpLimitHour
            // 
            this.dtpLimitHour.CustomFormat = "HH:mm";
            this.dtpLimitHour.Font = new System.Drawing.Font("Verdana", 11F);
            this.dtpLimitHour.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLimitHour.Location = new System.Drawing.Point(21, 98);
            this.dtpLimitHour.Name = "dtpLimitHour";
            this.dtpLimitHour.ShowUpDown = true;
            this.dtpLimitHour.Size = new System.Drawing.Size(87, 25);
            this.dtpLimitHour.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Time to shutdown computer:";
            // 
            // pnlLocalConfig
            // 
            this.pnlLocalConfig.Controls.Add(this.chkEnableShutdown);
            this.pnlLocalConfig.Controls.Add(this.label6);
            this.pnlLocalConfig.Controls.Add(this.label2);
            this.pnlLocalConfig.Controls.Add(this.dtpLimitHour);
            this.pnlLocalConfig.Controls.Add(this.label3);
            this.pnlLocalConfig.Controls.Add(this.label4);
            this.pnlLocalConfig.Controls.Add(this.nudWarnAgain);
            this.pnlLocalConfig.Controls.Add(this.label5);
            this.pnlLocalConfig.Controls.Add(this.nudAnswerBeforeShutdown);
            this.pnlLocalConfig.Location = new System.Drawing.Point(31, 123);
            this.pnlLocalConfig.Name = "pnlLocalConfig";
            this.pnlLocalConfig.Size = new System.Drawing.Size(562, 331);
            this.pnlLocalConfig.TabIndex = 16;
            // 
            // chkEnableShutdown
            // 
            this.chkEnableShutdown.AutoSize = true;
            this.chkEnableShutdown.Checked = true;
            this.chkEnableShutdown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableShutdown.Font = new System.Drawing.Font("Verdana", 11F);
            this.chkEnableShutdown.Location = new System.Drawing.Point(21, 19);
            this.chkEnableShutdown.Name = "chkEnableShutdown";
            this.chkEnableShutdown.Size = new System.Drawing.Size(233, 22);
            this.chkEnableShutdown.TabIndex = 17;
            this.chkEnableShutdown.Text = "Enable automatic shutdown";
            this.chkEnableShutdown.UseVisualStyleBackColor = true;
            // 
            // chkUseLocalConfig
            // 
            this.chkUseLocalConfig.AutoSize = true;
            this.chkUseLocalConfig.Checked = true;
            this.chkUseLocalConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseLocalConfig.Font = new System.Drawing.Font("Verdana", 11F);
            this.chkUseLocalConfig.Location = new System.Drawing.Point(52, 88);
            this.chkUseLocalConfig.Name = "chkUseLocalConfig";
            this.chkUseLocalConfig.Size = new System.Drawing.Size(202, 22);
            this.chkUseLocalConfig.TabIndex = 18;
            this.chkUseLocalConfig.Text = "Use local configuration?";
            this.chkUseLocalConfig.UseVisualStyleBackColor = true;
            this.chkUseLocalConfig.CheckedChanged += new System.EventHandler(this.ChkUseLocalConfig_CheckedChanged);
            // 
            // FrmConfiguracaoLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 577);
            this.Controls.Add(this.chkUseLocalConfig);
            this.Controls.Add(this.pnlLocalConfig);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConfiguracaoLocal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local shutdown configuration policy";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnswerBeforeShutdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWarnAgain)).EndInit();
            this.pnlLocalConfig.ResumeLayout(false);
            this.pnlLocalConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudAnswerBeforeShutdown;
        private System.Windows.Forms.NumericUpDown nudWarnAgain;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DateTimePicker dtpLimitHour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlLocalConfig;
        private System.Windows.Forms.CheckBox chkEnableShutdown;
        private System.Windows.Forms.CheckBox chkUseLocalConfig;
    }
}