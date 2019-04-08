using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ini;
using System.Net;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections;

namespace HhzWebClient
{
    public class hhzperson
    {
        public string testpersonno { set; get; }
        public string name { set; get; }
        public string sex { set; get; }
        public string birthday { set; get; }
        public string job { set; get; }
        public string cardnumber { set; get; }
        public string state { set; get; }
        public string remark { set; get; }
        public string exchangetime { set; get; }
        public string tsno { set; get; }
    }
    public class hhzjcx
    {
        public string tsno { set; get; }
        public string testlineno { set; get; }
        public string testlinename { set; get; }
        public string testlinetype { set; get; }
        public string firstauthdate { set; get; }
        public string testtype { set; get; }
        public string status { set; get; }
        public string provider { set; get; }
        public string testexpirecode { set; get; }
        public string testexpiredade { set; get; }
        public string dynamometer { set; get; }
        public string dprovider { set; get; }
        public string dadate { set; get; }
        public string analyser { set; get; }
        public string aprovider { set; get; }
        public string aadate { set; get; }
        public string flowmeter { set; get; }
        public string fprovider { set; get; }
        public string fadate { set; get; }
        public string smokemeter { set; get; }
        public string sprovider { set; get; }
        public string sadate { set; get; }
        public string tachometer { set; get; }
        public string tprovider { set; get; }
        public string tadate { set; get; }
        public string otsensor { set; get; }
        public string oprovider { set; get; }
        public string oadate { set; get; }
        public string wstype { set; get; }
        public string wsrovider { set; get; }
        public string wsadate { set; get; }
        public string exchangetime { set; get; }

    }
    public class hhzbhgjl
    {
        public string cphm { set; get; }
        public string cplx { set; get; }
        public string jcdjbm { set; get; }
        public string vin { set; get; }
        public string clxh { set; get; }
        public string cbrq { set; get; }
        public string jczbm { set; get; }
        public string jczmc { set; get; }
    }
    public class Hhzclient
    {
        string url = "";
        public enum DATALX {JCZXX,JCZRY,JCZRYKZ,JCXXX,CLXX,CXXX,FDJXX,BZXX,SXJLSB,WJDLXX,JYXX,PICTURE,JCXX,CLXXCX,WGCLXXCX,SDSXZCX,VMASXZCX,ASMXZCX,JZJSXZCX,ZYJSXZCX,JCRYJBXX,JCBHGCLXX,JCXJBXX,JCZJBXX,JCXX1}
        public string[] DATAPATH = {"unit_task", "unit_person_task", "unit_person_ext_task", "check_device_task", "vehicle_task",
            "vehicle_model_task","engine_task","sign_task","sxjlsb_task","wjdlxx_task","jyxx_task","uploadimage_task",
            "upload_task","vehicle_query","wgcl_query","dsjcxz_limit","jystgkjcxz_limit","jywtgkjcxz_limit","jsjsgkxz_limit",
            "zyjsjcxz_ limit","unitperson_query","jcbhgcl_query","checkdevice_query","unit_query","upload_task1"};
        public Dictionary<string, string> Hhz_AckCode = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_JCZ_JJLX = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_JCZ_YESORNO = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_JCZ_VMASORASM = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_PERSON_SEX = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_PERSON_EDUCATION = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_PERSON_POST = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_PERSON_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_LINE_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_LINE_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_LINE_ISLOCK = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_CPYS = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_PFBZ = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_CLZL = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_QDXS = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_BSQXS = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_RLZL = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_GYFS = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_DPFS= new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_YESORNO= new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_JQFS= new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_HPZL = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_HCLTYPE = new Dictionary<string, string>();
        /// <summary>
        /// 冲程类型
        /// </summary>
        public Dictionary<string, string> Hhz_VEHICLE_CCLX = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_CHZZ = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_SYXZ = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_VEHICLE_CARORTRUCK = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_FLAG_TYPE= new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_FLAG_YESORNO = new Dictionary<string, string>();

        /// <summary>
        /// 补标原因
        /// </summary>
        public Dictionary<string, string> Hhz_FLAG_BBYY = new Dictionary<string, string>();
        /// <summary>
        /// 有效期
        /// </summary>
        public Dictionary<string, string> Hhz_FLAG_YXQ = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_RESULT_YESORNO = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_RESULT_JCLX = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_RESULT_JCFF = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_RESULT_PDJG = new Dictionary<string, string>();
        public Dictionary<string, string> Hhz_RESULT_DSLX = new Dictionary<string, string>();
        /// <summary>
        /// 检测异常类型
        /// </summary>
        public Dictionary<string, string> Hhz_RESULT_JCYCLX = new Dictionary<string, string>();
        /// <summary>
        /// 终止原因
        /// </summary>
        public Dictionary<string, string> Hhz_RESULT_ZZYY = new Dictionary<string, string>();
        /// <summary>
        /// 数据类型
        /// </summary>
        public Dictionary<string, string> Hhz_RESULT_SJLX = new Dictionary<string, string>();


        public Dictionary<string, string> HhzR_JCZ_JJLX = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_JCZ_YESORNO = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_JCZ_VMASORASM = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_PERSON_SEX = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_PERSON_EDUCATION = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_PERSON_POST = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_PERSON_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_LINE_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_LINE_STATE = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_LINE_ISLOCK = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_CPYS = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_PFBZ = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_CLZL = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_QDXS = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_BSQXS = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_RLZL = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_GYFS = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_DPFS = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_YESORNO = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_JQFS = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_HPZL = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_HCLTYPE = new Dictionary<string, string>();
        /// <summary>
        /// 冲程类型
        /// </summary>
        public Dictionary<string, string> HhzR_VEHICLE_CCLX = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_CHZZ = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_SYXZ = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_VEHICLE_CARORTRUCK = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_FLAG_TYPE = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_FLAG_YESORNO = new Dictionary<string, string>();

        /// <summary>
        /// 补标原因
        /// </summary>
        public Dictionary<string, string> HhzR_FLAG_BBYY = new Dictionary<string, string>();
        /// <summary>
        /// 有效期
        /// </summary>
        public Dictionary<string, string> HhzR_FLAG_YXQ = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_RESULT_YESORNO = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_RESULT_JCLX = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_RESULT_JCFF = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_RESULT_PDJG = new Dictionary<string, string>();
        public Dictionary<string, string> HhzR_RESULT_DSLX = new Dictionary<string, string>();
        /// <summary>
        /// 检测异常类型
        /// </summary>
        public Dictionary<string, string> HhzR_RESULT_JCYCLX = new Dictionary<string, string>();
        /// <summary>
        /// 终止原因
        /// </summary>
        public Dictionary<string, string> HhzR_RESULT_ZZYY = new Dictionary<string, string>();
        /// <summary>
        /// 数据类型
        /// </summary>
        public Dictionary<string, string> HhzR_RESULT_SJLX = new Dictionary<string, string>();
        
        public Hhzclient(string url)
        {
            Hhz_VEHICLE_HPZL.Add("01", "大型汽车");
            Hhz_VEHICLE_HPZL.Add("02", "小型汽车");
            Hhz_VEHICLE_HPZL.Add("03", "使馆汽车");
            Hhz_VEHICLE_HPZL.Add("04", "领馆汽车");
            Hhz_VEHICLE_HPZL.Add("05", "境外汽车");
            Hhz_VEHICLE_HPZL.Add("06", "外籍汽车");
            Hhz_VEHICLE_HPZL.Add("07", "两、三轮摩托车");
            Hhz_VEHICLE_HPZL.Add("08", "轻便摩托车");
            Hhz_VEHICLE_HPZL.Add("09", "使馆摩托车");
            Hhz_VEHICLE_HPZL.Add("10", "领馆摩托车");
            Hhz_VEHICLE_HPZL.Add("11", "境外摩托车");
            Hhz_VEHICLE_HPZL.Add("12", "外籍摩托车");
            Hhz_VEHICLE_HPZL.Add("13", "农用运输车");
            Hhz_VEHICLE_HPZL.Add("14", "拖拉机");
            Hhz_VEHICLE_HPZL.Add("15", "挂车");
            Hhz_VEHICLE_HPZL.Add("16", "教练汽车");
            Hhz_VEHICLE_HPZL.Add("17", "教练摩托车");
            Hhz_VEHICLE_HPZL.Add("18", "试验汽车");
            Hhz_VEHICLE_HPZL.Add("19", "试验摩托车");
            Hhz_VEHICLE_HPZL.Add("20", "临时人境汽车");
            Hhz_VEHICLE_HPZL.Add("21", "临时人境摩托车");
            Hhz_VEHICLE_HPZL.Add("22", "临时行驶车");
            Hhz_VEHICLE_HPZL.Add("23", "警用汽车");
            Hhz_VEHICLE_HPZL.Add("24", "警用摩托");
            Hhz_VEHICLE_HPZL.Add("99", "其他");

            HhzR_VEHICLE_HPZL.Add("大型汽车", "01");
            HhzR_VEHICLE_HPZL.Add("小型汽车", "02");
            HhzR_VEHICLE_HPZL.Add("使馆汽车", "03");
            HhzR_VEHICLE_HPZL.Add("领馆汽车", "04");
            HhzR_VEHICLE_HPZL.Add("境外汽车", "05");
            HhzR_VEHICLE_HPZL.Add("外籍汽车", "06");
            HhzR_VEHICLE_HPZL.Add("两、三轮摩托车", "07");
            HhzR_VEHICLE_HPZL.Add("轻便摩托车", "08");
            HhzR_VEHICLE_HPZL.Add("使馆摩托车", "09");
            HhzR_VEHICLE_HPZL.Add("领馆摩托车", "10");
            HhzR_VEHICLE_HPZL.Add("境外摩托车", "11");
            HhzR_VEHICLE_HPZL.Add("外籍摩托车", "12");
            HhzR_VEHICLE_HPZL.Add("农用运输车", "13");
            HhzR_VEHICLE_HPZL.Add("拖拉机", "14");
            HhzR_VEHICLE_HPZL.Add("挂车", "15");
            HhzR_VEHICLE_HPZL.Add("教练汽车", "16");
            HhzR_VEHICLE_HPZL.Add("教练摩托车", "17");
            HhzR_VEHICLE_HPZL.Add("试验汽车", "18");
            HhzR_VEHICLE_HPZL.Add("试验摩托车", "19");
            HhzR_VEHICLE_HPZL.Add("临时人境汽车", "20");
            HhzR_VEHICLE_HPZL.Add("临时人境摩托车", "21");
            HhzR_VEHICLE_HPZL.Add("临时行驶车", "22");
            HhzR_VEHICLE_HPZL.Add("警用汽车", "23");
            HhzR_VEHICLE_HPZL.Add("警用摩托", "24");
            HhzR_VEHICLE_HPZL.Add("其他", "99");


            Hhz_VEHICLE_HCLTYPE.Add("1", "三元催化");
            Hhz_VEHICLE_HCLTYPE.Add("2", "DPF");
            Hhz_VEHICLE_HCLTYPE.Add("3", "SCF");
            Hhz_VEHICLE_HCLTYPE.Add("4", "DOC");
            Hhz_VEHICLE_HCLTYPE.Add("5", "POC");
            Hhz_VEHICLE_HCLTYPE.Add("6", "其他");


            HhzR_VEHICLE_HCLTYPE.Add("三元催化", "1");
            HhzR_VEHICLE_HCLTYPE.Add("DPF", "2");
            HhzR_VEHICLE_HCLTYPE.Add("SCF", "3");
            HhzR_VEHICLE_HCLTYPE.Add("DOC", "4");
            HhzR_VEHICLE_HCLTYPE.Add("POC", "5");
            HhzR_VEHICLE_HCLTYPE.Add("其他", "6");


            Hhz_AckCode.Add("0", "上传成功");
            Hhz_AckCode.Add("01", "上传数据格式错误");
            Hhz_AckCode.Add("02", "检测方法缺失");
            Hhz_AckCode.Add("03", "数据不完整");
            Hhz_AckCode.Add("030", "车辆信息缺失");
            Hhz_AckCode.Add("031", "检测登记信息缺失");
            Hhz_AckCode.Add("032", "怠速检测信息缺失");
            Hhz_AckCode.Add("033", "简易稳态工况检测信息缺失");
            Hhz_AckCode.Add("034", "简易稳态工况检测信息缺失");
            Hhz_AckCode.Add("035", "加载减速工况检测信息缺失");
            Hhz_AckCode.Add("036", "自由加速检测信息缺失");
            Hhz_AckCode.Add("041", "监测站无效");
            Hhz_AckCode.Add("042", "检测线无效");
            Hhz_AckCode.Add("043", "检测人员编码无效");
            Hhz_AckCode.Add("044", "检测超限");


            Hhz_JCZ_JJLX.Add("0", "国有全资");
            Hhz_JCZ_JJLX.Add("1", "集体全资");
            Hhz_JCZ_JJLX.Add("2", "股份合作");
            Hhz_JCZ_JJLX.Add("3", "联营");
            Hhz_JCZ_JJLX.Add("4", "私有");
            Hhz_JCZ_JJLX.Add("5", "其他内资");

            HhzR_JCZ_JJLX.Add("国有全资", "0");
            HhzR_JCZ_JJLX.Add("集体全资", "1");
            HhzR_JCZ_JJLX.Add("股份合作", "2");
            HhzR_JCZ_JJLX.Add("联营", "3");
            HhzR_JCZ_JJLX.Add("私有", "4");
            HhzR_JCZ_JJLX.Add("其他内资", "5");

            Hhz_JCZ_YESORNO.Add("0", "否");
            Hhz_JCZ_YESORNO.Add("1", "是");

            HhzR_JCZ_YESORNO.Add("否","0");
            HhzR_JCZ_YESORNO.Add( "是","1");

            Hhz_JCZ_VMASORASM.Add("0", "ASM");
            Hhz_JCZ_VMASORASM.Add("1", "VMAS");

            HhzR_JCZ_VMASORASM.Add( "ASM", "0");
            HhzR_JCZ_VMASORASM.Add( "VMAS", "1");

            Hhz_PERSON_SEX.Add("0", "女");
            Hhz_PERSON_SEX.Add("1", "男");

            HhzR_PERSON_SEX.Add("女", "0");
            HhzR_PERSON_SEX.Add("男", "1");

            Hhz_PERSON_EDUCATION.Add("0", "大专以下");
            Hhz_PERSON_EDUCATION.Add("1", "大专");
            Hhz_PERSON_EDUCATION.Add("2", "本科");
            Hhz_PERSON_EDUCATION.Add("3", "研究生");
            Hhz_PERSON_EDUCATION.Add("4", "博士");
            Hhz_PERSON_EDUCATION.Add("5", "大学学历");
            HhzR_PERSON_EDUCATION.Add("大专以下", "0");
            HhzR_PERSON_EDUCATION.Add("大专", "1");
            HhzR_PERSON_EDUCATION.Add("本科", "2");
            HhzR_PERSON_EDUCATION.Add("研究生", "3");
            HhzR_PERSON_EDUCATION.Add("博士", "4");
            HhzR_PERSON_EDUCATION.Add("大学学历", "5");

            Hhz_PERSON_POST.Add("0", "高级工程师");
            Hhz_PERSON_POST.Add("1", "工程师");
            Hhz_PERSON_POST.Add("2", "技术人员");
            Hhz_PERSON_POST.Add("3", "技术负责人");
            Hhz_PERSON_POST.Add("4", "质量负责人");
            HhzR_PERSON_POST.Add("高级工程师", "0");
            HhzR_PERSON_POST.Add("工程师", "1");
            HhzR_PERSON_POST.Add("技术人员", "2");
            HhzR_PERSON_POST.Add("技术负责人", "3");
            HhzR_PERSON_POST.Add("质量负责人", "4");
            Hhz_PERSON_STATE.Add("0", "正常");
            Hhz_PERSON_STATE.Add("1", "暂停");
            Hhz_PERSON_STATE.Add("2", "无效");
            HhzR_PERSON_STATE.Add("正常", "0");
            HhzR_PERSON_STATE.Add("暂停", "1");
            HhzR_PERSON_STATE.Add("无效", "2");
            Hhz_LINE_TYPE.Add("0", "轻汽");
            Hhz_LINE_TYPE.Add("1", "重汽");
            Hhz_LINE_TYPE.Add("2", "轻柴");
            Hhz_LINE_TYPE.Add("3", "重柴");
            Hhz_LINE_TYPE.Add("4", "汽柴混合");
            HhzR_LINE_TYPE.Add("轻汽", "0");
            HhzR_LINE_TYPE.Add("重汽", "1");
            HhzR_LINE_TYPE.Add("轻柴", "2");
            HhzR_LINE_TYPE.Add("重柴", "3");
            HhzR_LINE_TYPE.Add("汽柴混合", "4");
            Hhz_LINE_STATE.Add("0", "关");
            Hhz_LINE_STATE.Add("1", "开");
            Hhz_LINE_STATE.Add("2", "检修");
            HhzR_LINE_STATE.Add("关", "0");
            HhzR_LINE_STATE.Add("开", "1");
            Hhz_LINE_STATE.Add("检修", "2");
            Hhz_LINE_ISLOCK.Add("0", "运行");
            Hhz_LINE_ISLOCK.Add("1", "锁止");
            Hhz_VEHICLE_CPYS.Add("1", "蓝牌");
            Hhz_VEHICLE_CPYS.Add("2", "黄牌");
            Hhz_VEHICLE_CPYS.Add("3", "白牌");
            Hhz_VEHICLE_CPYS.Add("4", "黑牌");
            HhzR_VEHICLE_CPYS.Add("蓝牌", "1");
            HhzR_VEHICLE_CPYS.Add("黄牌", "2");
            HhzR_VEHICLE_CPYS.Add("白牌", "3");
            HhzR_VEHICLE_CPYS.Add("黑牌", "4");
            Hhz_VEHICLE_PFBZ.Add("0", "国零");
            Hhz_VEHICLE_PFBZ.Add("1", "国I");
            Hhz_VEHICLE_PFBZ.Add("2", "国II");
            Hhz_VEHICLE_PFBZ.Add("3", "国III");
            Hhz_VEHICLE_PFBZ.Add("4", "国IV");
            Hhz_VEHICLE_PFBZ.Add("5", "国V");
            Hhz_VEHICLE_PFBZ.Add("6", "国VI");
            HhzR_VEHICLE_PFBZ.Add("国零", "0");
            HhzR_VEHICLE_PFBZ.Add("国I", "1");
            HhzR_VEHICLE_PFBZ.Add("国II", "2");
            HhzR_VEHICLE_PFBZ.Add("国III", "3");
            HhzR_VEHICLE_PFBZ.Add("国IV", "4");
            HhzR_VEHICLE_PFBZ.Add("国V", "5");
            HhzR_VEHICLE_PFBZ.Add("国VI", "6");
            Hhz_VEHICLE_CLZL.Add("0", "汽油车(含天然气)");
            Hhz_VEHICLE_CLZL.Add("1", "柴油车");
            Hhz_VEHICLE_CLZL.Add("2", "电动车");
            Hhz_VEHICLE_CLZL.Add("3", "混合动力");
            HhzR_VEHICLE_CLZL.Add("汽油车(含天然气)", "0");
            HhzR_VEHICLE_CLZL.Add("柴油车", "1");
            HhzR_VEHICLE_CLZL.Add("电动车", "2");
            HhzR_VEHICLE_CLZL.Add("混合动力", "3");
            Hhz_VEHICLE_QDXS.Add("01", "前驱");
            Hhz_VEHICLE_QDXS.Add("02", "后驱");
            Hhz_VEHICLE_QDXS.Add("03", "四驱");
            Hhz_VEHICLE_QDXS.Add("04", "全时四驱");
            HhzR_VEHICLE_QDXS.Add("前驱", "01");
            HhzR_VEHICLE_QDXS.Add("后驱", "02");
            HhzR_VEHICLE_QDXS.Add("四驱", "03");
            HhzR_VEHICLE_QDXS.Add("全时四驱", "04");
            Hhz_VEHICLE_BSQXS.Add("01", "手动档");
            Hhz_VEHICLE_BSQXS.Add("02", "自动档");
            Hhz_VEHICLE_BSQXS.Add("03", "手自一体");
            HhzR_VEHICLE_BSQXS.Add("手动档", "01");
            HhzR_VEHICLE_BSQXS.Add("自动档", "02");
            HhzR_VEHICLE_BSQXS.Add("手自一体", "03");
            Hhz_VEHICLE_RLZL.Add("A", "汽油");
            Hhz_VEHICLE_RLZL.Add("B", "柴油");
            Hhz_VEHICLE_RLZL.Add("C", "电");
            Hhz_VEHICLE_RLZL.Add("D", "混合油");
            Hhz_VEHICLE_RLZL.Add("E", "天然气");
            Hhz_VEHICLE_RLZL.Add("F", "液化石油气");
            Hhz_VEHICLE_RLZL.Add("L", "甲醇");
            Hhz_VEHICLE_RLZL.Add("M", "乙醇");
            Hhz_VEHICLE_RLZL.Add("N", "太阳能");
            Hhz_VEHICLE_RLZL.Add("O", "混合动力");
            Hhz_VEHICLE_RLZL.Add("X", "氢");
            Hhz_VEHICLE_RLZL.Add("Y", "无");
            Hhz_VEHICLE_RLZL.Add("Z", "其他");
            Hhz_VEHICLE_RLZL.Add("AC", "汽油电力混合");
            Hhz_VEHICLE_RLZL.Add("BC", "柴油电力混合");
            Hhz_VEHICLE_RLZL.Add("AE", "汽油天然气混合");
            Hhz_VEHICLE_RLZL.Add("BE", "柴油天然气混合");
            Hhz_VEHICLE_RLZL.Add("AF", "汽油液化石油气混合");
            Hhz_VEHICLE_RLZL.Add("BF", "柴油液化石油气混合");

            HhzR_VEHICLE_RLZL.Add("汽油", "A");
            HhzR_VEHICLE_RLZL.Add("柴油", "B");
            HhzR_VEHICLE_RLZL.Add("电", "C");
            HhzR_VEHICLE_RLZL.Add("混合油", "D");
            HhzR_VEHICLE_RLZL.Add("天然气", "E");
            HhzR_VEHICLE_RLZL.Add("液化石油气", "F");
            HhzR_VEHICLE_RLZL.Add("甲醇", "L");
            HhzR_VEHICLE_RLZL.Add("乙醇", "M");
            HhzR_VEHICLE_RLZL.Add("太阳能", "N");
            HhzR_VEHICLE_RLZL.Add("混合动力", "O");
            HhzR_VEHICLE_RLZL.Add("氢", "X");
            HhzR_VEHICLE_RLZL.Add("无", "Y");
            HhzR_VEHICLE_RLZL.Add("其他", "Z");
            HhzR_VEHICLE_RLZL.Add("汽油电力混合", "AC");
            HhzR_VEHICLE_RLZL.Add("柴油电力混合", "BC");
            HhzR_VEHICLE_RLZL.Add("汽油天然气混合", "AE");
            HhzR_VEHICLE_RLZL.Add("柴油天然气混合", "BE");
            HhzR_VEHICLE_RLZL.Add("汽油液化石油气混合", "AF");
            HhzR_VEHICLE_RLZL.Add("柴油液化石油气混合", "BF");

            Hhz_VEHICLE_GYFS.Add("01", "化油器");
            Hhz_VEHICLE_GYFS.Add("02", "化油器改造");
            Hhz_VEHICLE_GYFS.Add("03", "开环电喷");
            Hhz_VEHICLE_GYFS.Add("04", "闭环电喷");
            Hhz_VEHICLE_GYFS.Add("05", "高压共轨");
            Hhz_VEHICLE_GYFS.Add("06", "泵喷嘴");
            Hhz_VEHICLE_GYFS.Add("07", "单体泵");
            Hhz_VEHICLE_GYFS.Add("08", "直列泵");
            Hhz_VEHICLE_GYFS.Add("09", "机械泵");
            Hhz_VEHICLE_GYFS.Add("99", "其他");
            HhzR_VEHICLE_GYFS.Add("化油器", "01");
            HhzR_VEHICLE_GYFS.Add("化油器改造", "02");
            HhzR_VEHICLE_GYFS.Add("开环电喷", "03");
            HhzR_VEHICLE_GYFS.Add("闭环电喷", "04");
            HhzR_VEHICLE_GYFS.Add("高压共轨", "05");
            HhzR_VEHICLE_GYFS.Add("泵喷嘴", "06");
            HhzR_VEHICLE_GYFS.Add("单体泵", "07");
            HhzR_VEHICLE_GYFS.Add("直列泵", "08");
            HhzR_VEHICLE_GYFS.Add("机械泵", "09");
            HhzR_VEHICLE_GYFS.Add("其他", "99");

            Hhz_VEHICLE_DPFS.Add("0", "单点电喷");
            Hhz_VEHICLE_DPFS.Add("1", "多点电喷");
            HhzR_VEHICLE_DPFS.Add("单点电喷", "0");
            HhzR_VEHICLE_DPFS.Add("多点电喷", "1");

            Hhz_VEHICLE_YESORNO.Add("N", "否");
            Hhz_VEHICLE_YESORNO.Add("Y", "是");
            HhzR_VEHICLE_YESORNO.Add("否", "N");
            HhzR_VEHICLE_YESORNO.Add("是", "Y");

            Hhz_VEHICLE_JQFS.Add("01", "涡轮增压");
            Hhz_VEHICLE_JQFS.Add("02", "自然进气");
            Hhz_VEHICLE_JQFS.Add("99", "其他");
            HhzR_VEHICLE_JQFS.Add("涡轮增压", "01");
            HhzR_VEHICLE_JQFS.Add("自然进气", "02");
            HhzR_VEHICLE_JQFS.Add("其他", "99");

            Hhz_VEHICLE_CCLX.Add("0", "二冲程");
            Hhz_VEHICLE_CCLX.Add("1", "四冲程");
            HhzR_VEHICLE_CCLX.Add("二冲程", "0");
            HhzR_VEHICLE_CCLX.Add("四冲程", "1");

            Hhz_VEHICLE_CHZZ.Add("0", "无");
            Hhz_VEHICLE_CHZZ.Add("1", "能解锁");
            Hhz_VEHICLE_CHZZ.Add("2", "不能解锁");
            HhzR_VEHICLE_CHZZ.Add("无", "0");
            HhzR_VEHICLE_CHZZ.Add("能解锁", "1");
            HhzR_VEHICLE_CHZZ.Add("不能解锁", "2");

            Hhz_VEHICLE_SYXZ.Add("A", "非营运");
            Hhz_VEHICLE_SYXZ.Add("B", "公路客运");
            Hhz_VEHICLE_SYXZ.Add("C", "公交客运");
            Hhz_VEHICLE_SYXZ.Add("D", "出租客运");
            Hhz_VEHICLE_SYXZ.Add("E", "旅游客运");
            Hhz_VEHICLE_SYXZ.Add("F", "货运");
            Hhz_VEHICLE_SYXZ.Add("G", "租赁");
            Hhz_VEHICLE_SYXZ.Add("H", "警用");
            Hhz_VEHICLE_SYXZ.Add("I", "消防");
            Hhz_VEHICLE_SYXZ.Add("J", "救护");
            Hhz_VEHICLE_SYXZ.Add("K", "工程抢险");
            Hhz_VEHICLE_SYXZ.Add("L", "营转非");
            Hhz_VEHICLE_SYXZ.Add("M", "出租转非");
            Hhz_VEHICLE_SYXZ.Add("N", "教练");
            Hhz_VEHICLE_SYXZ.Add("O", "幼儿校车");
            Hhz_VEHICLE_SYXZ.Add("P", "小学生校车");
            Hhz_VEHICLE_SYXZ.Add("Q", "初中生校车");
            Hhz_VEHICLE_SYXZ.Add("R", "危险品校车");
            Hhz_VEHICLE_SYXZ.Add("S", "中小学生校车");

            HhzR_VEHICLE_SYXZ.Add("非营运", "A");
            HhzR_VEHICLE_SYXZ.Add("公路客运", "B");
            HhzR_VEHICLE_SYXZ.Add("公交客运", "C");
            HhzR_VEHICLE_SYXZ.Add("出租客运", "D");
            HhzR_VEHICLE_SYXZ.Add("旅游客运", "E");
            HhzR_VEHICLE_SYXZ.Add("货运", "F");
            HhzR_VEHICLE_SYXZ.Add("租赁", "G");
            HhzR_VEHICLE_SYXZ.Add("警用", "H");
            HhzR_VEHICLE_SYXZ.Add("消防", "I");
            HhzR_VEHICLE_SYXZ.Add("救护", "J");
            HhzR_VEHICLE_SYXZ.Add("工程抢险", "K");
            HhzR_VEHICLE_SYXZ.Add("营转非", "L");
            HhzR_VEHICLE_SYXZ.Add("出租转非", "M");
            HhzR_VEHICLE_SYXZ.Add("教练", "N");
            HhzR_VEHICLE_SYXZ.Add("幼儿校车", "O");
            HhzR_VEHICLE_SYXZ.Add("小学生校车", "P");
            HhzR_VEHICLE_SYXZ.Add("初中生校车", "Q");
            HhzR_VEHICLE_SYXZ.Add("危险品校车", "R");
            HhzR_VEHICLE_SYXZ.Add("中小学生校车", "S");

            Hhz_VEHICLE_CARORTRUCK.Add("K", "客车");
            Hhz_VEHICLE_CARORTRUCK.Add("H", "货车");
            HhzR_VEHICLE_CARORTRUCK.Add("客车", "K");
            HhzR_VEHICLE_CARORTRUCK.Add("货车", "H");

            Hhz_FLAG_TYPE.Add("0", "黄标");
            Hhz_FLAG_TYPE.Add("1", "绿标");
            HhzR_FLAG_TYPE.Add("黄标", "0");
            HhzR_FLAG_TYPE.Add("绿标", "1");

            Hhz_FLAG_YESORNO.Add("0", "否");
            Hhz_FLAG_YESORNO.Add("1", "是");
            HhzR_FLAG_YESORNO.Add("否", "0");
            HhzR_FLAG_YESORNO.Add("是", "1");

            Hhz_FLAG_BBYY.Add("0", "标志丢失");
            Hhz_FLAG_BBYY.Add("1", "标志损坏");
            Hhz_FLAG_BBYY.Add("2", "标志发错");
            Hhz_FLAG_BBYY.Add("3", "打印错误");
            Hhz_FLAG_BBYY.Add("4", "其他");
            HhzR_FLAG_BBYY.Add("标志丢失", "0");
            HhzR_FLAG_BBYY.Add("标志损坏", "1");
            HhzR_FLAG_BBYY.Add("标志发错", "2");
            HhzR_FLAG_BBYY.Add("打印错误", "3");
            HhzR_FLAG_BBYY.Add("其他", "4");

            Hhz_FLAG_YXQ.Add("0", "2年");
            Hhz_FLAG_YXQ.Add("1", "1年");
            Hhz_FLAG_YXQ.Add("2", "半年");
            HhzR_FLAG_YXQ.Add("2年", "0");
            HhzR_FLAG_YXQ.Add("1年", "1");
            HhzR_FLAG_YXQ.Add("半年", "2");

            Hhz_RESULT_YESORNO.Add("0", "否");
            Hhz_RESULT_YESORNO.Add("1", "是");
            HhzR_RESULT_YESORNO.Add("否", "0");
            HhzR_RESULT_YESORNO.Add("是", "1");

            Hhz_RESULT_JCLX.Add("0", "年检");
            Hhz_RESULT_JCLX.Add("1", "复检-遥感");
            Hhz_RESULT_JCLX.Add("2", "复检-路检");
            Hhz_RESULT_JCLX.Add("3", "抽检");
            Hhz_RESULT_JCLX.Add("4", "委托年检");
            Hhz_RESULT_JCLX.Add("5", "办理环保合格证");
            Hhz_RESULT_JCLX.Add("6", "外地车转入");
            Hhz_RESULT_JCLX.Add("7", "过户车");
            HhzR_RESULT_JCLX.Add("年检", "0");
            HhzR_RESULT_JCLX.Add("复检-遥感", "1");
            HhzR_RESULT_JCLX.Add("复检-路检", "2");
            HhzR_RESULT_JCLX.Add("抽检", "3");
            HhzR_RESULT_JCLX.Add("委托年检", "4");
            HhzR_RESULT_JCLX.Add("办理环保合格证", "5");
            HhzR_RESULT_JCLX.Add("外地车转入", "6");
            HhzR_RESULT_JCLX.Add("过户车", "7");

            Hhz_RESULT_JCFF.Add("DB", "SDS");
            Hhz_RESULT_JCFF.Add("WT", "ASM");
            Hhz_RESULT_JCFF.Add("IG", "VMAS");
            Hhz_RESULT_JCFF.Add("ST", "瞬态");
            Hhz_RESULT_JCFF.Add("LZ", "LZ");
            Hhz_RESULT_JCFF.Add("TG", "ZYJS");
            Hhz_RESULT_JCFF.Add("LD", "JZJS");
            HhzR_RESULT_JCFF.Add("SDS", "DB");
            HhzR_RESULT_JCFF.Add("ASM", "WT");
            HhzR_RESULT_JCFF.Add("VMAS", "IG");
            HhzR_RESULT_JCFF.Add("瞬态", "ST");
            HhzR_RESULT_JCFF.Add("LZ", "LZ");
            HhzR_RESULT_JCFF.Add("ZYJS", "TG");
            HhzR_RESULT_JCFF.Add("JZJS", "LD");

            Hhz_RESULT_PDJG.Add("0", "不合格");
            Hhz_RESULT_PDJG.Add("1", "合格");
            HhzR_RESULT_PDJG.Add("不合格", "0");
            HhzR_RESULT_PDJG.Add("合格", "1");

            Hhz_RESULT_DSLX.Add("0", "双怠速");
            Hhz_RESULT_DSLX.Add("1", "怠速");
            HhzR_RESULT_DSLX.Add("双怠速", "0");
            HhzR_RESULT_DSLX.Add("怠速", "1");

            Hhz_RESULT_JCYCLX.Add("0", "过程数据比对有问题");
            Hhz_RESULT_JCYCLX.Add("1", "数据合理性分析有问题");
            Hhz_RESULT_JCYCLX.Add("3", "检测结果计算有问题");
            Hhz_RESULT_JCYCLX.Add("4", "EIS上传检测结果与系统计算结果数据");
            Hhz_RESULT_JCYCLX.Add("5", "RFID一致性校验有问 题");
            Hhz_RESULT_JCYCLX.Add("6", "检测过程分析有问题");

            Hhz_RESULT_ZZYY.Add("0", "无故障，检测正常");
            Hhz_RESULT_ZZYY.Add("1", "底盘测功机故障");
            Hhz_RESULT_ZZYY.Add("2", "废气分析仪故障");
            Hhz_RESULT_ZZYY.Add("3", "烟度计故障");
            Hhz_RESULT_ZZYY.Add("4", "转速计故障");
            Hhz_RESULT_ZZYY.Add("5", "超过允许重检次数");
            Hhz_RESULT_ZZYY.Add("6", "气体稀释");
            Hhz_RESULT_ZZYY.Add("7", "采样管被堵");
            Hhz_RESULT_ZZYY.Add("8", "车辆故障常");
            Hhz_RESULT_ZZYY.Add("9", "用户主动终止");
            Hhz_RESULT_ZZYY.Add("10", "其他设备故障常");
            Hhz_RESULT_ZZYY.Add("11", "其他原因");

            Hhz_RESULT_SJLX.Add("0", "只做5025");
            Hhz_RESULT_SJLX.Add("1", "只做5025和2540");
            Hhz_RESULT_SJLX.Add("2", "只做5025和怠速");
            Hhz_RESULT_SJLX.Add("3", "只做5025，2540和怠速");

            this.url = url;
            
        }
        #region json相关
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
        public bool JsonPost(string path, string jsonParas, out string responseStatus, out string responseDescription, out string code, out string message)
        {
            responseStatus = "";
            responseDescription = "";
            string strURL = url + path+"/";
            //创建一个HTTP请求  
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/x-www-form-urlencoded";
            //设置参数，并进行URL编码 
            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;

            ini.INIIO.saveSocketLogInf("\r\n[POST]:\r\n" + "strURL=" + strURL + "\r\nrequest.Method=" + request.Method + "\r\nrequest.ContentType=" + request.ContentType + "\r\njsondata=" + jsonParas);
            //发送请求，获得请求流 
            Stream newStream = request.GetRequestStream();
            
            newStream.Write(payload, 0, payload.Length);
            newStream.Close();

            HttpWebResponse response;
            try
            {
                string result = "";
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    result = sr.ReadToEnd();
                    if (result != "")
                    {
                        //textBoxResult.Text = "GET:" + result;
                        Console.WriteLine("GET:" + result);
                    }
                    else
                    {
                        // textBoxResult.Text = "GET NONE";
                        Console.WriteLine("GET NONE");
                    }

                    responseStatus = ((int)(response.StatusCode)).ToString();
                    responseDescription = result;
                    code = "1";
                    message = "";
                    ini.INIIO.saveSocketLogInf("\r\n[RESPONSE]:\r\nHTTPCODE=" + responseStatus + "\r\nDescription=" + responseDescription);
                    //在这里对接收到的页面内容进行处理
                }

                return true;//返回Json数据
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                Stream s = response.GetResponseStream();
                //Stream postData = Request.InputStream;
                StreamReader sRead = new StreamReader(s);
                string postContent = sRead.ReadToEnd();
                sRead.Close();
                code = "-1";
                message = postContent;
                ini.INIIO.saveSocketLogInf("response异常："+ex.Message+"\r\n异常响应content:"+message);
                return false;
            }
        }
        #endregion
        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="data">hashtable数据</param>
        /// <param name="lx">数据类型</param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadHashtableJson(string jsonstring, DATALX lx,out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            try
            {
                ini.INIIO.saveSocketLogInf("【发送数据】:"+ DATAPATH[(int)lx]);
                if (JsonPost(DATAPATH[(int)lx], jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "0")
                        {
                            return true;
                        }
                        else
                        {
                            Hhz_AckCode.TryGetValue(responseStatus, out message);
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 以JsonObject字符串形式上传
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="lx"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadJsonObject(Hashtable ht, DATALX lx, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            try
            {
                ini.INIIO.saveSocketLogInf("【发送数据】:" + DATAPATH[(int)lx]);
                string jsonstring = JsonConvert.SerializeObject(ht);
                if (JsonPost(DATAPATH[(int)lx], jsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200")
                        {
                            string ackjsonstring = responseDescription;
                            if (ackjsonstring != "{}"&&ackjsonstring!="[]")
                            {
                                JObject ackjosnobject = (JObject)JsonConvert.DeserializeObject(responseDescription);
                                using (IEnumerator<KeyValuePair<string, JToken>> enumerator = ackjosnobject.GetEnumerator())
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        KeyValuePair<string, JToken> item = enumerator.Current;
                                        var Key = item.Key.ToString();
                                        var ackcode = item.Value.ToString();
                                        if (ackcode == "0")
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            message = ackcode;
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 以JsonArray字符串形式上传
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="lx"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool uploadJsonArray(Hashtable ht, DATALX lx, out string code, out string message)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            try
            {
                ini.INIIO.saveSocketLogInf("【发送数据】:" + DATAPATH[(int)lx]);
                string jsonstring = ObjectToJson(ht);
                JObject j1 = (JObject)JsonConvert.DeserializeObject(jsonstring);
                JArray arrFile = new JArray();
                arrFile.Add(j1);
                string modeljsonstring = "Jsondata=" + arrFile.ToString();
                if (JsonPost(DATAPATH[(int)lx], modeljsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if ( responseStatus == "200")
                        {
                            string ackjsonstring = responseDescription;
                            if (ackjsonstring != "{}" && ackjsonstring != "[]")
                            {
                                JObject ackjosnobject = (JObject)JsonConvert.DeserializeObject(responseDescription);
                                using (IEnumerator<KeyValuePair<string, JToken>> enumerator = ackjosnobject.GetEnumerator())
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        KeyValuePair<string, JToken> item = enumerator.Current;
                                        var Key = item.Key.ToString();
                                        var ackcode = item.Value.ToString();
                                        if (ackcode == "0")
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            message = ackcode;
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                return true;
                            }
                            //string ackcode = ackjosnobject["null"].ToString();
                            
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        public bool uploadJsonArray(string clid,Hashtable ht, DATALX lx, out string code, out string message,out JObject queryobject)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            queryobject =null;
            try
            {
                ini.INIIO.saveSocketLogInf("【发送数据】:" + DATAPATH[(int)lx]);
                string jsonstring = ObjectToJson(ht);
                JObject j1 = (JObject)JsonConvert.DeserializeObject(jsonstring);
                JArray arrFile = new JArray();
                arrFile.Add(j1);
                string modeljsonstring = "Jsondata=" + arrFile.ToString();
                if (JsonPost(DATAPATH[(int)lx], modeljsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200")
                        {
                            string ackjsonstring = responseDescription;
                            queryobject= (JObject)JsonConvert.DeserializeObject(responseDescription);
                            
                            if (ackjsonstring != "{}" && ackjsonstring != "[]")
                            {
                                JObject ackjosnobject = (JObject)JsonConvert.DeserializeObject(responseDescription);
                                
                                using (IEnumerator<KeyValuePair<string, JToken>> enumerator = ackjosnobject.GetEnumerator())
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        KeyValuePair<string, JToken> item = enumerator.Current;
                                        var Key = item.Key.ToString();
                                        var ackcode = item.Value.ToString();
                                        if(Key=="code")//如果返回的有code值
                                        {
                                            code = ackcode;
                                            return true;
                                        }
                                    }
                                    message = responseDescription;
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                            }
                            //string ackcode = ackjosnobject["null"].ToString();

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 以JsonArray字符串形式上传
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="lx"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool queryData(Hashtable ht, DATALX lx, out string code, out string message,out JObject queryresult)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            queryresult = new JObject();
            try
            {
                ini.INIIO.saveSocketLogInf("【发送数据】:" + DATAPATH[(int)lx]);
                string jsonstring = ObjectToJson(ht);
                JObject j1 = (JObject)JsonConvert.DeserializeObject(jsonstring);
                JArray arrFile = new JArray();
                arrFile.Add(j1);
                string modeljsonstring = "Jsondata=" + arrFile.ToString();
                if (JsonPost(DATAPATH[(int)lx], modeljsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200")
                        {
                            queryresult = (JObject)JsonConvert.DeserializeObject(responseDescription);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
        /// <summary>
        /// 以JsonArray字符串形式上传
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="lx"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool queryData(Hashtable ht, DATALX lx, out string code, out string message, out string queryresult)
        {
            message = "";
            string responseStatus = "";
            string responseDescription = "";
            try
            {
                ini.INIIO.saveSocketLogInf("【发送数据】:" + DATAPATH[(int)lx]);
                string jsonstring = ObjectToJson(ht);
                JObject j1 = (JObject)JsonConvert.DeserializeObject(jsonstring);
                JArray arrFile = new JArray();
                arrFile.Add(j1);
                string modeljsonstring = "Jsondata=" + arrFile.ToString();
                if (JsonPost(DATAPATH[(int)lx], modeljsonstring, out responseStatus, out responseDescription, out code, out message))
                {
                    queryresult = responseDescription;
                    if (code == "-1")
                    {
                        ini.INIIO.saveSocketLogInf("RESPONSE数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                        return false;
                    }
                    else
                    {
                        if (responseStatus == "200")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    queryresult = "";
                    ini.INIIO.saveSocketLogInf("POST数据失败:\r\ncode=" + code + "\r\nmessage=" + message);
                    return false;
                }
            }
            catch (Exception er)
            {
                queryresult = "";
                ini.INIIO.saveSocketLogInf("发生异常:\r\n" + er.Message);
                code = "-1";
                message = er.Message;
                return false;
            }
        }
    }
}
