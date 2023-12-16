using System.Diagnostics;
using System.Net;
using Transitions;

namespace Pimject
{
    public partial class LilUI : Form
    {
        bool BsRunning = false;
        bool Busy = false;

        string LHSysPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\lighthouse.exe";
        public LilUI()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.StatusLabel.Text = "Hai hai";

            Application.DoEvents();

            MicroCheckAsync();
        }

        private void RefreshUi()
        {
            Application.DoEvents();
            this.Invalidate();
            this.Update();
            this.Refresh();
        }

        private async void FadeIn()
        {
            await Task.Run(() => Transition.run(this, "Opacity", 1.0, new TransitionType_EaseInEaseOut(1000)));
        }

        private async void FadeOut()
        {
            await Task.Run(() => Transition.run(this, "Opacity", 0.0, new TransitionType_EaseInEaseOut(250)));
        }

        private async Task DownloadLilFileAsync()
        {
            try
            {
                using var client = new WebClient();
                await Task.Run(() => client.DownloadFile("https://github.com/julianpoelmann/VasTool/raw/main/lighthouse.exe", "lighthouse.exe"));
                FadeOut();
            }
            catch
            {
                MessageBox.Show("Either your internet connection dropped or i dont have permission to place a file here", "Vastool LH Micro download error");

                File.Delete(LHSysPath);
            }
        }

        private void MicroCheckAsync()
        {
            if (File.Exists(LHSysPath) == true)
            {
                DetectTimer.Enabled = true;
            }
            else
            {
                FadeIn();

                this.StatusLabel.Text = "Downloading LH Man";

                RefreshUi();

                DownloadLilFileAsync();

                MessageBox.Show("You can find this around " + LHSysPath, "Lighthouse Manager by SHayBox");

                //new ToastContentBuilder()
                //.AddText("Lighthouse Manager by SHayBox")
                //.AddText("You can find this around " + LHSysPath)
                //.Show();

                MicroCheckAsync();
            }

        }

        private void StartBasestation()
        {
            Busy = true;

            WaitForExitTimer.Enabled = true;

            if (Process.GetProcessesByName("lighthouse").Length > 0)
            {
                this.StatusLabel.Text = "Conflict, Retry";
                Busy = false;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = LHSysPath;
                process.StartInfo.Arguments = "-s On";
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            }
        }

        private void StopBasestation()
        {
            Busy = true;

            WaitForExitTimer.Enabled = true;

            if (Process.GetProcessesByName("lighthouse").Length > 0)
            {
                this.StatusLabel.Text = "Conflict, Retry";
                Busy = false;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = LHSysPath;
                process.StartInfo.Arguments = "-s Off";
                process.StartInfo.CreateNoWindow = true;
                process.Start();
            }
        }

        private void DetectTimer_Tick(object sender, EventArgs e)
        {
            if (Busy == false)
            {
                if (Process.GetProcessesByName("PimaxClient").Length > 0)
                {
                    if (BsRunning == false)
                    {
                        if (this.Opacity == 0)
                        {
                            FadeIn();
                        }
                        this.StatusLabel.Text = "BS Starting";
                        StartBasestation();
                    }
                }
                else
                {
                    this.StatusLabel.Text = "Client Stopped";

                    if (BsRunning == true)
                    {
                        if (this.Opacity == 0)
                        {
                            FadeIn();
                        }
                        this.StatusLabel.Text = "BS Stopping";
                        StopBasestation();
                    }
                }
            }
        }

        private void WaitForExitTimer_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("lighthouse").Length > 0)
            {
                
            }
            else
            {
                if (BsRunning == false)
                {
                    BsRunning = true;
                    this.StatusLabel.Text = "BS Started!";
                }
                else
                {
                    BsRunning = false;
                    this.StatusLabel.Text = "BS Stopped!";
                }
                RefreshUi();
                FadeOut();
                Busy = false;
                WaitForExitTimer.Enabled = false;
            }
        }
    }
}
