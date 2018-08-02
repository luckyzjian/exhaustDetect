using System;
namespace SYS.Model
{
    /// <summary>
    /// ASM:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class compensationModel
    {
        public compensationModel()
        {
            ASM_HC = 1;
            ASM_CO = 1;
            ASM_NO = 1;
            VMAS_HC = 1;
            VMAS_CO = 1;
            VMAS_NO = 1;
            SDS_HC = 1;
            SDS_CO = 1;
            ZYJS_K = 1;
            JZJS_K = 1;
            JZJS_GL = 1;
            ISUSE = false;
        }
        public string LINEID { set; get; }
        public double ASM_HC { set; get; }
        public double ASM_CO { set; get; }
        public double ASM_NO { set; get; }
        public double VMAS_HC { set; get; }
        public double VMAS_CO { set; get; }
        public double VMAS_NO { set; get; }
        public double SDS_HC { set; get; }
        public double SDS_CO { set; get; }
        public double ZYJS_K { set; get; }
        public double JZJS_K { set; get; }
        public double JZJS_GL { set; get; }
        public bool ISUSE { set; get; }
    }
}

