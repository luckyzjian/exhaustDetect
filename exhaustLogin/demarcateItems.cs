using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SYS_DAL;

namespace exhaustDetect
{
    public partial class demarcateItems : Form
    {
        public demarcateItems()
        {
            InitializeComponent();
        }

        private void demarcateItems_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "操作日志";
            textBox1.Text = mainPanel.lineid;
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            demarcateControl demarcatecontrol = new demarcateControl();
            DataTable datagrid = demarcatecontrol.getAllDemarcateLog(dateTimePickerStart.Value, dateTimePickerEnd.Value, mainPanel.stationid, textBox1.Text, comboBox1.Text);
            if (datagrid.Rows.Count>0)
            {
                //datagrid.Rows.RemoveAt(0);
                //setDataGridView(datagrid);
                dataGridView1.DataSource = datagrid;
                switch (comboBox1.Text)
                {
                    case "废气仪检查":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["CO2BZ"].HeaderText = "CO2标值";
                        dataGridView1.Columns["CO2CLZ"].HeaderText = "CO2测量值";
                        dataGridView1.Columns["COBZ"].HeaderText = "CO标值";
                        dataGridView1.Columns["COCLZ"].HeaderText = "CO测量值";
                        dataGridView1.Columns["HCBZ"].HeaderText = "HC标值";
                        dataGridView1.Columns["HCCLZ"].HeaderText = "HC测量值";
                        dataGridView1.Columns["NOBZ"].HeaderText = "NO标值";
                        dataGridView1.Columns["NOCLZ"].HeaderText = "NO测量值";
                        dataGridView1.Columns["JZDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["GDJZ"].HeaderText = "高低校准";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;

                    case "废气仪标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["CO2BZ"].HeaderText = "CO2标值";
                        dataGridView1.Columns["CO2CLZ"].HeaderText = "CO2测量值";
                        dataGridView1.Columns["COBZ"].HeaderText = "CO标值";
                        dataGridView1.Columns["COCLZ"].HeaderText = "CO测量值";
                        dataGridView1.Columns["HCBZ"].HeaderText = "HC标值";
                        dataGridView1.Columns["HCCLZ"].HeaderText = "HC测量值";
                        dataGridView1.Columns["NOBZ"].HeaderText = "NO标值";
                        dataGridView1.Columns["NOCLZ"].HeaderText = "NO测量值";
                        dataGridView1.Columns["JZDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["GDJZ"].HeaderText = "高低校准";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "流量计标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["O2GLCBZ"].HeaderText = "O2高量程浓度";
                        dataGridView1.Columns["O2GLCCLZ"].HeaderText = "O2高量程测量值";
                        dataGridView1.Columns["O2GLCWC"].HeaderText = "O2高量程误差";
                        dataGridView1.Columns["O2DLCBZ"].HeaderText = "O2低量程浓度";
                        dataGridView1.Columns["O2DLCCLZ"].HeaderText = "O2低量程测量值";
                        dataGridView1.Columns["O2DLCWC"].HeaderText = "O2低量程误差";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "烟度计标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["KBZ"].HeaderText = "K标值";
                        dataGridView1.Columns["KSCZ"].HeaderText = "K测量值";
                        dataGridView1.Columns["KABSWC"].HeaderText = "K绝对误差";
                        dataGridView1.Columns["KRELWC"].HeaderText = "K相对误差";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "气象站校准":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["WDBZ"].HeaderText = "温度标值";
                        dataGridView1.Columns["WDSCZ"].HeaderText = "温度测量值";
                        dataGridView1.Columns["SDBZ"].HeaderText = "湿度标值";
                        dataGridView1.Columns["SDSCZ"].HeaderText = "湿度实测值";
                        dataGridView1.Columns["DQYBZ"].HeaderText = "大气压标值";
                        dataGridView1.Columns["DQYSCZ"].HeaderText = "大气压实测值";
                        dataGridView1.Columns["WDWC"].HeaderText = "湿度误差";
                        dataGridView1.Columns["SDWC"].HeaderText = "湿度误差";
                        dataGridView1.Columns["DQYWC"].HeaderText = "大气压误差";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "惯量测试试验":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["T1POWER"].HeaderText = "f1";
                        dataGridView1.Columns["T2POWER"].HeaderText = "f2";
                        dataGridView1.Columns["STARTSPEED"].HeaderText = "初速度";
                        dataGridView1.Columns["ENDSPEED"].HeaderText = "末速度";
                        dataGridView1.Columns["ACD1_1"].HeaderText = "t1_1";
                        dataGridView1.Columns["ACD1_2"].HeaderText = "t1_2";
                        dataGridView1.Columns["ACD1_3"].HeaderText = "t1_3";
                        dataGridView1.Columns["ACD1"].HeaderText = "t1";
                        dataGridView1.Columns["ACD2_1"].HeaderText = "t2_1";
                        dataGridView1.Columns["ACD2_2"].HeaderText = "t2_2";
                        dataGridView1.Columns["ACD2_3"].HeaderText = "t2_3";
                        dataGridView1.Columns["ACD2"].HeaderText = "t2";
                        dataGridView1.Columns["DIW_1"].HeaderText = "DIW1";
                        dataGridView1.Columns["DIW_2"].HeaderText = "DIW2";
                        dataGridView1.Columns["DIW_3"].HeaderText = "DIW3";
                        dataGridView1.Columns["DIW"].HeaderText = "DIW";
                        dataGridView1.Columns["DIW_BC"].HeaderText = "标称DIW";
                        dataGridView1.Columns["DIW_SC"].HeaderText = "实测DIW";
                        dataGridView1.Columns["WC"].HeaderText = "误差";
                        dataGridView1.Columns["PD"].HeaderText = "判定";
                        dataGridView1.Columns["HXSJ"].HeaderText = "滑行时间";
                        dataGridView1.Columns["BZ"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "寄生功率试验":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["SDQJ"].HeaderText = "速度区间";
                        dataGridView1.Columns["MYSD"].HeaderText = "名义速度";
                        dataGridView1.Columns["HXSJ"].HeaderText = "滑行时间";
                        dataGridView1.Columns["JSGL"].HeaderText = "寄生功率";
                        dataGridView1.Columns["LJHXSJ"].HeaderText = "累计滑行时间";
                        dataGridView1.Columns["BZ"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "加载滑行试验":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["HXQJ"].HeaderText = "滑行区间";
                        dataGridView1.Columns["QJMYSD"].HeaderText = "区间名义速度";
                        dataGridView1.Columns["CCDT"].HeaderText = "理论滑行时间";
                        dataGridView1.Columns["PLHP"].HeaderText = "寄生功率";
                        dataGridView1.Columns["ACDT"].HeaderText = "实际滑行时间";
                        dataGridView1.Columns["JZSDGL"].HeaderText = "加载功率(kW)";
                        dataGridView1.Columns["WC"].HeaderText = "误差";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "变载荷滑行测试":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["HXQJ"].HeaderText = "滑行区间";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["CCDT"].HeaderText = "理论滑行时间";
                        dataGridView1.Columns["ACDT"].HeaderText = "实际滑行时间";
                        dataGridView1.Columns["WC"].HeaderText = "误差";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "响应时间测试":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["SPEED"].HeaderText = "速度点";
                        dataGridView1.Columns["STARTPOWER"].HeaderText = "初功率";
                        dataGridView1.Columns["STARTFORCE"].HeaderText = "初扭力";
                        dataGridView1.Columns["ENDPOWER"].HeaderText = "末功率";
                        dataGridView1.Columns["ENDFORCE"].HeaderText = "末扭力";
                        dataGridView1.Columns["XYTIME"].HeaderText = "响应时间";
                        dataGridView1.Columns["WDTIME"].HeaderText = "稳定时间";
                        dataGridView1.Columns["CZY"].HeaderText = "操作员";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "扭力标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["BZ1"].HeaderText = "标值1";
                        dataGridView1.Columns["CLZ1"].HeaderText = "测量值1";
                        dataGridView1.Columns["BZ2"].HeaderText = "标值2";
                        dataGridView1.Columns["CLZ2"].HeaderText = "测量值2";
                        dataGridView1.Columns["BZ3"].HeaderText = "标值3";
                        dataGridView1.Columns["CLZ3"].HeaderText = "测量值31";
                        dataGridView1.Columns["BZ4"].HeaderText = "标值4";
                        dataGridView1.Columns["CLZ4"].HeaderText = "测量值4";
                        dataGridView1.Columns["BZ5"].HeaderText = "标值5";
                        dataGridView1.Columns["CLZ5"].HeaderText = "测量值5";
                        dataGridView1.Columns["WC1"].HeaderText = "误差1";
                        dataGridView1.Columns["WC2"].HeaderText = "误差2";
                        dataGridView1.Columns["WC3"].HeaderText = "误差3";
                        dataGridView1.Columns["WC4"].HeaderText = "误差4";
                        dataGridView1.Columns["WC5"].HeaderText = "误差5";
                        dataGridView1.Columns["BDDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注说明";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "速度标定":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["BZ1"].HeaderText = "标值1";
                        dataGridView1.Columns["CLZ1"].HeaderText = "测量值1";
                        dataGridView1.Columns["BZ2"].HeaderText = "标值2";
                        dataGridView1.Columns["CLZ2"].HeaderText = "测量值2";
                        dataGridView1.Columns["BZ3"].HeaderText = "标值3";
                        dataGridView1.Columns["CLZ3"].HeaderText = "测量值31";
                        dataGridView1.Columns["WC1"].HeaderText = "误差1";
                        dataGridView1.Columns["WC2"].HeaderText = "误差2";
                        dataGridView1.Columns["WC3"].HeaderText = "误差3";
                        dataGridView1.Columns["BDDS"].HeaderText = "校准点数";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注说明";
                        dataGridView1.Columns["BDJG"].HeaderText = "判定结果";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    case "操作日志":
                        dataGridView1.Columns["STATIONID"].HeaderText = "检测站编号";
                        dataGridView1.Columns["LINEID"].HeaderText = "检测线号";
                        dataGridView1.Columns["PROID"].HeaderText = "操作编号";
                        dataGridView1.Columns["PRONAME"].HeaderText = "操作项目";
                        dataGridView1.Columns["DATA"].HeaderText = "数据";
                        dataGridView1.Columns["STATE"].HeaderText = "状态";
                        dataGridView1.Columns["RESULT"].HeaderText = "结果";
                        dataGridView1.Columns["BZSM"].HeaderText = "备注说明";
                        dataGridView1.Columns["BDRQ"].HeaderText = "操作时间";
                        break;
                    default:break;
                }
            }
            else
            {
                MessageBox.Show("没有找到相关记录");
            }
        }
    }
}
