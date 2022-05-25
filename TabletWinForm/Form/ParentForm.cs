using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Media;
using static JsSQL.db;

namespace TabletWinForm
{
    public partial class ParentForm : XtraForm
    {
        System.Timers.Timer timer;
        public ParentForm()
        {
            InitializeComponent();

            UserHost = "211.46.7.109";
            UserPort = "7057";
            Userid = "wms";
            UserPwd = "wms1234";
            UserDatabase = "wms_db";
            SetSQL(2);

            timer = new System.Timers.Timer(10000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (SConn() == true)
            {
                Invoke(new Action(delegate 
                {
                    pictureEdit2.Visible = true;
                    pictureEdit1.Visible = false;
                }));
            }
            else if(SConn() == false)
            {
                Invoke(new Action(delegate
                {
                    pictureEdit1.Visible = true;
                    pictureEdit2.Visible = false;
                }));
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchForm searchWindow = new SearchForm();

            searchWindow.MdiParent = this;
            panelControl5.Controls.Add(searchWindow);
            searchWindow.Show();
            searchWindow.WindowState = FormWindowState.Maximized;

            Common.previewWindow.Add(searchWindow.Name.ToLower());
            SearchTopBtn.Enabled = false;
            SearchLeftBtn.Enabled = false;
        }

        private void WarehousingBtn_Click(object sender, EventArgs e)
        {
            WarehousingForm warehousingWindow = new WarehousingForm();
            
            warehousingWindow.MdiParent = this;
            panelControl5.Controls.Add(warehousingWindow);
            warehousingWindow.Show();
            warehousingWindow.WindowState = FormWindowState.Maximized;

            Common.previewWindow.Add(warehousingWindow.Name.ToLower());
            WarehousingTopBtn.Enabled = false;
            WarehousingLeftBtn.Enabled = false;
        }

        private void ReleaseBtn_Click(object sender, EventArgs e)
        {
            ReleaseForm releaseWindow = new ReleaseForm();
            
            releaseWindow.MdiParent = this;
            panelControl5.Controls.Add(releaseWindow);
            releaseWindow.Show();
            releaseWindow.WindowState = FormWindowState.Maximized;

            Common.previewWindow.Add(releaseWindow.Name.ToLower());
            ReleaseTopBtn.Enabled = false;
            ReleaseLeftBtn.Enabled = false;
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            ReturnForm returnWindow = new ReturnForm();
            
            returnWindow.MdiParent = this;
            panelControl5.Controls.Add(returnWindow);
            returnWindow.Show();
            returnWindow.WindowState = FormWindowState.Maximized;

            Common.previewWindow.Add(returnWindow.Name.ToLower());
            ReturnTopBtn.Enabled = false;
            ReturnLeftBtn.Enabled = false;
        }

        private void SearchTopBtn_Click(object sender, EventArgs e)
        {
            Common.SubWindowButton(this, "searchform");
            
            foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }
            foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }
            
            SearchLeftBtn.Enabled = false;
            SearchTopBtn.Enabled = false;
        }

        private void WarehousingTopBtn_Click(object sender, EventArgs e)
        {
            Common.SubWindowButton(this, "warehousingform");
            
            foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }
            foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }

            WarehousingTopBtn.Enabled = false;
            WarehousingLeftBtn.Enabled = false;
        }

        private void ReleaseTopBtn_Click(object sender, EventArgs e)
        {
            Common.SubWindowButton(this, "releaseform");

            foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }
            foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }

            ReleaseTopBtn.Enabled = false;
            ReleaseLeftBtn.Enabled = false;
        }

        private void ReturnTopBtn_Click(object sender, EventArgs e)
        {
            Common.SubWindowButton(this, "returnform");

            foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }
            foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }

            ReturnTopBtn.Enabled = false;
            ReturnLeftBtn.Enabled = false;
        }

        private void HomePicture_Click(object sender, EventArgs e)
        {
            if (panelControl5.Controls.OfType<XtraForm>().Count() < 1)
            {
                return;
            }

            foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }
            foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
            {
                item.Enabled = true;
            }

            int windowCount = panelControl5.Controls.OfType<XtraForm>().Count();
            for(int i = 0; i < windowCount; i++)
            {
                panelControl5.Controls.OfType<XtraForm>().FirstOrDefault().Dispose();
            }
            foreach (var item in panelControl5.Controls.OfType<SimpleButton>())
            {
                item.Visible = true;
            }

            Common.previewWindow.RemoveRange(0, Common.previewWindow.Count);
        }

        private void BackPicture_Click(object sender, EventArgs e)
        {
            if(panelControl5.Controls.OfType<XtraForm>().Count() < 1)
            {
                return;
            }
            else if(panelControl5.Controls.OfType<XtraForm>().Count() == 1)
            {
                foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
                {
                    item.Enabled = true;
                }
                foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
                {
                    item.Enabled = true;
                }
            }
            else
            {
                foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
                {
                    if(item.Name.ToLower().Contains(Common.previewWindow.Last().Remove(Common.previewWindow.Last().IndexOf("form"))) == true)
                    {
                        item.Enabled = true;
                    }
                }
                foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
                {
                    if (item.Name.ToLower().Contains(Common.previewWindow.Last().Remove(Common.previewWindow.Last().IndexOf("form"))) == true)
                    {
                        item.Enabled = true;
                    }
                }
            }

            XtraForm window = panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true);

            Common.previewWindow.RemoveAt(Common.previewWindow.IndexOf(window.Name.ToLower()));
            window.Dispose();

            foreach (var item in panelControl5.Controls.OfType<XtraForm>())
            {
                if(item.Name.ToLower() == Common.previewWindow.Last())
                {
                    item.Visible = true;
                }
            }

            if (Common.previewWindow.Count > 0)
            {
                foreach (var item in panelControl2.Controls.OfType<SimpleButton>())
                {
                    if (item.Name.ToLower().Contains(Common.previewWindow.Last().Remove(Common.previewWindow.Last().IndexOf("form"))) == true)
                    {
                        item.Enabled = false;
                    }
                }
                foreach (var item in panelControl3.Controls.OfType<SimpleButton>())
                {
                    if (item.Name.ToLower().Contains(Common.previewWindow.Last().Remove(Common.previewWindow.Last().IndexOf("form"))) == true)
                    {
                        item.Enabled = false;
                    }
                }
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MessageBoxForm messageWindow = new MessageBoxForm("프로그램을 종료하시겠습니까?", this);
            var result = messageWindow.ShowDialog();

            if (result == DialogResult.OK)
            {
                Application.Exit();
                timer.Dispose();
            }
        }

        private void ApplyPicture_Click(object sender, EventArgs e)
        {
            if (panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true).Name == "WarehousingForm")
            {
                WarehousingForm warehousingWindow = (WarehousingForm)panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true);
                warehousingWindow.Apply_Click();
            }
            else if(panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true).Name == "ReleaseForm")
            {
                ReleaseForm releaseWindow = (ReleaseForm)panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true);
                releaseWindow.Apply_Click();
            }
            else if(panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true).Name == "ReturnForm")
            {
                ReturnForm returnWindow = (ReturnForm)panelControl5.Controls.OfType<XtraForm>().FirstOrDefault((x) => x.Visible == true);
                returnWindow.Apply_Click();
            }
        }
    }
}
