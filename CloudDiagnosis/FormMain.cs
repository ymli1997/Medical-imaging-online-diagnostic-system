using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CloudDiagnosis.UI.Tools;
using CloudDiagnosis.UI.Help;
using CloudDiagnosis.UI.File;
using CloudDiagnosis.UI.Configuration;
using Rising.Utilities;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using System.Threading;
using CloudDiagnosis.UI.Tabs;
using System.Diagnostics;
using CloudDiagnosis.Business;
using CloudDiagnosis.Entity;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Printing;

namespace CloudDiagnosis
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            SystemConfiguration.FormMain = this;
            InitStyle();
            InitTree();
            InitMdiForm();
        }

        #region mdi控制
        public TabItem AddANewTab(string typeName)
        {
            // 通过数据库的值获得要打开的模块对应的窗体类型。
            System.Type type = System.Type.GetType(typeName);
            if (type == null)
            {
                MessageBox.Show("需要增加的窗体不存在，请确认", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            object obj = (object)Activator.CreateInstance(type, null);
            Form mdiForm = obj as Form;

            DevComponents.DotNetBar.TabItem tabItemNew = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel tabControlPanelNew = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanelNew.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPanelNew.Name = typeName;
            tabControlPanelNew.TabItem = tabItemNew;
            tabControlPanelNew.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            tabItemNew.AttachedControl = tabControlPanelNew;
            tabItemNew.Name = typeName;
            mdiForm.FormBorderStyle = FormBorderStyle.None;
            mdiForm.TopLevel = false;
            mdiForm.Parent = tabControlPanelNew;
            mdiForm.Dock = DockStyle.Fill;
            tabControlPanelNew.Controls.Add(mdiForm);
            mdiForm.Show();
            tabItemNew.Text = mdiForm.Text;
            tabControlMain.Controls.Add(tabControlPanelNew);
            tabControlMain.Tabs.Add(tabItemNew);
            tabControlMain.Refresh();
            tabControlMain.SelectedTab = tabItemNew;
            tabControlMain.SelectedTabIndex = 0;

            return tabItemNew;
        }

        public void change()
        {
            tabControlMain.SelectedTabIndex = 1;
        }
        private void InitMdiForm()
        {
            AddANewTab("CloudDiagnosis.UI.Tabs.FormReportQuery");
            AddANewTab("CloudDiagnosis.UI.Tabs.FormConsultation");
            tabControlMain.SelectedTabIndex = 0;
        }

        /// <summary>
        /// 皮肤按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleButtonClick(object sender, System.EventArgs e)
        {
            BaseItem item = sender as BaseItem;
            if (item == null)
                return;

            foreach (int style in Enum.GetValues(typeof(eDotNetBarStyle)))
            {
                string styleName = Enum.GetName(typeof(eDotNetBarStyle), style);//获取名称
                if (item.Text == styleName)
                {
                    ChangeDotNetBarStyle((eDotNetBarStyle)style);
                    foreach (BaseItem button in bChangeStyle.SubItems)
                    {

                        if (button.Name == string.Format("styleButton{0}", style))
                        {
                            ((ButtonItem)button).Checked = true;
                        }
                        else
                        {
                            ((ButtonItem)button).Checked = false;
                        }
                    }

                    break;
                }
            }
        }
        /// <summary>
        /// 初始化所有可用的风格
        /// </summary>
        private void InitStyle()
        {
            foreach (int style in Enum.GetValues(typeof(eDotNetBarStyle)))
            {
                string styleName = Enum.GetName(typeof(eDotNetBarStyle), style);//获取名称
                ButtonItem button = new ButtonItem(string.Format("styleButton{0}", style), styleName);
                if ((eDotNetBarStyle)style == eDotNetBarStyle.Office2007)
                {
                    button.Checked = true;
                }
                button.Click += new System.EventHandler(StyleButtonClick);
                bChangeStyle.SubItems.Add(button);
            }
        }
        ///TODO:此处功能还需完善,tab 和 树的皮肤不一致，建议去除无效皮肤
        ///
        /// <summary>
        /// 更改皮肤
        /// </summary>
        /// <param name="style"></param>
        private void ChangeDotNetBarStyle(eDotNetBarStyle style)
        {
            dotNetBarManagerMain.Style = style;

            //if (dotNetBarManagerMain.IsThemeActive)
            //{
            //    barStand.RecalcLayout();
            //}
            if (style == eDotNetBarStyle.Office2003)
            {
                tabControlMain.Style = eTabStripStyle.OneNote;
            }
            else if (style == eDotNetBarStyle.Office2007)
            {
                tabControlMain.Style = eTabStripStyle.Office2007Document;
            }
            else if (style == eDotNetBarStyle.VS2005)
            {
                tabControlMain.Style = eTabStripStyle.VS2005;
            }
            else
            {
                tabControlMain.Style = eTabStripStyle.Flat;
            }
        }

        #endregion

        /// <summary>
        /// 进度条设置，默认进度 10
        /// </summary>
        /// <param name="incrementValue"></param>
        private void ProgressBarIncrement(int incrementValue = 10)
        {
            ProgressBarItem progress = itemProgressBar;
            if (progress.Value == progress.Maximum)
                progress.Value = progress.Minimum;
            else
                progress.Increment(incrementValue);
        }
        public DevComponents.DotNetBar.LabelItem LabelPosition
        {
            get
            {
                return labelPosition;
            }
        }
        public void SetLabelPositionText(string statusText)
        {
            if (!string.IsNullOrEmpty(statusText))
            {
                labelPosition.Text = statusText;
            }
            else
            {
                labelStatus.Text = "（0,0）";
            }
        }
        private void SetLabelStatusText(string statusText)
        {
            if (!string.IsNullOrEmpty(statusText))
            {
                labelStatus.Text = statusText;

            }
            else
            {
                labelStatus.Text = "欢迎" + SystemConfiguration.LoginUser.UserName + "使用智慧云眼（CloudEyes）--云上的医学影像诊断专家";
            }
        }

        /// <summary>
        /// 在状态栏显示所有选择的节点信息
        /// </summary>
        private void SetLabelStatusSelectedPoints()
        {
            //string selectedPointsList = string.Empty;
            //selectedPointsList = PointsHelper.GetPointsListFromPoinMs(SelectedPoints);
            //selectedPointsList = string.Format("已经选择{0}个监测点：{1}", SelectedPoints.Length, selectedPointsList);

            //SetLabelStatusText(selectedPointsList);
        }

        #region 节点树控制




        /// <summary>
        /// 所有监测点
        /// </summary>
        private CloudDiagnosis.Entity.Reports[] _reports = null;

        /// <summary>
        /// 所有监测点
        /// </summary>
        public CloudDiagnosis.Entity.Reports[] AllReports
        {
            get
            {
                return _reports;
            }
        }
        //public bool IsPointInSelectPoint(string pointName)
        //{

        //    for (int i = 0; i < SelectedPoints.Length; i++)
        //    {
        //        if (pointName == SelectedPoints[i].PointName)
        //            return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 从服务器获取report列表
        /// </summary>
        private void GetAllReport()
        {
            ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");

            string jsonResult = serviceClient.GetReportsByAuditUserID(SystemConfiguration.LoginUser.User_ID);
            //把集合放入json中
            //反序列化对象  
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //List<Reports> reportsList = js.Deserialize<List<Reports>>(jsonResult);
            List<Reports> reportsList = JsonConvert.DeserializeObject<List<Reports>>(jsonResult.ToString());


            Reports[] tempReports = new Reports[reportsList.Count()];
            int i = 0;
            foreach (Reports report in reportsList)
            {
                tempReports[i] = report;
                i++;
            }

            _reports = tempReports;
        }

        /// <summary>
        /// 选中的监测点
        /// </summary>
        public CloudDiagnosis.Entity.Reports SelectedPoints
        {
            get
            {
                return GetSelectedReport();
            }
        }

        public CloudDiagnosis.Entity.Reports GetSelectedReport()
        {
            int iSelectedNodesCount = advTreePoints.CheckedNodes.Count;
            CloudDiagnosis.Entity.Reports selectedReport = new CloudDiagnosis.Entity.Reports();
            //int i = 0;
            //foreach (Node node in advTreePoints.CheckedNodes)
            //{
            //    if (node.Checked)
            //    {
            //        selectedReport = (CloudDiagnosis.Entity.Reports)node.Tag;
            //        SystemConfiguration.report = selectedReport;
            //    }
            //}
            foreach (Node node in advTreePoints.Nodes)
            {
                if (node.IsSelected)
                {
                    selectedReport = (CloudDiagnosis.Entity.Reports)node.Tag;
                    SystemConfiguration.report = selectedReport;
                }
            }
            return selectedReport;

        }


        /// <summary>
        /// 增加监测节点
        /// </summary>
        /// <param name="parentNode">所属组节点</param>
        /// <param name="point">监测点</param>
        /// <returns></returns>
        private Node AddReportNode(CloudDiagnosis.Entity.Reports report)
        {
            Node node = null;

            node = new Node();
            node.Text = report.PatientName;
            node.Tag = report;
            node.Cells.Add(new Cell(report.RequestTime));
            //node.Cells.Add(new Cell(report.IsAudited.ToString()));
            if (report.IsAudited == false)
            {
                node.Cells.Add(new Cell("未审核"));
            }
            if (report.IsAudited == true)
            {
                node.Cells.Add(new Cell("已审核"));
            }
            //node.Cells.Add(new Cell(report.IsAudited.ToString()));
            node.CheckBoxVisible = true;
            advTreePoints.Nodes.Add(node);
            node.CheckBoxVisible = false;
            return node;
        }

        /// <summary>
        /// 初始化树形控件
        /// </summary>
        private void InitTree()
        {
            advTreePoints.Nodes.Clear();

            GetAllReport();

            foreach (Reports report in _reports)
            {
                AddReportNode(report);
            }

        }

        /// <summary>
        /// 更新树
        /// </summary>
        private void RefreshTree()
        {
            ///TODO 尚未完成，请郝惠惠继续完成
            Reports[] previewReports = _reports;
            GetAllReport();
            Reports[] currentReports = _reports;
            //if (currentReports.Length != previewReports.Length)
            //{
            //    foreach (Reports report in _reports)
            //    {
            //        AddReportNode(report);
            //    }
            //}


            foreach (Reports currentReport in currentReports)
            {
                Boolean isNew = true;
                foreach (Reports previewReport in previewReports)
                {
                    if (currentReport.Report_ID == previewReport.Report_ID)
                    {
                        isNew = false;
                        //比较数据是否发生变化，更新树节点
                        if ((currentReport.IsAudited != previewReport.IsAudited) || (currentReport.StudyDescription != previewReport.StudyDescription) || (currentReport.Content != previewReport.Content) || (currentReport.Comment != previewReport.Comment))
                        {
                            advTreePoints.SelectedNode.Remove();
                            AddReportNode(currentReport);
                        }
                    }
                }
                // 新节点
                if (isNew)
                {

                    AddReportNode(currentReport);
                }
            }
        }
        /// <summary>
        /// 分组节点选择后操作，如果选择为选中 那么选择所有子节点，如果未选中，那么取消所有选择，如果未中间状态，那么恢复到原选择
        /// </summary>
        /// <param name="node"></param>
        private void GroupNodeAfterCheck(Node node)
        {
            switch (node.CheckState)
            {
                case CheckState.Checked:
                case CheckState.Unchecked:
                    foreach (Node childNode in node.Nodes)
                    {
                        childNode.CheckState = node.CheckState;
                    }
                    break;
                case CheckState.Indeterminate:
                    break;
                default:
                    break;
            }
        }
        private void NodeAfterCheck(Node clickedNode)
        {
            Node node = clickedNode.Parent;
            if (node == null)
                return;

            CheckState childNodeState = node.Nodes[0].CheckState;

            foreach (Node childNode in node.Nodes)
            {
                if (childNode.CheckState != childNodeState)
                {
                    childNodeState = CheckState.Indeterminate;
                    break;
                }
            }
            node.CheckState = childNodeState;
        }
        #endregion



        private void advTreePoints_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            //暂时去除事件，防止选中重复响应
            this.advTreePoints.AfterCheck -= new DevComponents.AdvTree.AdvTreeCellEventHandler(this.advTreePoints_AfterCheck);
            Node nodeSelected = e.Cell.Parent;
            if (nodeSelected == null)
                return;
            //如果有子节点，表示是分组
            if (nodeSelected.HasChildNodes)
            {
                GroupNodeAfterCheck(nodeSelected);
            }
            else
            {
                NodeAfterCheck(nodeSelected);
            }

            FormTabBase formTabBase = tabControlMain.SelectedPanel.Controls[0] as FormTabBase;
            formTabBase.DataRefresh();

            SetLabelStatusSelectedPoints();
            //重新注册事件
            this.advTreePoints.AfterCheck += new DevComponents.AdvTree.AdvTreeCellEventHandler(this.advTreePoints_AfterCheck);
        }





        #region dotNetBarManagerMain 事件

        private void dotNetBarManagerMain_BarClosing(object sender, BarClosingEventArgs e)
        {
            //Bar bar = sender as Bar;
            //if (bar == null || bar != barTaskList)
            //    return;
            //if (bar.VisibleItemCount > 1)
            //{
            //    bar.Items[bar.SelectedDockTab].Visible = false;
            //    bar.RecalcLayout();
            //    e.Cancel = true;
            //}
        }



        public void SetPropertyGridObject(Object obj)
        {
            if (tabControlMain.SelectedPanel != null)
            {
                FormTabBase formTabBase = tabControlMain.SelectedPanel.Controls[0] as FormTabBase;
                if (formTabBase != null)
                {
                    formTabBase.InitLeftTabProperty(ref obj);
                }
            }
        }


        private void dotNetBarManagerMain_ItemClick(object sender, EventArgs e)
        {
            //BaseItem item = sender as BaseItem;
            //frmDocument activedocument = this.ActiveMdiChild as frmDocument;

            //// Activate the form
            //if (item.Name == "window_list")
            //    ((Form)item.Tag).Activate();
            //else if (item == bThemes)
            //    EnableThemes(bThemes);
            //else if (item.GlobalName == bTextColor.GlobalName && activedocument != null)
            //    activedocument.ExecuteCommand(item.GlobalName, ((ColorPickerDropDown)item).SelectedColor);
            //else if (activedocument != null)
            //{
            //    // Pass command to the active document
            //    // Note the usage of GlobalName property! Since same command can be found on both menus and toolbars, for example Bold
            //    // you have to give two different names through Name property to these two instances. However, you can and should
            //    // give them same GlobalName. GlobalName will ensure that properties set on one instance are replicated to all
            //    // objects with the same GlobalName. You can read more about Global Items feature in help file.
            //    activedocument.ExecuteCommand(item.GlobalName, null);
            //}
        }


        private void dotNetBarManagerMain_MouseEnter(object sender, EventArgs e)
        {
            // Sync Status-bar with the item tooltip...
            BaseItem item = sender as BaseItem;
            if (item == null)
                return;
            SetLabelStatusText(item.Tooltip);
            //labelStatus.Text = item.Tooltip;
            //// Disable timer stop flashing on Style button...
            //if (item == bChangeStyle && timer1.Enabled)
            //{
            //    timer1.Enabled = false;
            //    bChangeStyle.ForeColor = Color.Empty;
            //}
        }

        private void dotNetBarManagerMain_MouseLeave(object sender, EventArgs e)
        {
            SetLabelStatusText("");
        }


        private void dotNetBarManagerMain_PopupContainerLoad(object sender, EventArgs e)
        {
            //ButtonItem item = sender as ButtonItem;
            //if (item == bTabColor)
            //{
            //    DevComponents.DotNetBar.PopupContainerControl container = item.PopupContainerControl as PopupContainerControl;
            //    ColorPicker clr = new ColorPicker();
            //    container.Controls.Add(clr);
            //    if (cmdStyleOffice2003.Checked)
            //    {
            //        clr.BackColor = dotNetBarManager1.Bars[0].ColorScheme.BarBackground2;
            //        clr.tabStrip1.Style = eTabStripStyle.Office2003;
            //    }
            //    clr.Location = container.ClientRectangle.Location;
            //    container.ClientSize = clr.Size;
            //}
        }

        private void dotNetBarManagerMain_PopupContainerUnload(object sender, EventArgs e)
        {
            //ButtonItem item = sender as ButtonItem;
            //if (item.Name == "bTabColor")
            //{
            //    DevComponents.DotNetBar.PopupContainerControl container = item.PopupContainerControl as PopupContainerControl;
            //    ColorPicker clr = container.Controls[0] as ColorPicker;
            //    if (clr.SelectedColor != Color.Empty)
            //    {
            //        tabStrip1.ColorScheme.TabBackground = ControlPaint.LightLight(clr.SelectedColor);
            //        tabStrip1.ColorScheme.TabBackground2 = clr.SelectedColor;
            //        tabStrip1.Refresh();
            //    }
            //    // Close popup menu, since it is not closed when Popup Container is closed...
            //    item.Parent.Expanded = false;
            //}
        }
        #endregion



        #region 菜单点击事件
        #region 文件
        /// <summary>
        /// 连接到GeoMos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemDicomImport_Click(object sender, EventArgs e)
        {
            FormDicomUpload formDicomUpload = new FormDicomUpload();
            formDicomUpload.ShowDialog();
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.Description = "请选择文件路径";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    string foldPath = dialog.SelectedPath;
            //    MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //AddANewTab("CloudEyes.UI.Tabs.FormConsultation");
        }


        #region 数据库
        private void menuItemDatabaseBackup_Click(object sender, EventArgs e)
        {
            FormDBExport formOpen = new FormDBExport();
            formOpen.ShowDialog(this);
        }

        private void menuItemDatabaseRestore_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 打印及打印预览
        StringReader lineReader = null;//打印内容存放


        /// <summary>
        /// 实现打印事件功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;//获得绘图对象

            float yposition = 0;//绘制字符串的纵向位置
            int count = 0;//行计数器
            float lefmargin = e.MarginBounds.Left;//左边距
            float topmargin = e.MarginBounds.Top;//上边距
            string line = "";//行字符串

            Font printFont = new Font("宋体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));//当前的打印字体
            SolidBrush mybrush = new SolidBrush(Color.Black);//刷子
            float linesperpage = e.MarginBounds.Height / printFont.GetHeight(g);//每页可打印的行数

            //StringReader 解析：打开一个文本文件以读取指定范围的字符，或基于现有的流创建一个读取器

            /*逐行的循环打印一页*/
            while (count < linesperpage && ((line = lineReader.ReadLine())) != null)
            {//行计数器  页面的行数(总行数) && 要打印的字符串 = 文本文件读取的字符串（IO流）
                yposition = topmargin + (count * printFont.GetHeight(g));
                g.DrawString(line, printFont, mybrush, lefmargin, yposition, new StringFormat());
                //字符串,字体格式,笔刷(颜色), x坐标   ,y坐标   ,文本的格式化特性
                count++;
            }

            /*
             * 注意：使用本段代码前,要在该窗体的类中定义lineReader对象，即StringReader类：StringReader lineReader = null;
             * 
             * 如果本页打印完成而line不为空，说明还有没完成的页面，这将触发下一次的打印事件。在下一次的打印中lineReader会
             * 自动读取上次没有打印完的内容，因为lineReader是这个打印方法外的类的成员，它可以记录当前读取的位置
             */

            if (line != null)
            {
                e.HasMorePages = true;//是否打印副页/即下一页的内容
            }
            else
            {
                e.HasMorePages = false;
            }

            //重新初始化lineReader对象，不然使用打印预览中的打印按钮打印出来的是白纸
            //lineReader = new StringReader(textBox1.Text);//textbox是你要打印的文本框内容

        }

        /// <summary>
        /// 页面设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemPageSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog.Document = printDocument;//在printDocument获取页面设置
            pageSetupDialog.ShowDialog();
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemPrintPreview_Click(object sender, EventArgs e)
        {
            ProgressBarIncrement(10);
            printPreviewDialog.Document = printDocument;//设置要预览的文档
            //lineReader = new StringReader(textBox1.Text);
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 打印菜单和工具条上打印按钮 Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemPrint_Click(object sender, EventArgs e)
        {
            printDialog.Document = printDocument;//在printDocument获取打印设置
            //lineReader = new StringReader(textBox1.Text);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();//开始文档的打印进程。
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString(), "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                }
            }
        }
        #endregion
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 编辑
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemCopy_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 查看

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            if (textBoxQuery.Text == "已审核")
            {

                foreach (Reports Report in _reports)
                {
                    if (Report.IsAudited == false)
                    {
                        AddReportNode(Report);

                    }

                }
                textBoxQuery.Text = null;

            }

            if (textBoxQuery.Text == "未审核")
            {

                foreach (Reports Report in _reports)
                {
                    if (Report.IsAudited == true)
                    {
                        AddReportNode(Report);

                    }
                }
                textBoxQuery.Text = null;
            }

            FormMain fromMain = SystemConfiguration.FormMain;
            Reports report = fromMain.GetSelectedReport();
            RefreshTree();
            FormTabBase formTabBase = tabControlMain.SelectedPanel.Controls[0] as FormTabBase;
            formTabBase.FormOnLoad();

        }
        public string getSelectPanelFormName()
        {
            FormTabBase formTabBase = tabControlMain.SelectedPanel.Controls[0] as FormTabBase;
            return formTabBase.Text;
        }

        /// <summary>
        /// 通过子窗口名称获得子窗口句柄
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public FormTabBase getForm(string formName)
        {
            DevComponents.DotNetBar.TabControlPanel tabs = (DevComponents.DotNetBar.TabControlPanel)tabControlMain.Controls.Find(formName, true)[0];

            FormTabBase formTabBase = tabs.Controls[0] as FormTabBase;
            return formTabBase;
        }

        public void loadForm(string formName)
        {
            InitTree();

            DevComponents.DotNetBar.TabControlPanel tabs = (DevComponents.DotNetBar.TabControlPanel)tabControlMain.Controls.Find(formName, true)[0];

            FormTabBase formTabBase = tabs.Controls[0] as FormTabBase;
            formTabBase.FormOnLoad();
            tabControlMain.SelectedPanel = tabs;
        }
        /// <summary>
        /// 时间段设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemReportQuery_Click(object sender, EventArgs e)
        {
            //FormSetReportQuery formOpen = new FormSetReportQuery();
            //formOpen.ShowDialog(this);

            AddANewTab("CloudDiagnosis.UI.Tabs.FormReportQuery");
        }

        /// <summary>
        /// 工具条开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemToolbar_Click(object sender, EventArgs e)
        {
            ButtonItem buttonItem = sender as ButtonItem;
            buttonItem.Checked = !buttonItem.Checked;

            barToolbar.Visible = buttonItem.Checked;
        }

        /// <summary>
        /// 状态栏开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemStatusbar_Click(object sender, EventArgs e)
        {
            ButtonItem buttonItem = sender as ButtonItem;
            buttonItem.Checked = !buttonItem.Checked;

            barStatus.Visible = buttonItem.Checked;
        }
        #endregion


        #region 工具

        /// <summary>
        /// 系统选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSystemOption_Click(object sender, EventArgs e)
        {
            FormSystemSetting formSystemSetting = new FormSystemSetting();
            formSystemSetting.ShowDialog();
        }

        /// <summary>
        /// 启动计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemToolsCaculator_Click(object sender, EventArgs e)
        {
            Process pcalc = Process.Start("calc.exe");
        }


        #endregion

        #region 帮助
        /// <summary>
        /// 帮助主题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemHelpTopic_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            FormAboutThis formOpen = new FormAboutThis();
            formOpen.ShowDialog(this);
        }
        #endregion

        private void labelPosition_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void advTreePoints_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Node node = advTreePoints.GetNodeAt(e.X, e.Y);
                if (null != node && !node.HasChildNodes)
                {
                    node.Checked = true;

                    advTreePoints.SelectedNode = node;
                }
            }
        }

        private void advTreePointsMenuStrip_Opening(object sender, CancelEventArgs e)
        {



        }

        private void advTreePoints_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Right)
            //{
            //    if (e.Node != null && !e.Node.HasChildNodes)
            //    {
            //        e.Node.Checked = true;
            //        advTreePoints.SelectedNode = e.Node;

            //        advTreePointsMenuStrip.Show();
            //    }
            //    //Node node = advTreePoints.GetNodeAt(e.X, e.Y);
            //    //if (null != node && !node.HasChildNodes)
            //    //{
            //    //    node.Checked = true;
            //    //    advTreePoints.SelectedNode = node;
            //    //}
            //}
        }

        private void advTreePoints_MouseDown(object sender, MouseEventArgs e)
        {
            string formName = getForm(SystemConfiguration.UIFormName.FormSiteMapImage).Text;
            if (getSelectPanelFormName() == formName && e.Button == MouseButtons.Right)
            {
                Node node = advTreePoints.GetNodeAt(e.X, e.Y);
                if (null != node && !node.HasChildNodes)
                {
                    node.Checked = true;
                    //FormSiteMapImage formMapImage = (FormSiteMapImage)getForm(SystemConfiguration.UIFormName.FormSiteMapImage);
                    //if (formMapImage.ImageLoadFlag)
                    //{
                    //    advTreePoints.SelectedNode = node;
                    //    advTreePoints.ContextMenuStrip = advTreePointsMenuStrip;
                    //}


                }
                else advTreePoints.ContextMenuStrip = null;
            }
            else advTreePoints.ContextMenuStrip = null;
        }

        private void tabControlMain_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 右键菜单响应  添加当前选中的点到当前监测地图中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeMenuItemAddToSiteMapImageAddPoint_Click(object sender, EventArgs e)
        {
            //FormSiteMapImage formMapImage = (FormSiteMapImage)getForm(SystemConfiguration.UIFormName.FormSiteMapImage);
            //if (formMapImage.ImageLoadFlag)
            //{
            //    if (formMapImage.IsInMapImagePoint(advTreePoints.SelectedNode.Text.ToString()))
            //    {
            //        MessageBox.Show("该点在地图中已经存在，不能重复添加，请先删除再添加或者进行编辑");
            //    }
            //    else
            //        formMapImage.AddMapImagePoint(advTreePoints.SelectedNode.Text.ToString());

            //}

        }

        /// <summary>
        /// 右键菜单响应  从当前监测地图中删除选中的点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemDeletePoint_Click(object sender, EventArgs e)
        {
            string str = "您确定要从当前地图删除监测点 " + advTreePoints.SelectedNode.Text.ToString() + " 吗？";
            DialogResult result = MessageBox.Show(str, "注意", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //FormSiteMapImage formMapImage = (FormSiteMapImage)getForm(SystemConfiguration.UIFormName.FormSiteMapImage);
                //if (formMapImage.DeleteMapImagePoint(advTreePoints.SelectedNode.Text.ToString()))
                //{
                //    formMapImage.DrawMapImagePointList();
                //    MessageBox.Show("成功删除！");
                //}
                //else
                //    MessageBox.Show("该点不存在！");
            }
        }


        /// <summary>
        /// 属性修改后，响应到对应控件
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (s != null)
            {
                string str = e.ChangedItem.ToString();
                str = e.ChangedItem.Label;
                if (tabControlMain.SelectedPanel != null)
                {
                    FormTabBase formTabBase = tabControlMain.SelectedPanel.Controls[0] as FormTabBase;
                    if (formTabBase != null)
                    {
                        //最终响应位置位窗口的UpdateLeftTabProperty事件，可能在父类
                        formTabBase.UpdateLeftTabProperty(str, e.ChangedItem.Value);
                    }
                }
            }
        }

        public event EventHandler evt;
        private void advTreePoints_DoubleClick(object sender, EventArgs e)
        {
            FormTabBase formTabBase = tabControlMain.SelectedPanel.Controls[0] as FormTabBase;
            formTabBase.FormOnLoad();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitTree();
            // 这里需要隐藏主窗体
            //this.Hide();

            //// 这里显示登录窗体
            //FormLogin formLogin = new FormLogin();
            //formLogin.ShowDialog(this);
        }


        /// <summary>
        /// 检索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            //advTreePoints.Nodes.Clear();

            //GetAllReport();

            // bool isRetrievalByPatient = true;
            if (string.IsNullOrEmpty(textBoxQuery.Text))
            {
                InitTree();
                MessageBox.Show("您输入的检索信息为空，请重新输入！");
            }
            else if (textBoxQuery.Text == "未审核")
            {

                advTreePoints.Nodes.Clear();
                foreach (Reports report in _reports)
                {
                    if (report.IsAudited == false)
                    {
                        AddReportNode(report);
                    }


                }
            }
            else if (textBoxQuery.Text == "已审核")
            {
                advTreePoints.Nodes.Clear();

                foreach (Reports report in _reports)
                {
                    if (report.IsAudited == true)
                    {
                        AddReportNode(report);
                    }


                }

            }
            else
            {

                //if (isRetrievalByPatient)

                advTreePoints.Nodes.Clear();
                ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");       //数据库方法

                string jsonResult = serviceClient.GetReportInfoByRetrieval(textBoxQuery.Text);

                List<Reports> reportsList = JsonConvert.DeserializeObject<List<Reports>>(jsonResult.ToString());
                Reports[] tempReports = new Reports[reportsList.Count()];
                int i = 0;
                foreach (Reports report in reportsList)
                {
                    tempReports[i] = report;
                    i++;
                }

                _reports = tempReports;
                foreach (Reports report in _reports)
                {
                    //advTreePoints.Nodes.Clear();
                    AddReportNode(report);

                }


            }

            //advTreePoints.Nodes.Clear();
            //GetAllReport();

            //foreach (Reports report in _reports)
            //{                
            //    if ((textBoxQuery.Text == report.PatientName) || (textBoxQuery.Text == report.RequestTime) || (report.IsAudited == true && textBoxQuery.Text == "已审核") || (report.IsAudited == false && textBoxQuery.Text == "未审核"))
            //    {                    
            //        AddReportNode(report);
            //    }
            //else
            //{
            //    advTreePoints.Nodes.Clear();
            //    InitTree();
            //}
        }

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    advTreePoints.Nodes.Clear();
        //    foreach (Reports report in _reports)
        //    {
        //        if (report.IsAudited == true)
        //        {
        //            AddReportNode(report);
        //        }


        //    }
        //}

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    advTreePoints.Nodes.Clear();
        //    foreach (Reports report in _reports)
        //    {
        //        if (report.IsAudited == false)
        //        {
        //            AddReportNode(report);
        //        }


        //    }
        //}
    }
}

