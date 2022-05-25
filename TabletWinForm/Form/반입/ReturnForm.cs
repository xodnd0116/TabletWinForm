using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
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
    public partial class ReturnForm : DevExpress.XtraEditors.XtraForm
    {
        bool checkShift { get; set; }
        int limitCount { get; set; }
        public ReturnForm()
        {
            InitializeComponent();

            checkShift = false;
            limitCount = 0;
            ProductText.Focus();
        }

        private void ReturnForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(AmountText.ContainsFocus == true)
                {
                    LotText.Focus();
                    return;
                }
                if(LotText.ContainsFocus == true)
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
                DataBind(ref reader, $"select item_info.당사품명, inv_info.거래처코드, vendor_info.거래처명 from inv_info join item_info on inv_info.당사품명코드=item_info.당사품명코드 join vendor_info " +
                    $"on vendor_info.거래처코드=inv_info.거래처코드 where inv_info.당사품명코드='{ProductText.Text}'");

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
                string manufactureCode = FindStr("code_master", "코드키", "코드명_한글='생산1'");

                DataSet ds = new DataSet();
                DataSetBind(ds, $"select 현재고량 from inv_info where 당사품명코드='{productCode}' and 보관위치='{manufactureCode}'");
                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    limitCount += Convert.ToInt32(dt.Rows[i]["현재고량"]);
                }

                dt.Reset();
                
                DataSetBind(ds, $"SELECT 그룹,보관위치 FROM sector_info WHERE 그룹 IN(SELECT 그룹 FROM item_info WHERE 당사품명코드 = '{productCode}') AND " +
                    $"보관위치 NOT IN(SELECT 보관위치 FROM inv_info WHERE 장소 = '{position}' AND 현재고량 > 0 AND 당사품명코드 = '{productCode}') ORDER BY 중요도 ASC");

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
                        button.Click += SelectTable_Click;

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

        private void InsertData(object obj)
        {
            DataSet ds = new DataSet();

            string manufactureCode = FindStr("code_master", "코드키", "코드명_한글='생산1'");
            string warehouseCode = FindStr("code_master", "코드키", $"코드명_한글='제{Common.WarehouseNumber}창고'");
            int amount = Convert.ToInt32(obj);

            Add_Field("inout_info", "번호|바코드|구분|타입|상위번호|거래처코드|당사품명코드|일자|수량|LOT|장소|보관위치|등록자", $"{Common.GetWarehousingNumber()}|{ProductText.Text}|A|RU||" +
                $"{VendorText.Text}|{ProductText.Text}|{DateTime.Now.ToString("yyyy-MM-dd")}|{amount}|{LotText.Text}|{manufactureCode}|{manufactureCode}|{Common.TabletName}^{Common.GetWarehousingNumber()}|" +
                $"{ProductText.Text}|A|RT||{VendorText.Text}|{ProductText.Text}|{DateTime.Now.ToString("yyyy-MM-dd")}|{amount}|{LotText.Text}|{warehouseCode}|{ShowSelectLabel.Text}|" +
                $"{Common.TabletName}", true);

            Query_String($"update inv_info set 현재고량=현재고량-{amount}, 반품수량=반품수량+{amount}, 수정자='{Common.TabletName}' where 보관위치='{manufactureCode}' and 당사품명코드='{ProductText.Text}'");

            DataSetBind(ds, $"select * from inv_info where 보관위치='{ShowSelectLabel.Text}' and 당사품명코드='{ProductText.Text}'");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                Query_String($"update inv_info set 현재고량=현재고량+{amount}, 반입수량=반입수량+{amount}, 수정자='{Common.TabletName}' where 보관위치='{ShowSelectLabel.Text}' and 당사품명코드='{ProductText.Text}'");
            }
            else
            {
                string group = FindStr("item_info", "그룹", $"당사품명코드='{ProductText.Text}'");
                Add_Field("inv_info", "거래처코드|구분|그룹|당사품명코드|반입수량|현재고량|장소|보관위치|기준년월|등록자", $"{VendorText.Text}|A|{group}|{ProductText.Text}|{amount}|{amount}|{warehouseCode}|" +
                    $"{ShowSelectLabel.Text}|{DateTime.Now.ToString("yyyy-MM-dd")}|{Common.TabletName}", true);
            }

            ResetUI();
        }

        public void Apply_Click()
        {
            if (ShowSelectLabel.Text == "")
            {
                Common.ShowMessageBox("위치를 선택해주세요.");
                return;
            }

            if (AmountText.Text == "")
            {
                Common.ShowMessageBox("반입 수량을 입력해주세요.");
                AmountText.Focus();
                AmountText.SelectAll();
                return;
            }
            else if(int.TryParse(AmountText.Text, out int count) == false)
            {
                Common.ShowMessageBox("숫자를 입력해주세요.");
                AmountText.Focus();
                AmountText.SelectAll();
                return;
            }
            else if(limitCount < Convert.ToInt32(AmountText.Text))
            {
                Common.ShowMessageBox($"입력한 숫자가 현재고량({limitCount}) 보다 많습니다.");
                AmountText.Focus();
                AmountText.SelectAll();
                return;
            }

            CarryForm carryWindow = new CarryForm(ShowSelectLabel.Text, AmountText.Text);
            carryWindow.FormSendEvent += new CarryForm.FormSendDataHandle(InsertData);
            carryWindow.ShowDialog();
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

        private void ReturnForm_VisibleChanged(object sender, EventArgs e)
        {
            if (((XtraForm)sender).Visible == true)
            {
                if (ShowSelectLabel.Text != "")
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