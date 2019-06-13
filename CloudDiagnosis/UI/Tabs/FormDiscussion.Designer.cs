/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-27
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CloudDiagnosis.UI.Tabs
{
    partial class FormDiscussion
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiscussion));
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.dotNetBarManagerPrediction = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.imageListToolbar = new System.Windows.Forms.ImageList(this.components);
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.barMain = new DevComponents.DotNetBar.Bar();
            this.toolbarItemQueryData = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarItemExportDt2Excel = new DevComponents.DotNetBar.ButtonItem();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.dockSite7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(4, 38);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.Size = new System.Drawing.Size(976, 614);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // dotNetBarManagerPrediction
            // 
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManagerPrediction.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManagerPrediction.BottomDockSite = this.dockSite4;
            this.dotNetBarManagerPrediction.Images = this.imageListToolbar;
            this.dotNetBarManagerPrediction.LeftDockSite = this.dockSite1;
            this.dotNetBarManagerPrediction.ParentForm = this;
            this.dotNetBarManagerPrediction.RightDockSite = this.dockSite2;
            this.dotNetBarManagerPrediction.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.dotNetBarManagerPrediction.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManagerPrediction.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManagerPrediction.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManagerPrediction.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManagerPrediction.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 657);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(985, 0);
            this.dockSite4.TabIndex = 19;
            this.dockSite4.TabStop = false;
            // 
            // imageListToolbar
            // 
            this.imageListToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolbar.ImageStream")));
            this.imageListToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolbar.Images.SetKeyName(0, "0ExportDt2Excel.png");
            this.imageListToolbar.Images.SetKeyName(1, "1DataProcessing.png");
            this.imageListToolbar.Images.SetKeyName(2, "2Reset.png");
            this.imageListToolbar.Images.SetKeyName(3, "3calculator.png");
            this.imageListToolbar.Images.SetKeyName(4, "4saveDataBase.png");
            this.imageListToolbar.Images.SetKeyName(5, "peace.png");
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 33);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 624);
            this.dockSite1.TabIndex = 16;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(985, 33);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 624);
            this.dockSite2.TabIndex = 17;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 657);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(985, 0);
            this.dockSite8.TabIndex = 23;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 33);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 624);
            this.dockSite5.TabIndex = 20;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(985, 33);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 624);
            this.dockSite6.TabIndex = 21;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Controls.Add(this.barMain);
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(985, 33);
            this.dockSite7.TabIndex = 22;
            this.dockSite7.TabStop = false;
            // 
            // barMain
            // 
            this.barMain.AccessibleDescription = "DotNetBar Bar (barMain)";
            this.barMain.AccessibleName = "DotNetBar Bar";
            this.barMain.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.barMain.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.barMain.Font = new System.Drawing.Font("宋体", 9F);
            this.barMain.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.barMain.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.toolbarItemQueryData,
            this.toolbarItemExportDt2Excel});
            this.barMain.Location = new System.Drawing.Point(0, 0);
            this.barMain.Name = "barMain";
            this.barMain.Size = new System.Drawing.Size(237, 33);
            this.barMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.barMain.TabIndex = 1;
            this.barMain.TabStop = false;
            this.barMain.Text = "barMain";
            // 
            // toolbarItemQueryData
            // 
            this.toolbarItemQueryData.BeginGroup = true;
            this.toolbarItemQueryData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.toolbarItemQueryData.ImageIndex = 2;
            this.toolbarItemQueryData.Name = "toolbarItemQueryData";
            this.toolbarItemQueryData.Text = "查询数据";
            // 
            // toolbarItemExportDt2Excel
            // 
            this.toolbarItemExportDt2Excel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.toolbarItemExportDt2Excel.ImageIndex = 0;
            this.toolbarItemExportDt2Excel.Name = "toolbarItemExportDt2Excel";
            this.toolbarItemExportDt2Excel.Text = "导出数据";
            this.toolbarItemExportDt2Excel.Tooltip = "将表中数据以Excel方式导出到本地";
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 33);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(985, 0);
            this.dockSite3.TabIndex = 18;
            this.dockSite3.TabStop = false;
            // 
            // FormDiscussion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 657);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.Name = "FormDiscussion";
            this.Text = "病例讨论";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.dockSite7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            this.ResumeLayout(false);

        }
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManagerPrediction;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private System.Windows.Forms.ImageList imageListToolbar;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private DevComponents.DotNetBar.Bar barMain;
        private DevComponents.DotNetBar.ButtonItem toolbarItemExportDt2Excel;
        private DevComponents.DotNetBar.ButtonItem toolbarItemQueryData;
    }
}
