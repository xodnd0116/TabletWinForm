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

namespace TabletWinForm
{
    public partial class CarryForm : DevExpress.XtraEditors.XtraForm
    {
        Color FormColor { get; set; }
        System.Timers.Timer timer;
        public delegate void FormSendDataHandle(object obj);
        public event FormSendDataHandle FormSendEvent;
        public CarryForm(string rack, string carryCount)
        {
            InitializeComponent();

            FormColor = this.BackColor;
            SelectRackText.Text = rack;
            ScanRackText.Focus();

            CarryCountText.Text = carryCount;

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
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

        private void CarryForm_KeyUp(object sender, KeyEventArgs e)
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
            else
            {
                BackColor = FormColor;
                timer.Stop();
            }

            FormSendEvent(Convert.ToInt32(CarryCountText.Text));
            timer.Dispose();
            this.Dispose();
        }
    }
}