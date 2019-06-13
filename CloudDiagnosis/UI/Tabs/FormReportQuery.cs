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
using CloudDiagnosis.UI.Tools;
using CloudDiagnosis.UI.Tabs;
using DevComponents.DotNetBar;
using CloudDiagnosis.Entity;
using static CloudDiagnosis.FormMain;
using System.Web.Script.Serialization;
using System.IO;
using Microsoft.Office.Interop.Excel;


namespace CloudDiagnosis.UI.Tabs
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormReportQuery : FormTabBase
    {

        public FormReportQuery()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

        }

        private void toolbarItemDicomDisplay_Click(object sender, EventArgs e)
        {
            
            //FormDicomDisplay formDicomDisplay = new FormDicomDisplay();
            //formDicomDisplay.Show();
            //ITK - SNAP.exe - g d:/ 1_0007358162_ET1.nii.gz - s d:/ 1_0007358162_ET1_seg1.nii.gz
            //string mainImageFile = "E:/IPV6/1_0007358162_ET1.nii.gz";
            //string segmentationImageFile = "E:/IPV6/1_0007358162_ET1_seg1.nii.gz";
            if (string.IsNullOrEmpty(textBoxLocation.Text) && string.IsNullOrEmpty(textBoxLocationSeg.Text))
            {
                MessageBox.Show("影像查看失败，请先选择病例！");

            }
            else
            {
                if ((System.IO.File.Exists(textBoxLocation.Text)) && (System.IO.File.Exists(textBoxLocationSeg.Text)))
                {
                    string mainImageFile = textBoxLocation.Text;
                    string segmentationImageFile = textBoxLocationSeg.Text;

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
                    string imageFile = textBoxLocation.Text;
                    string maskFile = textBoxLocationSeg.Text;
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
                            FormMain fromMain = SystemConfiguration.FormMain;
                            Reports report = fromMain.GetSelectedReport();
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
                            textBoxLocation.Text = fileName;
                            textBoxLocationSeg.Text = fileNameSeg;
                            report.StudyLocalDirectory = fileName;
                            report.StudyLocalDirectorySeg = fileNameSeg;
                            MessageBox.Show("影像文件" + "\n" + imageFileName + "\n" + maskFileName + "\n" + "已下载到本地" + path, "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("影像文件" + "\n" + textBoxLocation.Text + "\n" + textBoxLocationSeg.Text + "\n" + "不存在", "警告");
                    }
                }

            }
        }

        public void toolbarItemConsultation_Click(object sender, EventArgs e)
        {
            //FormConsultation formConsultation = new FormConsultation();
            //formConsultation.ShowDialog(); 
            //InitializeComponent();
            //FormMain formain = new FormMain();
            //formain.change();
        }


        /// <summary>
        /// 下载报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ExportExcel(fileName);
            }
        }
        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="fileName">默认文件名</param>
        /// <param name="listView">数据源，一个页面上的ListView控件</param>
        /// <param name="titleRowCount">标题占据的行数，为0表示无标题</param>
        public void ExportExcel(string fileName)
        {
            string saveFileName = "";
            //bool fileSaved = false;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消 
            Microsoft.Office.Interop.Excel.Application xlApp;
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
            }
            catch (Exception)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            finally
            {
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1



            // 手动添加值


            FormMain fromMain = SystemConfiguration.FormMain;
            Reports report = fromMain.GetSelectedReport();
            MergeCells(worksheet, 1, 1, 3, 13, "患者基本情况表");
            MergeCells(worksheet, 4, 1, 5, 2, "姓名");
            MergeCells(worksheet, 6, 1, 7, 2, "年龄");
            MergeCells(worksheet, 8, 1, 9, 2, "性别");
            MergeCells(worksheet, 10, 1, 11, 2, "检查号");
            MergeCells(worksheet, 12, 1, 13, 2, "审核医生");
            MergeCells(worksheet, 14, 1, 24, 2, "检查情况");
            MergeCells(worksheet, 25, 1, 27, 2, "检查评估");
            MergeCells(worksheet, 28, 1, 35, 2, "备注信息");
            MergeCells(worksheet, 4, 3, 5, 13, report.PatientName);
            MergeCells(worksheet, 6, 3, 7, 13, report.PatientAge.ToString());
            MergeCells(worksheet, 8, 3, 9, 13, report.PatientSex);
            MergeCells(worksheet, 10, 3, 11, 13, report.PatientID);
            MergeCells(worksheet, 12, 3, 13, 13, report.AuditUserName);
            MergeCells(worksheet, 14, 3, 24, 13, report.StudyDescription);
            MergeCells(worksheet, 25, 3, 27, 13, report.Comment);
            MergeCells(worksheet, 28, 3, 35, 13, report.Content);


            //if (saveFileName != "")
            //    {
            //        try
            //        {
            workbook.Saved = true;
            workbook.SaveCopyAs(saveFileName);
            //            //fileSaved = true;
            //        }
            //        catch (Exception ex)
            //        {
            //            //fileSaved = false;
            //            MessageBox.Show("导出文件时出错,文件可能正被打开！\n " + ex.Message);
            //        }
            //       finally
            //       {
            //        }
            //}

            xlApp.Quit();
            GC.Collect();//强行销毁             
            MessageBox.Show(fileName + "报告已下载到本地", "提示", MessageBoxButtons.OK);
        }

        /// <summary> 
        /// 合并单元格，并赋值，对指定WorkSheet操作 
        /// </summary> 
        /// <param name="sheetIndex">WorkSheet索引</param> 
        /// <param name="beginRowIndex">开始行索引</param> 
        /// <param name="beginColumnIndex">开始列索引</param> 
        /// <param name="endRowIndex">结束行索引</param> 
        /// <param name="endColumnIndex">结束列索引</param> 
        /// <param name="text">合并后Range的值</param> 
        public void MergeCells(Microsoft.Office.Interop.Excel.Worksheet workSheet, int beginRowIndex, int beginColumnIndex, int endRowIndex, int endColumnIndex, string text)
        {
            Microsoft.Office.Interop.Excel.Range range = workSheet.Range[workSheet.Cells[beginRowIndex, beginColumnIndex], workSheet.Cells[endRowIndex, endColumnIndex]];
            range.ClearContents();                    //先把Range内容清除，合并才不会出错 
            range.MergeCells = true;
            range.WrapText = true;
            range.Value2 = text;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        }





        //private void buttonOpenDirectory_Click(object sender, EventArgs e)
        //{

        //}


        public override void FormOnLoad()
        {
            base.FormOnLoad();
            FormMain fromMain = SystemConfiguration.FormMain;
            CloudDiagnosis.Entity.Reports report = fromMain.GetSelectedReport();

            if (report != null)
            {
                textBoxUploadTime.Text = report.RequestTime;
                textBoxLocation.Text = report.StudyLocalDirectory;
                textBoxLocationSeg.Text= report.StudyLocalDirectorySeg; 
                textBoxPatientName.Text = report.PatientName;
                textBoxAge.Text = report.PatientAge.ToString();
                textBoxPatientSex.Text = report.PatientSex;
                textBoxPatientCheckNumber.Text = report.PatientID;
                textBoxCheckDoctorName.Text = report.AuditUserName;
                textBoxCheckInformation.Text = report.StudyDescription;
                textBoxEvaluateInformation.Text = report.Comment;
                textBoxNoteInformation.Text = report.Content;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowDialog();
            textBoxLocation.Text = " " + folderDlg.SelectedPath;
        }

        private void buttonItemReportCheck_Click(object sender, EventArgs e)
        {
            try
            {
                CloudDiagnosis.Entity.Reports report = new CloudDiagnosis.Entity.Reports();
                decimal reportid = SystemConfiguration.report.Report_ID;
                string patientid = textBoxPatientCheckNumber.Text;
                report.Content = textBoxNoteInformation.Text;
                report.Comment = textBoxEvaluateInformation.Text;
                report.StudyDescription = textBoxCheckInformation.Text;
                report.AuditUserID = SystemConfiguration.LoginUser.User_ID;
                report.AuditUserName = SystemConfiguration.LoginUser.UserName;
                // 序列化
                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonReport = js.Serialize(report);


                // 上传
                ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");
                bool ret = serviceClient.UploadInfo(reportid, jsonReport);
                if (ret)
                    MessageBox.Show("上传成功！");
                else
                    MessageBox.Show("上传失败！");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("上传失败！");
            }

        }
    }
}

