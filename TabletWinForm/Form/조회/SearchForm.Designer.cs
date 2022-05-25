
namespace TabletWinForm
{
    partial class SearchForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GridControl = new JsGridControl.JsGridControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.SearchBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SearchText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ConditionCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionCombo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.groupControl1);
            this.tablePanel1.Controls.Add(this.tablePanel2);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 90F)});
            this.tablePanel1.Size = new System.Drawing.Size(1171, 669);
            this.tablePanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AlwaysScrollActiveControlIntoView = false;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 20F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.groupControl1, 0);
            this.groupControl1.Controls.Add(this.GridControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 70);
            this.groupControl1.Name = "groupControl1";
            this.tablePanel1.SetRow(this.groupControl1, 1);
            this.groupControl1.Size = new System.Drawing.Size(1165, 596);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "현재고현황";
            // 
            // GridControl
            // 
            this.GridControl.BackColor = System.Drawing.Color.Transparent;
            this.GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl.Font = new System.Drawing.Font("맑은 고딕", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GridControl.Location = new System.Drawing.Point(2, 40);
            this.GridControl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(1161, 554);
            this.GridControl.TabIndex = 3;
            this.GridControl.ToolBox = false;
            // 
            // tablePanel2
            // 
            this.tablePanel1.SetColumn(this.tablePanel2, 0);
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 80F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 15F)});
            this.tablePanel2.Controls.Add(this.SearchBtn);
            this.tablePanel2.Controls.Add(this.SearchText);
            this.tablePanel2.Controls.Add(this.labelControl2);
            this.tablePanel2.Controls.Add(this.ConditionCombo);
            this.tablePanel2.Controls.Add(this.labelControl1);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(3, 3);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel1.SetRow(this.tablePanel2, 0);
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(1165, 61);
            this.tablePanel2.TabIndex = 1;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.SearchBtn.Appearance.Options.UseFont = true;
            this.tablePanel2.SetColumn(this.SearchBtn, 4);
            this.SearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.SearchBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SearchBtn.ImageOptions.SvgImage")));
            this.SearchBtn.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.SearchBtn.Location = new System.Drawing.Point(1068, 3);
            this.SearchBtn.Name = "SearchBtn";
            this.tablePanel2.SetRow(this.SearchBtn, 0);
            this.SearchBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.SearchBtn.Size = new System.Drawing.Size(94, 55);
            this.SearchBtn.TabIndex = 6;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Text = "검색";
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchText
            // 
            this.tablePanel2.SetColumn(this.SearchText, 3);
            this.SearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchText.Location = new System.Drawing.Point(536, 3);
            this.SearchText.Name = "SearchText";
            this.SearchText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.SearchText.Properties.Appearance.Options.UseFont = true;
            this.SearchText.Properties.Appearance.Options.UseTextOptions = true;
            this.SearchText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel2.SetRow(this.SearchText, 0);
            this.SearchText.Size = new System.Drawing.Size(527, 55);
            this.SearchText.TabIndex = 3;
            this.SearchText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchText_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel2.SetColumn(this.labelControl2, 2);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(369, 3);
            this.labelControl2.Name = "labelControl2";
            this.tablePanel2.SetRow(this.labelControl2, 0);
            this.labelControl2.Size = new System.Drawing.Size(160, 55);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "검색내용";
            // 
            // ConditionCombo
            // 
            this.tablePanel2.SetColumn(this.ConditionCombo, 1);
            this.ConditionCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionCombo.Location = new System.Drawing.Point(169, 3);
            this.ConditionCombo.Name = "ConditionCombo";
            this.ConditionCombo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.ConditionCombo.Properties.Appearance.Options.UseFont = true;
            this.ConditionCombo.Properties.Appearance.Options.UseTextOptions = true;
            this.ConditionCombo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ConditionCombo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 20F);
            this.ConditionCombo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ConditionCombo.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.ConditionCombo.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ConditionCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ConditionCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tablePanel2.SetRow(this.ConditionCombo, 0);
            this.ConditionCombo.Size = new System.Drawing.Size(194, 55);
            this.ConditionCombo.TabIndex = 1;
            this.ConditionCombo.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel2.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel2.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(160, 55);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "검색조건";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 669);
            this.ControlBox = false;
            this.Controls.Add(this.tablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.Text = "SearchForm";
            this.VisibleChanged += new System.EventHandler(this.SearchForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConditionCombo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.ComboBoxEdit ConditionCombo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton SearchBtn;
        private DevExpress.XtraEditors.TextEdit SearchText;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal JsGridControl.JsGridControl GridControl;
    }
}