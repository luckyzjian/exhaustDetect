using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using ini;
using System.Data;
using System.Collections;

namespace HnWebClient
{
    public class hnWebControl
    {
        private string logininCmd = "11Q01";
        private string loginoutCmd = "11Q02";
        private string queryServerTimeCmd = "11Q03";
        private string queryDemTimeCmd = "11Q04";
        private string queryVehicleInfCmd = "11Q05";
        private string queryTestItemCmd = "11Q06";
        private string logininforceCmd = "11Q07";
        private string downloadPictureCmd = "11Q08";
        private string queryRepairInfCmd = "11Q09";

        private string changePasswordCmd = "11C01";
        private string startSelfCheckCmd = "11C02";
        private string finishSelfCheckCmd = "11C03";
        private string writeSelfCheckCmd = "11C04";
        private string startDemarcateCmd = "11C05";
        private string finishDemarcateCmd = "11C06";
        private string writeDemarcateCmd = "11C07";
        private string startTestCmd = "11C08";
        private string finishTestCmd = "11C09";
        private string writeTestResultCmd = "11C10";
        private string writeTestDatasecondsCmd = "11C11";
        private string downloadAuthorisedConfigCmd = "11C12";
        private string downloadReportInfCmd = "11C13";
        private string uploadPictureCmd = "01Q05";
        private string capturePictureCmd = "11Z01";

        public bool enableASM = false;
        public bool enableVMAS = false;
        public bool enableLUGDOWN = false;
        public bool enableZYJS = false;
        public bool enableLZ = false;
        public bool enableSDS = false;
        public string asmyy = "";
        public string vmasyy = "";
        public string lugdownyy = "";
        public string zyjsyy = "";
        public string sdsyy = "";
        public string lzyy = "";

        public Dictionary<string, string> HN_HPZL = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> RHN_HPZL = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> HN_JYZL = new Dictionary<string, string>();//
        public Dictionary<string, string> RHN_JYZL = new Dictionary<string, string>();//
        public Dictionary<string, string> HN_CSYS = new Dictionary<string, string>();//GA24.8
        public Dictionary<string, string> RHN_CSYS = new Dictionary<string, string>();//GA24.8
        public Dictionary<string, string> HN_SYXZ = new Dictionary<string, string>();//GA24.3
        public Dictionary<string, string> RHN_SYXZ = new Dictionary<string, string>();//GA24.3
        public Dictionary<string, string> HN_RLZL = new Dictionary<string, string>();//GA24.9
        public Dictionary<string, string> RHN_RLZL = new Dictionary<string, string>();//GA24.9
        public Dictionary<string, string> HN_BSQXS = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> RHN_BSQXS = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> HN_JQFS = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> RHN_JQFS = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> HN_GYXS = new Dictionary<string, string>();//GA24.7
        public Dictionary<string, string> RHN_GYXS = new Dictionary<string, string>();//GA24.7
        WebReference.ExternalAccess hnservice = null;
        public string md5key = "";
        private string authorisedKey;
        public string autoriseForceKey;
        public hnWebControl(string key)
        {
            HN_HPZL.Add("01", "大型汽车号牌");
            HN_HPZL.Add("02", "小型汽车号牌");
            HN_HPZL.Add("03", "使馆汽车号牌");
            HN_HPZL.Add("04", "领馆汽车号牌");
            HN_HPZL.Add("05", "境外汽车号牌");
            HN_HPZL.Add("06", "外籍汽车号牌");
            HN_HPZL.Add("07", "两、三轮摩托车号牌");
            HN_HPZL.Add("08", "轻便摩托车号牌");
            HN_HPZL.Add("09", "使馆摩托车号牌");
            HN_HPZL.Add("10", "领馆摩托车号牌");
            HN_HPZL.Add("11", "境外摩托车号牌");
            HN_HPZL.Add("12", "外籍摩托车号牌");
            HN_HPZL.Add("13", "农用运输车号牌");
            HN_HPZL.Add("14", "拖拉机号牌");
            HN_HPZL.Add("15", "挂车号牌");
            HN_HPZL.Add("16", "教练汽车号牌");
            HN_HPZL.Add("17", "教练摩托车号牌");
            HN_HPZL.Add("18", "试验汽车号牌");
            HN_HPZL.Add("19", "试验摩托车号牌");
            HN_HPZL.Add("20", "临时人境汽车号牌");
            HN_HPZL.Add("21", "临时人境摩托车号牌");
            HN_HPZL.Add("22", "临时行驶车号牌");
            HN_HPZL.Add("23", "警用汽车号牌");
            HN_HPZL.Add("24", "警用摩托号牌");
            HN_HPZL.Add("99", "其他号牌");

            RHN_HPZL.Add( "大型汽车号牌","01");
            RHN_HPZL.Add( "小型汽车号牌", "02");
            RHN_HPZL.Add( "使馆汽车号牌","03");
            RHN_HPZL.Add("领馆汽车号牌","04" );
            RHN_HPZL.Add( "境外汽车号牌","05");
            RHN_HPZL.Add( "外籍汽车号牌","06");
            RHN_HPZL.Add( "两、三轮摩托车号牌","07");
            RHN_HPZL.Add( "轻便摩托车号牌","08");
            RHN_HPZL.Add( "使馆摩托车号牌","09");
            RHN_HPZL.Add( "领馆摩托车号牌","10");
            RHN_HPZL.Add("境外摩托车号牌","11" );
            RHN_HPZL.Add("外籍摩托车号牌","12" );
            RHN_HPZL.Add( "农用运输车号牌","13");
            RHN_HPZL.Add("拖拉机号牌","14" );
            RHN_HPZL.Add( "挂车号牌","15");
            RHN_HPZL.Add( "教练汽车号牌","16");
            RHN_HPZL.Add( "教练摩托车号牌","17");
            RHN_HPZL.Add( "试验汽车号牌","18");
            RHN_HPZL.Add("试验摩托车号牌","19" );
            RHN_HPZL.Add( "临时人境汽车号牌","20");
            RHN_HPZL.Add( "临时人境摩托车号牌","21");
            RHN_HPZL.Add( "临时行驶车号牌","22");
            RHN_HPZL.Add( "警用汽车号牌","23");
            RHN_HPZL.Add( "警用摩托号牌","24");
            RHN_HPZL.Add("其他号牌","99" );


            HN_JYZL.Add("1", "注册登记检验(新车)");
            HN_JYZL.Add("2", "在用车检验");
            HN_JYZL.Add("3", "转入");
            HN_JYZL.Add("4", "转出");
            HN_JYZL.Add("5", "委托检验");
            HN_JYZL.Add("6", "受托检验");
            HN_JYZL.Add("7", "临时检验");

            RHN_JYZL.Add("注册登记检验(新车)", "1");
            RHN_JYZL.Add("在用车检验", "2");
            RHN_JYZL.Add("转入", "3");
            RHN_JYZL.Add("转出", "4");
            RHN_JYZL.Add("委托检验", "5");
            RHN_JYZL.Add("受托检验", "6");
            RHN_JYZL.Add("临时检验", "7");

            HN_SYXZ.Add("A", "非营运");
            HN_SYXZ.Add("B", "公路客运");
            HN_SYXZ.Add("C", "公交客运");
            HN_SYXZ.Add("D", "出租客运");
            HN_SYXZ.Add("E", "旅游客运");
            HN_SYXZ.Add("F", "货运");
            HN_SYXZ.Add("G", "租赁");
            HN_SYXZ.Add("H", "警用");
            HN_SYXZ.Add("I", "消防");
            HN_SYXZ.Add("J", "救护");
            HN_SYXZ.Add("K", "工程抢险");
            HN_SYXZ.Add("L", "营转非");
            HN_SYXZ.Add("M", "出租转非");
            HN_SYXZ.Add("Z", "其他");

            RHN_SYXZ.Add("非营运", "A");
            RHN_SYXZ.Add("公路客运", "B");
            RHN_SYXZ.Add("公交客运", "C");
            RHN_SYXZ.Add("出租客运", "D");
            RHN_SYXZ.Add("旅游客运", "E");
            RHN_SYXZ.Add("货运", "F");
            RHN_SYXZ.Add("租赁", "G");
            RHN_SYXZ.Add("警用", "H");
            RHN_SYXZ.Add("消防", "I");
            RHN_SYXZ.Add("救护", "J");
            RHN_SYXZ.Add("工程抢险", "K");
            RHN_SYXZ.Add("营转非", "L");
            RHN_SYXZ.Add("出租转非", "M");
            RHN_SYXZ.Add("其他", "Z");


            HN_RLZL.Add("A", "汽油");
            HN_RLZL.Add("B", "柴油");
            HN_RLZL.Add("C", "电");
            HN_RLZL.Add("D", "混合油");
            HN_RLZL.Add("E", "天然气");
            HN_RLZL.Add("F", "液化石油气");
            HN_RLZL.Add("L", "甲醇");
            HN_RLZL.Add("M", "乙醇");
            HN_RLZL.Add("N", "太阳能");
            HN_RLZL.Add("O", "混合动力");
            HN_RLZL.Add("Y", "无");
            HN_RLZL.Add("Z", "其他");
            HN_RLZL.Add("A1", "油改气");

            RHN_RLZL.Add("汽油", "A");
            RHN_RLZL.Add("柴油", "B");
            RHN_RLZL.Add("电", "C");
            RHN_RLZL.Add("混合油", "D");
            RHN_RLZL.Add("天然气", "E");
            RHN_RLZL.Add("液化石油气", "F");
            RHN_RLZL.Add("甲醇", "L");
            RHN_RLZL.Add("乙醇", "M");
            RHN_RLZL.Add("太阳能", "N");
            RHN_RLZL.Add("混合动力", "O");
            RHN_RLZL.Add("无", "Y");
            RHN_RLZL.Add("其他", "Z");
            RHN_RLZL.Add("油改气", "A1");


            HN_CSYS.Add("A", "白");
            HN_CSYS.Add("B", "灰");
            HN_CSYS.Add("C", "黄");
            HN_CSYS.Add("D", "粉");
            HN_CSYS.Add("E", "红");
            HN_CSYS.Add("F", "紫");
            HN_CSYS.Add("G", "绿");
            HN_CSYS.Add("H", "蓝");
            HN_CSYS.Add("I", "棕");
            HN_CSYS.Add("J", "黑");
            HN_CSYS.Add("Z", "其他");

            RHN_CSYS.Add("白", "A");
            RHN_CSYS.Add("灰", "B");
            RHN_CSYS.Add("黄", "C");
            RHN_CSYS.Add("粉", "D");
            RHN_CSYS.Add("红", "E");
            RHN_CSYS.Add("紫", "F");
            RHN_CSYS.Add("绿", "G");
            RHN_CSYS.Add("蓝", "H");
            RHN_CSYS.Add("棕", "I");
            RHN_CSYS.Add("黑", "J");
            RHN_CSYS.Add("其他", "Z");

            HN_BSQXS.Add("1", "手动挡");
            HN_BSQXS.Add("2", "自动挡");
            HN_BSQXS.Add("3", "手自一体");

            RHN_BSQXS.Add("手动挡", "1");
            RHN_BSQXS.Add("自动挡", "2");
            RHN_BSQXS.Add("手自一体", "3");

            HN_JQFS.Add("0", "自然进气");
            HN_JQFS.Add("1", "涡轮增压");

            RHN_JQFS.Add("自然进气", "0");
            RHN_JQFS.Add("涡轮增压", "1");

            HN_GYXS.Add("0", "化油器");
            HN_GYXS.Add("1", "开环电喷");
            HN_GYXS.Add("2", "闭环电喷");

            RHN_GYXS.Add("化油器", "0");
            RHN_GYXS.Add("开环电喷", "1");
            RHN_GYXS.Add("闭环电喷", "2");
            md5key = ini.INIIO.md5(key, 32);
            hnservice = new WebReference.ExternalAccess();
        }
        public hnWebControl(string url,string key)
        {
            HN_HPZL.Add("01", "大型汽车号牌");
            HN_HPZL.Add("02", "小型汽车号牌");
            HN_HPZL.Add("03", "使馆汽车号牌");
            HN_HPZL.Add("04", "领馆汽车号牌");
            HN_HPZL.Add("05", "境外汽车号牌");
            HN_HPZL.Add("06", "外籍汽车号牌");
            HN_HPZL.Add("07", "两、三轮摩托车号牌");
            HN_HPZL.Add("08", "轻便摩托车号牌");
            HN_HPZL.Add("09", "使馆摩托车号牌");
            HN_HPZL.Add("10", "领馆摩托车号牌");
            HN_HPZL.Add("11", "境外摩托车号牌");
            HN_HPZL.Add("12", "外籍摩托车号牌");
            HN_HPZL.Add("13", "农用运输车号牌");
            HN_HPZL.Add("14", "拖拉机号牌");
            HN_HPZL.Add("15", "挂车号牌");
            HN_HPZL.Add("16", "教练汽车号牌");
            HN_HPZL.Add("17", "教练摩托车号牌");
            HN_HPZL.Add("18", "试验汽车号牌");
            HN_HPZL.Add("19", "试验摩托车号牌");
            HN_HPZL.Add("20", "临时人境汽车号牌");
            HN_HPZL.Add("21", "临时人境摩托车号牌");
            HN_HPZL.Add("22", "临时行驶车号牌");
            HN_HPZL.Add("23", "警用汽车号牌");
            HN_HPZL.Add("24", "警用摩托号牌");
            HN_HPZL.Add("99", "其他号牌");

            RHN_HPZL.Add("大型汽车号牌", "01");
            RHN_HPZL.Add("小型汽车号牌", "02");
            RHN_HPZL.Add("使馆汽车号牌", "03");
            RHN_HPZL.Add("领馆汽车号牌", "04");
            RHN_HPZL.Add("境外汽车号牌", "05");
            RHN_HPZL.Add("外籍汽车号牌", "06");
            RHN_HPZL.Add("两、三轮摩托车号牌", "07");
            RHN_HPZL.Add("轻便摩托车号牌", "08");
            RHN_HPZL.Add("使馆摩托车号牌", "09");
            RHN_HPZL.Add("领馆摩托车号牌", "10");
            RHN_HPZL.Add("境外摩托车号牌", "11");
            RHN_HPZL.Add("外籍摩托车号牌", "12");
            RHN_HPZL.Add("农用运输车号牌", "13");
            RHN_HPZL.Add("拖拉机号牌", "14");
            RHN_HPZL.Add("挂车号牌", "15");
            RHN_HPZL.Add("教练汽车号牌", "16");
            RHN_HPZL.Add("教练摩托车号牌", "17");
            RHN_HPZL.Add("试验汽车号牌", "18");
            RHN_HPZL.Add("试验摩托车号牌", "19");
            RHN_HPZL.Add("临时人境汽车号牌", "20");
            RHN_HPZL.Add("临时人境摩托车号牌", "21");
            RHN_HPZL.Add("临时行驶车号牌", "22");
            RHN_HPZL.Add("警用汽车号牌", "23");
            RHN_HPZL.Add("警用摩托号牌", "24");
            RHN_HPZL.Add("其他号牌", "99");


            HN_JYZL.Add("1", "注册登记检验(新车)");
            HN_JYZL.Add("2", "在用车检验");
            HN_JYZL.Add("3", "转入");
            HN_JYZL.Add("4", "转出");
            HN_JYZL.Add("5", "委托检验");
            HN_JYZL.Add("6", "受托检验");
            HN_JYZL.Add("7", "临时检验");

            RHN_JYZL.Add("注册登记检验(新车)", "1");
            RHN_JYZL.Add("在用车检验", "2");
            RHN_JYZL.Add("转入", "3");
            RHN_JYZL.Add("转出", "4");
            RHN_JYZL.Add("委托检验", "5");
            RHN_JYZL.Add("受托检验", "6");
            RHN_JYZL.Add("临时检验", "7");

            HN_SYXZ.Add("A", "非营运");
            HN_SYXZ.Add("B", "公路客运");
            HN_SYXZ.Add("C", "公交客运");
            HN_SYXZ.Add("D", "出租客运");
            HN_SYXZ.Add("E", "旅游客运");
            HN_SYXZ.Add("F", "货运");
            HN_SYXZ.Add("G", "租赁");
            HN_SYXZ.Add("H", "警用");
            HN_SYXZ.Add("I", "消防");
            HN_SYXZ.Add("J", "救护");
            HN_SYXZ.Add("K", "工程抢险");
            HN_SYXZ.Add("L", "营转非");
            HN_SYXZ.Add("M", "出租转非");
            HN_SYXZ.Add("Z", "其他");

            RHN_SYXZ.Add("非营运", "A");
            RHN_SYXZ.Add("公路客运", "B");
            RHN_SYXZ.Add("公交客运", "C");
            RHN_SYXZ.Add("出租客运", "D");
            RHN_SYXZ.Add("旅游客运", "E");
            RHN_SYXZ.Add("货运", "F");
            RHN_SYXZ.Add("租赁", "G");
            RHN_SYXZ.Add("警用", "H");
            RHN_SYXZ.Add("消防", "I");
            RHN_SYXZ.Add("救护", "J");
            RHN_SYXZ.Add("工程抢险", "K");
            RHN_SYXZ.Add("营转非", "L");
            RHN_SYXZ.Add("出租转非", "M");
            RHN_SYXZ.Add("其他", "Z");


            HN_RLZL.Add("A", "汽油");
            HN_RLZL.Add("B", "柴油");
            HN_RLZL.Add("C", "电");
            HN_RLZL.Add("D", "混合油");
            HN_RLZL.Add("E", "天然气");
            HN_RLZL.Add("F", "液化石油气");
            HN_RLZL.Add("L", "甲醇");
            HN_RLZL.Add("M", "乙醇");
            HN_RLZL.Add("N", "太阳能");
            HN_RLZL.Add("O", "混合动力");
            HN_RLZL.Add("Y", "无");
            HN_RLZL.Add("Z", "其他");
            HN_RLZL.Add("A1", "油改气");

            RHN_RLZL.Add("汽油", "A");
            RHN_RLZL.Add("柴油", "B");
            RHN_RLZL.Add("电", "C");
            RHN_RLZL.Add("混合油", "D");
            RHN_RLZL.Add("天然气", "E");
            RHN_RLZL.Add("液化石油气", "F");
            RHN_RLZL.Add("甲醇", "L");
            RHN_RLZL.Add("乙醇", "M");
            RHN_RLZL.Add("太阳能", "N");
            RHN_RLZL.Add("混合动力", "O");
            RHN_RLZL.Add("无", "Y");
            RHN_RLZL.Add("其他", "Z");
            RHN_RLZL.Add("油改气", "A1");


            HN_CSYS.Add("A", "白");
            HN_CSYS.Add("B", "灰");
            HN_CSYS.Add("C", "黄");
            HN_CSYS.Add("D", "粉");
            HN_CSYS.Add("E", "红");
            HN_CSYS.Add("F", "紫");
            HN_CSYS.Add("G", "绿");
            HN_CSYS.Add("H", "蓝");
            HN_CSYS.Add("I", "棕");
            HN_CSYS.Add("J", "黑");
            HN_CSYS.Add("Z", "其他");

            RHN_CSYS.Add("白", "A");
            RHN_CSYS.Add("灰", "B");
            RHN_CSYS.Add("黄", "C");
            RHN_CSYS.Add("粉", "D");
            RHN_CSYS.Add("红", "E");
            RHN_CSYS.Add("紫", "F");
            RHN_CSYS.Add("绿", "G");
            RHN_CSYS.Add("蓝", "H");
            RHN_CSYS.Add("棕", "I");
            RHN_CSYS.Add("黑", "J");
            RHN_CSYS.Add("其他", "Z");

            HN_BSQXS.Add("1", "手动挡");
            HN_BSQXS.Add("2", "自动挡");
            HN_BSQXS.Add("3", "手自一体");

            RHN_BSQXS.Add("手动挡", "1");
            RHN_BSQXS.Add("自动挡", "2");
            RHN_BSQXS.Add("手自一体", "3");

            HN_JQFS.Add("0", "自然进气");
            HN_JQFS.Add("1", "涡轮增压");

            RHN_JQFS.Add("自然进气", "0");
            RHN_JQFS.Add("涡轮增压", "1");

            HN_GYXS.Add("0", "化油器");
            HN_GYXS.Add("1", "开环电喷");
            HN_GYXS.Add("2", "闭环电喷");

            RHN_GYXS.Add("化油器", "0");
            RHN_GYXS.Add("开环电喷", "1");
            RHN_GYXS.Add("闭环电喷", "2");
            md5key = ini.INIIO.md5(key, 32);
            hnservice = new WebReference.ExternalAccess();
            hnservice.Url = url;
        }
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            string newstring = xmlString.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"gb2312\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            //string newstring = xmlString.Replace("<xml version=\"1.0\">", "");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveSocketLogInf("SEND:\r\n" + newstring);
            return newstring;
        }
        /// <summary>
        /// 测试链接是否成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool testConnect(out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("testserver");
                root.AppendChild(xe1);                
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring=hnservice.wsInvokeInterface(md5key, "Q0000", xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 从业人员登录
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="forceloginsqm"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool loginIn(Hashtable ht,out string forceloginsqm, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            forceloginsqm = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("login");
                IDictionaryEnumerator et = ht.GetEnumerator();                
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(md5key, logininCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dt1 = ds.Tables["list"];
                    authorisedKey = dt1.Rows[0]["data"].ToString();
                    return true;
                }
                else
                {
                    if (errMsg.Contains("强制登录"))
                    {
                        dt1 = ds.Tables["list"];
                        forceloginsqm = dt1.Rows[0]["data"].ToString();
                        autoriseForceKey = forceloginsqm;
                    }
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 从业人员注销
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool loginOut(out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("logout");

                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, loginoutCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 查询服务器时间
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool queryTime(out string datetime,out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            datetime = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("gettime");

                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, queryServerTimeCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dt1 = ds.Tables["list"];
                    //authorisedKey = (DateTime.ParseExact(dt1.Rows[0]["time"].ToString(), "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture)).ToString("yyyy-MM-dd HH:mm:ss"); 
                    datetime = dt1.Rows[0]["time"].ToString();
                    datetime = datetime.Substring(0, 4) + "-" + datetime.Substring(4, 2) + "-" + datetime.Substring(6, 2) + " " + datetime.Substring(8, 2) + ":" + datetime.Substring(10, 2) + ":" + datetime.Substring(12, 2);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 查询设备校准时限
        /// </summary>
        /// <param name="dtack"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool queryDemarcate(out DataTable dtack, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            dtack = new DataTable();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("getjzsx");

                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, queryDemTimeCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dtack = ds.Tables["list"];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 查询机动车注册信息
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="dtack"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool queryVehicleInf(Hashtable ht, out DataTable dtack, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            dtack = new DataTable();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("veh");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, queryVehicleInfCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dtack = ds.Tables["veh"];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 查询检测线检测项目状态
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="dtack"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool queryTestItemInf(Hashtable ht, out DataTable dtack, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            dtack = new DataTable();
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jcxjcxm");
                /*IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }*/
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, queryTestItemCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dtack = ds.Tables["list"];
                    enableASM = dtack.Rows[0]["asm"].ToString() == "True";
                    enableVMAS = dtack.Rows[0]["vmas"].ToString() == "True";
                    enableSDS = dtack.Rows[0]["tsi"].ToString() == "True";
                    enableLUGDOWN = dtack.Rows[0]["ld"].ToString() == "True";
                    enableZYJS = dtack.Rows[0]["snap"].ToString() == "True";
                    enableLZ = dtack.Rows[0]["ftst"].ToString() == "True";
                    asmyy = dtack.Rows[0]["asmyy"].ToString();
                    vmasyy = dtack.Rows[0]["asmyy"].ToString();
                    sdsyy = dtack.Rows[0]["tsiyy"].ToString();
                    lugdownyy = dtack.Rows[0]["ldyy"].ToString();
                    zyjsyy = dtack.Rows[0]["snapyy"].ToString();
                    lzyy = dtack.Rows[0]["ftstyy"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 从业人员强制登录
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool loginInForce(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("login");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(md5key, logininforceCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dt1 = ds.Tables["list"];
                    authorisedKey = dt1.Rows[0]["hhrzm"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 下载环保检测过程照片
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="dtack"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool downloadTestPic(Hashtable ht,out DataTable dtack, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jcgczp");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, downloadPictureCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dtack = ds.Tables["list"];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 查询不合格车辆维修信息
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="dtack"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool downloadRepairInf(Hashtable ht, out DataTable dtack, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("wxjl");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, queryRepairInfCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    dtack = ds.Tables["list"];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 更改登录用户口令
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool changePassword(Hashtable ht,  out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("ggkl");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, changePasswordCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 报告环检设备自检开始
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="result"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool startSelfCheck(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("zj");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, startSelfCheckCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool finishSelfCheck(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("zj");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, finishSelfCheckCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool writeSelfCheck(Hashtable ht,Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("zj");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                XmlElement xe2 = xmldoc.CreateElement("data");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe2.AppendChild(xe11);
                }
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, writeSelfCheckCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }

        public bool startDemarcate(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jz");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, startDemarcateCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool finishDemarcate(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jz");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, finishDemarcateCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool writeDemarcate(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jz");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                XmlElement xe2 = xmldoc.CreateElement("data");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe2.AppendChild(xe11);
                }
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, writeDemarcateCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool startTest(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jdcjc");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, startTestCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }/// <summary>
         /// 报告环检设备自检开始
         /// </summary>
         /// <param name="ht"></param>
         /// <param name="result"></param>
         /// <param name="errMsg"></param>
         /// <returns></returns>
        public bool capturePic(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jdcjc");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, capturePictureCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool uploadCapPicture(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jdcjczpsj");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, uploadPictureCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool finishTest(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jdcjc");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, finishTestCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool writeTestResult(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jdcjc");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                XmlElement xe2 = xmldoc.CreateElement("data");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe2.AppendChild(xe11);
                }
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, writeTestResultCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool writeTestDataSeconds(Hashtable ht, Hashtable htdata, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("jdcjcgcsj");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                XmlElement xe2 = xmldoc.CreateElement("data");
                et = htdata.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe2.AppendChild(xe11);
                }
                xe1.AppendChild(xe2);
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, writeTestDatasecondsCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool writeAuthorisedConfig(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("sqsj");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, downloadAuthorisedConfigCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
        public bool writePrintInf(Hashtable ht, out string result, out string errMsg)
        {
            result = "0";
            errMsg = "";
            //dtack = null;
            try
            {
                XmlDocument xmldoc, xlmrecivedoc;
                XmlNode xmlnode;
                XmlElement xmlelem;
                DataTable dt = null;
                xmldoc = new XmlDocument();
                xmlelem = xmldoc.CreateElement("", "root", "");
                xmldoc.AppendChild(xmlelem);
                XmlNode root = xmldoc.SelectSingleNode("root");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("dygz");
                IDictionaryEnumerator et = ht.GetEnumerator();
                while (et.MoveNext()) // 作哈希表循环
                {
                    XmlElement xe11 = xmldoc.CreateElement((string)et.Key);
                    xe11.InnerText = (string)et.Value;
                    xe1.AppendChild(xe11);
                }
                root.AppendChild(xe1);
                string xmlstring = ConvertXmlToString(xmldoc);
                string ackstring = hnservice.wsInvokeInterface(authorisedKey, downloadReportInfCmd, xmlstring);
                ini.INIIO.saveSocketLogInf("RECEIVE:\r\n" + ackstring);
                DataSet ds = new DataSet();
                StringReader stream = new StringReader(ackstring);
                XmlTextReader reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                DataTable dt1 = ds.Tables["head"];
                result = dt1.Rows[0]["code"].ToString();
                errMsg = dt1.Rows[0]["message"].ToString();
                if (result == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception er)
            {
                result = "-1";
                errMsg = er.Message;
                return false;
            }
        }
    }
    

}
