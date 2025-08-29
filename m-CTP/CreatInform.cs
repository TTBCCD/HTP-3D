using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Canondemo;
using Sunny.UI.Demo;
using System.IO;

namespace m_CTP
{
    public partial class CreatInform : Form
    {
        public static string ALLProjectName = "";
        BioProjectList bioProjectList;
        public static string[] du = new string[] { "", "", "", "", "", "", "", "" };
        public static string ProjectFolderPath = "";
        public CreatInform()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private static readonly char[] SpecialChars = "!@#$%^&*()/.,?`+=".ToCharArray();
        private void ProjectName_TextChanged(object sender, EventArgs e)//判断
        {
            int indexOf = ProjectName.Text.IndexOfAny(SpecialChars);
            if (indexOf != -1)
            {
                uiLabel9.Text = "不允许包含特殊符号";
                uiLabel9.ForeColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < ProjectName.Text.Length; i++)
                {
                    if ((int)ProjectName.Text[i] > 127)
                    {
                        uiLabel9.Text = "不允许包含汉字";
                        uiLabel9.ForeColor = Color.Red;
                        return;
                    }
                    else 
                    {
                        if (ProjectName.Text == "")
                        {
                            uiLabel9.Text = "未填写";
                            uiLabel9.ForeColor = Color.Green;
                        }
                        else
                        {
                            uiLabel9.Text = "填写正常";
                            uiLabel9.ForeColor = Color.Green;
                        }
                        
                    }
                    
                      
                }
            }
        }

        private void ProjectName_Click(object sender, EventArgs e)
        {
            //ProjectName.Clear();
        }

        private void UserName_Click(object sender, EventArgs e)
        {
            //UserName.Clear();
        }

        private void UnitName_Click(object sender, EventArgs e)
        {
            //UnitName.Clear();
        }

        private void CropSpecies_Click(object sender, EventArgs e)
        {
           // CropSpecies.Clear();
        }

        private void ProjectID_Click(object sender, EventArgs e)
        {
            //ProjectID.Clear();
        }

        private void User_Click(object sender, EventArgs e)
        {
            //User.Clear();
        }

        private void StationName_Click(object sender, EventArgs e)
        {
            //StationName.Clear();
        }

        private void CreatDate_Click(object sender, EventArgs e)
        {
            //CreatDate.Clear();
        }

       

        private void Empty_Click_1(object sender, EventArgs e)
        {
            ProjectName.Clear();
            UserName.Clear();
            UnitName.Clear();
            CropSpecies.Clear();
            ProjectID.Clear();
            User.Clear();
            StationName.Clear();
            uiDatePicker1.Clear();
            //CreatDate.Clear();
        }

        private void Creat_Click(object sender, EventArgs e)
        {
            if (ProjectName.Text == "" || UserName.Text == "" || UnitName.Text == "" || CropSpecies.Text == "" ||
               ProjectID.Text == "" || User.Text == "" || StationName.Text == "" || uiDatePicker1.Text == ""
               )
            {
                MessageBox.Show("表格请填写完整！！！");
            } 
            else if (uiLabel9.ForeColor==Color.Red||
                uiLabel9.ForeColor == Color.Red ||
                uiLabel10.ForeColor == Color.Red ||
                uiLabel11.ForeColor == Color.Red ||
                uiLabel12.ForeColor == Color.Red ||
                uiLabel13.ForeColor == Color.Red ||
                uiLabel14.ForeColor == Color.Red ||
                uiLabel15.ForeColor == Color.Red 
                ) 
            {
                MessageBox.Show("信息表填写不正确，请检查红色提示框！！！");
            }
            else
            {
                Hide();
                for (int i = 0; i < du.Length; i++)
                {
                    if (i == 0) du[0] = ProjectName.Text;
                    else if (i == 1) du[1] = UserName.Text;
                    else if (i == 2) du[2] = UnitName.Text;
                    else if (i == 3) du[3] = CropSpecies.Text;
                    else if (i == 4) du[4] = ProjectID.Text;
                    else if (i == 5) du[5] = User.Text;
                    else if (i == 6) du[6] = StationName.Text;
                    else if (i == 7) du[7] = uiDatePicker1.Text;
                }
                if (CreatExcel.StringCheck(ProjectName.Text))
                {
                    bioProjectList = new BioProjectList(FLogin.ProjectListPath);

                    for (int i = 0; i < bioProjectList.projectList.Count; i++) //判断该项目是否已经存在
                    {
                        string str = bioProjectList.projectList[i].projectName;

                        if (str == du[0])
                        {
                            MessageBox.Show("该项目已存在");
                            return;
                        }
                    }
                    CreatExcel.Excel(FLogin.ProjectListPath, du);//将数据添加到project表中
                    ProjectFolderPath = FLogin.User_path + "\\" + du[0];
                    if (!Directory.Exists(ProjectFolderPath))
                    {
                        Directory.CreateDirectory(ProjectFolderPath);

                    }
                    else
                    {
                        MessageBox.Show("该路径已存在");
                    }
                   
                }
                else
                {
                    MessageBox.Show("用户名不能包含下列任何字符：* / ? \\ > < :");
                }
            }
        }

        private void CreatInform_Load(object sender, EventArgs e)
        {
            uiDatePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
            int indexOf = UserName.Text.IndexOfAny(SpecialChars);
            if (indexOf != -1)
            {
                uiLabel10.Text = "不允许包含特殊符号";
                uiLabel10.ForeColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < UserName.Text.Length; i++)
                {
                    if ((int)UserName.Text[i] > 127)
                    {
                        uiLabel10.Text = "不允许包含汉字";
                        uiLabel10.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        if (UserName.Text == "")
                        {
                            uiLabel10.Text = "未填写";
                            uiLabel10.ForeColor = Color.Green;
                        }
                        else
                        {
                            uiLabel10.Text = "填写正常";
                            uiLabel10.ForeColor = Color.Green;
                        }

                    }


                }
            }
        }

        private void UnitName_TextChanged(object sender, EventArgs e)
        {
            int indexOf = UnitName.Text.IndexOfAny(SpecialChars);
            if (indexOf != -1)
            {
                uiLabel11.Text = "不允许包含特殊符号";
                uiLabel11.ForeColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < UnitName.Text.Length; i++)
                {
                    if ((int)UnitName.Text[i] > 127)
                    {
                        uiLabel11.Text = "不允许包含汉字";
                        uiLabel11.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        if (UnitName.Text == "")
                        {
                            uiLabel11.Text = "未填写";
                            uiLabel11.ForeColor = Color.Green;
                        }
                        else
                        {
                            uiLabel11.Text = "填写正常";
                            uiLabel11.ForeColor = Color.Green;
                        }

                    }


                }
            }
        }

        private void CropSpecies_TextChanged(object sender, EventArgs e)
        {
            int indexOf = CropSpecies.Text.IndexOfAny(SpecialChars);
            if (indexOf != -1)
            {
                uiLabel12.Text = "不允许包含特殊符号";
                uiLabel12.ForeColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < CropSpecies.Text.Length; i++)
                {
                    if ((int)CropSpecies.Text[i] > 127)
                    {
                        uiLabel12.Text = "不允许包含汉字";
                        uiLabel12.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        if (CropSpecies.Text == "")
                        {
                            uiLabel12.Text = "未填写";
                            uiLabel12.ForeColor = Color.Green;
                        }
                        else
                        {
                            uiLabel12.Text = "填写正常";
                            uiLabel12.ForeColor = Color.Green;
                        }

                    }


                }
            }
        }

        private void ProjectID_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool result = int.TryParse(ProjectID.Text, out i); //i now = 108  
            if (!result)
            {
                uiLabel13.Text = "必须填写9位数字";
                uiLabel13.ForeColor = Color.Red;
            }
            else if (ProjectID.Text.Length != 9)
            {
                uiLabel13.Text = "需要填写9位数字";
                uiLabel13.ForeColor = Color.Red;
            }
            else
            {
                uiLabel13.Text = "填写正常";
                uiLabel13.ForeColor = Color.Green;
            }
        }

        private void User_TextChanged(object sender, EventArgs e)
        {
            int indexOf = User.Text.IndexOfAny(SpecialChars);
            if (indexOf != -1)
            {
                uiLabel14.Text = "不允许包含特殊符号";
                uiLabel14.ForeColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < User.Text.Length; i++)
                {
                    if ((int)User.Text[i] > 127)
                    {
                        uiLabel14.Text = "不允许包含汉字";
                        uiLabel14.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        if (User.Text == "")
                        {
                            uiLabel14.Text = "未填写";
                            uiLabel14.ForeColor = Color.Green;
                        }
                        else
                        {
                            uiLabel14.Text = "填写正常";
                            uiLabel14.ForeColor = Color.Green;
                        }

                    }


                }
            }
        }

        private void StationName_TextChanged(object sender, EventArgs e)
        {
            int indexOf = StationName.Text.IndexOfAny(SpecialChars);
            if (indexOf != -1)
            {
                uiLabel15.Text = "不允许包含特殊符号";
                uiLabel15.ForeColor = Color.Red;
            }
            else
            {
                for (int i = 0; i < StationName.Text.Length; i++)
                {
                    if ((int)StationName.Text[i] > 127)
                    {
                        uiLabel15.Text = "不允许包含汉字";
                        uiLabel15.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        if (StationName.Text == "")
                        {
                            uiLabel15.Text = "未填写";
                            uiLabel15.ForeColor = Color.Green;
                        }
                        else
                        {
                            uiLabel15.Text = "填写正常";
                            uiLabel15.ForeColor = Color.Green;
                        }

                    }


                }
            }
        }
    }
}
