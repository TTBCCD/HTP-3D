using EDSDKLib;
using Org.BouncyCastle.Asn1.Cmp;
using Sunny.UI;
using Sunny.UI.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace m_CTP
{
    public partial class Form1 : UIForm
    {
        public static string ProgramChecking = "";
        public string MutiCameraPath = "C:\\Users\\SF\\Desktop\\test";
        private bool isClosingInProgress = false;
        private CancellationTokenSource closingCancellationToken;
        public Form1()
        {
            InitializeComponent();

            int pageIndex = 1000;

            //uiNavBar1设置节点，也可以在Nodes属性里配置
            uiNavBar1.Nodes.Add("用户信息");
            uiNavBar1.Nodes.Add("设备连接与设置");
            uiNavBar1.Nodes.Add("数据与设置");
            uiNavBar1.Nodes.Add("数据采集");
            uiNavBar1.Nodes.Add("主题");
            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[0], 999);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[0], 61451);
            TreeNode parent = uiNavMenu1.CreateNode("用户信息", 61451, 24, 999);

            //通过设置PageIndex关联，节点文字、图标由相应的Page的Text、Symbol提供
            uiNavMenu1.CreateChildNode(parent, AddPage(new UserInform(), 1000));
            //uiNavMenu1.CreateChildNode(parent, AddPage(new UserTask(),1001));

            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[1], 1500);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[1], 61818);
            parent = uiNavMenu1.CreateNode("设备连接与设置", 61818, 24, 1500);
            //通过设置GUID关联，节点字体图标和大小由UIPage设置
            uiNavMenu1.CreateChildNode(parent, AddPage(new Link(),1501));
            uiNavMenu1.CreateChildNode(parent, AddPage(new UserTask(), 1502));

            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[2], 2000);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[2], 61545);
            parent = uiNavMenu1.CreateNode("数据与设置", 61545, 24, 2000);
            //通过设置GUID关联，节点字体图标和大小由UIPage设置
            uiNavMenu1.CreateChildNode(parent, AddPage(new Motion_Set(), 2001));
            //uiNavMenu1.CreateChildNode(parent, AddPage(new Hyper_Set(), 2002));
           // uiNavMenu1.CreateChildNode(parent, AddPage(new Thermal_Set(), 2003));//深圳项目先注释掉
          //  uiNavMenu1.CreateChildNode(parent, AddPage(new RGB_Set(), 2004));
            uiNavMenu1.CreateChildNode(parent, AddPage(new MutiCamera_Set(), 2005));
            uiNavMenu1.CreateChildNode(parent, AddPage(new Depth_Set(), 2006));
            uiNavMenu1.CreateChildNode(parent, AddPage(new Hyper(), 2007));
            //uiNavMenu1.CreateChildNode(parent, AddPage(new Lidar_Set(), 2005));
            // uiNavMenu1.CreateChildNode(parent, AddPage(new Fluor_Set(), 2006));//深圳项目先注释掉

            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[3], 2500);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[3], 61515);
            parent = uiNavMenu1.CreateNode("数据采集", 61515, 24, 2500);
            //通过设置GUID关联，节点字体图标和大小由UIPage设置
            uiNavMenu1.CreateChildNode(parent, AddPage(new DataAcquisition(), 2501));

            uiNavBar1.SetNodePageIndex(uiNavBar1.Nodes[4], 3000);
            uiNavBar1.SetNodeSymbol(uiNavBar1.Nodes[4], 61502);
            parent = uiNavMenu1.CreateNode("主题", 61502, 24, 3000);
            //通过设置GUID关联，节点字体图标和大小由UIPage设置
            uiNavMenu1.CreateChildNode(parent, AddPage(new FColorful(), 3001));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
           
            //Util.Assert(EDSDK.EdsInitializeSDK(), "Failed to initialize!");//打开软件初始化相机SDK
        }


        private void uiNavMenu1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }

        private void uiSplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiNavBar1_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            switch (menuIndex)
            {
                case 4:
                    UIStyle style = (UIStyle)pageIndex;
                    if (pageIndex < UIStyle.Colorful.Value())
                        StyleManager.Style = style;
                    else
                        uiNavMenu1.SelectPage(pageIndex);
                    break;
                default:
                    uiNavMenu1.SelectPage(pageIndex);
                    break;
            }
        }

        private void uiNavMenu1_MenuItemClick_1(TreeNode node, NavMenuItem item, int pageIndex)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uiPanel3.Text = DateTime.Now.ToString();
            uiPanel1.Text = ProgramChecking;
        }

       

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
       
            Environment.Exit(0);

           
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            progressBar.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = "传感器关闭中";
            progressBar.Value = 0;
            if (Link.HyperCameraControlH)
            {
                Link.hyperCamera_2.Camera_Exit();
            }
            progressBar.Value = 25;
            if (Link.MutiCamera)
            {
                Link.mutiCamera.CloseCamera();
            }
            progressBar.Value = 50;
            if (Link.Depth)
            {
                Link.depth.StopPreview();
                //depth_Set.CloseDepth_Click(null, null);
                //depth_Set.StopPreview_Click(null, null); 
                PictureBox pictureBox = new PictureBox();
                Link.depth.CloseDepth(pictureBox);
            }
            progressBar.Value = 75;

            progressBar.Value = 100;
            lblStatus.Text = "传感器关闭完成";
            //if (isClosingInProgress)
            //{
            //     e.Cancel = true;
            //    return;
            //}

            //// 检查是否有需要关闭的设备
            //bool hasDevices = Link.HyperCameraControlH || Link.MutiCamera || Link.Depth;
            //if (!hasDevices) return;

            //// 取消本次关闭操作
            // e.Cancel = true;

            //// 初始化关闭进度控件
            //progressBar.Value = 0;
            //progressBar.Visible = true;
            //lblStatus.Visible = true;
            //lblStatus.Text = "正在关闭设备...";
            //isClosingInProgress = true;

            //// 创建取消令牌源
            //closingCancellationToken = new CancellationTokenSource();

            //// 开始异步关闭设备
            //Task.Run(() => CloseDevicesAsync(closingCancellationToken.Token));

           
        }

        private async Task CloseDevicesAsync(CancellationToken cancellationToken)
        {
            try
            {
                int totalSteps = 0;
                if (Link.HyperCameraControlH) totalSteps++;
                if (Link.MutiCamera) totalSteps++;
                if (Link.Depth) totalSteps++; // 深度相机只算一步

                int currentStep = 0;

                // 更新方法（添加了范围保护）
                void UpdateProgress(int progress, string message)
                {
                    int safeProgress = Math.Max(0, Math.Min(100, progress));

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            progressBar.Value = safeProgress;
                            lblStatus.Text = $"{message} {safeProgress}%";
                        }));
                    }
                    else
                    {
                        progressBar.Value = safeProgress;
                        lblStatus.Text = $"{message} {safeProgress}%";
                    }
                }

                // 关闭HyperCamera
                if (Link.HyperCameraControlH)
                {
                    currentStep++;
                    UpdateProgress((currentStep * 100) / totalSteps, "正在关闭Hyper相机");
                    await Task.Run(() => Link.hyperCamera_2.Camera_Exit());
                }

                // 关闭多相机
                if (Link.MutiCamera)
                {
                    currentStep++;
                    UpdateProgress((currentStep * 100) / totalSteps, "正在关闭多相机系统");
                    await Task.Run(() => Link.mutiCamera.CloseCamera());
                }

                // 关闭深度相机（修正后的逻辑）
                if (Link.Depth)
                {
                    currentStep++;
                    // 第一步：停止预览
                    UpdateProgress((currentStep * 100) / totalSteps, "正在停止深度相机预览");
                    await Task.Run(() => Link.depth.StopPreview());

                    // 第二步：关闭深度相机（不增加步骤计数）
                    UpdateProgress((currentStep * 100) / totalSteps, "正在释放深度相机资源");
                    await Task.Run(() =>
                    {
                        PictureBox pictureBox = new PictureBox();
                        Link.depth.CloseDepth(pictureBox);
                    });
                }

                // 最终完成
                UpdateProgress(100, "所有设备已安全关闭");
                await Task.Delay(500);

                // 关闭窗体
                this.Invoke(new Action(() => this.Close()));
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"关闭设备时出错: {ex.Message}");
                    progressBar.Visible = false;
                    lblStatus.Visible = false;
                    isClosingInProgress = false;
                }));
            }
           // Application.Exit();
           // isClosingInProgress = true;
          //  Application.

        }

    }
}
