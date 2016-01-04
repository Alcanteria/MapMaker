using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace MapMaker
{
    static class Program
    {
        static bool isSplashScreenShowing = true;

        static SplashScreen SPLASH_SCREEN;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show the splash Screen.
            SPLASH_SCREEN = new SplashScreen();
            SPLASH_SCREEN.ShowDialog();

            // Create a timer for the splash screen.
            //System.Timers.Timer splashTimer = new System.Timers.Timer();
            //splashTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //splashTimer.Interval = 3000;
            //splashTimer.Enabled = true;
            

            Application.Run(new mainForm());
        }

    }
}
