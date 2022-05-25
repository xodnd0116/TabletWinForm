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
using JsGridControl;
using System.Windows.Controls;

namespace TabletWinForm
{
    public partial class SearchForm : DevExpress.XtraEditors.XtraForm
    {
        public string[] ConditionList = new string[] { "당사품명코드", "당사품명", "거래처코드", "거래처명", "장소", "보관위치"};
        
        //public Form previewWindow { get; set; }
        public SearchForm()
        {
            InitializeComponent();

            ConditionCombo.Properties.Items.AddRange(ConditionList);

            ConditionCombo.SelectedIndex = 0;

            GridControl.JsGrid.AllowEditing = false;
            GridControl.JsGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            
            SearchText.Focus();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            GridControl.WaitOn();

            string table = null;

            if(ConditionCombo.Text == "당사품명")
            {
                table = "item_info";
            }
            else
            {
                table = "inv_info";
            }

            GridControl.ResetGridTotal(GridControl.JsGrid);
            GridBind(GridControl.JsGrid, $"select inv_info.id,inv_info.당사품명코드,item_info.당사품명,inv_info.보관위치,inv_info.현재고량,inv_info.기준년월 from inv_info join item_info " +
                $"on inv_info.당사품명코드=item_info.당사품명코드 join code_master on code_master.코드키=inv_info.장소 where {table}.{ConditionCombo.Text} like '%{SearchText.Text}%' and code_master.그룹명='창고구분'");
            GridControl.JsGrid.Font = new Font("맑은 고딕", 20);
            Common.SetGrid(GridControl);
            GridControl.ShowTotals(GridControl.JsGrid, 0, 2, 2, 5, 4, "Total");
            GridControl.JsGrid.Cols[0].Width = 72;
            GridControl.JsGrid.ScrollBars = ScrollBars.Vertical;

            GridControl.WaitOff();

            SearchText.Focus();
            SearchText.SelectAll();
        }

        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SearchBtn_Click(sender, e);
            }
        }

        private void SearchForm_VisibleChanged(object sender, EventArgs e)
        {
            if (((XtraForm)sender).Visible == true)
            {
                SearchText.Focus();
                SearchText.SelectAll();
            }
        }
    }
}