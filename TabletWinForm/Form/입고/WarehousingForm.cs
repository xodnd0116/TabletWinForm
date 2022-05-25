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
using MySql.Data.MySqlClient;
using DevExpress.Utils.Layout;
using System.Configuration;
using System.Threading;

namespace TabletWinForm
{
    public partial class WarehousingForm : DevExpress.XtraEditors.XtraForm
    {
        public WarehousingForm()
        {
            InitializeComponent();

            ProductText.Focus();
        }

        private void WarehousingForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(AmountText.ContainsFocus == true)
                {
                    LotText.Focus();
                    return;
                }
                else if(LotText.ContainsFocus == true)
                {
                    ShowSelectLabel.Focus();
                    return;
                }

                ResetUI();
                string[] subString = ProductText.Text.Split('^');

                if (subString.Length < 4)
                {
                    ProductText.Text = subString[0];
                }
                else
                {
                    ProductText.Text = subString[0];
                    VendorText.Text = subString[1];
                    AmountText.Text = subString[2];
                    LotText.Text = subString[3];
                }

                string productCode = null;
                string productName = null;
                string vendorCode = null;
                string vendorName = null;

                MySqlDataReader reader = null;
                DataBind(ref reader, $"select item_info.당사품명코드, item_info.당사품명, vendor_info.거래처코드, vendor_info.거래처명 from item_info join vendor_info on item_info.구분=vendor_info.거래처구분 " +
                    $"where item_info.당사품명코드='{ProductText.Text}'");

                if (RecordCount != 0)
                {
                    reader.Read();
                    
                    productCode = subString[0];
                    productName = reader["당사품명"].ToString();
                    vendorCode = reader["거래처코드"].ToString();
                    vendorName = reader["거래처명"].ToString();

                    ProductNameText.Text = productName;
                    VendorText.Text = vendorCode;
                    VendorNameText.Text = vendorName;
                }
                else
                {
                    Common.ShowMessageBox("해당 품명 재고가 존재하지 않습니다.");
                    ResetUI();
                    ReaderDispose(ref reader);
                    return;
                }

                ReaderDispose(ref reader);

                string position = FindStr("code_master", "코드키", $"코드명_한글='제{Common.WarehouseNumber}창고'");

                DataSet ds = new DataSet();
                DataSetBind(ds, $"SELECT 그룹,보관위치 FROM sector_info WHERE 그룹 IN(SELECT 그룹 FROM item_info WHERE 당사품명코드 = '{productCode}') AND " +
                    $"보관위치 NOT IN(SELECT 보관위치 FROM inv_info WHERE 장소 = '{position}' AND 현재고량 > 0 AND 당사품명코드 = '{productCode}') ORDER BY 중요도 ASC");
                DataTable dt = ds.Tables[0];

                Array.Clear(subString, 0, subString.Length);

                int col = 1;
                int row = 0;

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        subString = dt.Rows[i]["보관위치"].ToString().Split('-');
                        Control label = RackSelectPanel.Controls.Find($"RackLabel{i + 1}", true).FirstOrDefault();
                        label.Text = subString[0];
                        SimpleButton button = new SimpleButton();
                        RackSelectPanel.Controls.Add(button);
                        RackSelectPanel.SetCell(button, row, col);
                        RackSelectPanel.SetRowSpan(button, 1);
                        RackSelectPanel.SetColumnSpan(button, 1);
                        button.Font = new Font("tahoma", 25);
                        button.Text = dt.Rows[i]["보관위치"].ToString();
                        button.Dock = DockStyle.Fill;
                        button.Click += new EventHandler(SelectTable_Click);

                        if (i == 4)
                        {
                            row = 0;
                            col = 3;
                        }
                        else if (i == 9)
                        {
                            row = 5;
                            col = 1;
                        }
                        else if (i == 14)
                        {
                            row = 5;
                            col = 1;
                        }
                        else
                        {
                            row++;
                        }
                    }
                    ProductText.SelectAll();
                }
                else
                {
                    Common.ShowMessageBox("해당 품명 재고가 존재하지 않습니다.");
                    ResetUI();
                }

                return;
            }
        }

        private void SelectTable_Click(object sender, EventArgs e)
        {
            ShowSelectLabel.Text = ((SimpleButton)sender).Text;
            this.ParentForm.Controls["tableLayoutPanel1"].Controls["panelControl1"].Controls["ApplyPicture"].Visible = true;
        }

        private void InsertData(object count)
        {
            DataSet ds = new DataSet();
            DataSetBind(ds, $"select * from code_master where 코드명_한글='제{Common.WarehouseNumber}창고'");
            DataTable dt = ds.Tables[0];

            int amount = Convert.ToInt32(count);

            string[] productCode = ProductText.Text.Split(' ');
            string[] vendorCode = VendorText.Text.Split(' ');

            Add_Field("inout_info", "번호|바코드|구분|거래처코드|당사품명코드|일자|수량|LOT|장소|보관위치|등록자", $"{Common.GetWarehousingNumber()}|{productCode[0]}|W|{vendorCode[0]}|" +
                    $"{productCode[0]}|{DateTime.Now.ToString("yyyy-MM-dd")}|{amount}|{LotText.Text}|{dt.Rows[0]["코드키"]}|{ShowSelectLabel.Text}|{Common.TabletName}", true);

            DataSetBind(ds, $"select * from inv_info where 보관위치='{ShowSelectLabel.Text}'");
            dt = ds.Tables[0];

            if (dt.Rows.Count > 1)
            {
                Update_Field("inv_info", "가입고수량|수정자", $"{amount}|{Common.TabletName}", $"보관위치='{ShowSelectLabel.Text}'", true);
            }
            else
            {
                string group = FindStr("item_info", "그룹", $"당사품명코드='{productCode[0]}'");
                Add_Field("inv_info", "거래처코드|그룹|당사품명코드|가입고수량|장소|보관위치|기준년월|등록자", $"{vendorCode[0]}|{group}|{productCode[0]}|{amount}|{dt.Rows[0]["코드키"]}|" +
                    $"{ShowSelectLabel.Text}|{DateTime.Now.ToString("yyyy-MM-dd")}|{Common.TabletName}", true);
            }
            
            ResetUI();
        }

        public void Apply_Click()
        {
            if(ShowSelectLabel.Text == "")
            {
                Common.ShowMessageBox("위치를 선택해주세요.");
                return;
            }

            if(AmountText.Text == "")
            {
                Common.ShowMessageBox("수량을 입력해주세요.");
                AmountText.Focus();
                AmountText.SelectAll();
                return;
            }
            else if(int.TryParse(AmountText.Text, out int amount) == false)
            {
                Common.ShowMessageBox("숫자를 입력해주세요.");
                AmountText.Focus();
                AmountText.SelectAll();
                return;
            }
            
            LoadingForm loadingWindow = new LoadingForm(ShowSelectLabel.Text, AmountText.Text);
            loadingWindow.FormSendEvent += new LoadingForm.FormSendDataHandle(InsertData);
            loadingWindow.ShowDialog();
            ProductText.Focus();
        }

        private void ResetUI()
        {
            int count = RackSelectPanel.Controls.OfType<SimpleButton>().Count();
            for (int i = 0; i < count; i++)
            {
                RackSelectPanel.Controls.Remove(RackSelectPanel.Controls.OfType<SimpleButton>().FirstOrDefault());
            }

            foreach (var item in RackSelectPanel.Controls.OfType<LabelControl>())
            {
                item.Text = null;
            }

            ProductText.Focus();
            ProductText.SelectAll();
            VendorText.Text = null;
            AmountText.Text = null;
            LotText.Text = null;
            ShowSelectLabel.Text = null;
            ProductNameText.Text = null;
            VendorNameText.Text = null;

            this.ParentForm.Controls["tableLayoutPanel1"].Controls["panelControl1"].Controls["ApplyPicture"].Visible = false;
        }

        private void WarehousingForm_VisibleChanged(object sender, EventArgs e)
        {
            if (((XtraForm)sender).Visible == true)
            {
                if(ShowSelectLabel.Text != "")
                {
                    this.ParentForm.Controls["tableLayoutPanel1"].Controls["panelControl1"].Controls["ApplyPicture"].Visible = true;
                }
                else
                {
                    this.ParentForm.Controls["tableLayoutPanel1"].Controls["panelControl1"].Controls["ApplyPicture"].Visible = false;
                }

                ProductText.Focus();
            }
        }
    }
}