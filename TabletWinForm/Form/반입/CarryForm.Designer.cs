
namespace TabletWinForm
{
    partial class CarryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarryForm));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.ApplyBtn = new DevExpress.XtraEditors.SimpleButton();
            this.CloseBtn = new DevExpress.XtraEditors.SimpleButton();
            this.ScanRackText = new DevExpress.XtraEditors.TextEdit();
            this.SelectRackText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.CarryCountText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScanRackText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectRackText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarryCountText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 40F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.ApplyBtn);
            this.tablePanel1.Controls.Add(this.CloseBtn);
            this.tablePanel1.Controls.Add(this.ScanRackText);
            this.tablePanel1.Controls.Add(this.SelectRackText);
            this.tablePanel1.Controls.Add(this.labelControl3);
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.labelControl5);
            this.tablePanel1.Controls.Add(this.CarryCountText);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Size = new System.Drawing.Size(1050, 600);
            this.tablePanel1.TabIndex = 3;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBtn.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.ApplyBtn, 1);
            this.ApplyBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplyBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ApplyBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ApplyBtn.ImageOptions.SvgImage")));
            this.ApplyBtn.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.ApplyBtn.Location = new System.Drawing.Point(497, 477);
            this.ApplyBtn.Name = "ApplyBtn";
            this.tablePanel1.SetRow(this.ApplyBtn, 4);
            this.ApplyBtn.Size = new System.Drawing.Size(241, 89);
            this.ApplyBtn.TabIndex = 7;
            this.ApplyBtn.Text = "확인";
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.CloseBtn, 2);
            this.CloseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.CloseBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CloseBtn.ImageOptions.SvgImage")));
            this.CloseBtn.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.CloseBtn.Location = new System.Drawing.Point(744, 477);
            this.CloseBtn.Name = "CloseBtn";
            this.tablePanel1.SetRow(this.CloseBtn, 4);
            this.CloseBtn.Size = new System.Drawing.Size(241, 89);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "취소";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ScanRackText
            // 
            this.tablePanel1.SetColumn(this.ScanRackText, 1);
            this.tablePanel1.SetColumnSpan(this.ScanRackText, 2);
            this.ScanRackText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScanRackText.Location = new System.Drawing.Point(497, 287);
            this.ScanRackText.Name = "ScanRackText";
            this.ScanRackText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ScanRackText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 40F);
            this.ScanRackText.Properties.Appearance.Options.UseBackColor = true;
            this.ScanRackText.Properties.Appearance.Options.UseFont = true;
            this.ScanRackText.Properties.Appearance.Options.UseTextOptions = true;
            this.ScanRackText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel1.SetRow(this.ScanRackText, 2);
            this.ScanRackText.Size = new System.Drawing.Size(488, 89);
            this.ScanRackText.TabIndex = 4;
            // 
            // SelectRackText
            // 
            this.tablePanel1.SetColumn(this.SelectRackText, 1);
            this.tablePanel1.SetColumnSpan(this.SelectRackText, 2);
            this.SelectRackText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectRackText.Location = new System.Drawing.Point(497, 192);
            this.SelectRackText.Name = "SelectRackText";
            this.SelectRackText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 40F);
            this.SelectRackText.Properties.Appearance.Options.UseFont = true;
            this.SelectRackText.Properties.Appearance.Options.UseTextOptions = true;
            this.SelectRackText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SelectRackText.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.SelectRackText, 1);
            this.SelectRackText.Size = new System.Drawing.Size(488, 89);
            this.SelectRackText.TabIndex = 3;
            this.SelectRackText.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel1.SetColumn(this.labelControl3, 0);
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.Location = new System.Drawing.Point(3, 287);
            this.labelControl3.Name = "labelControl3";
            this.tablePanel1.SetRow(this.labelControl3, 2);
            this.labelControl3.Size = new System.Drawing.Size(488, 89);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "불출할 Rack";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel1.SetColumn(this.labelControl2, 0);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(3, 192);
            this.labelControl2.Name = "labelControl2";
            this.tablePanel1.SetRow(this.labelControl2, 1);
            this.labelControl2.Size = new System.Drawing.Size(488, 89);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "현재 선택한 Rack";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.labelControl1, 4);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(1044, 183);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "적재 위치의 바코드를 스캔해주세요.";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel1.SetColumn(this.labelControl5, 0);
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl5.Location = new System.Drawing.Point(3, 382);
            this.labelControl5.Name = "labelControl5";
            this.tablePanel1.SetRow(this.labelControl5, 3);
            this.labelControl5.Size = new System.Drawing.Size(488, 89);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "반입 수량";
            // 
            // CarryCountText
            // 
            this.tablePanel1.SetColumn(this.CarryCountText, 1);
            this.tablePanel1.SetColumnSpan(this.CarryCountText, 2);
            this.CarryCountText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarryCountText.Enabled = false;
            this.CarryCountText.Location = new System.Drawing.Point(497, 382);
            this.CarryCountText.Name = "CarryCountText";
            this.CarryCountText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CarryCountText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 40F);
            this.CarryCountText.Properties.Appearance.Options.UseBackColor = true;
            this.CarryCountText.Properties.Appearance.Options.UseFont = true;
            this.CarryCountText.Properties.Appearance.Options.UseTextOptions = true;
            this.CarryCountText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CarryCountText.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.CarryCountText, 3);
            this.CarryCountText.Size = new System.Drawing.Size(488, 89);
            this.CarryCountText.TabIndex = 4;
            // 
            // CarryForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.tablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CarryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarryForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CarryForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScanRackText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectRackText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarryCountText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.SimpleButton ApplyBtn;
        private DevExpress.XtraEditors.SimpleButton CloseBtn;
        private DevExpress.XtraEditors.TextEdit ScanRackText;
        private DevExpress.XtraEditors.TextEdit SelectRackText;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit CarryCountText;
    }
}