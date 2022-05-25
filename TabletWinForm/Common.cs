using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JsGridControl;

namespace TabletWinForm
{
    class Common
    {
        public static string TabletName = ConfigurationManager.AppSettings["TabletNumber"];
        public static int WarehouseNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WarehouseNumber"]);
        //public static string[] previewWindow = new string[] { "", "", "", "" };
        public static List<string> previewWindow = new List<string>();

        public static void SetGrid(JsGridControl.JsGridControl GridControl)
        {
            GridControl.SetAllAlign("mid", "mid");
            GridControl.JsGrid.AutoSizeCols();
            GridControl.JsGrid.AutoSizeRows();
            GridControl.GridAutoSize();
        }

        public static void SubWindowButton(XtraForm window, string controlName)
        {
            Control panel = window.Controls.Find("panelControl5", true).FirstOrDefault();
            
            bool returnCheck = false;

            foreach (var item in panel.Controls.OfType<XtraForm>())
            {
                if (item.Name.ToLower() == controlName)
                {
                    previewWindow.RemoveAt(previewWindow.IndexOf(controlName));
                    previewWindow.Add(controlName);
                    item.Visible = true;
                    returnCheck = true;
                }
                else
                {
                    item.Visible = false;
                }
            }

            if (returnCheck == true) return;

            if (controlName == "searchform")
            {
                SearchForm searchWindow = new SearchForm();
                searchWindow.MdiParent = window;
                panel.Controls.Add(searchWindow);
                searchWindow.WindowState = FormWindowState.Maximized;
                searchWindow.Show();

                previewWindow.Add(searchWindow.Name.ToLower());
            }
            else if (controlName == "warehousingform")
            {
                WarehousingForm warehousingWindow = new WarehousingForm();
                warehousingWindow.MdiParent = window;
                panel.Controls.Add(warehousingWindow);
                warehousingWindow.WindowState = FormWindowState.Maximized;
                warehousingWindow.Show();

                previewWindow.Add(warehousingWindow.Name.ToLower());
            }
            else if (controlName == "releaseform")
            {
                ReleaseForm releaseWindow = new ReleaseForm();
                releaseWindow.MdiParent = window;
                panel.Controls.Add(releaseWindow);
                releaseWindow.WindowState = FormWindowState.Maximized;
                releaseWindow.Show();

                previewWindow.Add(releaseWindow.Name.ToLower());
            }
            else if (controlName == "returnform")
            {
                ReturnForm returnWindow = new ReturnForm();
                returnWindow.MdiParent = window;
                panel.Controls.Add(returnWindow);
                returnWindow.WindowState = FormWindowState.Maximized;
                returnWindow.Show();

                previewWindow.Add(returnWindow.Name.ToLower());
            }
        }

        public static string GetWarehousingNumber()
        {
            string returnString = null;

            returnString = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");

            return returnString;
        }

        public static void ShowMessageBox(string message)
        {
            MessageBoxForm messageWindow = new MessageBoxForm(message);
            messageWindow.ShowDialog();
        }
    }
}
