using System.Reflection;
using YoutubeAudioDownloader2.Main;

namespace YoutubeAudioDownloader2
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

            using var mutex = new Mutex(false, Application.ProductName + "_" + Assembly.GetExecutingAssembly().GetType().GUID);

            if (mutex.WaitOne(0, false))
            {
                Application.Run(new MainForm());
            }
            else
            {
                var text = "Non sono consentite istanze multiple, al momento.";

                MessageBox.Show(text, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}