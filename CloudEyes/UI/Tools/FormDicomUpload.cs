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
using CloudEyes;
using CloudEyes.UI.Tabs;
using DevComponents.DotNetBar;
using CloudEyes.Entity;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using itk.simple;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;


namespace CloudEyes.UI.Tools
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormDicomUpload : FormTabBase
    {

        public FormDicomUpload()
        {
            InitializeComponent();

        }


        private void toolbarItemPredictionAlgorithm_Click(object sender, EventArgs e)
        {
            ////默认智能选中一种算法
            //toolbarItemDDGM11.Checked = false;
            //toolbarItemDGM0N.Checked = false;
            //toolbarItemDGM11.Checked = false;
            //toolbarItemDGM21.Checked = false;
            //toolbarItemGM11.Checked = false;
            //toolbarItemGM1N.Checked = false;
            //toolbarItemVerhulst.Checked = false;
            //设置选中选项
            ButtonItem itemClicked = sender as ButtonItem;
            itemClicked.Checked = !itemClicked.Checked;
        }

        private void toolbarItemQueryData_Click(object sender, EventArgs e)
        {
        }

        private void Predict(string dataPropertyName)
        {
        }

        private void toolbarItemPrediction_Click(object sender, EventArgs e)
        {

            MessageBox.Show("预测数据计算完成！");
        }

        private void toolbarItemPrediction2DB_Click(object sender, EventArgs e)
        {

        }


        private void toolbarItemDataPreprocessing_Click(object sender, EventArgs e)
        {
        }

        private void FormDicomUpload_Load(object sender, EventArgs e)
        {

        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFileLoad_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFileChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = ("医学图像格式文件|*.dcm;*.nii.gz");
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                textBoxFileLoad.Text = " " + openDlg.FileName;
            }
            //textBoxFileLoadSeg.Text = textBoxFileLoad.Text.Replace(".nii.gz", "_seg1.nii.gz");
            //textBoxPatientName.Text = "zhangsan";
            //textBoxPatientSex.Text = "女";
            //textBoxPatientAge.Text = "12";
            //textBoxPatientID.Text = "123456";
            //textBoxReportID.Text = "12345633";
            //richTextBoxDetails.Text = "123131";


         
            }

        
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            string imageFile = textBoxFileLoad.Text;
            string maskFile = textBoxFileLoadSeg.Text;
            string imageFileName = System.IO.Path.GetFileName(imageFile);
            string maskFileName = System.IO.Path.GetFileName(maskFile);
            int i = 0;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty((c as TextBox).Text))
                    {
                        MessageBox.Show("属性不能为空,请返回检查");
                        i++;
                        break;
                    }
                }
            }
            if (i == 0)
            {
               
                
                    Upload();
               
            }
        }
        private void callOnClick(Button btn)
        {
            //建立一个类型  
            Type t = typeof(Button);
            //参数对象  
            object[] p = new object[1];
            //产生方法  
            MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
            //参数赋值。传入函数  
            p[0] = EventArgs.Empty;
            //调用  
            m.Invoke(btn, p);
            return;
        }

        private void Upload()
        {
            //数据上传
            string imageFile = textBoxFileLoad.Text;
            string maskFile = textBoxFileLoadSeg.Text;
            string imageFileName = System.IO.Path.GetFileName(imageFile);
            string maskFileName = System.IO.Path.GetFileName(maskFile);
            Reports report = new Reports();
            report.PatientName = textBoxPatientName.Text;
            report.PatientSex = textBoxPatientSex.Text;
            report.PatientAge = int.Parse(textBoxPatientAge.Text);
            report.PatientID = textBoxPatientID.Text;
            report.StudyDescription = richTextBoxDetails.Text;
            report.StudyLocalDirectory = textBoxFileLoad.Text;
            report.StudyLocalDirectorySeg = textBoxFileLoadSeg.Text;
            report.ImageFilePath = SystemConfiguration.ServerfileStoreDir + imageFileName;
            report.MaskFilePath = SystemConfiguration.ServerfileStoreDir + maskFileName;
            report.User_ID = SystemConfiguration.LoginUser.User_ID;
            Type type = report.GetType();
            System.Reflection.PropertyInfo[] ps = type.GetProperties();
            //FormFileTransfer formFileTransfer = new FormFileTransfer(imageFile, maskFile);
            //if (formFileTransfer.ShowDialog() != DialogResult.OK)                                         //Transfer窗体没有加载出来就显示失败
            //{
            //    MessageBox.Show("影像上传到服务器失败，请联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.Close();
            //    return;
            //}
            //else
            //{                                                                                      //加载出来的情况

                UploadDate(report);
                UploadFile(imageFile, maskFile);
            //}
        }

        //上传
        private void UploadFile(string imageFile, string maskFile)
        {
            bool flag = true;
            byte[] bytes1 = GetBytesByPath(imageFile);
            byte[] bytes2 = GetBytesByPath(maskFile);
            string uploadPath = "MedicalImages";
            string imageFileName = System.IO.Path.GetFileName(imageFile);
            string maskFileName = System.IO.Path.GetFileName(maskFile);
            try
            {
                ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");
                if (serviceClient.UploadFile(bytes1, uploadPath, imageFileName) && serviceClient.UploadFile(bytes2, uploadPath, maskFileName))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
            if (!flag)
            {
                MessageBox.Show("影像上传到服务器失败，请联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("影像信息上传成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;

        }
        public static byte[] GetBytesByPath(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((int)fs.Length);
            fs.Flush();
            fs.Close();
            return bytes;
        }

        private void UploadDate(Reports report) {

            //文件信息上传
            JavaScriptSerializer js = new JavaScriptSerializer();
            string res = js.Serialize(report);
            ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");
            bool isSuccess = false;
            isSuccess = serviceClient.DicomUpload(res);
            //  try { isSuccess = serviceClient.DicomUpload(res); }
            //  catch { DialogResult = DialogResult.OK; }
            if (isSuccess)
            {
                MessageBox.Show("文件信息上传成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ///TODO 错误处理
                MessageBox.Show("文件信息上传失败！");
                this.Close();
            }
        }
        /// <summary>
        /// 将Dicom目录转化为NiFTI格式
        /// </summary>
        /// <param name="dicomPath">Dicom目录</param>
        /// <returns>转化成功之后的.nii.gz文件</returns>
        private string ConvetDicom2NiFTI(string dicomPath)
        {
            ///TODO 吴昌霖继续完成
            SimpleITK.ReadImage(dicomPath);
            string niFTIFilePath = "";
            return niFTIFilePath;
            /*      private static string[] GetFile(String filepath)
        {
            string[] file = null;
            file = Directory.GetFiles(filepath);
            return file;
        }
        public static void Main(string[] args)
        {
            var vs = new VectorString();
            String[] dir = GetFile("C:/Users/dell/Desktop/d2n/T1");
            int time = 0;
            foreach (String fileName in dir)
            {
                if (fileName.EndsWith(".dcm"))
                {
                    string str = dir.GetValue(time).ToString();
                    vs.Add(str);
                    Console.WriteLine(str + "已经添加");
                    time++;

                }
                else {
                    time++;
                }
            }
            time = 0;                                                                                                                                                                                                                                                                            ;
            ImageSeriesReader isr = new ImageSeriesReader();
            isr.SetFileNames(vs);
            //String strr = vs.ToString();
            //Console.WriteLine(strr);
            Image img = SimpleITK.ReadImage(vs);
            //ImageSeriesWriter isw = new ImageSeriesWriter();
            // isw.SetFileNames(vs);
            //bool isTransport = isw.GetUseCompression();
            //Console.WriteLine(isTransport);
            //Console.ReadLine();
            ImageFileWriter isw = new ImageFileWriter();
            //
            isw.SetFileName("C:/Users/dell/Desktop/d2n/dcm2nii.nii.gz");
            isw.Execute(img);
            
        }
    }
}     */

        }

        private void textBoxPatientAge_TextChanged(object sender, EventArgs e)
        {

        }
        private string renameByTime(string name)//重命名
        {

            string ext = System.IO.Path.GetExtension(name);// 获取文件的扩展名，比如 .gif
            string newname = DateTime.Now.ToString("yyyyMMddhhmmss") + ext;//利用时间生成新文件名后再加扩展名生成完整名字
                                                                           //string path = "~/load/" + newname;
                                                                           // FileUpload1.SaveAs(System.Web.HttpContext.Current.Se
            return newname;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void buttonSegFileChoose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("本地是否存在分割文件？" + "\n" + textBoxFileLoadSeg.Text + "\n" + "注：选择“否”按钮将执行分割操作！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                string mainImageFile = textBoxFileLoad.Text;
                string args = "-g " + mainImageFile;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WorkingDirectory = "..\\..\\..\\ITK-SNAP\\bin\\ITK-SNAP.exe";
                System.Diagnostics.Process.Start(process.StartInfo.WorkingDirectory, args);

            }

            if (dr == DialogResult.Yes)
            {

                OpenFileDialog openDlg = new OpenFileDialog();
                openDlg.Filter = ("医学图像格式文件|*.dcm;*.nii.gz");
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    textBoxFileLoadSeg.Text = " " + openDlg.FileName;
                }
         
                //textBoxFileLoadSeg.Text = textBoxFileLoad.Text.Replace(".nii.gz", "_seg1.nii.gz");
                textBoxPatientName.Text = "zhangsan";
                textBoxPatientSex.Text = "女";
                textBoxPatientAge.Text = "12";
                textBoxPatientID.Text = "123456";
                textBoxReportID.Text = "12345633";
                richTextBoxDetails.Text = "123131";
                if (!string.IsNullOrEmpty(textBoxFileLoadSeg.Text))
                {
                    MessageBox.Show("正在预览图像,请稍候！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    string mainImageFile = textBoxFileLoad.Text;
                    string segmentationImageFile = textBoxFileLoadSeg.Text;
                    string args = "-g " + mainImageFile + " -s " + segmentationImageFile;
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.WorkingDirectory = "..\\..\\..\\ITK-SNAP\\bin\\ITK-SNAP.exe";
                    //process.StartInfo.FileName = "..\\..\\..\\DicomViewer\\bin\\Debug\\DicomViewer.exe";
                    //process.StartInfo.FileName = "C:\\Program Files\\ITK-SNAP 3.6\\bin\\ITK-SNAP.exe";
                    //process.StartInfo.Arguments = args;
                    System.Diagnostics.Process.Start(process.StartInfo.WorkingDirectory, args);
                }
            }

            //if ((System.IO.File.Exists(textBoxFileLoadSeg.Text)))
            //{
            //    MessageBox.Show("正在预览图像，请稍后……");
            //    string mainImageFile = textBoxFileLoad.Text;
            //    string segmentationImageFile = textBoxFileLoadSeg.Text;

            //    string args = "-g " + mainImageFile + " -s " + segmentationImageFile;

            //    System.Diagnostics.Process process = new System.Diagnostics.Process();
            //    process.StartInfo.WorkingDirectory = "..\\..\\..\\ITK-SNAP\\bin\\ITK-SNAP.exe";
            //    //process.StartInfo.FileName = "..\\..\\..\\DicomViewer\\bin\\Debug\\DicomViewer.exe";
            //    //process.StartInfo.FileName = "C:\\Program Files\\ITK-SNAP 3.6\\bin\\ITK-SNAP.exe";
            //    //process.StartInfo.Arguments = args;

            //    System.Diagnostics.Process.Start(process.StartInfo.WorkingDirectory, args);
            //}
            //else
            //{
               

            //    if (dr == DialogResult.Yes)
            //    {
            //        string mainImageFile = textBoxFileLoad.Text;
            //        string args = "-g " + mainImageFile;
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        process.StartInfo.WorkingDirectory = "..\\..\\..\\ITK-SNAP\\bin\\ITK-SNAP.exe";
            //        System.Diagnostics.Process.Start(process.StartInfo.WorkingDirectory, args);

            //    }

            //}
            //textBoxFileLoad.Text = null;
            //textBoxFileLoadSeg.Text = null;
            //MessageBox.Show("请重新选择文件！");
            //MessageBox.Show("未能找到" + "\n" + textBoxFileLoadSeg.Text + "\n" + "文件!");
        }
    }
}
