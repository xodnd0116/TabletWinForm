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

namespace TabletWinForm
{
    public partial class MessageBoxForm : DevExpress.XtraEditors.XtraForm
    {
        public MessageBoxForm(string message, XtraForm form = null)
        {
            InitializeComponent();

            MessageLabel.Text = message;

            if (form?.Name == "ParentForm")
            {
                CloseBtn.Text = "취소";
                ApplyBtn.Visible = true;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void MessageLabel_Click(object sender, EventArgs e)
        {
            CloseBtn_Click(sender, e);
        }
    }
}