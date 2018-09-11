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
    public partial class xbUserLogin : Form
    {
        public xbUserLogin()
        {
            InitializeComponent();
        }

        private void xbUserLogin_Load(object sender, EventArgs e)
        {
            foreach(carinfo.XB_USER model in mainPanel.xb_user_list)
            {
                comboBoxUser.Items.Add(model.name);
            }
            if (comboBoxUser.Items.Count > 0)
                comboBoxUser.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "", errmsg = "";
            if (!mainPanel.xbsocket.Send_USER_LOGIN(comboBoxUser.Text, textBoxPassword.Text, out result, out errmsg))
            {
                MessageBox.Show("登录失败：" + errmsg);
            }
            else
            {
                mainPanel.xbLoginUserName = comboBoxUser.Text;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPanel.isNetUsed = false;
            this.Close();
        }
    }
}
