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
using System.Text.RegularExpressions;

namespace TabletWinForm
{
    public partial class ReleaseForm : DevExpress.XtraEditors.XtraForm
    {
        string[] conditionArray = new string[] { "당사품명코드", "당사품명" };
        public ReleaseForm()
        {
            InitializeComponent();

            SearchConditionCombo.Properties.Items.AddRange(conditionArray);
            SearchConditionCombo.SelectedIndex = 0;
            SearchContentText.Focus();
        }


        private void ReleaseForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(LotText.ContainsFocus == true)
                {
                    ShowSelectLabel.Focus();
                    return;
                }

                ResetUI();
                string[] subString = SearchContentText.Text.Split('^');

                if (subString.Length < 4)
                {
                    ProductCode.Text = subString[0];
                }
                else
                {
                    ProductCode.Text = subString[0];
                    VendorCodeText.Text = subString[1];
                    LotText.Text = subString[3];
                }

                string productCode = null;
                string productName = null;
                string vendorCode = null;
                string vendorName = null;

                MySqlDataReader reader = null;
                DataBind(ref reader, $"select item_info.당사품명, inv_info.거래처코드, vendor_info.거래처명 from inv_info join item_info on inv_info.당사품명코드=item_info.당사품명코드 join vendor_info " +
                    $"on vendor_info.거래처코드=inv_info.거래처코드 where inv_info.당사품명코드='{ProductCode.Text}'");

                if (RecordCount != 0)
                {
                    reader.Read();

                    productCode = subString[0];
                    productName = reader["당사품명"].ToString();
                    vendorCode = reader["거래처코드"].ToString();
                    vendorName = reader["거래처명"].ToString();

                    ProductNameText.Text = productName;
                    VendorCodeText.Text = vendorCode;
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

                SearchContentText.Text = productCode;
                DataSet ds = new DataSet();
                DataSetBind(ds, "select vendor_info.거래처코드, vendor_info.거래처명, item_info.당사품명코드, item_info.당사품명, inv_info.현재고량, item_info.포장단위, inv_info.보관위치 from inv_info " +
                    "join vendor_info on vendor_info.거래처코드=inv_info.거래처코드 join item_info on item_info.당사품명코드=inv_info.당사품명코드 join code_master on code_master.코드키=inv_info.장소 " +
                    $"where item_info.사용여부='Y' and vendor_info.사용여부='Y' and inv_info.당사품명코드='{productCode}' and inv_info.현재고량 > 0 and code_master.그룹명='창고구분' order by inv_info.등록일자 asc", true);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    int totalCount = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalCount += Convert.ToInt32(dt.Rows[i]["현재고량"]);
                    }
                    string packing = FindStr("code_master", "코드명_한글", $"코드키='{dt.Rows[0]["포장단위"]}'");

                    InventoryText.Text = totalCount.ToString() + " " + packing;

                    int col = 0;
                    int row = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Control label = RackSelectPanel.Controls.Find($"RackLabel{i + 1}", true).FirstOrDefault();
                        label.Text = dt.Rows[i]["현재고량"].ToString();

                        SimpleButton button = new SimpleButton();
                        RackSelectPanel.Controls.Add(button);
                        RackSelectPanel.SetCell(button, row, col);
                        RackSelectPanel.SetRowSpan(button, 1);
                        RackSelectPanel.SetColumnSpan(button, 1);
                        button.Font = new Font("tahoma", 25);
                        button.Text = dt.Rows[i]["보관위치"].ToString();
                        button.Dock = DockStyle.Fill;
                        button.Click += RackButton_Click;

                        if (i == 4)
                        {
                            row = 0;
                            col = 2;
                        }
                        else if (i == 9)
                        {
                            row = 5;
                            col = 0;
                        }
                        else if (i == 14)
                        {
                            row = 5;
                            col = 2;
                        }
                        else
                        {
                            row++;
                        }
                    }

                    SearchContentText.SelectAll();
                }
                else
                {
                    Common.ShowMessageBox("해당 품명 재고가 존재하지 않습니다.");
                    ResetUI();
                }

                return;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            ReleaseForm_KeyUp(sender, new KeyEventArgs(Keys.Enter));
        }

        private void RackButton_Click(object sender, EventArgs e)
        {
            ShowSelectLabel.Text = ((SimpleButton)sender).Text;
            this.ParentForm.Controls["tableLayoutPanel1"].Controls["panelControl1"].Controls["ApplyPicture"].Visible = true;
        }

        private void InsertData(object obj, object obj2)
        {
            DataSet ds = new DataSet();
            DataSetBind(ds, $"select 번호, 보관위치, 타입 from inout_info where 보관위치='{ShowSelectLabel.Text}' and 타입='TM' and 당사품명코드='{ProductCode.Text}' order by 번호 desc limit 1");
            DataTable dt = ds.Tables[0];
            DataSetBind(ds, $"select * from code_master where 코드명_한글='제{Common.WarehouseNumber}창고'");

            int releaseCount = Convert.ToInt32(obj);
            string manufactureCode = Convert.ToString(obj2);

            Add_Field("inout_info", "번호|바코드|구분|타입|상위번호|거래처코드|당사품명코드|일자|수량|LOT|장소|보관위치|등록자", $"{Common.GetWarehousingNumber()}|{ProductCode.Text}|A|IU|{dt.Rows[0]["번호"]}|" +
                $"{VendorCodeText.Text}|{ProductCode.Text}|{DateTime.Now.ToString("yyyy-MM-dd")}|{releaseCount}|{LotText.Text}|{dt.Rows[1]["코드키"]}|{ShowSelectLabel.Text}|{Common.TabletName}^" +
                $"{Common.GetWarehousingNumber()}|{ProductCode.Text}|A|RT|{dt.Rows[0]["번호"].ToString()}|{VendorCodeText.Text}|{ProductCode.Text}|{DateTime.Now.ToString("yyyy-MM-dd")}|{releaseCount}|{LotText.Text}|" +
                $"{manufactureCode}|{manufactureCode}|{Common.TabletName}", true);

            Query_String($"update inv_info set 현재고량=현재고량-{releaseCount}, 출고수량=출고수량+{releaseCount}, 수정자='{Common.TabletName}' where 보관위치='{ShowSelectLabel.Text}' " +
                $"and 당사품명코드='{ProductCode.Text}'");

            DataSetBind(ds, $"select * from inv_info where 당사품명코드='{ProductCode.Text}' and 보관위치='{manufactureCode}'");

            if(dt.Rows.Count > 2)
            {
                Query_String($"update inv_info set 현재고량=현재고량+{releaseCount}, 반입수량=반입수량+{releaseCount}, 수정자='{Common.TabletName}' where 보관위치='{manufactureCode}' " +
                    $"and 당사품명코드='{ProductCode.Text}'");
            }
            else
            {
                string group = FindStr("item_info", "그룹", $"당사품명코드='{ProductCode.Text}'");
                Add_Field("inv_info", "거래처코드|구분|그룹|당사품명코드|반입수량|현재고량|장소|보관위치|기준년월|등록자", $"{VendorCodeText.Text}|A|{group}|{ProductCode.Text}|{releaseCount}|{releaseCount}|" +
                    $"{manufactureCode}|{manufactureCode}|{DateTime.Now.ToString("yyyy-MM-dd")}|{Common.TabletName}");
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

            int row = 0;
            int col = 0;

            foreach (var item in RackSelectPanel.Controls.OfType<SimpleButton>())
            {
                if(item.Text == ShowSelectLabel.Text)
                {
                    row = RackSelectPanel.GetRow(item);
                    col = RackSelectPanel.GetColumn(item);
                }
            }
            
            int number = 0;
            int index = 0;

            if (row > 4)
            {
                index++;
            }
            if (col > 1)
            {
                index++;
            }

            number = (row + (5 * index)) + 1;

            Control label = RackSelectPanel.Controls.Find($"RackLabel{number}", true).FirstOrDefault();
            //string subString = Regex.Replace(label.Text, @"\D", "");

            UnLoadingForm loadingWindow = new UnLoadingForm(ShowSelectLabel.Text, label.Text);
            loadingWindow.FormSendEvent += new UnLoadingForm.FormSendDataHandle(InsertData);
            loadingWindow.ShowDialog();
            SearchContentText.Focus();
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

            SearchContentText.Focus();
            SearchContentText.SelectAll();
            VendorCodeText.Text = null;
            ProductCode.Text = null;
            InventoryText.Text = null;
            LotText.Text = null;
            ShowSelectLabel.Text = null;
            ProductNameText.Text = null;
            VendorNameText.Text = null;

            this.ParentForm.Controls["tableLayoutPanel1"].Controls["panelControl1"].Controls["ApplyPicture"].Visible = false;
        }

        private void ReleaseForm_VisibleChanged(object sender, EventArgs e)
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

                SearchContentText.Focus();
            }
        }
    }
}