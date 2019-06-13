/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-27
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CloudDiagnosis;
using CloudDiagnosis.UI.Tabs;
using DevComponents.DotNetBar;
using CloudDiagnosis.UI.Tools;
using System.Web.Script.Serialization;
using CloudDiagnosis.Entity;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace CloudDiagnosis.UI.Tabs
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormConsultation : FormTabBase
    {

        public FormConsultation()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            timer1.Start();
        }


        private void toolbarItemPredictionAlgorithm_Click(object sender, EventArgs e)
        {

        }

        private void Predict(string dataPropertyName)
        {
        }

        private void toolbarItemPrediction_Click(object sender, EventArgs e)
        {

            MessageBox.Show("预测数据计算完成！");
        }

        private void toolbarItemDicomDisplay_Click(object sender, EventArgs e)
        {
            //FormDicomDisplay formDicomDisplay = new FormDicomDisplay();
            //formDicomDisplay.Show();
            //ITK - SNAP.exe - g d:/ 1_0007358162_ET1.nii.gz - s d:/ 1_0007358162_ET1_seg1.nii.gz
            //string mainImageFile = "E:/IPV6/1_0007358162_ET1.nii.gz";
            //string segmentationImageFile = "E:/IPV6/1_0007358162_ET1_seg1.nii.gz";

            FormMain fromMain = SystemConfiguration.FormMain;
            Reports report = fromMain.GetSelectedReport();
            if (string.IsNullOrEmpty(report.StudyLocalDirectory) && string.IsNullOrEmpty(report.StudyLocalDirectorySeg))
            {
                MessageBox.Show("影像查看失败，请先选择病例！");

            }
            else
            {
                if ((System.IO.File.Exists(report.StudyLocalDirectory)) && (System.IO.File.Exists(report.StudyLocalDirectorySeg)))
                {
                    string mainImageFile = report.StudyLocalDirectory;
                    string segmentationImageFile = report.StudyLocalDirectorySeg;

                    string args = "-g " + mainImageFile + " -s " + segmentationImageFile;

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.WorkingDirectory = "..\\..\\..\\ITK-SNAP\\bin\\ITK-SNAP.exe";
                    //process.StartInfo.FileName = "..\\..\\..\\DicomViewer\\bin\\Debug\\DicomViewer.exe";
                    //process.StartInfo.FileName = "C:\\Program Files\\ITK-SNAP 3.6\\bin\\ITK-SNAP.exe";
                    //process.StartInfo.Arguments = args;

                    System.Diagnostics.Process.Start(process.StartInfo.WorkingDirectory, args);
                }
                else
                {

                    ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");
                    string imageFile = report.StudyLocalDirectory;
                    string maskFile = report.StudyLocalDirectorySeg;
                    DialogResult dr = MessageBox.Show("未能在本地找到影像文件,是否执行下载操作？" + "\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string imageFileName = System.IO.Path.GetFileName(imageFile);
                        string maskFileName = System.IO.Path.GetFileName(maskFile);
                        byte[] bs1 = serviceClient.DownloadFile(imageFileName, "MedicalImages");

                        FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
                        BrowDialog.ShowNewFolderButton = true;
                        BrowDialog.Description = "请选择影像文件保存位置";
                        if (BrowDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = BrowDialog.SelectedPath;
                            string fileName = path + "\\" + imageFileName;
                            FileStream stream1 = new FileStream(fileName, FileMode.Create);
                            stream1.Write(bs1, 0, bs1.Length);
                            stream1.Flush();
                            stream1.Close();
                            byte[] bs2 = serviceClient.DownloadFile(maskFileName, "MedicalImages");
                            string fileNameSeg = path + "\\" + maskFileName;
                            FileStream stream2 = new FileStream(fileNameSeg, FileMode.Create);
                            stream2.Write(bs2, 0, bs2.Length);
                            stream2.Flush();
                            stream2.Close();
                            report.StudyLocalDirectory = fileName;
                            report.StudyLocalDirectorySeg = fileNameSeg;
                            MessageBox.Show("影像文件" + "\n" + imageFileName + "\n" + maskFileName + "\n" + "已下载到本地" + path, "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("影像文件" + "\n" + report.StudyLocalDirectory + "\n" + report.StudyLocalDirectorySeg + "\n" + "不存在", "警告");
                    }
                }

            }
        }

        private void FormConsultation_Load(object sender, EventArgs e)
        {

        }

        private void SendButton_Click_1(object sender, EventArgs e)
        {
            FormMain formMain = SystemConfiguration.FormMain;
            Reports report = formMain.GetSelectedReport();
            //CloudDiagnosis.Entity.Reports report = formMain.GetSelectedReport();

            if (report.Report_ID != 0)
            {
                if (!report.IsAudited)
                {
                    this.ReadRichTextBox.Clear();
                    MessageBox.Show("该报表还没有经过医生审核，不能发起讨论!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                Consultation cs = new Consultation();//创建对象
                try
                {
                    this.ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length;
                    this.ReadRichTextBox.ScrollToCaret();
                    this.ReadRichTextBox.SelectionAlignment = HorizontalAlignment.Right;//改变文本排列方式右对齐
                                                                                        //发送信息，          
                                                                                        //if (this.WriteRichTextBox.Text != ""||WriteRichTextBox.Rtf.IndexOf((@"{\pict\"))>-1)
                    if (!string.IsNullOrWhiteSpace(WriteRichTextBox.Text) || WriteRichTextBox.Rtf.IndexOf((@"{\pict\")) > -1)//判断发送框中是否有东西
                    {
                        //ReadRichTextBox.ReadOnly = false;

                        //string left = this.ReadRichTextBox.SelectionAlignment.ToString();
                        //   if (this.ReadRichTextBox.Text != "")
                        // {
                        this.ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length;
                        this.ReadRichTextBox.ScrollToCaret();
                        this.ReadRichTextBox.SelectionAlignment = HorizontalAlignment.Right;//改变文本排列方式右对齐
                        if (!string.IsNullOrWhiteSpace(WriteRichTextBox.Text))//判断发送框中是否有文字
                        {



                            this.ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length;
                            this.ReadRichTextBox.ScrollToCaret();
                            Font font1 = new Font(FontFamily.GenericMonospace, 16, FontStyle.Regular);
                            ReadRichTextBox.SelectionFont = font1;
                            ReadRichTextBox.SelectionColor = Color.Blue;
                            this.ReadRichTextBox.AppendText(SystemConfiguration.LoginUser.UserName + "    " + DateTime.Now.ToString() + "\n");
                            //this.ReadRichTextBox.Text = this.ReadRichTextBox.Text + "\r\n";
                            Font font2 = new Font(FontFamily.GenericMonospace, 24, FontStyle.Regular);
                            ReadRichTextBox.SelectionFont = font2;
                            ReadRichTextBox.SelectionColor = Color.Red;
                            this.ReadRichTextBox.AppendText(this.WriteRichTextBox.Text + "\n");
                        }
                        else
                        {

                            //this.ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length;
                            //this.ReadRichTextBox.ScrollToCaret();
                            ReadRichTextBox.SelectionColor = Color.Blue;
                            Font font1 = new Font(FontFamily.GenericMonospace, 16, FontStyle.Regular);
                            ReadRichTextBox.SelectionFont = font1;
                            this.ReadRichTextBox.AppendText(SystemConfiguration.LoginUser.UserName + "    " + DateTime.Now.ToString() + "\n");
                            //this.ReadRichTextBox.Text = this.ReadRichTextBox.Text + "\r\n";
                        }

                        //发送图片

                        PictureBox pb = new PictureBox();
                        pb.Image = null;
                        pb.Image = Clipboard.GetImage();
                        if (pb.Image != null)
                        {
                            pb.Image.Save("8.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            //pb.Image.Save("C:/2/7.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            pb.Image.Dispose();

                            pb.Dispose();
                            Clipboard.Clear();
                            byte[] buffer = getBytes("8.jpg");//转为二进制
                            //byte[] buffer = getBytes("C:/2/7.jpg");//转为二进制
                            MemoryStream ms = new MemoryStream(buffer);//显示图片

                            //pictureBox1.Image =System.Drawing. Image.FromStream(ms);
                            Bitmap bmp = new Bitmap(ms);
                            // PictureBox pb = new PictureBox();
                            // pb.Image = System.Drawing.Image.FromStream(ms);
                            //this.ReadRichTextBox.Controls.Add(pb);
                            //pictureBox1.Image =System.Drawing. Image.FromStream(ms);
                            //ReadRichTextBox.AppendText(System.Drawing.Image.FromStream(ms).ToString());
                            Clipboard.SetDataObject(bmp, false);
                            ReadRichTextBox.Paste();
                            ReadRichTextBox.AppendText("\n");

                            // this.ReadRichTextBox.Text = this.ReadRichTextBox.Text + SystemConfiguration.LoginUser.UserName + "    " + DateTime.Now.ToString() + "\r\n";
                            //this.ReadRichTextBox.Text = this.ReadRichTextBox.Text + this.WriteRichTextBox.Text;
                            //  this.ReadRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
                            //this.ReadRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                            //  }
                            // else

                            // {
                            //    this.ReadRichTextBox();
                            //   this.ReadRichTextBox.Text = SystemConfiguration.LoginUser.UserName+ "    " + DateTime.Now.ToString() + "\r\n" + this.WriteRichTextBox.Text;
                            //this.ReadRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                            //  }
                            //信息封装成一个对象
                            //decimal readbox = 1;
                            cs.Content = SystemConfiguration.LoginUser.UserName + "    " + DateTime.Now.ToString() + "\r\n" + this.WriteRichTextBox.Text;
                            cs.SenderID = SystemConfiguration.LoginUser.User_ID;
                            cs.Report_ID = report.Report_ID;
                            cs.ReceiverID = Convert.ToDecimal(report.User_ID);
                            cs.images = Convert.ToBase64String(buffer);

                            // list.Add(cs); 

                            string jsondata = JsonConvert.SerializeObject(cs);
                            //string read = (string)readbox;
                            ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");


                            bool jsonResult = serviceClient.SendMessage(jsondata);
                        }
                        else
                        {
                            cs.Content = SystemConfiguration.LoginUser.UserName + "    " + DateTime.Now.ToString() + "\r\n" + this.WriteRichTextBox.Text;
                            cs.SenderID = SystemConfiguration.LoginUser.User_ID;
                            cs.Report_ID = report.Report_ID;
                            cs.ReceiverID = Convert.ToDecimal(report.User_ID);
                            cs.images = "";
                            string jsondata = JsonConvert.SerializeObject(cs);
                            //string read = (string)readbox;
                            ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");


                            bool jsonResult = serviceClient.SendMessage(jsondata);
                        }

                        //把集合放入json中
                        //反序列化对象  
                        //  JavaScriptSerializer js = new JavaScriptSerializer();
                        // Consultation consultation = js.Deserialize<Consultation>(jsonResult.ToString());
                        ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length; //Set the current caret position at the end
                        ReadRichTextBox.ScrollToCaret();
                        Clipboard.Clear();
                        this.WriteRichTextBox.Clear();
                    }
                    else MessageBox.Show("无消息发不出");
                    //ReadRichTextBox.ReadOnly = true;
                    WriteRichTextBox.Focus();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }


        }


        /// <summary>
        /// 图片转为二进制
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public byte[] getBytes(string filePath)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                image.Dispose();
                return buffer;


            }
        }
        private void ReceiveButton_Click(object sender, EventArgs e)
        {


        }
        public override void FormOnLoad()
        {
            base.FormOnLoad();
            FormMain formMain = SystemConfiguration.FormMain;
            Reports report = formMain.GetSelectedReport();
            //CloudDiagnosis.Entity.Reports report = formMain.GetSelectedReport();

            if (report.Report_ID != 0)
            {




                //if (!report.IsAudited)
                //{
                //    this.ReadRichTextBox.Clear();
                //    MessageBox.Show("该报表还没有经过医生审核，不能发起讨论!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //ReadRichTextBox.ReadOnly = false;
                Consultation cs = new Consultation();
                cs.SenderID = Convert.ToDecimal(report.User_ID);
                cs.Report_ID = report.Report_ID;
                cs.ReceiverID = SystemConfiguration.LoginUser.User_ID;
                //连接服务器
                ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");
                //连接接口
                string jsonResult = serviceClient.GetMessage(cs.SenderID, cs.ReceiverID);
                //反序列化
                List<Consultation> cons = JsonConvert.DeserializeObject<List<Consultation>>(jsonResult);
                //接收信息
                Consultation[] tempcon = new Consultation[cons.Count];
                int i = 0;
                this.ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length;
                //this.ReadRichTextBox.ScrollToCaret();
                this.ReadRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                foreach (Consultation con in cons)
                {

                    tempcon[i] = con;
                    int j = 0;
                    int k = 0;
                    while (tempcon[i].Content[j].ToString() != "\n")

                    {

                        ReadRichTextBox.SelectionColor = Color.Red;
                        Font font = new Font(FontFamily.GenericMonospace, 16, FontStyle.Regular);
                        ReadRichTextBox.SelectionFont = font;
                        ReadRichTextBox.AppendText(tempcon[i].Content[j].ToString());
                        j++;
                        k = j;
                    }
                    ReadRichTextBox.AppendText("\n");
                    k++;
                    while (k != tempcon[i].Content.Length)
                    {
                        ReadRichTextBox.SelectionColor = Color.Green;
                        Font font = new Font(FontFamily.GenericMonospace, 24, FontStyle.Regular);
                        ReadRichTextBox.SelectionFont = font;
                        ReadRichTextBox.AppendText(tempcon[i].Content[k].ToString());
                        k++;
                    }
                    if (tempcon[i].images != "")
                    {
                        byte[] buffer = Convert.FromBase64String(tempcon[i].images);
                        MemoryStream ms = new MemoryStream(buffer);//显示图片

                        //pictureBox1.Image =System.Drawing. Image.FromStream(ms);
                        Bitmap bmp = new Bitmap(ms);
                        // PictureBox pb = new PictureBox();
                        // pb.Image = System.Drawing.Image.FromStream(ms);
                        //this.ReadRichTextBox.Controls.Add(pb);
                        //pictureBox1.Image =System.Drawing. Image.FromStream(ms);
                        //ReadRichTextBox.AppendText(System.Drawing.Image.FromStream(ms).ToString());
                        Clipboard.SetDataObject(bmp, false);
                        ReadRichTextBox.Paste();


                        //  ReadRichTextBox.AppendText("\n");
                    }
                    ReadRichTextBox.AppendText("\n");
                    ReadRichTextBox.SelectionStart = ReadRichTextBox.Text.Length; //Set the current caret position at the end
                    //ReadRichTextBox.ScrollToCaret();
                    Clipboard.Clear();
                    //WriteRichTextBox.Focus();
                    //  ReadRichTextBox.ReadOnly = true;
                }

            }

        }
        Cutter cutter = null;

        private void btnCutter_Click(object sender, EventArgs e)
        {

            // 新建一个和屏幕大小相同的图片
            Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);

            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics g = Graphics.FromImage(CatchBmp);

            // 把屏幕图片拷贝到我们创建的空白图片 CatchBmp中
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));

            // 创建截图窗体
            cutter = new Cutter();

            // 指示窗体的背景图片为屏幕图片
            cutter.BackgroundImage = CatchBmp;
            // 显示窗体
            //cutter.Show();
            // 如果Cutter窗体结束，则从剪切板获得截取的图片，并显示在聊天窗体的发送框中
            if (cutter.ShowDialog() == DialogResult.OK)
            {
                IDataObject iData = Clipboard.GetDataObject();
                DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    WriteRichTextBox.Paste(format);

                    // 清楚剪贴板的图片
                    //  Clipboard.Clear();
                }
            }
        }
        private void GlobalKeyProcess()
        {
            this.WindowState = FormWindowState.Minimized;
            // 窗口最小化也需要一定时间
            Thread.Sleep(200);
            btnCutter.PerformClick();
        }

        /// <summary>
        /// 重写WndProc()方法，通过监视系统消息，来调用过程
        /// 监视Windows消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //如果m.Msg的值为0x0312那么表示用户按下了热键
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    if (m.WParam.ToString() == "100")
                    {
                        GlobalKeyProcess();
                    }

                    break;
            }

            // 将系统消息传递自父类的WndProc
            base.WndProc(ref m);
        }

        private void ReadRichTextBox_MouseEnter(object sender, EventArgs e)
        {
            this.ReadRichTextBox.Enabled = true;
        }

        private void ReadRichTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.ReadRichTextBox.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormOnLoad();
        }

        private void toolbarItemQueryData_Click(object sender, EventArgs e)
        {
            FormMain fromMain = SystemConfiguration.FormMain;
            Reports report = fromMain.GetSelectedReport();
            if (report.IsAudited == false && report.PatientName != null)
            {
                MessageBox.Show("该报告未经审核，无法执行下载操作");
            }
            else if (report.PatientName == null)
            {
                MessageBox.Show("请先选择需要下载的报告");
            }
            else
            {
                FolderBrowserDialog BrowDialog = new FolderBrowserDialog();
                string path = BrowDialog.SelectedPath;
                string fileName = Console.ReadLine();
                FormReportQuery formReportQuery = new FormReportQuery();
                formReportQuery.ExportExcel(fileName);
            }

        }
    }
}
