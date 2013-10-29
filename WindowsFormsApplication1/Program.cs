using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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
            Form1 f = new Form1();
            f.GodModeEntered += f_GodModeEntered;
            Application.Run(f);
        }

        static void f_GodModeEntered(object sender, EventArgs e)
        {
            Console.WriteLine("God mode!!");
        }
    }
}
