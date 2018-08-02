using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SYS_DAL;
namespace exhaustDetect
{
    public partial class staffLogin : Form
    {
        //private loginInfModel logininfmodel = new loginInfModel();
        private loginInfControl logininfcontrol = new loginInfControl();
        private baseControl basecontrol = new baseControl();
        public staffLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!mainPanel.useHyDatabase)
            {
                if (logininfcontrol.checkUserIsAlive(comboBoxUser.Text, textBoxPassword.Text))
                {
                    string postid = basecontrol.getIDByName(comboBoxClass.Text, "职位", "POSTID");
                    mainPanel.nowUser.postID = postid;
                    mainPanel.nowUser.postName = comboBoxClass.Text;
                    mainPanel.nowUser.userName = comboBoxUser.Text;
                    mainPanel.nowUser.userPassword = textBoxPassword.Text;
                    mainPanel.isNetUsed = radioButtonNet.Checked;
                    mainPanel.userLoginSuccess = true;
                    this.Close();
                }
                else
                {
                    mainPanel.userLoginSuccess = false;
                    MessageBox.Show("用户名不存在或输入密码错误,请检查");
                }
            }
            else
            {
                if (hyDatabaseInter.checkUserIsAlive(comboBoxUser.Text, textBoxPassword.Text))
                {
                    //mainPanel.nowUser.postID = mainPanel.userGroupHy[comboBoxClass.Text];
                    switch(mainPanel.userGroupHy[comboBoxClass.Text])
                    {
                        case "1":
                            mainPanel.nowUser.postID = "6";break;
                        case "2":
                            mainPanel.nowUser.postID = "5"; break;
                        case "3":
                            mainPanel.nowUser.postID = "3"; break;
                        default:break;

                    }
                    mainPanel.nowUser.postName = comboBoxClass.Text;
                    mainPanel.nowUser.userName = comboBoxUser.Text;
                    mainPanel.nowUser.userPassword = textBoxPassword.Text;
                    mainPanel.isNetUsed = radioButtonNet.Checked;
                    mainPanel.userLoginSuccess = true;
                    this.Close();
                }
                else
                {
                    mainPanel.userLoginSuccess = false;
                    MessageBox.Show("用户名不存在或输入密码错误,请检查");
                }
            }
        }

        private void staffLogin_Load(object sender, EventArgs e)
        {
            radioButtonNet.Checked = mainPanel.isNetUsed;
            radioButtonLocal.Checked = !mainPanel.isNetUsed;
            if (!mainPanel.useHyDatabase)
            {
                DataTable dt = null;
                dt = logininfcontrol.getComBoBoxItemsInf("职位");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["GONGWEIQX"].ToString() == "1")
                        comboBoxClass.Items.Add(dt.Rows[i]["MC"].ToString());
                }
            }
            else
            {
                foreach (var dic in mainPanel.userGroupHy )
                {
                     comboBoxClass.Items.Add(dic.Key);
                }
            }
            comboBoxClass.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPanel.userLoginSuccess = false;
            this.Close();
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUser.Items.Clear();
            DataTable dt = null;
            if (!mainPanel.useHyDatabase)
            {
                string postid = basecontrol.getIDByName(comboBoxClass.Text, "职位", "POSTID");
                dt = logininfcontrol.getStaffByPost(postid);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxUser.Items.Add(dt.Rows[i]["NAME"].ToString());
                }
            }
            else
            {
                hyDatabaseInter.readUserByGourpID(mainPanel.userGroupHy[comboBoxClass.Text], out dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxUser.Items.Add(dt.Rows[i]["EMP_NAME"].ToString());
                }
            }
        }
    }
}
