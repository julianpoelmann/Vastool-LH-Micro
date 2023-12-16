namespace Pimject
{
    partial class LilUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            StatusLabel = new Label();
            Title = new Label();
            DetectTimer = new System.Windows.Forms.Timer(components);
            WaitForExitTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = VastoolLHMicro.Properties.Resources._535387178696572931;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(126, 126);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // StatusLabel
            // 
            StatusLabel.Dock = DockStyle.Bottom;
            StatusLabel.Font = new Font("NSimSun", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            StatusLabel.Location = new Point(0, 130);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(150, 20);
            StatusLabel.TabIndex = 1;
            StatusLabel.Text = "Status goes here";
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Title
            // 
            Title.Dock = DockStyle.Top;
            Title.Font = new Font("NSimSun", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Title.Location = new Point(0, 0);
            Title.Name = "Title";
            Title.Size = new Size(150, 20);
            Title.TabIndex = 2;
            Title.Text = "Vastool LH Micro";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DetectTimer
            // 
            DetectTimer.Interval = 2000;
            DetectTimer.Tick += DetectTimer_Tick;
            // 
            // WaitForExitTimer
            // 
            WaitForExitTimer.Tick += WaitForExitTimer_Tick;
            // 
            // LilUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(150, 150);
            Controls.Add(Title);
            Controls.Add(StatusLabel);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LilUI";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vastool LH Micro";
            TopMost = true;
            TransparencyKey = Color.Black;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label StatusLabel;
        private Label Title;
        private System.Windows.Forms.Timer DetectTimer;
        private System.Windows.Forms.Timer WaitForExitTimer;
    }
}
