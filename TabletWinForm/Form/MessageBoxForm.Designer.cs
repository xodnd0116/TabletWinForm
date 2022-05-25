
namespace TabletWinForm
{
    partial class MessageBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxForm));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.CloseBtn = new DevExpress.XtraEditors.SimpleButton();
            this.MessageLabel = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ApplyBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.MessageLabel);
            this.tablePanel1.Controls.Add(this.panelControl4);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 44F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 80F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.tablePanel1.Size = new System.Drawing.Size(720, 450);
            this.tablePanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.ApplyBtn);
            this.panelControl1.Controls.Add(this.CloseBtn);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 372);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 2);
            this.panelControl1.Size = new System.Drawing.Size(714, 75);
            this.panelControl1.TabIndex = 9;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);
            this.CloseBtn.Appearance.Options.UseFont = true;
            this.CloseBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.CloseBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CloseBtn.ImageOptions.SvgImage")));
            this.CloseBtn.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.CloseBtn.Location = new System.Drawing.Point(568, 5);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(140, 65);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "닫기";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);
            this.MessageLabel.Appearance.Options.UseFont = true;
            this.MessageLabel.Appearance.Options.UseTextOptions = true;
            this.MessageLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MessageLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.MessageLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.tablePanel1.SetColumn(this.MessageLabel, 0);
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.Location = new System.Drawing.Point(30, 47);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.MessageLabel.Name = "MessageLabel";
            this.tablePanel1.SetRow(this.MessageLabel, 1);
            this.MessageLabel.Size = new System.Drawing.Size(660, 319);
            this.MessageLabel.TabIndex = 8;
            this.MessageLabel.Click += new System.EventHandler(this.MessageLabel_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl4.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl4.Appearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.Appearance.Options.UseBorderColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl4, 0);
            this.panelControl4.Controls.Add(this.simpleButton1);
            this.panelControl4.Location = new System.Drawing.Point(1, 1);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl4.Name = "panelControl4";
            this.tablePanel1.SetRow(this.panelControl4, 0);
            this.panelControl4.Size = new System.Drawing.Size(718, 42);
            this.panelControl4.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(674, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(41, 40);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);
            this.ApplyBtn.Appearance.Options.UseFont = true;
            this.ApplyBtn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ApplyBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.ApplyBtn.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.ApplyBtn.Location = new System.Drawing.Point(422, 5);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(140, 65);
            this.ApplyBtn.TabIndex = 1;
            this.ApplyBtn.Text = "확인";
            this.ApplyBtn.Visible = false;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // MessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.tablePanel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxForm";
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton CloseBtn;
        private DevExpress.XtraEditors.LabelControl MessageLabel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton ApplyBtn;
    }
}