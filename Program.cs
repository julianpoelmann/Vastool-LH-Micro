namespace Pimject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("Pimject is already running", "That's fine. I'll make sure to not interrupt em oki? I'll close with Pimax play anyways UwU");

                //new ToastContentBuilder()
                //    .AddText("Pimject is already running")
                //    .AddText("That's fine. I'll make sure to not interrupt em oki? I'll close with Pimax play anyways UwU")
                //    .Show();

                Application.Exit();
            }
            Application.Run(new LilUI());
        }
    }
}