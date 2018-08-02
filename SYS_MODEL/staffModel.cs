using System;
using System.Collections.Generic;
using System.Text;

namespace SYS_MODEL
{
    public partial class staffModel
    {
        #region model
        private string staffid;

        public string STAFFID
        {
            get { return staffid; }
            set { staffid = value; }
        }
        private string name;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        private string postid;

        public string POSTID
        {
            get { return postid; }
            set { postid = value; }
        }
        private string sex;

        public string SEX
        {
            get { return sex; }
            set { sex = value; }
        }
        private string birthday;

        public string BIRTHDAY
        {
            get { return birthday; }
            set { birthday = value; }
        }
        private string age;

        public string AGE
        {
            get { return age; }
            set { age = value; }
        }
        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string education;

        public string EDUCATION
        {
            get { return education; }
            set { education = value; }
        }
        private string married;

        public string MARRIED
        {
            get { return married; }
            set { married = value; }
        }
        private string address;

        public string ADDRESS
        {
            get { return address; }
            set { address = value; }
        }
        private string phone;

        public string PHONE
        {
            get { return phone; }
            set { phone = value; }
        }
        private string qq;

        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }
        private string email;

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }
        private string photo;

        public string PHOTO
        {
            get { return photo; }
            set { photo = value; }
        }
        public string CZRYXKZH
        {
            get
            {
                return czryxkzh;
            }

            set
            {
                czryxkzh = value;
            }
        }

        public DateTime YXQSTARTTIME
        {
            get
            {
                return yxqstarttime;
            }

            set
            {
                yxqstarttime = value;
            }
        }

        public DateTime YXQENDTIME
        {
            get
            {
                return yxqendtime;
            }

            set
            {
                yxqendtime = value;
            }
        }

        public bool ISLOCK
        {
            get
            {
                return islock;
            }

            set
            {
                islock = value;
            }
        }

        public string LOCKREASON
        {
            get
            {
                return lockreason;
            }

            set
            {
                lockreason = value;
            }
        }

        public string PASSWORD
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        private string czryxkzh;
        private DateTime yxqstarttime;
        private DateTime yxqendtime;
        private bool islock;
        private string lockreason;
        private string password;
        #endregion
    }
}
