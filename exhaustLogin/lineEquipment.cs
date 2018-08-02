using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace exhaustDetect
{
    public partial class lineEquipment : Form
    {
        public delegate void wtlsb(Label Msgowner, string Msgstr);                //委托
        public delegate void wtlp(Label Msgowner, Panel Msgfather);                              //委托
        public delegate void wtlm(Label Msgowner, string Msgstr);
        public lineEquipment()
        {
            InitializeComponent();
        }

        private void lineState_Load(object sender, EventArgs e)
        {
            if (mainPanel.isNetUsed && mainPanel.NetMode == mainPanel.JINGHUANETMODE)
                labelJCZMC.Text = mainPanel.stationinfmodel.STATIONNAME + mainPanel.jhwebinf.lineid + "号线" + "(" + (!mainPanel.linebdzt.linezt ? "锁止" : "正常") + ")";
            else
                labelJCZMC.Text = mainPanel.stationinfmodel.STATIONNAME + mainPanel.lineid + "号线" + "(" + (!mainPanel.linebdzt.linezt ? "锁止" : "正常") + ")";
            labelCGJXH.Text = mainPanel.equipmodel.CGJXH;
            labelCGJBH.Text = mainPanel.equipmodel.CGJBH;
            labelCGJCJ.Text = mainPanel.equipmodel.CGJZZC;
            labelFXYXH.Text = mainPanel.equipmodel.FXYXH;
            labelFXYBH.Text = mainPanel.equipmodel.FXYBH;
            labelFXYCJ.Text = mainPanel.equipmodel.FXYZZC;
            labelLLJXH.Text = mainPanel.equipmodel.LLJXH;
            labelLLJBH.Text = mainPanel.equipmodel.LLJBH;
            labelLLJCJ.Text = mainPanel.equipmodel.LLJZZC;
            labelZSJXH.Text = mainPanel.equipmodel.ZSJXH;
            labelZSJBH.Text = mainPanel.equipmodel.ZSJBH;
            labelZSJCJ.Text = mainPanel.equipmodel.ZSJZZC;

        }

    }
}
