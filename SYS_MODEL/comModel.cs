using System;
using System.Collections.Generic;
using System.Text;

namespace SYS_MODEL
{
    public partial class comModel
    {
        #region model
        private string comname;

        public string Comname
        {
            get { return comname; }
            set { comname = value; }
        }
        private string comstring;

        public string Comstring
        {
            get { return comstring; }
            set { comstring = value; }
        }
        private bool isEnable;

        public bool IsEnable
        {
            get { return isEnable; }
            set { isEnable = value; }
        }

        #endregion
    }
}
