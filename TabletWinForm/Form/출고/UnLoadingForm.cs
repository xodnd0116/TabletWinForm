using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static JsSQL.db;

namespace TabletWinForm
{
    public partial class UnLoadingForm : DevExpress.XtraEditors.XtraForm
    {
        Color FormColor { get; set; }
        int limitCnt { get; set; }
        System.Timers.Timer timer;
        public delegate void FormSendDataHandle(object obj, object obj2);
        public event FormSendDataHandle FormSendEvent;

        public UnLoadingForm(string rack, string limitCount)
        {
            InitializeComponent();

            FormColor = this.BackColor;
            SelectRackText.Text = rack;
            limitCnt = Convert.ToInt32(limitCount);
            ScanRackText.Focus();

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;

            DataToOBJ(ManufactureCodeCombo.Properties, "select 코드키 from code_master where 그룹명='생산라인' order by 코드명_한글 asc", "코드키");
            ManufactureCodeCombo.SelectedIndex = 0;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            BeginInvoke(new Action(delegate
            {
                if (BackColor == FormColor)
                {
                    BackColor = Color.Red;
                }
                else
                {
                    BackColor = FormColor;
                }
            }));
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            timer.Dispose();
            this.Dispose();
        }

        private void UnLoadingForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyBtn_Click(sender, e);
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            if (ScanRackText.Text.ToLower() != SelectRackText.Text.ToLower())
            {
                BackColor = Color.Red;
                ScanRackText.Focus();
                ScanRackText.SelectAll();
                timer.Start();
                return;
            }
            else if(ScanRackText.Text.ToLower() == SelectRackText.Text.ToLower() && ScanRackText.ContainsFocus == true)
            {
                BackColor = FormColor;
                timer.Stop();
                ReleaseCountText.Enabled = true;
                ReleaseCountText.Focus();
                return;
            }

            ReleaseCountText.Focus();
            if (ReleaseCountText.Text == "")
            {
                Common.ShowMessageBox("출고 수량을 입력해주세요.");
                ReleaseCountText.Focus();
                ReleaseCountText.SelectAll();
                return;
            }
            else if (ReleaseCountText.ContainsFocus == true && int.TryParse(ReleaseCountText.Text, out int b) == false)
            {
                Common.ShowMessageBox("출고 수량 칸에 숫자를 입력해주세요.");
                ReleaseCountText.Focus();
                ReleaseCountText.SelectAll();
                return;
            }
            else if(ReleaseCountText.ContainsFocus == true && limitCnt < Convert.ToInt32(ReleaseCountText.Text))
            {
                Common.ShowMessageBox($"출고 수량이 현재고량({limitCnt}) 보다 많습니다.");
                ReleaseCountText.Focus();
                ReleaseCountText.SelectAll();
                return;
            }

            FormSendEvent(ReleaseCountText.Text, ManufactureCodeCombo.Text);
            timer.Dispose();
            this.Dispose();
        }
    }
}