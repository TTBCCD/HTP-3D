using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Canondemo;
using Sunny.UI;
using Sunny.UI.Demo;

namespace m_CTP
{
    public partial class UserInform : UIPage
    {
        public static string Projectselect = "";
        public static string ProjectTime = "";
        public static string GlobleProjectPath = "";
        public static string ProjectId = "";
        public static bool ProjectSelected = false;
        public UserInform()
        {
            InitializeComponent();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            Form1.ProgramChecking = "创建新项目";
            CreatInform creatInform = new CreatInform();
            creatInform.Show();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            // UserLogin userLogin = new UserLogin();
            listView2.Items.Clear();
            CreatExcel.DataExcel(FLogin.ProjectListPath);
            int v = CreatExcel.lastrownum;
            for (int i = 0; i < v + 1; i++)
            {
                if (i == 0)
                {
                    ListViewItem item2 = new ListViewItem();
                    string[] first2 = { "", "", "" };
                    string[] second2 = { "", "", "" };
                    item2.SubItems.AddRange(first2);
                    item2.SubItems.AddRange(second2);
                    listView2.Items.Add(item2);

                }
                else
                {
                    //这里i需要是字符型的，所以转换一下，i为第1列的内容
                    ListViewItem item = new ListViewItem(CreatExcel.arr[i, 7]);
                    string[] first = { CreatExcel.arr[i, 4], CreatExcel.arr[i, 0], CreatExcel.arr[i, 2], CreatExcel.arr[i, 1] };
                    item.SubItems.AddRange(first);
                    listView2.Items.Add(item);
                }

            }
            if (listView2.Items != null && listView2.Items.Count != 0)
            {
                uiButton1.Enabled = true;
                uiButton3.Enabled = true;
                Form1.ProgramChecking = "项目添加列表视图成功，在表中选择实验项目";
            }
            else
            {
                Form1.ProgramChecking = "项目添加列表失败，项目为空，请新建项目";
            }
        }

        private void ListView_Selected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                return;
            else
            {
                //选中点击那一行的第一列的值，索引值必须是0，而且无论点这一行的第几列，选中的都是这一行第一列的值 ，如果想获取这一行除第一列外的值，则用subitems获取，[]中为索引，从1开始。
                //string first = listView2.SelectedItems[0].Text;
                Projectselect = listView2.SelectedItems[0].SubItems[2].Text;//获取项目名
                ProjectTime = listView2.SelectedItems[0].SubItems[0].Text;//项目创建时间
                for (int i = 0; i < CreatExcel.lastrownum; i++)//将作物物种填写任务预览中
                {
                    if (CreatExcel.arr[i, 0] == Projectselect)
                    {

                    }
                }
                Form1.ProgramChecking = "项目已选中，请点击“加载项目”";
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            // 更新窗体的每个页面的所有显示数值
            // 为了给用户知道上次使用的设置，用户可以在此基础上修改一些参数，并且保存
            // 注意：每处修改保存的函数，都需要更新bioProject里面的各种settings，同时将bioProject里面的settings写入到文件中
            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("列表未刷新！！！请刷新设备");
                return;
            }
            if (Projectselect == null|| Projectselect =="")
            {
                MessageBox.Show("项目未选中！！！请选中项目");
                return;
            }
            
            GlobleProjectPath = FLogin.User_path + "\\" + Projectselect;//获取项目文件夹的路径
            ProjectId = listView2.SelectedItems[0].SubItems[1].Text;
            ProjectSelected = true;
            //task.ReadTaskExcle(UserLogin.TaskListPath,listView1);//将上个项目的任务加载到此项目Listview中
            //plots_static = field.importPlotsFromFile("D:\\plots.csv",listView3);//将plots赋值给静态变量//德会注释掉2024.4.27，手动选择项目
            Form1.ProgramChecking = "项目加载成功";
          
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string path = FLogin.User_path;

            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("路径不存在");
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < CreatExcel.lastrownum + 1; i++)
            {
                string str = CreatExcel.arr[i, 0];
                if (Projectselect == str)
                {
                    string data = "项目名称： " + CreatExcel.arr[i, 0] + '\n' +
                                  "我的名字： " + CreatExcel.arr[i, 1] + '\n' +
                                  "单位部门： " + CreatExcel.arr[i, 2] + '\n' +
                                  "作物物种： " + CreatExcel.arr[i, 3] + '\n' +
                                  "项目编号： " + CreatExcel.arr[i, 4] + '\n' +
                                  "姓名英文缩写： " + CreatExcel.arr[i, 5] + '\n' +
                                  "实验站名称： " + CreatExcel.arr[i, 6] + '\n' +
                                  "日期时间： " + CreatExcel.arr[i, 7];
                    MessageBox.Show(data);
                    Form1. ProgramChecking = "项目信息";
                }
            }
        }
    }
}
