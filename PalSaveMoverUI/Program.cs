using SaveGameMover;
using System;
using System.Windows.Forms;

namespace SaveGameMoverUI
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0 && args[0] == "v2")
            {
                // Install the application
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SGM2());
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSaver());
        }
    }
}
