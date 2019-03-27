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
    public partial class lineState : Form
    {
        public delegate void wtlsb(Label Msgowner, string Msgstr);                //委托
        public delegate void wtlp(Label Msgowner, Panel Msgfather);                              //委托
        public delegate void wtlm(Label Msgowner, string Msgstr);
        public lineState()
        {
            InitializeComponent();
        }

        private void lineState_Load(object sender, EventArgs e)
        {
            //Msg(labelJCZMC, panelJCZMC, mainPanel.stationinfmodel.STATIONNAME + mainPanel.lineid + "号线");
            if(mainPanel.isNetUsed&&mainPanel.NetMode==mainPanel.JINGHUANETMODE)
                labelJCZMC.Text = mainPanel.stationinfmodel.STATIONNAME + mainPanel.jhwebinf.lineid + "号线"+"(" + (!mainPanel.linebdzt.linezt ? "锁止" : "正常")+")";
            else
                labelJCZMC.Text = mainPanel.stationinfmodel.STATIONNAME + mainPanel.lineid + "号线" + "(" + (!mainPanel.linebdzt.linezt ? "锁止" : "正常") + ")";


            labelLockReason.Text = mainPanel.linebdzt.lineLockReason;
            labelVMAS.Text = mainPanel.linemodel.VMAS == "Y" ? "授权" : "未授权";
            labelZXJZJS.Text = mainPanel.linemodel.JZJS_HEAVY == "Y" ? "授权" : "未授权";
            labelQXJZJS.Text = mainPanel.linemodel.JZJS_LIGHT == "Y" ? "授权" : "未授权";
            labelASM.Text = mainPanel.linemodel.ASM == "Y" ? "授权" : "未授权";
            labelSDS.Text = mainPanel.linemodel.SDS == "Y" ? "授权" : "未授权";
            labelBTG.Text = mainPanel.linemodel.ZYJS == "Y" ? "授权" : "未授权";
            labelLZ.Text = mainPanel.linemodel.LZ == "Y" ? "授权" : "未授权";
            labelVMAS.ForeColor = mainPanel.linemodel.VMAS == "Y" ? Color.Blue : Color.Red;
            labelZXJZJS.ForeColor = mainPanel.linemodel.JZJS_HEAVY == "Y" ? Color.Blue : Color.Red;
            labelQXJZJS.ForeColor = mainPanel.linemodel.JZJS_LIGHT == "Y" ? Color.Blue : Color.Red;
            labelASM.ForeColor = mainPanel.linemodel.ASM == "Y" ? Color.Blue : Color.Red;
            labelSDS.ForeColor = mainPanel.linemodel.SDS == "Y" ? Color.Blue : Color.Red;
            labelBTG.ForeColor = mainPanel.linemodel.ZYJS == "Y" ? Color.Blue : Color.Red;
            labelLZ.ForeColor = mainPanel.linemodel.LZ == "Y" ? Color.Blue : Color.Red;

            if (mainPanel.linesbbd.Yrenable)
            {
                labelYR.ForeColor = mainPanel.linebdzt.yrzt ? Color.Black : Color.Red;
                labelYRSJ.ForeColor = mainPanel.linebdzt.yrzt ? Color.Black : Color.Red;
                labelYRTS.ForeColor = mainPanel.linebdzt.yrzt ? Color.Black : Color.Red;
                labelYRSJ.Text = mainPanel.linesbbd.Yrdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelYRTS.Text = mainPanel.linebdzt.yrts.ToString();
            }
            else
            {
                labelYR.ForeColor = Color.Gray;
                labelYRSJ.ForeColor = Color.Gray;
                labelYRTS.ForeColor = Color.Gray;
                labelYRSJ.Text = "--";
                labelYRTS.Text = "--";
            }
            if (mainPanel.linesbbd.Zjenable)
            {

                labelZJ.ForeColor = mainPanel.linebdzt.zjzt ? Color.Black : Color.Red;
                labelZJSJ.ForeColor = mainPanel.linebdzt.zjzt ? Color.Black : Color.Red;
                labelZJTS.ForeColor = mainPanel.linebdzt.zjzt ? Color.Black : Color.Red;
                labelZJSJ.Text = mainPanel.linesbbd.Zjdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelZJTS.Text = mainPanel.linebdzt.zjts.ToString();
            }
            else
            {
                labelZJ.ForeColor = Color.Gray;
                labelZJSJ.ForeColor = Color.Gray;
                labelZJTS.ForeColor = Color.Gray;
                labelZJSJ.Text = "--";
                labelZJTS.Text = "--";
            }
            if(mainPanel.linesbbd.Hxenable)
            {

                labelJZHX.ForeColor = mainPanel.linebdzt.hxzt ? Color.Black : Color.Red;
                labelJZHXSJ.ForeColor = mainPanel.linebdzt.hxzt ? Color.Black : Color.Red;
                labelJZHXTS.ForeColor = mainPanel.linebdzt.hxzt ? Color.Black : Color.Red;
                labelJZHXSJ.Text = mainPanel.linesbbd.Hxdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelJZHXTS.Text = mainPanel.linebdzt.hxts.ToString();
            }
            else
            {
                labelJZHX.ForeColor = Color.Gray;
                labelJZHXSJ.ForeColor = Color.Gray;
                labelJZHXTS.ForeColor = Color.Gray;
                labelJZHXSJ.Text = "--";
                labelJZHXTS.Text = "--";
            }
            if(mainPanel.linesbbd.Jsglenable)
            {
                labelJSGL.ForeColor = mainPanel.linebdzt.jsglzt ? Color.Black : Color.Red;
                labelJSGLSJ.ForeColor = mainPanel.linebdzt.jsglzt ? Color.Black : Color.Red;
                labelJSGLTS.ForeColor = mainPanel.linebdzt.jsglzt ? Color.Black : Color.Red;
                labelJSGLSJ.Text = mainPanel.linesbbd.Jsgldate.ToString("yyyy-MM-dd HH:mm:ss");
                labelJSGLTS.Text = mainPanel.linebdzt.jsglts.ToString();
            }
            else
            {
                labelJSGL.ForeColor = Color.Gray;
                labelJSGLSJ.ForeColor = Color.Gray;
                labelJSGLTS.ForeColor = Color.Gray;
                labelJSGLSJ.Text = "--";
                labelJSGLTS.Text = "--";
            }
            if (mainPanel.linesbbd.Glenable)
            {
                labelGL.ForeColor = mainPanel.linebdzt.glzt ? Color.Black : Color.Red;
                labelGLSJ.ForeColor = mainPanel.linebdzt.glzt ? Color.Black : Color.Red;
                labelGLTS.ForeColor = mainPanel.linebdzt.glzt ? Color.Black : Color.Red;
                labelGLSJ.Text = mainPanel.linesbbd.Gldate.ToString("yyyy-MM-dd HH:mm:ss");
                labelGLTS.Text = mainPanel.linebdzt.glts.ToString();
            }
            else
            {
                labelGL.ForeColor = Color.Gray;
                labelGLSJ.ForeColor = Color.Gray;
                labelGLTS.ForeColor = Color.Gray;
                labelGLSJ.Text = "--";
                labelGLTS.Text = "--";
            }
            if (mainPanel.linesbbd.Yljenable)
            {
                labelYLJ.ForeColor = mainPanel.linebdzt.yljzt ? Color.Black : Color.Red;
                labelYLJSJ.ForeColor = mainPanel.linebdzt.yljzt ? Color.Black : Color.Red;
                labelYLJTS.ForeColor = mainPanel.linebdzt.yljzt ? Color.Black : Color.Red;
                labelYLJSJ.Text = mainPanel.linesbbd.Yljdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelYLJTS.Text = mainPanel.linebdzt.yljts.ToString();
            }
            else
            {
                labelYLJ.ForeColor = Color.Gray;
                labelYLJSJ.ForeColor = Color.Gray;
                labelYLJTS.ForeColor = Color.Gray;
                labelYLJSJ.Text = "--";
                labelYLJTS.Text = "--";
            }
            if (mainPanel.linesbbd.Sdenable)
            {
                labelSD.ForeColor = mainPanel.linebdzt.sdzt ? Color.Black : Color.Red;
                labelSDSJ.ForeColor = mainPanel.linebdzt.sdzt ? Color.Black : Color.Red;
                labelSDTS.ForeColor = mainPanel.linebdzt.sdzt ? Color.Black : Color.Red;
                labelSDSJ.Text = mainPanel.linesbbd.Sddate.ToString("yyyy-MM-dd HH:mm:ss");
                labelSDTS.Text = mainPanel.linebdzt.sdts.ToString();
            }
            else
            {
                labelSD.ForeColor = Color.Gray;
                labelSDSJ.ForeColor = Color.Gray;
                labelSDTS.ForeColor = Color.Gray;
                labelSDSJ.Text = "--";
                labelSDTS.Text = "--";
            }
            if (mainPanel.linesbbd.Hjcsenable)
            {
                labelDZHJ.ForeColor = mainPanel.linebdzt.hjcszt ? Color.Black : Color.Red;
                labelHJCSSJ.ForeColor = mainPanel.linebdzt.hjcszt ? Color.Black : Color.Red;
                labelDZHJTS.ForeColor = mainPanel.linebdzt.hjcszt ? Color.Black : Color.Red;
                labelHJCSSJ.Text = mainPanel.linesbbd.Hjcsdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelDZHJTS.Text = mainPanel.linebdzt.hjcsts.ToString();
            }
            else
            {
                labelDZHJ.ForeColor = Color.Gray;
                labelHJCSSJ.ForeColor = Color.Gray;
                labelDZHJTS.ForeColor = Color.Gray;
                labelHJCSSJ.Text = "--";
                labelDZHJTS.Text = "--";
            }
            if (mainPanel.linesbbd.Zsjenable)
            {
                labelZSJ.ForeColor = mainPanel.linebdzt.zsjzt ? Color.Black : Color.Red;
                labelZSJSJ.ForeColor = mainPanel.linebdzt.zsjzt ? Color.Black : Color.Red;
                labelZSJTS.ForeColor = mainPanel.linebdzt.zsjzt ? Color.Black : Color.Red;

                labelZSJSJ.Text = mainPanel.linesbbd.Zsjdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelZSJTS.Text = mainPanel.linebdzt.zsjts.ToString();
            }
            else
            {
                labelZSJ.ForeColor = Color.Gray;
                labelZSJSJ.ForeColor = Color.Gray;
                labelZSJTS.ForeColor = Color.Gray;

                labelZSJSJ.Text = "--";
                labelZSJTS.Text = "--";
            }
            if (mainPanel.linesbbd.Fxylowenable)
            {
                labelFXYLOW.ForeColor = mainPanel.linebdzt.fxylowzt ? Color.Black : Color.Red;
                labelFXYLOWSJ.ForeColor = mainPanel.linebdzt.fxylowzt ? Color.Black : Color.Red;
                labelFXYLOWTS.ForeColor = mainPanel.linebdzt.fxylowzt ? Color.Black : Color.Red;
                labelFXYLOWSJ.Text = mainPanel.linesbbd.Fxylowdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelFXYLOWTS.Text = mainPanel.linebdzt.fxylowts.ToString();
            }
            else
            {
                labelFXYLOW.ForeColor = Color.Gray;
                labelFXYLOWSJ.ForeColor = Color.Gray;
                labelFXYLOWTS.ForeColor = Color.Gray;
                labelFXYLOWSJ.Text = "--";
                labelFXYLOWTS.Text = "--";
            }
            if (mainPanel.linesbbd.Fxyhighenable)
            {
                labelFXYHIGH.ForeColor = mainPanel.linebdzt.fxyhighzt ? Color.Black : Color.Red;
                labelFXYHIGHSJ.ForeColor = mainPanel.linebdzt.fxyhighzt ? Color.Black : Color.Red;
                labelFXYHIGHTS.ForeColor = mainPanel.linebdzt.fxyhighzt ? Color.Black : Color.Red;
                labelFXYHIGHSJ.Text = mainPanel.linesbbd.Fxyhighdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelFXYHIGHTS.Text = mainPanel.linebdzt.fxyhights.ToString();
            }
            else
            {
                labelFXYHIGH.ForeColor = Color.Gray;
                labelFXYHIGHSJ.ForeColor = Color.Gray;
                labelFXYHIGHTS.ForeColor = Color.Gray;
                labelFXYHIGHSJ.Text = "--";
                labelFXYHIGHTS.Text = "--";
            }
            if (mainPanel.linesbbd.Fxymidenable)
            {
                labelFXYMID.ForeColor = mainPanel.linebdzt.fxymidzt ? Color.Black : Color.Red;
                labelFXYMIDSJ.ForeColor = mainPanel.linebdzt.fxymidzt ? Color.Black : Color.Red;
                labelFXYMIDTS.ForeColor = mainPanel.linebdzt.fxymidzt ? Color.Black : Color.Red;
                labelFXYMIDSJ.Text = mainPanel.linesbbd.Fxymiddate.ToString("yyyy-MM-dd HH:mm:ss");
                labelFXYMIDTS.Text = mainPanel.linebdzt.fxymidts.ToString();
            }
            else
            {
                labelFXYMID.ForeColor = Color.Gray;
                labelFXYMIDSJ.ForeColor = Color.Gray;
                labelFXYMIDTS.ForeColor = Color.Gray;
                labelFXYMIDSJ.Text = "--";
                labelFXYMIDTS.Text = "--";
            }
            if (mainPanel.linesbbd.Jlenable)
            {
                labelJL.ForeColor = mainPanel.linebdzt.jlzt ? Color.Black : Color.Red;
                labelJLSJ.ForeColor = mainPanel.linebdzt.jlzt ? Color.Black : Color.Red;
                labelJLTS.ForeColor = mainPanel.linebdzt.jlzt ? Color.Black : Color.Red;
                labelJLSJ.Text = mainPanel.linesbbd.Jldate.ToString("yyyy-MM-dd HH:mm:ss");
                labelJLTS.Text = mainPanel.linebdzt.jlts.ToString();
            }
            else
            {
                labelJL.ForeColor = Color.Gray;
                labelJLSJ.ForeColor = Color.Gray;
                labelJLTS.ForeColor = Color.Gray;
                labelJLSJ.Text = "--";
                labelJLTS.Text = "--";
            }
            if (mainPanel.linesbbd.Ydjenable)
            {
                labelYDJ.ForeColor = mainPanel.linebdzt.ydjzt ? Color.Black : Color.Red;
                labelYDJSJ.ForeColor = mainPanel.linebdzt.ydjzt ? Color.Black : Color.Red;
                labelYDJTS.ForeColor = mainPanel.linebdzt.ydjzt ? Color.Black : Color.Red;
                labelYDJSJ.Text = mainPanel.linesbbd.Ydjdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelYDJTS.Text = mainPanel.linebdzt.ydjts.ToString();
            }
            else
            {
                labelYDJ.ForeColor = Color.Gray;
                labelYDJSJ.ForeColor = Color.Gray;
                labelYDJTS.ForeColor = Color.Gray;
                labelYDJSJ.Text = "--";
                labelYDJTS.Text = "--";
            }
            if (mainPanel.linesbbd.Lljenable)
            {
                labelLLJ.ForeColor = mainPanel.linebdzt.lljzt ? Color.Black : Color.Red;
                labelLLJSJ.ForeColor = mainPanel.linebdzt.lljzt ? Color.Black : Color.Red;
                labelLLJTS.ForeColor = mainPanel.linebdzt.lljzt ? Color.Black : Color.Red;
                labelLLJSJ.Text = mainPanel.linesbbd.Lljdate.ToString("yyyy-MM-dd HH:mm:ss");
                labelLLJTS.Text = mainPanel.linebdzt.lljts.ToString();
            }
            else
            {
                labelLLJ.ForeColor = Color.Gray;
                labelLLJSJ.ForeColor = Color.Gray;
                labelLLJTS.ForeColor = Color.Gray;
                labelLLJSJ.Text = "--";
                labelLLJTS.Text = "--";
            }

            


        }
        /// <summary>
        /// 信息显示
        /// </summary>
        /// <param name="Msgowner">信息显示的Label控件</param>
        /// <param name="Msgfather">Label控件的父级Panel</param>
        /// <param name="Msgstr">要显示的信息</param>
        /// <param name="Update_DB">是不是要更新到检测状态</param>
        public void Msg(Label Msgowner, Panel Msgfather, string Msgstr)
        {
            BeginInvoke(new wtlsb(Msg_Show), Msgowner, Msgstr);
            BeginInvoke(new wtlp(Msg_Position), Msgowner, Msgfather);
        }
        public void Label_Msg(Label Msgowner, string Msgstr)
        {
            BeginInvoke(new wtlm(Label_Show), Msgowner, Msgstr);
        }
        public void Label_Show(Label Msgowner, string Msgstr)
        {
            Msgowner.Text = Msgstr;
        }
        public void Msg_Show(Label Msgowner, string Msgstr)
        {
            Msgowner.Text = Msgstr;
        }

        public void Msg_Position(Label Msgowner, Panel Msgfather)
        {
            if (Msgowner.Width < Msgfather.Width)
                Msgowner.Location = new Point((Msgfather.Width - Msgowner.Width) / 2, Msgowner.Location.Y);
            else
                Msgowner.Location = new Point(0, Msgowner.Location.Y);
        }

        private void buttonYR_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("预热");
            //childcarlogin.TopLevel = false;
            childcarlogin.Show();
        }

        private void buttonZJ_Click(object sender, EventArgs e)
        {
            startSelfCheck childcarlogin = new startSelfCheck();
            //childcarlogin.TopLevel = false;
            childcarlogin.Show();
        }

        private void buttonYLJ_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("扭力标定");
            childcarlogin.Show();
        }

        private void buttonSD_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("速度标定");
            childcarlogin.Show();
        }

        private void buttonGL_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("惯量测试");
            childcarlogin.Show();
        }

        private void buttonJSGL_Click(object sender, EventArgs e)
        {

            startdemarcate childcarlogin = new startdemarcate("寄生功率测试");
            childcarlogin.Show();
        }

        private void buttonJZHX_Click(object sender, EventArgs e)
        {

            startdemarcate childcarlogin = new startdemarcate("滑行测试");
            childcarlogin.Show();
        }

        private void buttonFXYLOW_Click(object sender, EventArgs e)
        {

            startdemarcate childcarlogin = new startdemarcate("废气仪检查","L");
            childcarlogin.Show();
        }

        private void buttonFXYHIGH_Click(object sender, EventArgs e)
        {

            startdemarcate childcarlogin = new startdemarcate("废气仪检查", "H");
            childcarlogin.Show();
        }

        private void buttonFXYMID_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("废气仪标定","B");
            childcarlogin.Show();
        }

        private void buttonYDJ_Click(object sender, EventArgs e)
        {

            startdemarcate childcarlogin = new startdemarcate("烟度计检查");
            childcarlogin.Show();
        }

        private void buttonLLJ_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("流量计检测");
            childcarlogin.Show();
        }

        private void buttonDZHJ_Click(object sender, EventArgs e)
        {
            startdemarcate childcarlogin = new startdemarcate("气象站校准");
            childcarlogin.Show();
        }

        private void buttonJL_Click(object sender, EventArgs e)
        {

        }
    }
}
