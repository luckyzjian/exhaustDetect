using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace carinfor
{
    public static class TyNetDictionary
    {
        public static Dictionary<string, string> TY_PFBZ = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_BZLX = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_CPYS = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_SYXZ = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_QDFS = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_BSQXS = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_GYFS = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_RLZL = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_JQFS = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_PQHCLZZ = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_PQHCLZZL = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_JCJG = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_HPZL = new Dictionary<string, string>();
        public static Dictionary<string, string> TY_JCLX = new Dictionary<string, string>();
        public static void initDic()
        {
            TY_PFBZ.Add("1", "国0");
            TY_PFBZ.Add("2", "国Ⅰ");
            TY_PFBZ.Add("3", "国Ⅱ");
            TY_PFBZ.Add("4", "国Ⅲ");
            TY_PFBZ.Add("5", "国Ⅴ");
            TY_PFBZ.Add("6", "国VI");

            TY_BZLX.Add("0", "绿标");
            TY_BZLX.Add("1", "黄标");

            TY_CPYS.Add("1", "蓝牌");
            TY_CPYS.Add("2", "黄牌");
            TY_CPYS.Add("3", "拍牌");
            TY_CPYS.Add("4", "黑牌");


            TY_SYXZ.Add("A", "非营运");
            TY_SYXZ.Add("B", "公路客运");
            TY_SYXZ.Add("C", "公交客运");
            TY_SYXZ.Add("D", "出租客运");
            TY_SYXZ.Add("E", "旅游客运");
            TY_SYXZ.Add("F", "货运");
            TY_SYXZ.Add("G", "租赁");
            TY_SYXZ.Add("H", "警用");
            TY_SYXZ.Add("I", "消防");
            TY_SYXZ.Add("J", "救护");
            TY_SYXZ.Add("K", "工程抢险");
            TY_SYXZ.Add("L", "营转非");
            TY_SYXZ.Add("M", "出租转非");
            TY_SYXZ.Add("N", "教练");
            TY_SYXZ.Add("O", "幼儿校车");
            TY_SYXZ.Add("P", "小学车校车");
            TY_SYXZ.Add("Q", "初中生校车");
            TY_SYXZ.Add("R", "危险品运输");
            TY_SYXZ.Add("S", "中小学生校车");

            TY_QDFS.Add("1", "前驱");
            TY_QDFS.Add("2", "后驱");
            TY_QDFS.Add("3", "四驱");
            TY_QDFS.Add("4", "全时四驱");

            TY_BSQXS.Add("1", "手动");
            TY_BSQXS.Add("2", "自动");
            TY_BSQXS.Add("3", "手自一体");
        }
    }
}
