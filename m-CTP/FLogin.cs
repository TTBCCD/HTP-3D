using Canondemo;
using m_CTP;
using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Windows.Forms;

namespace Sunny.UI.Demo
{
    public partial class FLogin : UILoginForm
    {
        public static string User_path = "";
        public static string ProjectListPath = "";
        public static string TaskListPath = "";
        public static string GlobeUserName = "";
        public FLogin()
        {
            InitializeComponent();
            
        }

        private void FLogin_ButtonLoginClick(object sender, System.EventArgs e)
        {
            //UserName就是封装了界面里用户名输入框的值
            //Password就是封装了界面里密码输入框的值
            if (UserName == "plant" && Password == "123456")
            {
                GlobeUserName = UserName;
                IsLogin = true;
                Hide();
                Form1 form1 = new Form1();
                form1.Show();
                User_path = "D:\\mctp\\" + UserName;
                ProjectListPath = User_path + "\\" + "BioProjectList" + ".xlsx";
                TaskListPath = User_path + "\\" + "TaskList" + ".xlsx";
                CreatFoder();
            }
            else
            {
                this.ShowErrorTip("用户名或者密码错误。");
            }
        }

        private bool FLogin_OnLogin(string userName, string password)
        {
            return true;
        }

        public void CreatFoder() 
        {

            //User_path = "D:\\mctp\\" + User_name;

            //User_path = "E:\\mctp\\"+ User_name; //"E:\\""C:\\Users\\10446\\Desktop\\" 
            //不需要弹出窗体，在窗体用户名和密码处填写信息后点击新用户即可进入程序界面并且生成 用户文件夹
            //Directory.CreateDirectory(UserPath);
            if (Directory.Exists(User_path))
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(User_path);
            }
            ProjectListPath = User_path + "\\" + "BioProjectList" + ".xlsx";//创建项目表
            CreatExcel.UsingCreatExcel(ProjectListPath);
        }

        private void lblTitle_Click(object sender, System.EventArgs e)
        {

        }
    }
}