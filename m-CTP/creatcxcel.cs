using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using m_CTP;
using Sunny.UI.Demo;

namespace Canondemo
{
    public class CreatExcel
    {
        public static string[,] arr;// = new string[10000, 8];
        public static string[,] task2 = new string[10000, 5];
        public static int lastrownum = 0;
        public static int lastrownum2 = 0;
        public static string taskpath;
        public static void Excel(string filepath , string[] arr)
        {
           // UserLogin userLogin = new UserLogin();
            //string importExcelPath = userLogin.ProjectListPath;
            IWorkbook workbook = WorkbookFactory.Create(filepath);
            ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
            //int a = sheet.LastRowNum+1;
            sheet.ShiftRows(1, 10000, 1);//插入空白行,
            IRow row1 = sheet.CreateRow(1);//在原有数据下面创建新的数据行创建新的数据行
                                           //IRow row = (IRow)sheet.GetRow(a);//获取行

            //string Text = row.GetCell(1).ToString();
            for (int i = 0; i < CreatInform.du.Length; i++) {
                
                row1.CreateCell(i).SetCellValue(CreatInform.du[i]);//设置第一行第一列值
            }
            //导出excel
            FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();
        }
        public static void DataExcel(string filepath)
        {

            string importExcelPath1 = filepath;
            // string exportExcelPath1 = "C:\\Apps\\export.xlsx";
            IWorkbook workbook = WorkbookFactory.Create(importExcelPath1);
            ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
            //IRow row = sheet.GetRow(0);
            lastrownum = sheet.LastRowNum;
            arr = new string[lastrownum+1, 8];
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);  //读取当前行数据
                if (row != null&&row.GetCell(0).ToString()!="" )
                {
                    //LastCellNum 是当前行的总列数
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        //读取该行的第j列数据
                        arr[i, j] = row.GetCell(j).ToString();
                    }
                }

            }
        }
        public static void UsingCreatExcel(string taskpath )//创建EXCEL表
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            //创建一个Sheet
            ISheet sheet = workbook.CreateSheet("sheet1");
            IRow row1 = sheet.CreateRow(0);
            row1.CreateCell(0).SetCellValue("Project Name");
            row1.CreateCell(1).SetCellValue("Person Name");
            row1.CreateCell(2).SetCellValue("Dept.");
            row1.CreateCell(3).SetCellValue("Time");
            row1.CreateCell(4).SetCellValue("Project ID");
            row1.CreateCell(5).SetCellValue("Person Name (En.)");
            row1.CreateCell(6).SetCellValue("Site Name");
            row1.CreateCell(7).SetCellValue("Date and Time");
            FileStream filestream = new FileStream(taskpath, FileMode.Create);
            workbook.Write(filestream);
            workbook.Close();
            filestream.Close();
            filestream.Dispose();
        }
        public static void UsingCreatExcelTask(string taskpath)//创建EXCEL表
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            //创建一个Sheet
            ISheet sheet = workbook.CreateSheet("sheet1");
            FileStream filestream = new FileStream(taskpath, FileMode.Create);
            workbook.Write(filestream);
            workbook.Close();
            filestream.Close();
            filestream.Dispose();
        }

        //public static void creattaskdata(string filepath)//更新任务数据
        //{
            
        //    string taskexcel = filepath;
        //    IWorkbook workbook = WorkbookFactory.Create(taskexcel);
        //    ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
        //    //sheet.ShiftRows(1, 10000, 1);//插入空白行,
        //    IRow row2 = sheet.CreateRow(sheet.LastRowNum+1);//在原有数据下面创建新的数据行创建新的数据行
        //                                                  //IRow row = (IRow)sheet.GetRow(a);//获取行
        //    //string Text = row.GetCell(1).ToString();
        //    for (int i = 0; i < MainForm.taskdata.Length; i++)
        //    {
        //        //设置第一行第一列值,更多方法请参考源官方Demo
        //        row2.CreateCell(i).SetCellValue(MainForm.taskdata[i]);//设置第一行第一列值
        //    }
        //    //导出excel
        //    FileStream fs = new FileStream(taskexcel, FileMode.Create, FileAccess.ReadWrite);
        //    workbook.Write(fs);
        //    fs.Close();
        //}
        //public static void deletecxceldata(string filepath) 
        //{
        //    string taskexcel = filepath;
        //    IWorkbook workbook = WorkbookFactory.Create(taskexcel);
        //    ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
        //    sheet.ShiftRows(MainForm.deleteLine+1, 10000, -1);
        //    /*
        //    for (int i = 1; i < sheet.LastRowNum+1; i++) 
        //    {
        //        IRow row3 = sheet.GetRow(i-1);
        //        row3.GetCell(0).SetCellValue(i);
        //    }*/
        //    FileStream fs = new FileStream(taskexcel, FileMode.Create, FileAccess.ReadWrite);
        //    workbook.Write(fs);
        //    fs.Close();
        //}
        public static void UpdateParameter(string filepath,int i ,int j,string str) //更新参数设置
        {
            string taskexcel = filepath;
            // string exportExcelPath1 = "C:\\Apps\\export.xlsx";
            IWorkbook workbook = WorkbookFactory.Create(taskexcel);
            ISheet sheet = workbook.GetSheetAt(0);//获取第一个工作薄
            //IRow row = sheet.GetRow(0);
              // lastrownum2 = sheet.LastRowNum;
            IRow row3 = sheet.GetRow(i);  //读取当前行数据
            //LastCellNum 是当前行的总列数
            //读取该行的第j列数据
            row3.GetCell(j).SetCellValue(str);  
        }
        public static void CopyData(string folderpath , string filename,string oldfilepath) //复制文件
        {
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            //当前文件如果不用新的文件名，那么就用原文件文件名
            string fileName = Path.GetFileName("\\"+filename);
            //这里可以给文件换个新名字，如下：
            //string fileName = string.Format("{0}.{1}", "newFileText", "txt");

            //目标整体路径
            string targetPath = Path.Combine(folderpath, fileName);

            //Copy到新文件下
            FileInfo file = new FileInfo(oldfilepath);
            if (file.Exists)
            {
                //true 为覆盖已存在的同名文件，false 为不覆盖
                file.CopyTo(targetPath, true);
            }

        }
        public static bool StringCheck(string str)
        {
            bool a = str.Contains('*');
            bool b = str.Contains('?');
            bool c = str.Contains('/');
            bool d = str.Contains('\\');
            bool f = str.Contains('>');
            bool g = str.Contains('<');
            bool h = str.Contains('|');
            bool i = str.Contains(':');
            if (!a && !b && !c && !d && !f && !g && !h && !i)//不含有上述字符
            {
                return true;
            }
            else
            { 
                return false;
              
            }
           

        }
        public static void CreatFile(string str)
        {
            if (!System.IO.File.Exists(str))
            {
                FileStream stream = System.IO.File.Create(str);
                stream.Close();
                stream.Dispose();
                using (StreamWriter writer = new StreamWriter(str, true))
                {
                    string str1 = "UserName" + "," + "ProjectId" + "," + "ProjectName" + "," + "ProjectDate" + "," + "TaskId" + "," + "TaskName"
                        + "," + "TaskDate" + "," + "PlotId" + "," + "PlotName" + "," + "PlotProperty1" + "," + "PlotProperty2" + "," + "PlotProperty3" + ","
                        + "PlotProperty4" + "," + "PlotProperty5" + "," + "CameraId" + "," + "DataType"
                        + "," + "CaliFile" + "," + "DataId" + "," + "DataName"+","+ "DataDate";

                    writer.WriteLine(str1);
                    writer.Flush();
                    writer.Close();
                }
            }                                                           // CreatExcel.UsingCreatExcelTask(interExcelFile);

        }
        public static void InterData(string filepath, string CAMERAid, string CaliFile, string datatype, string dataId,string dataName)
        {
            if (CaliFile == "1")//采集参考板走这段函数
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    string str1 =
                    FLogin.GlobeUserName + "," +
                    UserInform.ProjectId + "," +
                    UserInform.Projectselect + "," +
                    UserInform.ProjectTime + "," +
                    DataAcquisition.GlobleTaskID + "," +
                    Path.GetFileName(DataAcquisition.GlobleTaskPath) + "," +
                    DataAcquisition.TaskTime + "," +
                    "null" + "," +
                    "null" + "," +
                    "null" + "," +
                    "null" + "," +
                    "null" + "," +
                    "null" + "," +
                    "null" + "," +
                    CAMERAid + "," +
                    datatype + "," +
                    CaliFile + "," +
                    dataId + "," +
                    dataName +","+
                    DateTime.Now.ToString("yyyy/M/d");
                    writer.WriteLine(str1);
                    writer.Flush();
                    writer.Close();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    string str1 =
                     FLogin.GlobeUserName + "," +
                     UserInform.ProjectId + "," +
                     UserInform.Projectselect + "," +
                     UserInform.ProjectTime + "," +
                     DataAcquisition.GlobleTaskID + "," +
                     Path.GetFileName(DataAcquisition.GlobleTaskPath) + "," +
                     DataAcquisition.TaskTime + "," +
                     DataAcquisition.GloblePlotID + "," +
                     DataAcquisition.PlotName + "," +
                     "null" + "," +
                     "null" + "," +
                     "null" + "," +
                     "null" + "," +
                     "null" + "," +
                     CAMERAid + "," +
                     datatype + "," +
                     CaliFile + "," +
                     dataId + "," +
                     dataName + "," +
                     DateTime.Now.ToString("yyyy/M/d");
                    writer.WriteLine(str1);
                    writer.Flush();
                    writer.Close();
                }

            }
        }
        public static void CreatDataFile(string str)
        {
            if (!System.IO.File.Exists(str))
            {
                FileStream stream = System.IO.File.Create(str);
                stream.Close();
                stream.Dispose();
                using (StreamWriter writer = new StreamWriter(str, true))
                {
                    string str1 = "Time" + "," + "Name" + "," + "Watering"+","+ "Quality";
                    writer.WriteLine(str1);
                    writer.Flush();
                    writer.Close();
                }
            }                                                           // CreatExcel.UsingCreatExcelTask(interExcelFile);

        }

        public static void WriteData(string filepath,string plotname,int wa,double we ) 
        {
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                string str1 =
                DateTime.Now.ToString("yyyy/M/d")+","+
                plotname +","+
                wa.ToString("f2")+","+
                we.ToString("f2");
                writer.WriteLine(str1);
                writer.Flush();
                writer.Close();
            }
        }
        public static void CreateDirectory(string str) 
        {
            if (!Directory.Exists(str))
            {
                Directory.CreateDirectory(str);

            }
            else
            {
                //MessageBox.Show("该路径已存在");
            }
        }

    }
}
