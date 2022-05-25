using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JsSQL.db;

namespace TabletWinForm
{
    public partial class LoadingForm : DevExpress.XtraEditors.XtraForm
    {
        Color FormColor { get; set; }
        System.Timers.Timer timer;
        public delegate void FormSendDataHandle(object sender);
        public event FormSendDataHandle FormSendEvent;

        public LoadingForm(string rack, string inputCount)
        {
            InitializeComponent();

            FormColor = this.BackColor;
            SelectRackText.Text = rack;
            ScanRackText.Focus();

            AmountText.Text = inputCount;

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new Action(delegate
            {
                if(BackColor == FormColor)
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

        private void LoadingForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
            else
            {
                BackColor = FormColor;
                timer.Stop();
            }

            FormSendEvent(Convert.ToInt32(AmountText.Text));
            timer.Dispose();
            this.Dispose();
        }
    }
}