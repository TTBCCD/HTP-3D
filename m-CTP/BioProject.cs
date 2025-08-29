using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canondemo
{

    // 项目类，包括 BioProject 类，和 BioProjectList 类。
   
    internal class BioProjectList
    {
        public List<BioProject> projectList;
      

        public BioProjectList()
        {
            projectList = new List<BioProject>();

        }
        public BioProjectList(string filename) // 用于读取已有项目列表，从文件读取
        {
              projectList = new List<BioProject>();
             BioProject bioProject = new BioProject();
            // 读文件，每一行为一个project信息，创建一个new project，add到projectList
            string importExcelPath1 = filename;
            IWorkbook workbook = WorkbookFactory.Create(importExcelPath1);
            ISheet sheet = workbook.GetSheetAt(0);
            // int lastrownum = sheet.LastRowNum;
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);  //读取当前行数据
                if (row != null&&row.GetCell(0).ToString()!="")
                {
                    //LastCellNum 是当前行的总列数
                    bioProject.projectName = row.GetCell(0).ToString();
                    bioProject.projectID = row.GetCell(1).ToString();
                    bioProject.Time = row.GetCell(2).ToString();
                    bioProject.SateName = row.GetCell(3).ToString();
                    bioProject.dataTime =row.GetCell(4).ToString();
                    projectList.Add(bioProject);
                }

            }

        }
        /**
        public void setBioProjectList(string filename, string[] arr) //将新建列表中的4项添加到EXCEL中
        {
            string importExcelPath1 = filename;
            IWorkbook workbook = WorkbookFactory.Create(importExcelPath1);
            ISheet sheet = workbook.GetSheetAt(0);
            // int lastrownum = sheet.LastRowNum;
            IRow row = sheet.GetRow(sheet.LastRowNum+1);
            row.CreateCell(0).SetCellValue(arr[0]);
            row.CreateCell(0).SetCellValue(arr[4]);
            row.CreateCell(0).SetCellValue(arr[6]);
            row.CreateCell(0).SetCellValue(arr[3]);
        }
        **/
        public void addProject(BioProject project1)
        {
            projectList.Add(project1);
        }
        public void deleteProject(long projectSerialId)
        {
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectSerialId == projectList[i].projectSerialId)
                {
                    projectList.RemoveAt(i);
                }
            }

        }

        public BioProject getProject(long projectSerialId) // 用于选择一个项目，返回一个project，用于界面显示
        {
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectSerialId == projectList[i].projectSerialId)
                {
                    return projectList[i];
                }
            }
            return null; //没有找到目标项目
        }

        /**   public void setListView(ListView listView)//往listview传入数据
           {
               for (int i = 0; i < projectList.Count; i++)
               {
                   ListView listView1 = new ListView(projectList[i].);
               }
           }**/
    }

    internal class BioProject
    {
        public string projectName = "";
        public string projectID = "";
        public long projectSerialId = 0;
        public string projectDirectory = ""; // 用于创建项目文件夹
        public DateTime dateTime;
        public string SateName = "";//实验站名称
        public string Time = "";//作物物种
        public string dataTime = "";
        // 当前project需要的各类设置参数，即将被task类用于执行操作
        public RGBSettings rgbSettings;
        public ThermalSettings thermalSettings;
        public HyperSettings hyperSettings;
        public RailCarSettings railCarSettings;
       // public List<RailCarSettings> railCarSettings1;


        public BioProject() //创建项目时，使用空的项目名称，ID，目录等信息
        {
            dateTime = DateTime.Now; //只有当实例化的时候，才会获得当前时间
            projectSerialId = dateTime.Ticks; //当前时间Ticks，1毫秒=10000Ticks
      
        }

        public BioProject(string ProjectName, string ProjectID, string ProjectDirectory) //创建项目时，指定项目名称，ID，目录等信息。用于新建项目
        {
            projectName = ProjectName;
            projectID = ProjectID;
            projectDirectory = ProjectDirectory;
            dateTime = DateTime.Now; //只有当实例化的时候，才会获得当前时间
            projectSerialId = dateTime.Ticks; //当前时间Ticks，1毫秒=10000Ticks
        }

        public void loadSettings(string filepath)//
        {
            BioProject bioProject = new BioProject();
            bioProject.ReadHyperSettings(filepath);
            bioProject.ReadRailCarSettings(filepath);
            bioProject.ReadRGBSettings(filepath);
            // 读取这个project的文件夹里的相机和railCar的setting 共4个表（这些表保存的是上一次结束时候的设置）
            // 赋值给上述各个settings， 如rgbSettings
        }


        public void writeSettingsToFile(string filepath,int x,int y, TextBox textBox)//随着界面数值改变，直接改写到EXCEL中
        {
            // 将当前修改后的各种settings，一个一个的保存到对应文件中
            string Path = filepath ;
            IWorkbook workbook = WorkbookFactory.Create(Path);
            ISheet sheet = workbook.GetSheetAt(0);
            string text1 = Convert.ToString(textBox);
            sheet.CreateRow(x).CreateCell(y).SetCellValue(text1);

        }
        public void ReadRailCarSettings(string filepath)//获取数据表的小车设置，建立一个USER时就要生成一个默认设置参数
        {
            //List<RailCarSettings> railCarSettings1 = new List<RailCarSettings>();
            // UserLogin userLogin = new UserLogin();
            string Path = filepath;
            IWorkbook workbook = WorkbookFactory.Create(Path);
            ISheet sheet = workbook.GetSheet("sheet1");
            // int lastrownum = sheet.LastRowNum;
           
            sheet.CreateRow(0).CreateCell(0).SetCellValue("RailcareForwardSpeed");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("RailcareBackwardSpeed");
            sheet.CreateRow(2).CreateCell(0).SetCellValue("SlideForwardSpeed");
            sheet.CreateRow(3).CreateCell(0).SetCellValue("SlideBackwardSpeed");
            sheet.CreateRow(4).CreateCell(0).SetCellValue("ReelsForwardSpeed");
            sheet.CreateRow(5).CreateCell(0).SetCellValue("ReelsBackwardSpeed");
            sheet.CreateRow(6).CreateCell(0).SetCellValue("TravelsSetting");
            sheet.CreateRow(7).CreateCell(0).SetCellValue("FlatForwardSpeed");
            sheet.CreateRow(8).CreateCell(0).SetCellValue("FlatBackwardSpeed");
            sheet.GetRow(0).CreateCell(1).SetCellValue(railCarSettings.TrolleyForwardSpeed);
            sheet.GetRow(1).CreateCell(1).SetCellValue(railCarSettings.TrolleyBackwardSpeed);
            sheet.GetRow(2).CreateCell(1).SetCellValue(railCarSettings.SlideForwardSpeed);
            sheet.GetRow(3).CreateCell(1).SetCellValue(railCarSettings.SlideBackwardSpeed);
            sheet.GetRow(4).CreateCell(1).SetCellValue(railCarSettings.ReelsForwardSpeed);
            sheet.GetRow(5).CreateCell(1).SetCellValue(railCarSettings.ReelsBackwardSpeed);
            sheet.GetRow(6).CreateCell(1).SetCellValue(railCarSettings.TravelsSetting);
            sheet.GetRow(7).CreateCell(1).SetCellValue(railCarSettings.FlatForwardSpeed);
            sheet.GetRow(8).CreateCell(1).SetCellValue(railCarSettings.FlatBackwardSpeed);

            FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();

        }
        public void ReadHyperSettings(string filepath)//获取高光谱数据表中参数
        {
            // UserLogin userLogin = new UserLogin();
            string Path = filepath ;
            IWorkbook workbook = WorkbookFactory.Create(Path);
            ISheet sheet = workbook.GetSheet("sheet1");
            // int lastrownum = sheet.LastRowNum;
            //IRow row = sheet.GetRow(i);
            sheet.CreateRow(0).CreateCell(0).SetCellValue("FrameRateAbs");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("FrameRateEnable");
            sheet.CreateRow(2).CreateCell(0).SetCellValue("ExposureTime");
            sheet.CreateRow(3).CreateCell(0).SetCellValue("HyperR");
            sheet.CreateRow(4).CreateCell(0).SetCellValue("HyperG");
            sheet.CreateRow(5).CreateCell(0).SetCellValue("HyperB");
            sheet.GetRow(0).CreateCell(1).SetCellValue(hyperSettings.FrameRateAbs);
            sheet.GetRow(1).CreateCell(1).SetCellValue("true");
            sheet.GetRow(2).CreateCell(1).SetCellValue(hyperSettings.ExposureTime);
            sheet.GetRow(3).CreateCell(1).SetCellValue(hyperSettings.HyperR);
            sheet.GetRow(4).CreateCell(1).SetCellValue(hyperSettings.HyperG);
            sheet.GetRow(5).CreateCell(1).SetCellValue(hyperSettings.HyperB);
            FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();

        }
        public void ReadRGBSettings(string filepath)//获取可见光数据表中参数
        {
            // UserLogin userLogin = new UserLogin();
            string Path = filepath;
            IWorkbook workbook = WorkbookFactory.Create(Path);
            ISheet sheet = workbook.GetSheet("sheet1");
            // int lastrownum = sheet.LastRowNum;
            //IRow row = sheet.GetRow(i);
            //判断RGB参数数据是否正常
            sheet.CreateRow(0).CreateCell(0).SetCellValue("ShutterSpeed");
            sheet.CreateRow(1).CreateCell(0).SetCellValue("IsoSetting");
            sheet.GetRow(0).CreateCell(1).SetCellValue(rgbSettings.ShutterSpeed);
            sheet.GetRow(1).CreateCell(1).SetCellValue(rgbSettings.IsoSetting);
            FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Close();
        }
    }
    
    struct RGBSettings
    {
        public string ShutterSpeed;//设置快门速度
        public string GetTargetAptrue;//?
        public string IsoSetting;//iso设置
        //RGB相机的全部设置参数
    }
    struct ThermalSettings
    {

        //RGB相机的全部设置参数
    }

    struct HyperSettings
    {
        public string FrameRateAbs;//设置高光谱帧频
        public string FrameRateEnable ;//是否启用帧频控制
        public string ExposureTime;//设置积分时间
        public string HyperR;
        public string HyperG;
        public string HyperB;
    }
    struct RailCarSettings
        {
            public string TrolleyForwardSpeed;//小车前进速度设置
            public string TrolleyBackwardSpeed;//小车后退速度设置
            public string SlideForwardSpeed;//滑台前进速度设置
            public string SlideBackwardSpeed;//滑台后退速度设置
            public string ReelsForwardSpeed;//卷线筒前进速度设置
            public string ReelsBackwardSpeed;//卷线筒后退速度设置
            public string TravelsSetting;//小车等距前进设置
            public string FlatForwardSpeed;//平板车前进速度设置
            public string FlatBackwardSpeed;//平板车后退速度设置
        }





   
}



