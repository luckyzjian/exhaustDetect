using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ini;

namespace exhaustDetect
{
    public partial class 检测线配置 : Form
    {
        public 检测线配置()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ini.INIIO.WritePrivateProfileString("检测线", "线号", textBoxLineID.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("检测线", "检综检", checkBoxZj.Checked?"Y":"N", @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("检测线", "共用油耗", checkBoxYhyShare.Checked?"Y":"N", @".\appConfig.ini");
            MessageBox.Show("保存成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ini.INIIO.WritePrivateProfileString("数据", "服务器", textBoxLocalServerIp.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("数据", "数据库", textBoxLocalServerDb.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("数据", "用户名", textBoxLocalServerUser.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("数据", "密码", textBoxLocalServerPassword.Text, @".\appConfig.ini");
            MessageBox.Show("保存成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ini.INIIO.WritePrivateProfileString("ATSA数据", "服务器", textBoxATSAServerIp.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("ATSA数据", "数据库", textBoxATSAServerDb.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("ATSA数据", "用户名", textBoxATSAServerUser.Text, @".\appConfig.ini");
            ini.INIIO.WritePrivateProfileString("ATSA数据", "密码", textBoxATSAServerPassword.Text, @".\appConfig.ini");
            MessageBox.Show("保存成功");

        }

        private void 检测线配置_Load(object sender, EventArgs e)
        {
            textBoxLineID.Text = mainPanel.lineid;
            checkBoxZj.Checked = mainPanel.enableDynTest;
            checkBoxYhyShare.Checked = mainPanel.shareYhy;
            textBoxLocalServerIp.Text = mainPanel.localdb.ip;
            textBoxLocalServerDb.Text = mainPanel.localdb.dbname;
            textBoxLocalServerUser.Text = mainPanel.localdb.user;
            textBoxLocalServerPassword.Text = mainPanel.localdb.password;
            textBoxATSAServerIp.Text = mainPanel.atsadb.ip;
            textBoxATSAServerDb.Text = mainPanel.atsadb.dbname;
            textBoxATSAServerUser.Text = mainPanel.atsadb.user;
            textBoxATSAServerPassword.Text = mainPanel.atsadb.password;
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                labelJCZMC.Text = mainPanel.stationinfmodel.STATIONNAME + mainPanel.jhwebinf.lineid + "号线" ;
            else
                labelJCZMC.Text = mainPanel.stationinfmodel.STATIONNAME + mainPanel.lineid + "号线";
            labelCGJXH.Text = mainPanel.equipmodel.CGJXH;
            labelCGJBH.Text = mainPanel.equipmodel.CGJBH;
            labelCGJCJ.Text = mainPanel.equipmodel.CGJZZC;
            labelFXYXH.Text = mainPanel.equipmodel.FXYXH;
            labelFXYBH.Text = mainPanel.equipmodel.FXYBH;
            labelFXYCJ.Text = mainPanel.equipmodel.FXYZZC;
            labelYDJXH.Text = mainPanel.equipmodel.YDJXH;
            labelYDJBH.Text = mainPanel.equipmodel.YDJBH;
            labelYDJCJ.Text = mainPanel.equipmodel.YDJZZC;
            labelLLJXH.Text = mainPanel.equipmodel.LLJXH;
            labelLLJBH.Text = mainPanel.equipmodel.LLJBH;
            labelLLJCJ.Text = mainPanel.equipmodel.LLJZZC;
            labelZSJXH.Text = mainPanel.equipmodel.ZSJXH;
            labelZSJBH.Text = mainPanel.equipmodel.ZSJBH;
            labelZSJCJ.Text = mainPanel.equipmodel.ZSJZZC;
        }
    }
}
