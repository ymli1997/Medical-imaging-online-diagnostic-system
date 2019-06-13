using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudDiagnosis
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ///
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin login = new FormLogin();
            login.ShowDialog();
            if (login.DialogResult.Equals(DialogResult.OK))
            {
                login.Close();
                Application.Run(new FormMain());
            }
            //Application.Run(new FormMain());
        }
    }
}
