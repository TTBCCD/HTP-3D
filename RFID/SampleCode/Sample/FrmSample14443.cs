using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    public partial class FrmSample14443 : Form
    {
        RFID reader = new RFID();
        bool IsConnected = false;

        public FrmSample14443()
        {
            InitializeComponent();
            SerialScan();
        }

        private void SerialScan()
        {
            cb_ConnAddr.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                if (!cb_ConnAddr.Items.Contains(port))
                {
                    cb_ConnAddr.Items.Add(port);
                }
            }
        }
        private void b_connect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {//disconnect
                IsConnected = false;
                reader.Disconnect();
                gb_RfidOper.Enabled = false;
            }
            else
            {//connect
                IsConnected = reader.Connect(cb_ConnAddr.Text.Trim(), int.Parse(cb_BaudPort.Text.Trim()));
            }

            gb_RfidOper.Enabled = IsConnected;
            b_Connect.Text = IsConnected ? "Disconnect" : "Connect";
        }

        private void b_setProtocol_Click(object sender, EventArgs e)
        {
            bool Result = false;
            if (rb_14443A.Checked)
                Result=reader.SetRfidProtocol(RfidLib.RfidProtocolEnum.RFID_PROTOCOL_14443A);
            else
                Result=reader.SetRfidProtocol(RfidLib.RfidProtocolEnum.RFID_PROTOCOL_15693);

            if (Result)
                AddStatus("Set RFID protocol succeeded.");
            else
                AddStatus("Set RFID protocol faild.");
        }

        private void AddStatus(string str)
        {
            this.BeginInvoke((EventHandler)delegate
            {
                tssl_status.Text = "Status:" + str;
            });
        }

        private void b_ReadRecord_Click(object sender, EventArgs e)
        {
            string[] Records = reader.GetTagRecords(5);

            if(Records != null)
            {
                for (int i = 0; i < Records.Length; i++)
                    tb_ReadData.Text += Records[i] + "\r\n";

                AddStatus("Get ID records succeeded.");
            }
            else
            {
                AddStatus("Get ID records faild.");
            }
        }

        private void FrmSample14443_Load(object sender, EventArgs e)
        {

        }
    }
}
