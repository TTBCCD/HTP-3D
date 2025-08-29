using RfidLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    public partial class FrmSample_GW : Form
    {
        RfidReader reader = new RfidReader();
        bool IsConnected = false;
        RadioButton[] rb_ready = new RadioButton[4];
        RadioButton[] rb_tp = new RadioButton[4];
        RadioButton[] rb_busy = new RadioButton[4];
        RadioButton[] rb_done = new RadioButton[4];
        RadioButton[] rb_err = new RadioButton[4];
        TextBox[] tb_stat = new TextBox[4];
        PictureBox[,] gw_rssi = new PictureBox[4, 3];
        bool[] TPSaved = new bool[4] { false, false, false, false };

        public FrmSample_GW()
        {
            InitializeComponent();
            GWRBControlInit();
        }

        #region DebugInfo

        private void AddDebugInfo(string Stat)
        {
            AddDebugInfo(Stat, Color.Black);
        }

        private void AddDebugInfo(string Stat, Color col)
        {
            AddDebugInfo(Stat, col, false);
        }

        private void AddDebugInfo(string Stat, Color col, bool isThis)
        {
            if (isThis)
            {
                if (rtb_DebugInfo.Text.Length > 20000)
                {
                    rtb_DebugInfo.Text = "";
                }
                string temp = string.Format("{0}->{1}\r\n", System.DateTime.Now.ToString("MM/dd hh:mm:ss"), Stat);
                rtb_DebugInfo.SelectionColor = col;
                rtb_DebugInfo.AppendText(temp);

                rtb_DebugInfo.SelectionStart = rtb_DebugInfo.Text.Length;
                rtb_DebugInfo.ScrollToCaret();//scroll to cursor
                rtb_DebugInfo.Refresh();
            }
            else
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    if (rtb_DebugInfo.Text.Length > 20000)
                    {
                        rtb_DebugInfo.Text = "";
                    }
                    string temp = string.Format("{0}->{1}\r\n", System.DateTime.Now.ToString("MM/dd hh:mm:ss"), Stat);
                    rtb_DebugInfo.SelectionColor = col;
                    rtb_DebugInfo.AppendText(temp);

                    rtb_DebugInfo.SelectionStart = rtb_DebugInfo.Text.Length;
                    rtb_DebugInfo.ScrollToCaret();//scroll to cursor
                });
            }
        }
        #endregion

        void TPInit()
        {
            for (int i = 0; i < TPSaved.Length; i++)
            {
                TPSaved[i] = false;
            }
        }

        void GWRBControlInit()
        {
            rb_ready[0] = rb_ready_rf1;
            rb_ready[1] = rb_ready_rf2;
            rb_ready[2] = rb_ready_rf3;
            rb_ready[3] = rb_ready_rf4;

            rb_tp[0] = rb_tp_rf1;
            rb_tp[1] = rb_tp_rf2;
            rb_tp[2] = rb_tp_rf3;
            rb_tp[3] = rb_tp_rf4;

            rb_busy[0] = rb_busy_rf1;
            rb_busy[1] = rb_busy_rf2;
            rb_busy[2] = rb_busy_rf3;
            rb_busy[3] = rb_busy_rf4;

            rb_done[0] = rb_done_rf1;
            rb_done[1] = rb_done_rf2;
            rb_done[2] = rb_done_rf3;
            rb_done[3] = rb_done_rf4;

            rb_err[0] = rb_err_rf1;
            rb_err[1] = rb_err_rf2;
            rb_err[2] = rb_err_rf3;
            rb_err[3] = rb_err_rf4;

            tb_stat[0] = tb_stat_rf1;
            tb_stat[1] = tb_stat_rf2;
            tb_stat[2] = tb_stat_rf3;
            tb_stat[3] = tb_stat_rf4;

            gw_rssi[0, 0] = pb_RssiLv1_rf1;
            gw_rssi[1, 0] = pb_RssiLv1_rf2;
            gw_rssi[2, 0] = pb_RssiLv1_rf3;
            gw_rssi[3, 0] = pb_RssiLv1_rf4;

            gw_rssi[0, 1] = pb_RssiLv2_rf1;
            gw_rssi[1, 1] = pb_RssiLv2_rf2;
            gw_rssi[2, 1] = pb_RssiLv2_rf3;
            gw_rssi[3, 1] = pb_RssiLv2_rf4;

            gw_rssi[0, 2] = pb_RssiLv3_rf1;
            gw_rssi[1, 2] = pb_RssiLv3_rf2;
            gw_rssi[2, 2] = pb_RssiLv3_rf3;
            gw_rssi[3, 2] = pb_RssiLv3_rf4;

        }

        void GWInfoInit()
        {
            for (int index = 0; index < 4; index++)
            {
                rb_ready[index].Checked = false;
                rb_tp[index].Checked = false;
                rb_busy[index].Checked = false;
                rb_done[index].Checked = false;
                rb_err[index].Checked = false;

                tb_stat[index].Text = "";

                gw_rssi[index, 0].BackColor = gw_rssi[index, 1].BackColor = gw_rssi[index, 2].BackColor = Color.Silver;
            }
        }

        private void b_Connect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {//disconnect
                IsConnected = false;
                reader.RfidDisconnect();

                AddDebugInfo("Disconnected...");
            }
            else
            {//connect
                if (reader.RfidConnect(cb_ConnAddr.Text.Trim(), int.Parse(cb_BaudPort.Text.Trim())))
                {
                    IsConnected = true;
                    AddDebugInfo("Connection established...");
                    DeviceInfo _DeviceInfo = new DeviceInfo();
                    if (reader.RfidGetDeviceInfo(0x00, ref _DeviceInfo) == ModbusErrEnum.MODBUS_ERR_NONE)
                    {
                        AddDebugInfo("MAC:" + _DeviceInfo.MAC);
                        AddDebugInfo("Version:" + _DeviceInfo.Version);
                    }
                }
                else
                {
                    IsConnected = false;
                    AddDebugInfo("Connection establishment failed, please check the device connection and the connection parameter...", Color.Red);
                }
            }

            tlp_gateway.Enabled = IsConnected;
            b_Connect.Text = IsConnected ? "Disconnect" : "Connect";
        }

        private void t_gw_Diag_Tick(object sender, EventArgs e)
        {
            t_gw_Diag.Enabled = false;

            GateWayIO gateway = reader.GateWayStat;
            if (gateway == null)
            {
                AddDebugInfo("Please check the connection status...");
                cb_diag_gw.Checked = false;
                return;
            }

            for (int index = 0; index < 4; index++)
            {
                rb_ready[index].Checked = gateway.RfidIn[index].Ready;
                rb_tp[index].Checked = gateway.RfidIn[index].TP;
                rb_busy[index].Checked = gateway.RfidIn[index].Busy;
                rb_done[index].Checked = gateway.RfidIn[index].Done;
                rb_err[index].Checked = gateway.RfidIn[index].Err;

                if (TPSaved[index] == false && gateway.RfidIn[index].TP == true)
                {
                    if (gateway.RfidIn[index].Uid != null)
                        tb_stat[index].Text = Tool.ByteToHexString(gateway.RfidIn[index].Uid, 0, gateway.RfidIn[index].Uid.Length, "");
                    else
                    {
                        byte[] uid = new byte[28];
                        int uidLen = 0;

                        if (reader.GWRfidReadUID((RfidNum)index, ref uid, ref uidLen) == ModbusErrEnum.MODBUS_ERR_NONE)
                        {
                            tb_stat[index].Text = Tool.ByteToHexString(uid, 0, uidLen, "");
                        }
                    }

                }
                TPSaved[index] = gateway.RfidIn[index].TP;

                if (gateway.RfidIn[index].Err)
                    tb_stat[index].Text = gateway.RfidIn[index].ErrCode.ToString();

                if (!gateway.RfidIn[index].TP && !gateway.RfidIn[index].Err)
                    tb_stat[index].Text = "";

                for (int tmp = 0; tmp < 3; tmp++)
                {
                    if ((gateway.RfidIn[index].RSSI > tmp) && gateway.RfidIn[index].TP)
                        gw_rssi[index, tmp].BackColor = Color.Green;
                    else
                        gw_rssi[index, tmp].BackColor = Color.Silver;
                }

            }
            t_gw_Diag.Enabled = true;
        }

        private void cb_gw_ctrl_CheckedChanged(object sender, EventArgs e)
        {
            cb_enable_rf1.Enabled = cb_enable_rf2.Enabled = cb_gw_ctrl.Checked;
            cb_enable_rf3.Enabled = cb_enable_rf4.Enabled = cb_gw_ctrl.Checked;
            b_gw_read.Enabled = b_gw_write.Enabled = cb_gw_ctrl.Checked;
        }

        void RFID_Enable()
        {
            bool[] enable = new bool[4];

            enable[0] = cb_enable_rf1.Checked;
            enable[1] = cb_enable_rf2.Checked;
            enable[2] = cb_enable_rf3.Checked;
            enable[3] = cb_enable_rf4.Checked;
            reader.GWEnableRfid(enable);
        }

        private void cb_diag_gw_CheckedChanged(object sender, EventArgs e)
        {
            t_gw_Diag.Enabled = cb_diag_gw.Checked;
            cb_gw_ctrl.Enabled = !cb_diag_gw.Checked;
            b_gw_read.Enabled = b_gw_write.Enabled = cb_diag_gw.Checked & cb_gw_ctrl.Checked;

            if (cb_diag_gw.Checked)
            {
                if (reader.StartGateWaySync(cb_gw_ctrl.Checked))
                {
                    TPInit();
                    if (cb_gw_ctrl.Checked)
                        RFID_Enable();
                    AddDebugInfo("GateWay Diagnostic begins...");
                }
            }
            else
            {
                reader.StopGateWaySync();
                AddDebugInfo("GateWay Diagnostic stopped...");
                GWInfoInit();
            }
        }

        private void cb_enable_rf1_CheckedChanged(object sender, EventArgs e)
        {
            RFID_Enable();
        }

        private void cb_enable_rf2_CheckedChanged(object sender, EventArgs e)
        {
            RFID_Enable();
        }

        private void cb_enable_rf3_CheckedChanged(object sender, EventArgs e)
        {
            RFID_Enable();
        }

        private void cb_enable_rf4_CheckedChanged(object sender, EventArgs e)
        {
            RFID_Enable();
        }

        private void rb_gw_hex_CheckedChanged(object sender, EventArgs e)
        {
            byte[] Data;

            if (rb_gw_hex.Checked)//convert ascii to hex string
            {
                Data = RfidLib.Tool.StringToAscii(b_gw_data.Text.Trim());

                if (Data != null && Data.Length > 0)
                {
                    b_gw_data.Text = RfidLib.Tool.ByteToHexString(Data, 0, Data.Length, " ");
                }
            }
            else
            {
                Data = RfidLib.Tool.HexStringToByte(b_gw_data.Text.Trim(), 0);

                if (Data != null && Data.Length > 0)
                    b_gw_data.Text = RfidLib.Tool.AsciiToString(Data, 0, Data.Length);
            }
        }

        private void b_gw_read_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                RfidNum rfid = RfidNum.RFID_1;

                if (rb_rw_rf1.Checked)
                    rfid = RfidNum.RFID_1;
                else if (rb_rw_rf2.Checked)
                    rfid = RfidNum.RFID_2;
                else if (rb_rw_rf3.Checked)
                    rfid = RfidNum.RFID_3;
                else if (rb_rw_rf4.Checked)
                    rfid = RfidNum.RFID_4;

                byte[] Datas = null;
                int addr = int.Parse(tb_gw_addr.Text);
                int len = int.Parse(tb_gw_num.Text);

                if (reader.GWRfidRead(rfid, (ushort)addr, (byte)len, ref Datas) == ModbusErrEnum.MODBUS_ERR_NONE)
                {
                    if (Datas != null)
                    {
                        if (rb_gw_hex.Checked)
                            b_gw_data.Text = Tool.ByteToHexString(Datas, 0, Datas.Length, " ");
                        else
                            b_gw_data.Text = RfidLib.Tool.AsciiToString(Datas, 0, Datas.Length);
                    }

                    AddDebugInfo(string.Format("Read finished, takes:{0}ms", (DateTime.Now - start).TotalMilliseconds.ToString("F1")));
                }
                else
                {
                    AddDebugInfo("Read failed.");
                }
            }
            catch { AddDebugInfo("Please check the parameters..."); }
        }

        private void b_gw_write_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                RfidNum rfid = RfidNum.RFID_1;

                if (rb_rw_rf1.Checked)
                    rfid = RfidNum.RFID_1;
                else if (rb_rw_rf2.Checked)
                    rfid = RfidNum.RFID_2;
                else if (rb_rw_rf3.Checked)
                    rfid = RfidNum.RFID_3;
                else if (rb_rw_rf4.Checked)
                    rfid = RfidNum.RFID_4;

                if (!reader.GateWayStat.RfidIn[(byte)rfid].TP)
                {
                    AddDebugInfo("Tag not detected.");
                    return;
                }

                int addr = int.Parse(tb_gw_addr.Text);
                int len = int.Parse(tb_gw_num.Text);
                byte[] datas;
                if (rb_gw_hex.Checked)
                    datas = RfidLib.Tool.HexStringToByte(b_gw_data.Text.Trim(), 0);
                else
                    datas = RfidLib.Tool.StringToAscii(b_gw_data.Text.Trim());
                if (datas == null || datas.Length < len)
                {
                    AddDebugInfo("Please check the parameters...");
                    return;
                }

                if (reader.GWRfidWrite(rfid, (ushort)addr, (byte)len, datas) == ModbusErrEnum.MODBUS_ERR_NONE)
                {
                    AddDebugInfo(string.Format("Write finished, takes:{0}ms", (DateTime.Now - start).TotalMilliseconds.ToString("F1")));
                }
                else
                {
                    AddDebugInfo("Write failed.");
                }
            }
            catch { AddDebugInfo("Please check the parameters..."); }
        }
    }
}
