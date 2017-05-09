using System;
using System.Windows.Forms;
using System.IO.IsolatedStorage;
using System.IO;

namespace AutomaticShutdown
{
    /// <summary>
    /// Screen for IT to configure local shutdown policy
    /// </summary>
    public partial class frmLocalConfiguration : Form
    {
        
        public frmLocalConfiguration()
        {
            InitializeComponent();
            
            
            LocalConfig.Load();
            
            //UI
            chkUseLocalConfig.Checked = LocalConfig.UseLocalConfiguration;
            chkEnableShutdown.Checked = LocalConfig.UseLocalConfiguration ? LocalConfig.ShutdownEnabled : GlobalConfig.ShutdownEnabled;
            dtpLimitHour.Value = LocalConfig.UseLocalConfiguration ? LocalConfig.LimitHour : GlobalConfig.LimitHour;
            nudAnswerBeforeShutdown.Value = LocalConfig.UseLocalConfiguration ? LocalConfig.TimeToWaitForConfirmationBeforeShutdown : GlobalConfig.TimeToWaitBeforeShutdown;
            nudWarnAgain.Value = LocalConfig.UseLocalConfiguration ? LocalConfig.SnoozeTimeBeforeShutdown : GlobalConfig.TimeToPostponeShutdown;
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            LocalConfig.SaveConfiguracao(string.Format("{0}|{1}|{2}|{3}|{4}", 
                chkUseLocalConfig.Checked ? "Y" : "N", 
                chkEnableShutdown.Checked ? "Y" : "N", 
                dtpLimitHour.Value.ToString("HH:mm"), 
                nudAnswerBeforeShutdown.Value, 
                nudWarnAgain.Value));
            
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkUseLocalConfig_CheckedChanged(object sender, EventArgs e)
        {
            pnlLocalConfig.Enabled = chkUseLocalConfig.Checked;
        }
    }
}
