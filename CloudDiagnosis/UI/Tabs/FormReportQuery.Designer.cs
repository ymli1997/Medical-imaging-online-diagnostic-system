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
    partial class FormReportQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportQuery));
            this.imageListToolbar = new System.Windows.Forms.ImageList(this.components);
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxLocationSeg = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxNoteInformation = new System.Windows.Forms.TextBox();
            this.textBoxEvaluateInformation = new System.Windows.Forms.TextBox();
            this.textBoxCheckInformation = new System.Windows.Forms.TextBox();
            this.textBoxCheckDoctorName = new System.Windows.Forms.TextBox();
            this.textBoxPatientCheckNumber = new System.Windows.Forms.TextBox();
            this.textBoxPatientSex = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxPatientName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxUploadTime = new System.Windows.Forms.TextBox();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.barMain = new DevComponents.DotNetBar.Bar();
            this.toolbarItemQueryData = new DevComponents.DotNetBar.ButtonItem();
            this.toolbarItemDicomDisplay = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItemReportCheck = new DevComponents.DotNetBar.ButtonItem();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManagerPrediction = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.panel1.SuspendLayout();
            this.dockSite7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            this.SuspendLayout();
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
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.textBoxLocationSeg);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.textBoxNoteInformation);
            this.panel1.Controls.Add(this.textBoxEvaluateInformation);
            this.panel1.Controls.Add(this.textBoxCheckInformation);
            this.panel1.Controls.Add(this.textBoxCheckDoctorName);
            this.panel1.Controls.Add(this.textBoxPatientCheckNumber);
            this.panel1.Controls.Add(this.textBoxPatientSex);
            this.panel1.Controls.Add(this.textBoxAge);
            this.panel1.Controls.Add(this.textBoxPatientName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBoxLocation);
            this.panel1.Controls.Add(this.textBoxUploadTime);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 824);
            this.panel1.TabIndex = 29;
            // 
            // textBoxLocationSeg
            // 
            this.textBoxLocationSeg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLocationSeg.Location = new System.Drawing.Point(398, 77);
            this.textBoxLocationSeg.Name = "textBoxLocationSeg";
            this.textBoxLocationSeg.Size = new System.Drawing.Size(551, 21);
            this.textBoxLocationSeg.TabIndex = 50;
            this.textBoxLocationSeg.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(12, 578);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "备注信息";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.Location = new System.Drawing.Point(12, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 48;
            this.label12.Text = "检查评估";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.Location = new System.Drawing.Point(12, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 47;
            this.label13.Text = "检查情况：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.Location = new System.Drawing.Point(917, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 46;
            this.label14.Text = "审核医生：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.Location = new System.Drawing.Point(674, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 45;
            this.label15.Text = "检查号：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F);
            this.label16.Location = new System.Drawing.Point(463, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 44;
            this.label16.Text = "性别：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F);
            this.label17.Location = new System.Drawing.Point(252, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 43;
            this.label17.Text = "年龄：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 9F);
            this.label18.Location = new System.Drawing.Point(12, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 42;
            this.label18.Text = "姓名：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F);
            this.label19.Location = new System.Drawing.Point(327, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 41;
            this.label19.Text = "本地路径：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 9F);
            this.label20.Location = new System.Drawing.Point(12, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 40;
            this.label20.Text = "上传时间：";
            // 
            // textBoxNoteInformation
            // 
            this.textBoxNoteInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNoteInformation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNoteInformation.Location = new System.Drawing.Point(14, 593);
            this.textBoxNoteInformation.Multiline = true;
            this.textBoxNoteInformation.Name = "textBoxNoteInformation";
            this.textBoxNoteInformation.Size = new System.Drawing.Size(1120, 220);
            this.textBoxNoteInformation.TabIndex = 39;
            // 
            // textBoxEvaluateInformation
            // 
            this.textBoxEvaluateInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEvaluateInformation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxEvaluateInformation.Location = new System.Drawing.Point(14, 347);
            this.textBoxEvaluateInformation.Multiline = true;
            this.textBoxEvaluateInformation.Name = "textBoxEvaluateInformation";
            this.textBoxEvaluateInformation.Size = new System.Drawing.Size(1120, 220);
            this.textBoxEvaluateInformation.TabIndex = 37;
            // 
            // textBoxCheckInformation
            // 
            this.textBoxCheckInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCheckInformation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCheckInformation.Location = new System.Drawing.Point(14, 101);
            this.textBoxCheckInformation.Multiline = true;
            this.textBoxCheckInformation.Name = "textBoxCheckInformation";
            this.textBoxCheckInformation.Size = new System.Drawing.Size(1120, 220);
            this.textBoxCheckInformation.TabIndex = 35;
            // 
            // textBoxCheckDoctorName
            // 
            this.textBoxCheckDoctorName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCheckDoctorName.Location = new System.Drawing.Point(988, 46);
            this.textBoxCheckDoctorName.Name = "textBoxCheckDoctorName";
            this.textBoxCheckDoctorName.Size = new System.Drawing.Size(144, 21);
            this.textBoxCheckDoctorName.TabIndex = 33;
            // 
            // textBoxPatientCheckNumber
            // 
            this.textBoxPatientCheckNumber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPatientCheckNumber.Location = new System.Drawing.Point(733, 46);
            this.textBoxPatientCheckNumber.Name = "textBoxPatientCheckNumber";
            this.textBoxPatientCheckNumber.Size = new System.Drawing.Size(141, 21);
            this.textBoxPatientCheckNumber.TabIndex = 31;
            // 
            // textBoxPatientSex
            // 
            this.textBoxPatientSex.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPatientSex.Location = new System.Drawing.Point(510, 46);
            this.textBoxPatientSex.Name = "textBoxPatientSex";
            this.textBoxPatientSex.Size = new System.Drawing.Size(127, 21);
            this.textBoxPatientSex.TabIndex = 29;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxAge.Location = new System.Drawing.Point(299, 46);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(133, 21);
            this.textBoxAge.TabIndex = 27;
            // 
            // textBoxPatientName
            // 
            this.textBoxPatientName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPatientName.Location = new System.Drawing.Point(65, 48);
            this.textBoxPatientName.Name = "textBoxPatientName";
            this.textBoxPatientName.Size = new System.Drawing.Size(133, 21);
            this.textBoxPatientName.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1020, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "重新下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(971, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 28);
            this.button2.TabIndex = 22;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLocation.Location = new System.Drawing.Point(398, 12);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(551, 21);
            this.textBoxLocation.TabIndex = 4;
            // 
            // textBoxUploadTime
            // 
            this.textBoxUploadTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUploadTime.Location = new System.Drawing.Point(79, 12);
            this.textBoxUploadTime.Name = "textBoxUploadTime";
            this.textBoxUploadTime.Size = new System.Drawing.Size(191, 21);
            this.textBoxUploadTime.TabIndex = 2;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(1146, 33);
            this.dockSite2.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 826);
            this.dockSite2.TabIndex = 17;
            this.dockSite2.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 33);
            this.dockSite1.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 826);
            this.dockSite1.TabIndex = 16;
            this.dockSite1.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 33);
            this.dockSite3.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(1146, 0);
            this.dockSite3.TabIndex = 18;
            this.dockSite3.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 859);
            this.dockSite4.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(1146, 0);
            this.dockSite4.TabIndex = 19;
            this.dockSite4.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 33);
            this.dockSite5.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 826);
            this.dockSite5.TabIndex = 20;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(1146, 33);
            this.dockSite6.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 826);
            this.dockSite6.TabIndex = 21;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Controls.Add(this.barMain);
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(1146, 33);
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
            this.toolbarItemDicomDisplay,
            this.buttonItemReportCheck});
            this.barMain.Location = new System.Drawing.Point(0, 0);
            this.barMain.Margin = new System.Windows.Forms.Padding(4);
            this.barMain.Name = "barMain";
            this.barMain.Size = new System.Drawing.Size(270, 33);
            this.barMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.barMain.TabIndex = 1;
            this.barMain.TabStop = false;
            this.barMain.Text = "barMain";
            // 
            // toolbarItemQueryData
            // 
            this.toolbarItemQueryData.BeginGroup = true;
            this.toolbarItemQueryData.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.toolbarItemQueryData.ImageIndex = 1;
            this.toolbarItemQueryData.Name = "toolbarItemQueryData";
            this.toolbarItemQueryData.Text = "下载报告";
            this.toolbarItemQueryData.Click += new System.EventHandler(this.toolbarItemQueryData_Click);
            // 
            // toolbarItemDicomDisplay
            // 
            this.toolbarItemDicomDisplay.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.toolbarItemDicomDisplay.ImageIndex = 2;
            this.toolbarItemDicomDisplay.Name = "toolbarItemDicomDisplay";
            this.toolbarItemDicomDisplay.Text = "查看影像";
            this.toolbarItemDicomDisplay.Click += new System.EventHandler(this.toolbarItemDicomDisplay_Click);
            // 
            // buttonItemReportCheck
            // 
            this.buttonItemReportCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItemReportCheck.ImageIndex = 0;
            this.buttonItemReportCheck.Name = "buttonItemReportCheck";
            this.buttonItemReportCheck.Text = "审核上传";
            this.buttonItemReportCheck.Click += new System.EventHandler(this.buttonItemReportCheck_Click);
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 859);
            this.dockSite8.Margin = new System.Windows.Forms.Padding(4);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(1146, 0);
            this.dockSite8.TabIndex = 23;
            this.dockSite8.TabStop = false;
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
            // FormReportQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1146, 859);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReportQuery";
            this.Text = "报告查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private DevComponents.DotNetBar.Bar barMain;
        private DevComponents.DotNetBar.ButtonItem toolbarItemQueryData;
        private DevComponents.DotNetBar.ButtonItem toolbarItemDicomDisplay;
        private DevComponents.DotNetBar.ButtonItem buttonItemReportCheck;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxNoteInformation;
        private System.Windows.Forms.TextBox textBoxEvaluateInformation;
        private System.Windows.Forms.TextBox textBoxCheckInformation;
        private System.Windows.Forms.TextBox textBoxCheckDoctorName;
        private System.Windows.Forms.TextBox textBoxPatientCheckNumber;
        private System.Windows.Forms.TextBox textBoxPatientSex;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxPatientName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxUploadTime;
        private System.Windows.Forms.TextBox textBoxLocationSeg;
    }
}
