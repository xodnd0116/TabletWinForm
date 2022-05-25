using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TabletWinForm
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] proc = null;
            string currentProc = Process.GetCurrentProcess().ProcessName.ToUpper();
            proc = Process.GetProcessesByName(currentProc);
            if(proc.Length > 1)
            {
                MessageBox.Show($"{currentProc} 이 이미 실행중입니다.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }

        
    }
}
