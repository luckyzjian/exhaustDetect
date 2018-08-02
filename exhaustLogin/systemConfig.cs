using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace exhaustDetect
{
    public partial class systemConfig : Form
    {
        carinfor.configIni configini = new carinfor.configIni();
        public systemConfig()
        {
            InitializeComponent();
        }

        private void systemConfig_Load(object sender, EventArgs e)
        {
            foreach (String fPrinterName in LocalPrinter.GetLocalPrinters())
                comboBoxPrinter.Items.Add(fPrinterName);
            mainPanel.linemodel = mainPanel.stationcontrol.getLineInf(mainPanel.stationid, mainPanel.lineid);
            comboBoxPrinter.Text = mainPanel.linemodel.PRINTER;
            checkBoxAutoPrint.Checked=mainPanel.linemodel.AUTOPRINT=="Y"?true:false;
            DataTable allstaff = mainPanel.logininfcontrol.getAllStaff();
            foreach (DataRow dr in allstaff.Rows)
            {
                comboBoxSHY.Items.Add(dr["NAME"].ToString());
            }
            comboBoxSHY.Text = mainPanel.shy;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string printerName = comboBoxPrinter.Text;
            mainPanel.stationcontrol.setLinePrinter(mainPanel.stationid, mainPanel.lineid, printerName);
            mainPanel.stationcontrol.setLineAutoPrint(mainPanel.stationid, mainPanel.lineid, checkBoxAutoPrint.Checked?"Y":"N");
            mainPanel.linemodel = mainPanel.stationcontrol.getLineInf(mainPanel.stationid, mainPanel.lineid);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            initConfigInfo();
        }
        private void initConfigInfo()
        {
            carinfor.equipmentConfigInfdata equipconfig = configini.getEquipConfigIni();
            carinfor.VmasConfigInfdata vmasconfig = configini.getVmasConfigIni();
            carinfor.AsmConfigInfdata asmconfig = configini.getAsmConfigIni();
            carinfor.SdsConfigInfdata sdsconfig = configini.getSdsConfigIni();
            carinfor.BtgConfigInfdata btgconfig = configini.getBtgConfigIni();
            carinfor.LugdownConfigInfdata lugdownconfig = configini.getLugdownConfigIni();

            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete(@".\detectConfig.ini");
            File.Copy(@".\detectConfigbk.ini", @".\detectConfig.ini");
            initConfigInfo();
        }

        private void checkBoxVmasSdjk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxVmasLljk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxVmasJzgljk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxVmasNdjk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void buttonSelectShy_Click(object sender, EventArgs e)
        {
            mainPanel.shy = comboBoxSHY.Text;
            ini.INIIO.WritePrivateProfileString("报告单", "审核员", comboBoxSHY.Text, @".\appConfig.ini");
            MessageBox.Show("保存成功");
        }
    }
    public class LocalPrinter
    {
        private static PrintDocument fPrintDocument = new PrintDocument();
        /// <summary>
        /// 获取本机默认打印机名称
        /// </summary>
        public static String DefaultPrinter
        {
            get { return fPrintDocument.PrinterSettings.PrinterName; }
        }
        /// <summary>
        /// 获取本机的打印机列表。列表中的第一项就是默认打印机。
        /// </summary>
        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<string>();
            fPrinters.Add(DefaultPrinter); // 默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                    fPrinters.Add(fPrinterName);
            }
            return fPrinters;
        }
    }
}
