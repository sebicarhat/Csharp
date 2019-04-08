using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Planete
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var form = new Autentificare();
            //form.Show();
            Application.Run(new Operatii("Administrator"));
        }
    }
}
