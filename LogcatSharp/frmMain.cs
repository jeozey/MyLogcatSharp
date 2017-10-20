using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogcatSharp
{
    public partial class frmMain : Form
    {
        string adbPath = string.Empty;

        public frmMain()
        {
            InitializeComponent();
        }

        Process adb = null;

        private void frmMain_Load(object sender, EventArgs e)
        {

            this.regSelect.SelectedIndex = 0;
            //this.levelSelect.SelectedIndex = 1;

            this.adbPath = Settings.GetPath();

            if (string.IsNullOrEmpty(adbPath) || !System.IO.File.Exists(adbPath))
            {
                frmAdbFinder faf = new frmAdbFinder();
                if (faf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.adbPath = faf.AdbPath;
                    Settings.SavePath(faf.AdbPath);
                }
                else
                {
                    MessageBox.Show(this, "Could not find adb.exe.  Please install the SDK and Emulator and try again!  Alternatively you can set the path manually adb-path.txt", "Failed to find adb.exe", MessageBoxButtons.OK);

                    this.Close();
                    Application.Exit();
                }
            }
            devices();
        }

        void clear()
        {

            try
            {
                if (adb == null || adb.HasExited)
                {
                    adb = new Process();
                    adb.StartInfo.UseShellExecute = false;
                    adb.StartInfo.FileName = this.adbPath;//
                    adb.StartInfo.Arguments = "logcat -c";
                    adb.StartInfo.CreateNoWindow = true;
                    adb.Start();
                    adb.WaitForExit(1500);
                }
            }
            catch { }

        }

        void devices()
        {

            if (adb != null && !adb.HasExited)
                return;

            adb = new Process();
            adb.StartInfo.UseShellExecute = false;
            adb.StartInfo.FileName = this.adbPath;
            adb.StartInfo.Arguments = "devices";
            adb.StartInfo.RedirectStandardOutput = true;
            adb.StartInfo.RedirectStandardError = true;
            adb.EnableRaisingEvents = true;
            adb.StartInfo.CreateNoWindow = true;
            //adb.ErrorDataReceived += new DataReceivedEventHandler(adb_ErrorDataReceived);
            adb.OutputDataReceived += new DataReceivedEventHandler(adbDevices_OutputDataReceived);


            try { var started = adb.Start(); }
            catch (Exception ex)
            {
                this.btnStart.Enabled = true;
                this.toolStripButtonStop.Enabled = false;

                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            //adb.BeginErrorReadLine();
            adb.BeginOutputReadLine();

        }

        void stop()
        {
            this.toolStripButtonStop.Enabled = false;

            if (adb != null && !adb.HasExited)
            {
                adb.Kill();
            }

            this.btnStart.Enabled = true;
        }

        void start()
        {
            if (deviceSelect.Items.Count > 0)
            {
                if (deviceSelect.Items.Count == 1)
                {
                    deviceSelect.SelectedIndex = 0;
                }
                if (deviceSelect.SelectedItem == null)
                {
                    outputAdb.AppendText("Please select one devices\n");
                    return;
                }
            }
            else
            {
                outputAdb.AppendText("No devices connected\n");
                return;
            }

            String device = deviceSelect.Text;
            String logLevel = "D";
            switch (this.levelSelect.SelectedIndex)
            {
                case 0:
                    logLevel = "V";
                    break;
                case 1:
                    logLevel = "D";
                    break;
                case 2:
                    logLevel = "I";
                    break;
                case 3:
                    logLevel = "W";
                    break;
                case 4:
                    logLevel = "E";
                    break;
                case 5:
                    logLevel = "F";
                    break;
            }

            this.btnStart.Enabled = false;

            if (adb != null && !adb.HasExited)
                return;

            adb = new Process();
            adb.StartInfo.UseShellExecute = false;
            adb.StartInfo.FileName = this.adbPath;//
            adb.StartInfo.Arguments = String.IsNullOrEmpty(device) ? "" : ("-s " + device + " logcat") + (" *:" + logLevel);
            adb.StartInfo.RedirectStandardOutput = true;
            adb.StartInfo.RedirectStandardError = true;
            adb.EnableRaisingEvents = true;
            adb.StartInfo.CreateNoWindow = true;
            adb.ErrorDataReceived += new DataReceivedEventHandler(adb_ErrorDataReceived);
            adb.OutputDataReceived += new DataReceivedEventHandler(adb_OutputDataReceived);


            try { var started = adb.Start(); }
            catch (Exception ex)
            {
                this.btnStart.Enabled = true;
                this.toolStripButtonStop.Enabled = false;

                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            adb.BeginErrorReadLine();
            adb.BeginOutputReadLine();

            this.toolStripButtonStop.Enabled = true;
        }

        void adbDevices_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action<object, DataReceivedEventArgs>(adbDevices_OutputDataReceived), sender, e);
            else
            {
                String str = filterData(e.Data);
                if (str.Contains("\tdevice"))
                {
                    this.deviceSelect.Items.Add(str.Replace("\tdevice", "").Replace("\r","").Replace("\n",""));
                }
                outputAdb.AppendText(filterData(e.Data));
            }
        }
        void adb_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action<object, DataReceivedEventArgs>(adb_OutputDataReceived), sender, e);
            else
            {
                if (String.IsNullOrEmpty(e.Data))
                {
                    return;
                }
                string str = e.Data;
                string color = "0x000000";
                if (str.IndexOf(" V ") != -1)
                {
                    color = "0xBBBBBB";
                }
                else if (str.Contains(" D ")) { color = "0x0070BB"; }
                else if (str.Contains(" I ")) { color = "0x48BB31"; }
                else if (str.Contains(" W ")) { color = "0xBBBB23"; }
                else if (str.Contains(" E ")) { color = "0xFF0006"; }
                else if (str.Contains(" A ")) { color = "0x8F0005"; }

                outputAdb.SelectionColor = ColorTranslator.FromHtml(color);
                outputAdb.AppendText(filterData(str));
            }
        }

        void adb_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action<object, DataReceivedEventArgs>(adb_ErrorDataReceived), sender, e);
            else
            {
                outputAdb.SelectionColor = Color.Red; 
                outputAdb.AppendText(filterData(e.Data));
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            outputAdb.Clear();
            //stop(); by jeo
            //clear();
            //start(); by jeo
        }

        string filterData(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return string.Empty;

            if (!string.IsNullOrEmpty(this.txtFilter.Text))
            {
                var pattern = !this.regSelect.Text.Equals("Regex") ? this.txtFilter.Text.Replace("*", ".*")
                    : this.txtFilter.Text;
                System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.Singleline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                if (rx.IsMatch(data))
                    return data.Trim() + Environment.NewLine;
                else
                    return string.Empty;
            }

            return data.Trim() + Environment.NewLine;
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            start();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            stop();
        }

        private void levelSelect_IndexChange(object sender, EventArgs e)
        {
            stop();
            start();

        }
    }
}
