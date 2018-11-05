using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Xml;
using ini;
using System.IO;

namespace carinfor
{
    public class ACSocketInf
    {
        public string IP;
        public string PORT;
        public string AREA;
    }
    public class NeusoftSocketInf
    {
        public string IP;
        public string PORT;
        public string EISID;
        public string AREA;
        public string YCY;
    }
    public class CCSocketInf
    {
        public string IP;
        public string PORT;
    }
    public class WGSocketInf
    {
        public string IP;	//检测工位号
        public string PORT;	//设备名称
        public string JCZJC;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string SBRZBH;
    }
    public class JHWebInf
    {
        public string weburl;	//webserive url
        public string safepwd;	//安全代码
        public string stationid;	//检测站代码
        public string lineid;	//检测站代码
        public string dbip;
        public string dbuser;
        public string dbpassword;
        public string serverIP;
        public string area;
        public bool checkprint;
    }
    public class AHWebInf
    {
        public string weburl;	//webserive url
        public string lineid;
        public string version;
    }

    public class NHWebInf
    {
        public string weburl;	//webserive url
        public string lineid;
    }
    public class JXWebInf
    {
        public string user;	//webserive url
        public string password;
        public string lineid;
        public string url;
        public string socketip;
        public string socketport;
    }
    public class HNHYWebInf
    {
        public string weburl;	//webserive url
        public string stationid;	//检测站代码
        public string lineid;	//检测站代码
    }
    public class EZWebInf
    {
        public string weburl;	//webserive url
        public string stationid;	//检测站代码
        public string lineid;	//检测站代码
    }
    public class HHZWebInf
    {
        public string weburl;	//webserive url
    }
    public class ZKYTWebInf
    {
        public string weburl;	//webserive url
        public string add;	//webserive url
        public string regcode;
        public DateTime regtime;
        public bool regsuccess;
        public int waitUploadTime;
        public bool checkUploadSuccess;
        public bool displayCheckResult;
        public string lineID;
    }
    public class DALIWebInf
    {
        public string LINEID;
        public string SERVERIP;
        public string SERVERPORT;
    }
    public class GLWebInf
    {
        public string weburl;
        public string user;
        public string password;
    }
    public class XBWebInf
    {
        public string ip;	//webserive url
        public string port;	//检测站代码
        public string lineid;	//检测站代码
        public string version;	//检测站代码
        public string certificateNo;	//检测站代码
        public string diskNo;	//检测站代码
    }
    public class JXPNWebInf
    {
        public string Url;
        public string User;
        public string Pwd;
    }
    public class WGcgjSelfDetectInf
    {
        //以下为测功机数据内容	
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;	//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string JSQJC;	//举升器检查 1：成功 0：失败
        public string TTYRKSSJ;	//台体预热开始时间
        public string TTYRJSSJ;	//台体预热结束时间
        public string GXDL;	//惯性当量，Kg
        public string JZHXDS;	//加载滑行点数
        public string CS1;//车速1（区间），km/h
        public string JZGL1;	//加载功率1， kw
        public string JSGL1;	//寄生功率1，kw
        public string LLHXSJ1;	//理论滑行时间1，S
        public string SJHXSJ1;	//实际滑行时间1，S
        public string PC1;//偏差1 %
        public string CS2;	//车速2（区间）
        public string JZGL2;	//加载功率2
        public string JSGL2;	//寄生功率2
        public string LLHXSJ2;	//理论滑行时间2
        public string SJHXSJ2;	//实际滑行时间2
        public string PC2;	//偏差2
        public string ZJJG;	//自检结果（通过/不通过）
    }
    public class WGfqySelfDetectInf
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;	//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string YQYR;	//仪器预热 1：成功 0：失败
        public string YQJL;	//仪器检漏 1：成功 0：失败
        public string YQTL;	//仪器调零 1：成功 0：失败
        public string YQLL;	//仪器流量，L/S
        public string YQYQ;	//仪器氧气，%
        public string ZJJG;	//自检结果（通过/不通过）
    }
    public class WGydjSelfDetectInf
    {
        //以下为烟度计数据内容	
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string YQYR;	//仪器预热 1：成功 0：失败
        public string YQTL;	//仪器调零 1：成功 0：失败
        public string LCJC;	//量程检查 1：成功 0：失败
        public string JCDS;	//检查点数
        public string BTGSDZ1;		//不透光设定值1，%
        public string BTGSCZ1;	//不透光实测值1，%
        public string BTGPC1;	//不透光偏差1
        public string BTGSDZ2;	//不透光设定值2
        public string BTGSCZ2;	//不透光实测值2
        public string BTGPC2;	//不透光偏差2
        public string ZJJG;//自检结果（通过/不通过）
    }
    public class WGdzhjSelfDetectInf
    {
        //以下为电子环境信息仪数据内容	
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string HJWD;	//环境温度，摄氏度
        public string YQWD;	//仪器温度，摄氏度
        public string HJSD;	//环境湿度，%
        public string YQSD;	//仪器湿度，%
        public string HJQY;	//环境气压，kpa
        public string YQQY;	//仪器气压，kpa
        public string ZJJG;	//自检结果（通过/不通过）
    }
    public class WGzsjSelfDetecInf
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;	//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string DSZS;	//怠速转速
        public string ZJJG;	//自检结果（通过/不通过）
    }
    public class WGlljSelfDetectInf
    {
        //以下为流量计数据内容	
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string YQYR;	//仪器预热 1：成功 0：失败
        public string LLJC;	//流量检查 1：成功 0：失败
        public string YQLL;	//仪器流量，L/S
        public string QYLC;//氧气量程 1：成功 0：失败
        public string YQYQ;	//仪器氧气，%
        public string ZJJG;	//自检结果（通过/不通过）
        public string SynchDate;	
    }
    public class WGspeedDemarcate
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string BDSBMC;//标定设备名称
        public string BDSBXH;		//标定设备型号
        public string Date;	//标定时间如：2008年1月1日22点33分3秒
        public string BDDS;		//标定点数
        public string SDZ1;	//设定值1，km/h
        public string SCZ1;	//实测值1，km/h
        public string PC1;	//误差1，%
        public string SDZ2;	//设定值2
        public string SCZ2;	//实测值2
        public string PC2;	//误差
        public string SDZ3;	//设定值3
        public string SCZ3;	//实测值3
        public string PC3;	//误差3
        public string BDJG;	//标定结果（合格/不合格）
    }
    public class WGforceDemarcate
    {
        public string JCGWH;//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;	//标定设备型号
        public string Date;	//标定时间如：2008年1月1日22点33分3秒
        public string BDDS;		//标定点数
        public string SDZ1;	//设定值1 
        public string SCZ1;//实测值1
        public string PC1;		//误差1，%
        public string SDZ2;//设定值2
        public string SCZ2;	//实测值2
        public string PC2;		//误差2
        public string SDZ3;//设定值3
        public string SCZ3;	//实测值3
        public string PC3;	//误差3
        public string SDZ4;	//设定值4
        public string SCZ4;	//实测值4
        public string PC4;		//误差4
        public string SDZ5;	//设定值5
        public string SCZ5;	//实测值5
        public string PC5;	//误差5
        public string BDJG;	//标定结果（合格/不合格）
    }

    public class WGJSGLdemarcate
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;	//标定设备型号
        public string Date;	//标定时间如：2008年1月1日22点33分3秒
        public string GXDL;	//惯性当量，Kg
        public string BDDS;		//标定点数
        public string CS1;	//车速1（区间），km/h
        public string HXSJ1;		//滑行时间1，s
        public string JSGL1;	//寄生功率1，kw
        public string CS2;	//车速2（区间），km/h
        public string HXSJ2;		//滑行时间2，s
        public string JSGL2;	//寄生功率2，kw
        public string CS3;	//车速3（区间），km/h
        public string HXSJ3;		//滑行时间3，s
        public string JSGL3;	//寄生功率3，kw
        public string CS4;	//车速4（区间），km/h
        public string HXSJ4;		//滑行时间4，s
        public string JSGL4;	//寄生功率4，kw
        public string CS5;//车速5（区间），km/h
        public string HXSJ5;		//滑行时间5，s
        public string JSGL5;	//寄生功率5，kw
        public string BDJG;	//标定结果（合格/不合格）
    }

    public class WGJZHXdemarcate
    {
        public string JCGWH;//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;	//标定设备型号
        public string Date;//标定时间如：2008年1月1日22点33分3秒
        public string GXDL;	//惯性当量，Kg
        public string BDDS;	//标定点数
        public string CS1;	//车速1（区间），km/h
        public string JZGL1;//加载功率1，kw
        public string JSGL1;	//寄生功率1，kw
        public string LLHXSJ1;	//理论滑行时间1  S
        public string SJHXSJ1;//实际滑行时间1  S
        public string PC1;	//偏差1 %
        public string CS2;	//车速2（区间），km/h
        public string JZGL2;//加载功率2，kw
        public string JSGL2;	//寄生功率2，kw
        public string LLHXSJ2;	//理论滑行时间2，s
        public string SJHXSJ2;	//实际滑行时间2，s
        public string PC2;//误差2
        public string BDJG;	//标定结果（合格/不合格）
    }

    public class WGFQYdemarcate
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;	//标定设备型号
        public string BDQND;	//标定气浓度
        public string Date;//标定时间如：2008年1月1日22点33分3秒
        public string BDDS;	//标定点数
        public string HCSDZ1;	//HC设定值1
        public string HCSCZ1;	//HC实测值1
        public string HCPC1;	//HC偏差1， %
        public string COSDZ1;	//CO设定值1
        public string COSCZ1;		//CO实测值1
        public string COPC1;	//CO偏差1，%
        public string CO2SDZ1;	//CO2设定值1
        public string CO2SCZ1;	//CO2实测值1
        public string CO2PC1;	//CO2偏差1 ，%
        public string NOSDZ1;	//NO设定值1
        public string NOSCZ1;		//NO实测值1
        public string NOPC1;	//NO偏差1，%
        public string HCSDZ2;	//HC设定值2
        public string HCSCZ2;	//HC实测值2
        public string HCPC2;//HC偏差2，%
        public string COSDZ2;	//CO设定值2
        public string COSCZ2;	//CO实测值2
        public string COPC2;//CO偏差2，%
        public string CO2SDZ2;	//CO2设定值2
        public string CO2SCZ2;	//CO2实测值2
        public string CO2PC2;	//CO2偏差，%
        public string NOSDZ2;	//NO设定值2
        public string NOSCZ2;	//NO实测值2
        public string NOPC2;		//NO偏差2，%
        public string BDJG;	//标定结果（合格/不合格）
    }

    public class WGYDJdemarcate
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;	//检测站编号(地区编号(6位)+站编号(2位))
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;		//标定设备型号
        public string Date;	//标定时间如：2008年1月1日22点33分3秒
        public string BDDS;	//标定点数
        public string BTGSDZ1;	//不透光设定值1，%
        public string BTGSCZ1;	//不透光实测值1，%
        public string BTGPC1;	//不透光偏差1，%
        public string GXSSSDZ1;	//光吸收数设定值1，/m
        public string GXSSSCZ1;	//光吸收数实测值1， /m
        public string GXSSPC1;//光吸收数偏差1，%
        public string BTGSDZ2;	//不透光设定值2
        public string BTGSCZ2;	//不透光实测值2
        public string BTGPC2;	//不透光偏差2，%
        public string GXSSSDZ2;//光吸收数设定2
        public string GXSSSCZ2;	//光吸收数实测2
        public string GXSSPC2;	//光吸收偏差2
        public string BDJG;	//标定结果（合格/不合格）
    }
    public class WGnetRegCarWait
    {
        public string JCBGBH;
        public string CPHM;//车牌颜色+车牌号码
        public string CLZL;//=1	//车辆种类(1-客车，2-货车，3-摩托车)
        public string CLLX;//=K33	//车辆类型（按 GA24.4 ，如K33，参照附录A1.3)
        public string HPZL;//=01 	号牌种类(只用传编号即可,参照附录A1.1)
        public string CZMC;//=深圳西珍纸箱制品有限公司	//车主名称
        public string LXDZ;//=深圳市南山区南山大道888号	//联系地址
        public string LXDH;//= 15954889898	//联系电话
        public string CPXH;//=3000	//厂牌型号
        public string SYXZ;//=A	//使用性质(按公安 GA24.3 如A，参照附录A1.4) 
        public string CLSBM;//= LHA12D3D96AV00929	//车辆识别码
        public string CLSCQY;//=上海大众汽车有限公司	//生产企业
        public string ZDZZL;//= 2800.0	//最大总质量（单位KG）
        public string JZZL;//=1000	//基准质量（单位KG）
        public string CCDJRQ;//=2007-01-01	//初次登记日期
        public string CCRQ;//=2007-01-01	//初次登记日期
        public string DCZZ;//= 350.0	//单车轴重
        public string DPXH;//= LHA12D3D96AV00929	//底盘型号
        public string QDFS;//=1	//驱动方式(1-前驱,2-后驱,3-全驱)
        public string QDLTQY;//= 0.25	//驱动轮胎气压
        public string BSQXS;//=1	//变速器型式(1-手动，2-自动，3-手/自动一体)
        public string DWS;//= 5	//档位数
        public string FDJXH;//= ALG034264	//发动机型号
        public string FDJSCQY;//=上海大众汽车有限公司	//发动机生产企业
        public string QGS;//= 4	//汽缸数
        public string FDJPL;//= 1.8		//发动机排量
        public string RYXS;//=1	//供油方式（1-电喷，2-化油器，3-化油器改造)
        public string RYGG;//=A	//燃油种类 参照附录A1.2
        public string LJXSLC;//= 26830.0	//累计行驶里程（KM）
        public string CHZHQ;//=0	//催化转化器 (0-无 1-有)
        public string JQFS;//=1	//进气方式（1-自然吸气,2-涡轮增压）
        public string GYXTXS;//=1	//进气方式（1-自然吸气,2-涡轮增压）
        public string PQHCLZZ;//=1	//排气后处理装置(0-无 1-有）
        public string RYPH;//=90	//燃油牌号
        public string SFWDZR;//=0	//是否外地转入（0-否,1-是）
        public string SFYQBF;//=0	//是否延期报废（0-否,1-是）
        public string SJCYS;//=5	//设计乘员数
        public string SSXQ;//=150101	//所属区域(6位)
        public string ICCardNo;
        public string ZBZL;
        public string DPFS;
        public string OBD;
        public string DKGYYB;
        public string DLSP;
        public string CHZZ;
        public string FDJEDZS;
        public string FDJEDGL;
    }
    public class WGasmProcessData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string DJCCY;	//第几次采样（1.2.3…..递增）
        public string SJXL;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string HCCLZ;	//HC测量值  单位： ppm
        public string NOCLZ;	//NO测量值  单位： %
        public string COCLZ;	//CO测量值  单位： %
        public string CO2CLZ;	//CO2测量值  单位：%
        public string O2CLZ;//O2测量值   单位： %
        public string CS;	//车速（KM/S）
        public string ZS;	//转速（r/min）
        public string XSXZXS;	//稀释修正系数
        public string SDXZXS;	//湿度修正系数
        public string JSGL;//寄生功率（KW）
        public string ZSGL;	//指示功率（KW）
        public string HJWD;//环境温度（℃）
        public string DQYL;	//大气压力（Kpa）
        public string XDSD;		//相对湿度（%）
        public string YW;	//油温（℃）
    }
    public class WGSDSprocessData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string DJCCY;	//第几次采样（1.2.3…..递增）
        public string SJXL;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string HCCLZ;	//HC测量值[HC10-6]
        public string COCLZ;	//CO测量值[CO10-6]
        public string ZS;	//转速（r/min）
        public string GLKQXSZ;	//过量空气系数值（λ）
        public string GKLX;	//工况类型:0：低怠速检测中;1：高怠速检测中
        public string YW;	//油温（℃）
    }
    public class WGLUGDOWNprocessData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string DJCCY;	//第几次采样（1.2.3…..递增）
        public string SJXL;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string GXSXS;	//HC测量值[HC10-6]
        public string BTGD;	//CO测量值[CO10-6]
        public string ZSGL;	//转速（r/min）
        public string CS;	//过量空气系数值（λ）
        public string ZS;	//工况类型:0：低怠速检测中;1：高怠速检测中
        public string HJWD;	//工况类型:0：低怠速检测中;1：高怠速检测中
        public string DQYL;	//工况类型:0：低怠速检测中;1：高怠速检测中
        public string XDSD;	//工况类型:0：低怠速检测中;1：高怠速检测中
        public string YW;	//油温（℃）
    }
    public class WGBTGprocessData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string DJCCY;	//第几次采样（1.2.3…..递增）
        public string SJXL;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string YDZDS;	//HC测量值[HC10-6]
        public string FDJDSZS;	//CO测量值[CO10-6]
        public string YW;	//油温（℃）
    }
    public class WGBasicTestData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string JCLXBH;	//第几次采样（1.2.3…..递增）
        public string JCLXMC;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string JCGWH;	//HC测量值[HC10-6]
        public string JCZBH;	//CO测量值[CO10-6]
        public string JCZMC;	//油温（℃）
        public string JCRQ;	//油温（℃）
        public string JCLRY;
        public string JCCZY;
        public string JCJSY;
        public string CPHM;
        public string SFCJ;
        public string JCCS;
        public string SFLJ;
        public string SFCS;
        public string FWLX;
        public string PDJG;
        public string BGJCFFYY;
        public string WXBJ;
        public string WXCD;
        public string WXSJ;
        public string WXFY;
    }
    public class WGCommonTestData
    {
        public string SBRZBM;	//检测报告编码，对应检测方法中的JCBGBH
        public string SBMC;	//第几次采样（1.2.3…..递增）
        public string SBXH;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string SBZZC;	//HC测量值[HC10-6]
        public string DPCGJ;	//CO测量值[CO10-6]
        public string PQFXY;	//油温（℃）
        public string LLJ;	//油温（℃）
    }
    public class WGASMresultData
    {
        public string JCBGBH;//检测报告编号（关联对应检测车辆注册信息）
        public string WD;	//温度（℃）
        public string DQY;	//大气压(Kpa)
        public string XDSD;	//相对湿度(%)
        public string HC5025XZ;//HC5025限值
        public string HC5025CLZ;	//HC5025测量值
        public string HC5025PDJG;	//HC5025判定结果（合格/不合格）
        public string CO5025XZ;	//CO5025限值
        public string CO5025CLZ;	//CO5025测量值
        public string CO5025PDJG;	//CO5025判定结果（合格/不合格）
        public string NO5025XZ;	//NO5025限值
        public string NO5025CLZ;	//NO5025测量值
        public string NO5025PDJG;	//NO5025判定结果（合格/不合格）
        public string FDJZS5025;	//5025发动机转速(r/min)
        public string FDJYW5025;	//5025油温（℃）；可取5025检测过程中过程数据油温的平均值
        public string HC2540XZ;	//HC2540限值
        public string HC2540CLZ;	//HC2540测量值
        public string HC2540PDJG;	//HC2540判定结果（合格/不合格）
        public string CO2540XZ;//CO2540限值
        public string CO2540CLZ;	//CO2540测量值
        public string CO2540PDJG;	//CO2540判定结果（合格/不合格）
        public string NO2540XZ;	//NO2540限值
        public string NO2540CLZ;	//NO2540测量值
        public string NO2540PDJG;	//NO2540判定结果（合格/不合格）
        public string FDJZS2540;	//2540发动机转速(r/min)
        public string FDJYW2540;	//2540油温（℃）；可取2540检测过程中过程数据油温的平均值
        public string PDJG;	//判定结果（合格/不合格）
        public string SHY;	//审核员
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string YW;	//油温（℃）；可取对应过程数据油温的平均值
    }
    public class WGSDSresultData
    {
        public string JCBGBH;	//检测报告编号（关联对应检测车辆注册信息）
        public string WD;	//温度（℃）
        public string DQY;//大气压(Kpa)
        public string XDSD;	//相对湿度(%)
        public string GLKQXSZ;	//过量空气系数值（λ）
        public string GLKQXSPDJG;	//过量空气判定结果（合格/不合格）
        public string DDSCOXZ;	//低怠速[CO%]限值
        public string DDSCOZ;	//低怠速[CO%]值
        public string DDSCOPDJG;	//低怠速[CO%]（合格/不合格）
        public string DDSHCXZ;	//低怠速[HC10-6]限值
        public string DDSHCZ;	//低怠速[HC10-6]值
        public string DDSHCPDJG;	//低怠速[HC10-6]（合格/不合格）
        public string FDJDSZS;	//发动机怠速转速(r/min)
        public string DDSJYWD;	//低怠速油温（℃）；可取低怠速检测过程中油温的平均值
        public string GDSCOXZ;	//高怠速[CO%]限值
        public string GDSCOZ;//高怠速[CO%]值
        public string GDSCOPDJG;	//高怠速[CO%]（合格/不合格）
        public string GDSHCZ;	//高怠速[HC10-6]值
        public string GDSHCXZ;	//高怠速[HC10-6]限值
        public string GDSHCPDJG;	//高怠速[HC10-6]（合格/不合格）
        public string GDSZS;		//高怠速转速(r/min)
        public string GDSJYWD;		//高怠速油温（℃）可取高怠速检测过程中过程数据油温的平均值
        public string PDJG;	//判定结果（合格/不合格）
        public string SHY;	//审核员
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string YW;//油温（℃）；取对应过程数据油温的平均值
        public string GLKQXSSX;//过量空气系数限值上限
        public string GLKQXSXX;	//过量空气系数限值下限
    }
    public class WGLUGDOWNresultData
    {
        public string JCBGBH;	//检测报告编号（关联对应检测车辆注册信息）
        public string WD;	//温度（℃）
        public string DQY;//大气压(Kpa)
        public string XDSD;	//相对湿度(%)
        public string VELMAXHP;	//过量空气系数值（λ）
        public string VELMAXHPZS;	//过量空气判定结果（合格/不合格）
        public string ZDLBGL;	//低怠速[CO%]限值
        public string ZDLBGLXZ;	//低怠速[CO%]值
        public string ZDLBGLPDJG;	//低怠速[CO%]（合格/不合格）
        public string VELMAXHPYDZ100;	//低怠速[HC10-6]限值
        public string VELMAXHPYDZ90;	//低怠速[HC10-6]值
        public string VELMAXHPYDZ80;	//低怠速[HC10-6]（合格/不合格）
        public string YDXZ;	//发动机怠速转速(r/min)
        public string YDPDJG;	//低怠速油温（℃）；可取低怠速检测过程中油温的平均值
        public string PDJG;	//高怠速[CO%]限值
        public string SHY;//高怠速[CO%]值
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string YW;//油温（℃）；取对应过程数据油温的平均值
        public string FDJEDZSSX;//过量空气系数限值上限
        public string FDJEDZSXX;	//过量空气系数限值下限
    }
    public class WGBTGresultData
    {
        public string JCBGBH;//检测报告编号（关联对应检测车辆注册信息）
        public string WD;	//温度（℃）
        public string DQY;//大气压(Kpa)
        public string XDSD;	//相对湿度(%)
        public string FDJDSZS;	//发动机怠速转速(r/min)
        public string ZHDSCCSZ;	//最后第三次测量值
        public string ZHDECCSZ;	//最后第二次测量值
        public string ZHDYCCSZ;	//最后第一次测量值
        public string PJZ;	//平均值
        public string XZ;	//限值
        public string PDJG;	//判定结果（合格/不合格）
        public string SHY;	//审核员
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string YW;		//油温（℃）；取对应过程数据油温的平均值
    }
    public class WGFlagData
    {
        public string JCBGBH;//检测报告编号（关联对应检测车辆注册信息）
        public string JCZMC;	//温度（℃）
        public string JCRQ;//大气压(Kpa)
        public string HBFLBZHM;	//相对湿度(%)
        public string CPHM;	//发动机怠速转速(r/min)
        public string JCZBH;	//最后第三次测量值
        public string YXRQ;	//最后第二次测量值
        public string JCFF;	//最后第一次测量值
        public string DYY;	//平均值
        public string DYSJ;	//限值
        public string CZLX;	//判定结果（合格/不合格）
        public string HBFLBZ;	//审核员
        public string BBH;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string BZNX;		//油温（℃）；取对应过程数据油温的平均值
        public string PFBZ;		//油温（℃）；取对应过程数据油温的平均值
    }
    public class WGTakePictureData
    {
        public string JCBGBH;//检测报告编号（关联对应检测车辆注册信息）
        public string GWZT;	//工位状态(1-车辆到位,2-插入探头, 3-检测中,4-过车下线
        public string JCGWH;//大气压(Kpa)
        public string CREATEDATE;	//相对湿度(%)
    }
    public class WGTakeVideoData
    {
        public string JCBGBH;//检测报告编号（关联对应检测车辆注册信息）
        public string JCGWH;	//工位状态(1-车辆到位,2-插入探头, 3-检测中,4-过车下线
        public string LXKSSJ;//大气压(Kpa)
        public string ZT;	//录像状态（S=开始 E=结束）
    }
    public class wanguoSocketControl
    {
        HtmlExtractor.Gb2312Encoding encoding = new HtmlExtractor.Gb2312Encoding();
        IPAddress HostIP = IPAddress.Parse("192.168.1.5");
        int HostPort = 5464;
        IPEndPoint point;
        private static Socket socket;
        bool flag = true;
        Socket acceptedSocket;


        private string receivedString = "";
        private bool receivedFlag = false;
        Thread thread = null;

        private bool receivedflag = false;
        static int sendOutTime = 10;
        static int receiveOutTime = 250;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public wanguoSocketControl(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            HostPort = Int32.Parse(port);
        }

        public wanguoSocketControl()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void initSocket(string ip, string port)
        {
            HostIP = IPAddress.Parse(ip);
            HostPort = Int32.Parse(port);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eisid"></param>
        /// <returns></returns>
        public string init_equipment(out string eisid)
        {
            eisid = "";
            try
            {
                point = new IPEndPoint(HostIP, HostPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                return "连接成功";
            }
            catch (Exception ey)
            {
                return ey.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string init_equipment()
        {
            try
            {
                point = new IPEndPoint(HostIP, HostPort);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(point);
                return "连接成功";
            }
            catch (Exception ey)
            {
                return ey.Message;
            }
        }
        /// <summary>
        /// 向远程主机发送数据
        /// </summary>
        /// <param name="socket">连接到远程主机的socket</param>
        /// <param name="buffer">待发送数据</param>
        /// <param name="outTime">发送超时时长，单位是秒(为-1时，将一直等待直到有数据需要发送)</param>
        /// <returns>0:发送成功；-1:超时；-2:出现错误；-3:出现异常</returns>
        public static int SendData(byte[] buffer)
        {
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("参数socket为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("参数buffer为null ,或者长度为 0");
            }

            int flag = 0;
            try
            {
                int left = buffer.Length;
                int sndLen = 0;
                int hasSend = 0;

                while (true)
                {
                    if ((socket.Poll(sendOutTime * 1000, SelectMode.SelectWrite) == true))
                    {
                        // 收集了足够多的传出数据后开始发送
                        sndLen = socket.Send(buffer, hasSend, left, SocketFlags.None);
                        left -= sndLen;
                        hasSend += sndLen;

                        // 数据已经全部发送
                        if (left == 0)
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            // 数据部分已经被发送
                            if (sndLen > 0)
                            {
                                continue;
                            }
                            else // 发送数据发生错误
                            {
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else // 超时退出
                    {
                        flag = -1;
                        break;
                    }
                }
            }
            catch (SocketException)
            {
                //Log
                flag = -3;
            }
            return flag;
        }
        /// <summary>
        /// 向远程主机发送数据
        /// </summary>
        /// <param name="socket">连接到远程主机的socket</param>
        /// <param name="buffer">待发送的字符串</param>
        /// <param name="outTime">发送数据的超时时间，单位是秒(为-1时，将一直等待直到有数据需要发送)</param>
        /// <returns>0:发送数据成功；-1:超时；-2:错误；-3:异常</returns>
        public static int SendData(Socket socket, string buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("buffer为null或则长度为0.");
            }
            return SendData(System.Text.Encoding.Default.GetBytes(buffer));
        }
        /// <summary>
        /// 接收远程主机发送的数据
        /// </summary>
        /// <param name="socket">要接收数据且已经连接到远程主机的</param>
        /// <param name="buffer">接收数据的缓冲区(需要接收的数据的长度，由 buffer 的长度决定)</param>
        /// <param name="outTime">接收数据的超时时间，单位秒(指定为-1时，将一直等待直到有数据需要接收)</param>
        /// <returns></returns>
        public static int RecvData(Socket socket, out string receivedMessage)
        {
            byte[] buffer = new byte[1024 * 1024 * 2];
            receivedMessage = "";
            if (socket == null || socket.Connected == false)
            {
                throw new ArgumentException("socket为null，或者未连接到远程计算机");
            }
            if (buffer == null || buffer.Length == 0)
            {
                throw new ArgumentException("buffer为null ,或者长度为 0");
            }

            buffer.Initialize();
            int left = buffer.Length;
            int curRcv = 0;
            int hasRecv = 0;
            int flag = 0;
            int receiveOutCount = 0;
            try
            {
                while (true)
                {
                    if (socket.Poll(receiveOutTime * 1000, SelectMode.SelectRead) == true)
                    {
                        // 已经有数据等待接收
                        curRcv = socket.Receive(buffer, hasRecv, left, SocketFlags.None);
                        left -= curRcv;
                        hasRecv += curRcv;
                        string s = System.Text.Encoding.UTF8.GetString(buffer, 0, hasRecv);
                        //string s = Encoding.gbk.GetString(buffer, 0, hasRecv);//将已接收到的转换化字符串，以"/Message"为结束判断
                        // 数据已经全部接收 
                        bool isReceiveFinished = (s.Trim()).EndsWith("/Message>");
                        if (isReceiveFinished)
                        {
                            receivedMessage = s;
                            flag = 1;
                            break;
                        }
                        else if (left == 0)
                        {
                            flag = 0;
                            break;
                        }
                        else
                        {
                            // 数据已经部分接收
                            if (curRcv > 0)
                            {
                                continue;
                            }
                            else  // 出现错误
                            {
                                flag = -2;
                                break;
                            }
                        }
                    }
                    else // 超时退出
                    {
                        Thread.Sleep(100);
                        receiveOutCount++;
                        if (receiveOutCount >= receiveOutTime)
                        {
                            flag = -1;
                            break;
                        }
                    }
                }
            }
            catch (SocketException)
            {
                //Log
                flag = -3;
            }
            return flag;
        }
        
        /// <summary>  
        /// 将XmlDocument转化为string  
        /// </summary>  
        /// <param name="xmlDoc"></param>  
        /// <returns></returns>  
        static byte[] ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            // int versionindex=xmlString.IndexOf('>');
            //xmlString = xmlString.Remove(0, versionindex + 1);
            sr.Close();
            stream.Close();
            //xmlString = xmlString.Replace(" ", "");
            string newstring = xmlString.Replace("\r\n", "");
            newstring = newstring.Replace("xml version=\"1.0\"", "xml version=\"1.0\" encoding=\"gb2312\"");//.Replace(" ", "%20").Replace("\r\n", "%0d%0a") + "\r\n";
            INIIO.saveLogInf("SEND:\r\n" + newstring);
            //saveLogInf(newstring);
            byte[] bufferToSend = System.Text.Encoding.GetEncoding("gb2312").GetBytes(newstring);
            //byte[] bufferToSend = System.Text.Encoding.UTF8.GetBytes(newstring);
            return bufferToSend;
        }
        public bool SendCgjSelfCheckData(WGcgjSelfDetectInf wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCSBZJXX");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCGWH;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点     
            xe302.InnerText = wgdata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点   
            xe303.InnerText = wgdata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点   
            xe304.InnerText = wgdata.JCZBH;
            XmlElement xe305 = xmldoc.CreateElement("Date");//创建一个<Node>节点   
            xe305.InnerText = wgdata.Date;
            XmlElement xe306 = xmldoc.CreateElement("TXJC");//创建一个<Node>节点   
            xe306.InnerText = wgdata.TXJC;
            XmlElement xe307 = xmldoc.CreateElement("JSQJC");//创建一个<Node>节点  
            xe307.InnerText = wgdata.JSQJC;
            XmlElement xe308 = xmldoc.CreateElement("TTYRKSSJ");//创建一个<Node>节点    
            xe308.InnerText = wgdata.TTYRKSSJ;
            XmlElement xe309 = xmldoc.CreateElement("TTYRJSSJ");//创建一个<Node>节点   
            xe309.InnerText = wgdata.TTYRJSSJ;
            XmlElement xe310 = xmldoc.CreateElement("GXDL");//创建一个<Node>节点   
            xe310.InnerText = wgdata.GXDL;
            XmlElement xe311 = xmldoc.CreateElement("JZHXDS");//创建一个<Node>节点   
            xe311.InnerText = wgdata.JZHXDS;
            XmlElement xe312 = xmldoc.CreateElement("CS1");//创建一个<Node>节点  
            xe312.InnerText = wgdata.CS1;
            XmlElement xe313 = xmldoc.CreateElement("JZGL1");//创建一个<Node>节点   
            xe313.InnerText = wgdata.JZGL1;
            XmlElement xe314 = xmldoc.CreateElement("JSGL1");//创建一个<Node>节点   
            xe314.InnerText = wgdata.JSGL1;
            XmlElement xe315 = xmldoc.CreateElement("LLHXSJ1");//创建一个<Node>节点    
            xe315.InnerText = wgdata.LLHXSJ1;
            XmlElement xe316 = xmldoc.CreateElement("SJHXSJ1");//创建一个<Node>节点  
            xe316.InnerText = wgdata.SJHXSJ1;
            XmlElement xe317 = xmldoc.CreateElement("PC1");//创建一个<Node>节点  
            xe317.InnerText = wgdata.PC1;
            XmlElement xe318 = xmldoc.CreateElement("CS2");//创建一个<Node>节点   
            xe318.InnerText = wgdata.CS2;
            XmlElement xe319 = xmldoc.CreateElement("JZGL2");//创建一个<Node>节点  
            xe319.InnerText = wgdata.JZGL2;
            XmlElement xe320 = xmldoc.CreateElement("JSGL2");//创建一个<Node>节点  
            xe320.InnerText = wgdata.JSGL2;
            XmlElement xe321 = xmldoc.CreateElement("LLHXSJ2");//创建一个<Node>节点   
            xe321.InnerText = wgdata.LLHXSJ2;
            XmlElement xe322 = xmldoc.CreateElement("SJHXSJ2");//创建一个<Node>节点   
            xe322.InnerText = wgdata.SJHXSJ2;
            XmlElement xe323 = xmldoc.CreateElement("PC2");//创建一个<Node>节点    
            xe323.InnerText = wgdata.PC2;
            XmlElement xe324 = xmldoc.CreateElement("ZJJG");//创建一个<Node>节点    
            xe324.InnerText = wgdata.ZJJG;   
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe201.AppendChild(xe322);
            xe201.AppendChild(xe323);
            xe201.AppendChild(xe324);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendFqySelfCheckData(WGfqySelfDetectInf wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCSBZJXX");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点    
            xe301.InnerText = wgdata.JCGWH;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点  
            xe302.InnerText = wgdata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点 
            xe303.InnerText = wgdata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点  
            xe304.InnerText = wgdata.JCZBH;
            XmlElement xe305 = xmldoc.CreateElement("Date");//创建一个<Node>节点  
            xe305.InnerText = wgdata.Date;
            XmlElement xe306 = xmldoc.CreateElement("TXJC");//创建一个<Node>节点 
            xe306.InnerText = wgdata.TXJC;
            XmlElement xe307 = xmldoc.CreateElement("YQYR");//创建一个<Node>节点 
            xe307.InnerText = wgdata.YQYR;
            XmlElement xe308 = xmldoc.CreateElement("YQJL");//创建一个<Node>节点 
            xe308.InnerText = wgdata.YQJL;
            XmlElement xe309 = xmldoc.CreateElement("YQTL");//创建一个<Node>节点
            xe309.InnerText = wgdata.YQTL;
            XmlElement xe310 = xmldoc.CreateElement("YQLL");//创建一个<Node>节点 
            xe310.InnerText = wgdata.YQLL;
            XmlElement xe311 = xmldoc.CreateElement("YQYQ");//创建一个<Node>节点  
            xe311.InnerText = wgdata.YQYQ;
            XmlElement xe312 = xmldoc.CreateElement("ZJJG");//创建一个<Node>节点 
            xe312.InnerText = wgdata.ZJJG;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendYdjSelfCheckData(WGydjSelfDetectInf wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCSBZJXX");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点  
            xe301.InnerText = wgdata.JCGWH;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点  
            xe302.InnerText = wgdata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点 
            xe303.InnerText = wgdata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点 
            xe304.InnerText = wgdata.JCZBH;
            XmlElement xe305 = xmldoc.CreateElement("Date");//创建一个<Node>节点 
            xe305.InnerText = wgdata.Date;
            XmlElement xe306 = xmldoc.CreateElement("TXJC");//创建一个<Node>节点  
            xe306.InnerText = wgdata.TXJC;
            XmlElement xe307 = xmldoc.CreateElement("YQYR");//创建一个<Node>节点 
            xe307.InnerText = wgdata.YQYR;
            XmlElement xe308 = xmldoc.CreateElement("YQTL");//创建一个<Node>节点 
            xe308.InnerText = wgdata.YQTL;
            XmlElement xe309 = xmldoc.CreateElement("LCJC");//创建一个<Node>节点 
            xe309.InnerText = wgdata.LCJC;
            XmlElement xe310 = xmldoc.CreateElement("JCDS");//创建一个<Node>节点 
            xe310.InnerText = wgdata.JCDS;
            XmlElement xe311 = xmldoc.CreateElement("BTGSDZ1");//创建一个<Node>节点 
            xe311.InnerText = wgdata.BTGSDZ1;
            XmlElement xe312 = xmldoc.CreateElement("BTGSCZ1");//创建一个<Node>节点  
            xe312.InnerText = wgdata.BTGSCZ1;
            XmlElement xe313 = xmldoc.CreateElement("BTGPC1");//创建一个<Node>节点
            xe313.InnerText = wgdata.BTGPC1;
            XmlElement xe314 = xmldoc.CreateElement("BTGSDZ2");//创建一个<Node>节点 
            xe314.InnerText = wgdata.BTGSDZ2;
            XmlElement xe315 = xmldoc.CreateElement("BTGSCZ2");//创建一个<Node>节点 
            xe315.InnerText = wgdata.BTGSCZ2;
            XmlElement xe316 = xmldoc.CreateElement("BTGPC2");//创建一个<Node>节点
            xe316.InnerText = wgdata.BTGPC2;
            XmlElement xe317 = xmldoc.CreateElement("ZJJG");//创建一个<Node>节点
            xe317.InnerText = wgdata.ZJJG; 
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendDzhjSelfCheckData(WGdzhjSelfDetectInf wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCSBZJXX");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点  
            xe301.InnerText = wgdata.JCGWH;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点  
            xe302.InnerText = wgdata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点 
            xe303.InnerText = wgdata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点 
            xe304.InnerText = wgdata.JCZBH;
            XmlElement xe305 = xmldoc.CreateElement("Date");//创建一个<Node>节点 
            xe305.InnerText = wgdata.Date;
            XmlElement xe306 = xmldoc.CreateElement("TXJC");//创建一个<Node>节点 
            xe306.InnerText = wgdata.TXJC;
            XmlElement xe307 = xmldoc.CreateElement("HJWD");//创建一个<Node>节点 
            xe307.InnerText = wgdata.HJWD;
            XmlElement xe308 = xmldoc.CreateElement("YQWD");//创建一个<Node>节点 
            xe308.InnerText = wgdata.YQWD;
            XmlElement xe309 = xmldoc.CreateElement("HJSD");//创建一个<Node>节点 
            xe309.InnerText = wgdata.HJSD;
            XmlElement xe310 = xmldoc.CreateElement("YQSD");//创建一个<Node>节点 
            xe310.InnerText = wgdata.YQSD;
            XmlElement xe311 = xmldoc.CreateElement("HJQY");//创建一个<Node>节点 
            xe311.InnerText = wgdata.HJQY;
            XmlElement xe312 = xmldoc.CreateElement("YQQY");//创建一个<Node>节点 
            xe312.InnerText = wgdata.YQQY;
            XmlElement xe313 = xmldoc.CreateElement("ZJJG");//创建一个<Node>节点
            xe313.InnerText = wgdata.ZJJG; 
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendZsjSelfCheckData(WGzsjSelfDetecInf wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCSBZJXX");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点  
            xe301.InnerText = wgdata.JCGWH;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点  
            xe302.InnerText = wgdata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点 
            xe303.InnerText = wgdata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点  
            xe304.InnerText = wgdata.JCZBH;
            XmlElement xe305 = xmldoc.CreateElement("Date");//创建一个<Node>节点 
            xe305.InnerText = wgdata.Date;
            XmlElement xe306 = xmldoc.CreateElement("TXJC");//创建一个<Node>节点 
            xe306.InnerText = wgdata.TXJC;
            XmlElement xe307 = xmldoc.CreateElement("DSZS");//创建一个<Node>节点 
            xe307.InnerText = wgdata.DSZS;
            XmlElement xe308 = xmldoc.CreateElement("ZJJG");//创建一个<Node>节点 
            xe308.InnerText = wgdata.ZJJG;  
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendLljSelfCheckData(lljSelfDetectInf wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCSBZJXX");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点  
            xe301.InnerText = wgdata.JCGWH;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点 
            xe302.InnerText = wgdata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点 
            xe303.InnerText = wgdata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点  
            xe304.InnerText = wgdata.JCZBH;
            XmlElement xe305 = xmldoc.CreateElement("Date");//创建一个<Node>节点 
            xe305.InnerText = wgdata.Date;
            XmlElement xe306 = xmldoc.CreateElement("TXJC");//创建一个<Node>节点 
            xe306.InnerText = wgdata.TXJC;
            XmlElement xe307 = xmldoc.CreateElement("YQYR");//创建一个<Node>节点 
            xe307.InnerText = wgdata.YQYR;
            XmlElement xe308 = xmldoc.CreateElement("LLJC");//创建一个<Node>节点 
            xe308.InnerText = wgdata.LLJC;
            XmlElement xe309 = xmldoc.CreateElement("YQLL");//创建一个<Node>节点
            xe309.InnerText = wgdata.YQLL;
            XmlElement xe310 = xmldoc.CreateElement("QYLC");//创建一个<Node>节点
            xe310.InnerText = wgdata.QYLC;
            XmlElement xe311 = xmldoc.CreateElement("YQYQ");//创建一个<Node>节点 
            xe311.InnerText = wgdata.YQYQ;
            XmlElement xe312 = xmldoc.CreateElement("ZJJG");//创建一个<Node>节点  
            xe312.InnerText = wgdata.ZJJG;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendCarWaitData(WGnetRegCarWait wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("VEHICLE");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("CPHM");//创建一个<Node>节点     
            xe302.InnerText = wgdata.CPHM;
            XmlElement xe303 = xmldoc.CreateElement("CLZL");//创建一个<Node>节点   
            xe303.InnerText = wgdata.CLZL;
            XmlElement xe304 = xmldoc.CreateElement("HPZL");//创建一个<Node>节点   
            xe304.InnerText = wgdata.HPZL;
            XmlElement xe305 = xmldoc.CreateElement("CZMC");//创建一个<Node>节点   
            xe305.InnerText = wgdata.CZMC;
            XmlElement xe306 = xmldoc.CreateElement("LXDZ");//创建一个<Node>节点   
            xe306.InnerText = wgdata.LXDZ;
            XmlElement xe307 = xmldoc.CreateElement("LXDH");//创建一个<Node>节点  
            xe307.InnerText = wgdata.LXDH;
            XmlElement xe308 = xmldoc.CreateElement("CPXH");//创建一个<Node>节点    
            xe308.InnerText = wgdata.CPXH;
            XmlElement xe309 = xmldoc.CreateElement("SYXZ");//创建一个<Node>节点   
            xe309.InnerText = wgdata.SYXZ;
            XmlElement xe310 = xmldoc.CreateElement("CLSBM");//创建一个<Node>节点   
            xe310.InnerText = wgdata.CLSBM;
            XmlElement xe311 = xmldoc.CreateElement("CLSCQY");//创建一个<Node>节点   
            xe311.InnerText = wgdata.CLSCQY;
            XmlElement xe312 = xmldoc.CreateElement("ZDZZL");//创建一个<Node>节点  
            xe312.InnerText = wgdata.ZDZZL;
            XmlElement xe313 = xmldoc.CreateElement("JZZL");//创建一个<Node>节点   
            xe313.InnerText = wgdata.JZZL;
            XmlElement xe314 = xmldoc.CreateElement("CCDJRQ");//创建一个<Node>节点   
            xe314.InnerText = wgdata.CCDJRQ;
            XmlElement xe315 = xmldoc.CreateElement("CCRQ");//创建一个<Node>节点    
            xe315.InnerText = wgdata.CCRQ;
            XmlElement xe316 = xmldoc.CreateElement("DCZZ");//创建一个<Node>节点  
            xe316.InnerText = wgdata.DCZZ;
            XmlElement xe317 = xmldoc.CreateElement("DPXH");//创建一个<Node>节点  
            xe317.InnerText = wgdata.DPXH;
            XmlElement xe318 = xmldoc.CreateElement("QDFS");//创建一个<Node>节点   
            xe318.InnerText = wgdata.QDFS;
            XmlElement xe319 = xmldoc.CreateElement("QDLTQY");//创建一个<Node>节点  
            xe319.InnerText = wgdata.QDLTQY;
            XmlElement xe320 = xmldoc.CreateElement("BSQXS");//创建一个<Node>节点  
            xe320.InnerText = wgdata.BSQXS;
            XmlElement xe321 = xmldoc.CreateElement("DWS");//创建一个<Node>节点   
            xe321.InnerText = wgdata.DWS;
            XmlElement xe322 = xmldoc.CreateElement("FDJXH");//创建一个<Node>节点   
            xe322.InnerText = wgdata.FDJXH;
            XmlElement xe323 = xmldoc.CreateElement("FDJSCQY");//创建一个<Node>节点    
            xe323.InnerText = wgdata.FDJSCQY;
            XmlElement xe324 = xmldoc.CreateElement("QGS");//创建一个<Node>节点    
            xe324.InnerText = wgdata.QGS;


            XmlElement xe325 = xmldoc.CreateElement("FDJPL");//创建一个<Node>节点  
            xe325.InnerText = wgdata.FDJPL;
            XmlElement xe326 = xmldoc.CreateElement("RYXS");//创建一个<Node>节点  
            xe326.InnerText = wgdata.RYXS;
            XmlElement xe327 = xmldoc.CreateElement("RYGG");//创建一个<Node>节点   
            xe327.InnerText = wgdata.RYGG;
            XmlElement xe328 = xmldoc.CreateElement("LJXSLC");//创建一个<Node>节点  
            xe328.InnerText = wgdata.LJXSLC;
            XmlElement xe329 = xmldoc.CreateElement("CHZHQ");//创建一个<Node>节点  
            xe329.InnerText = wgdata.CHZHQ;
            XmlElement xe330 = xmldoc.CreateElement("JQFS");//创建一个<Node>节点   
            xe330.InnerText = wgdata.JQFS;
            XmlElement xe331 = xmldoc.CreateElement("GYXTXS");//创建一个<Node>节点   
            xe331.InnerText = wgdata.GYXTXS;
            XmlElement xe332 = xmldoc.CreateElement("PQHCLZZ");//创建一个<Node>节点    
            xe332.InnerText = wgdata.PQHCLZZ;
            XmlElement xe333 = xmldoc.CreateElement("RYPH");//创建一个<Node>节点    
            xe333.InnerText = wgdata.RYPH;
            XmlElement xe334 = xmldoc.CreateElement("SFWDZR");//创建一个<Node>节点   
            xe334.InnerText = wgdata.SFWDZR;
            XmlElement xe335 = xmldoc.CreateElement("SFYQBF");//创建一个<Node>节点   
            xe335.InnerText = wgdata.SFYQBF;
            XmlElement xe336 = xmldoc.CreateElement("SJCYS");//创建一个<Node>节点    
            xe336.InnerText = wgdata.SJCYS;
            XmlElement xe337 = xmldoc.CreateElement("SSXQ");//创建一个<Node>节点    
            xe337.InnerText = wgdata.SSXQ;
            XmlElement xe338 = xmldoc.CreateElement("ICCardNo");//创建一个<Node>节点    
            xe338.InnerText = wgdata.ICCardNo;
            XmlElement xe339 = xmldoc.CreateElement("ZBZL");//创建一个<Node>节点    
            xe339.InnerText = wgdata.ZBZL;
            XmlElement xe340 = xmldoc.CreateElement("DPFS");//创建一个<Node>节点   
            xe340.InnerText = wgdata.DPFS;
            XmlElement xe341 = xmldoc.CreateElement("OBD");//创建一个<Node>节点   
            xe341.InnerText = wgdata.OBD;
            XmlElement xe342 = xmldoc.CreateElement("DKGYYB");//创建一个<Node>节点    
            xe342.InnerText = wgdata.DKGYYB;
            XmlElement xe343 = xmldoc.CreateElement("DLSP");//创建一个<Node>节点    
            xe343.InnerText = wgdata.DLSP;
            XmlElement xe344 = xmldoc.CreateElement("CHZZ");//创建一个<Node>节点   
            xe344.InnerText = wgdata.CHZZ;
            XmlElement xe345 = xmldoc.CreateElement("FDJEDZS");//创建一个<Node>节点    
            xe345.InnerText = wgdata.FDJEDZS;
            XmlElement xe346 = xmldoc.CreateElement("FDJEDGL");//创建一个<Node>节点    
            xe346.InnerText = wgdata.FDJEDGL;
            XmlElement xe347 = xmldoc.CreateElement("CLLX");//创建一个<Node>节点    
            xe347.InnerText = wgdata.CLLX;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe201.AppendChild(xe322);
            xe201.AppendChild(xe323);
            xe201.AppendChild(xe324);
            xe201.AppendChild(xe325);
            xe201.AppendChild(xe326);
            xe201.AppendChild(xe327);
            xe201.AppendChild(xe328);
            xe201.AppendChild(xe329);
            xe201.AppendChild(xe330);
            xe201.AppendChild(xe331);
            xe201.AppendChild(xe332);
            xe201.AppendChild(xe333);
            xe201.AppendChild(xe334);
            xe201.AppendChild(xe335);
            xe201.AppendChild(xe336);
            xe201.AppendChild(xe337);
            xe201.AppendChild(xe338);
            xe201.AppendChild(xe339);
            xe201.AppendChild(xe340);
            xe201.AppendChild(xe341);
            xe201.AppendChild(xe342);
            xe201.AppendChild(xe343);
            xe201.AppendChild(xe344);
            xe201.AppendChild(xe345);
            xe201.AppendChild(xe346);
            xe201.AppendChild(xe347);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendAsmProcessData(WGasmProcessData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("H_PROCESSDATAEX_NEW");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("DJCCY");//创建一个<Node>节点     
            xe302.InnerText = wgdata.DJCCY;
            XmlElement xe303 = xmldoc.CreateElement("SJXL");//创建一个<Node>节点   
            xe303.InnerText = wgdata.SJXL;
            XmlElement xe304 = xmldoc.CreateElement("HCCLZ");//创建一个<Node>节点   
            xe304.InnerText = wgdata.HCCLZ;
            XmlElement xe305 = xmldoc.CreateElement("NOCLZ");//创建一个<Node>节点   
            xe305.InnerText = wgdata.NOCLZ;
            XmlElement xe306 = xmldoc.CreateElement("COCLZ");//创建一个<Node>节点   
            xe306.InnerText = wgdata.COCLZ;
            XmlElement xe307 = xmldoc.CreateElement("CO2CLZ");//创建一个<Node>节点  
            xe307.InnerText = wgdata.CO2CLZ;
            XmlElement xe308 = xmldoc.CreateElement("O2CLZ");//创建一个<Node>节点    
            xe308.InnerText = wgdata.O2CLZ;
            XmlElement xe309 = xmldoc.CreateElement("CS");//创建一个<Node>节点   
            xe309.InnerText = wgdata.CS;
            XmlElement xe310 = xmldoc.CreateElement("ZS");//创建一个<Node>节点   
            xe310.InnerText = wgdata.ZS;
            XmlElement xe311 = xmldoc.CreateElement("XSXZXS");//创建一个<Node>节点   
            xe311.InnerText = wgdata.XSXZXS;
            XmlElement xe312 = xmldoc.CreateElement("SDXZXS");//创建一个<Node>节点  
            xe312.InnerText = wgdata.SDXZXS;
            XmlElement xe313 = xmldoc.CreateElement("JSGL");//创建一个<Node>节点   
            xe313.InnerText = wgdata.JSGL;
            XmlElement xe314 = xmldoc.CreateElement("ZSGL");//创建一个<Node>节点   
            xe314.InnerText = wgdata.ZSGL;
            XmlElement xe315 = xmldoc.CreateElement("HJWD");//创建一个<Node>节点    
            xe315.InnerText = wgdata.HJWD;
            XmlElement xe316 = xmldoc.CreateElement("DQYL");//创建一个<Node>节点  
            xe316.InnerText = wgdata.DQYL;
            XmlElement xe317 = xmldoc.CreateElement("XDSD");//创建一个<Node>节点  
            xe317.InnerText = wgdata.XDSD;
            XmlElement xe318 = xmldoc.CreateElement("YW");//创建一个<Node>节点   
            xe318.InnerText = wgdata.YW;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendSdsProcessData(WGSDSprocessData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("H_PROCESSDATAEX_NEW");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("DJCCY");//创建一个<Node>节点     
            xe302.InnerText = wgdata.DJCCY;
            XmlElement xe303 = xmldoc.CreateElement("SJXL");//创建一个<Node>节点   
            xe303.InnerText = wgdata.SJXL;
            XmlElement xe304 = xmldoc.CreateElement("HCCLZ");//创建一个<Node>节点   
            xe304.InnerText = wgdata.HCCLZ;
            XmlElement xe305 = xmldoc.CreateElement("COCLZ");//创建一个<Node>节点   
            xe305.InnerText = wgdata.COCLZ;
            XmlElement xe306 = xmldoc.CreateElement("ZS");//创建一个<Node>节点   
            xe306.InnerText = wgdata.ZS;
            XmlElement xe307 = xmldoc.CreateElement("GLKQXSZ");//创建一个<Node>节点  
            xe307.InnerText = wgdata.GLKQXSZ;
            XmlElement xe308 = xmldoc.CreateElement("GKLX");//创建一个<Node>节点    
            xe308.InnerText = wgdata.GKLX;
            XmlElement xe309 = xmldoc.CreateElement("YW");//创建一个<Node>节点   
            xe309.InnerText = wgdata.YW;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendLugdownProcessData(WGLUGDOWNprocessData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("H_PROCESSDATAEX_NEW");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("DJCCY");//创建一个<Node>节点     
            xe302.InnerText = wgdata.DJCCY;
            XmlElement xe303 = xmldoc.CreateElement("SJXL");//创建一个<Node>节点   
            xe303.InnerText = wgdata.SJXL;
            XmlElement xe304 = xmldoc.CreateElement("GXSXS");//创建一个<Node>节点   
            xe304.InnerText = wgdata.GXSXS;
            XmlElement xe305 = xmldoc.CreateElement("BTGD");//创建一个<Node>节点   
            xe305.InnerText = wgdata.BTGD;
            XmlElement xe306 = xmldoc.CreateElement("ZSGL");//创建一个<Node>节点   
            xe306.InnerText = wgdata.ZSGL;
            XmlElement xe307 = xmldoc.CreateElement("CS");//创建一个<Node>节点  
            xe307.InnerText = wgdata.CS;
            XmlElement xe308 = xmldoc.CreateElement("ZS");//创建一个<Node>节点    
            xe308.InnerText = wgdata.ZS;
            XmlElement xe309 = xmldoc.CreateElement("HJWD");//创建一个<Node>节点   
            xe309.InnerText = wgdata.HJWD;
            XmlElement xe310 = xmldoc.CreateElement("DQYL");//创建一个<Node>节点   
            xe310.InnerText = wgdata.DQYL;
            XmlElement xe311 = xmldoc.CreateElement("XDSD");//创建一个<Node>节点   
            xe311.InnerText = wgdata.XDSD;
            XmlElement xe312 = xmldoc.CreateElement("YW");//创建一个<Node>节点  
            xe312.InnerText = wgdata.YW;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendBtgProcessData(WGBTGprocessData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("H_PROCESSDATAEX_NEW");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("DJCCY");//创建一个<Node>节点     
            xe302.InnerText = wgdata.DJCCY;
            XmlElement xe303 = xmldoc.CreateElement("SJXL");//创建一个<Node>节点   
            xe303.InnerText = wgdata.SJXL;
            XmlElement xe304 = xmldoc.CreateElement("YDZDS");//创建一个<Node>节点   
            xe304.InnerText = wgdata.YDZDS;
            XmlElement xe305 = xmldoc.CreateElement("FDJDSZS");//创建一个<Node>节点   
            xe305.InnerText = wgdata.FDJDSZS;
            XmlElement xe306 = xmldoc.CreateElement("YW");//创建一个<Node>节点   
            xe306.InnerText = wgdata.YW;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendBasicTestData(WGBasicTestData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("H_JCJGSHEET");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("JCLXBH");//创建一个<Node>节点     
            xe302.InnerText = wgdata.JCLXBH;
            XmlElement xe303 = xmldoc.CreateElement("JCLXMC");//创建一个<Node>节点   
            xe303.InnerText = wgdata.JCLXMC;
            XmlElement xe304 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点   
            xe304.InnerText = wgdata.JCGWH;
            XmlElement xe305 = xmldoc.CreateElement("JCZBH");//创建一个<Node>节点   
            xe305.InnerText = wgdata.JCZBH;
            XmlElement xe306 = xmldoc.CreateElement("JCZMC");//创建一个<Node>节点   
            xe306.InnerText = wgdata.JCZMC;
            XmlElement xe307 = xmldoc.CreateElement("JCRQ");//创建一个<Node>节点  
            xe307.InnerText = wgdata.JCRQ;
            XmlElement xe308 = xmldoc.CreateElement("JCLRY");//创建一个<Node>节点    
            xe308.InnerText = wgdata.JCLRY;
            XmlElement xe309 = xmldoc.CreateElement("JCCZY");//创建一个<Node>节点   
            xe309.InnerText = wgdata.JCCZY;
            XmlElement xe310 = xmldoc.CreateElement("JCJSY");//创建一个<Node>节点   
            xe310.InnerText = wgdata.JCJSY;
            XmlElement xe311 = xmldoc.CreateElement("CPHM");//创建一个<Node>节点   
            xe311.InnerText = wgdata.CPHM;
            XmlElement xe312 = xmldoc.CreateElement("SFCJ");//创建一个<Node>节点  
            xe312.InnerText = wgdata.SFCJ;
            XmlElement xe313 = xmldoc.CreateElement("JCCS");//创建一个<Node>节点   
            xe313.InnerText = wgdata.JCCS;
            XmlElement xe314 = xmldoc.CreateElement("SFLJ");//创建一个<Node>节点   
            xe314.InnerText = wgdata.SFLJ;
            XmlElement xe315 = xmldoc.CreateElement("SFCS");//创建一个<Node>节点    
            xe315.InnerText = wgdata.SFCS;
            XmlElement xe316 = xmldoc.CreateElement("FWLX");//创建一个<Node>节点  
            xe316.InnerText = wgdata.FWLX;
            XmlElement xe317 = xmldoc.CreateElement("PDJG");//创建一个<Node>节点  
            xe317.InnerText = wgdata.PDJG;
            XmlElement xe318 = xmldoc.CreateElement("BGJCFFYY");//创建一个<Node>节点   
            xe318.InnerText = wgdata.BGJCFFYY;
            XmlElement xe319 = xmldoc.CreateElement("WXBJ");//创建一个<Node>节点  
            xe319.InnerText = wgdata.WXBJ;
            XmlElement xe320 = xmldoc.CreateElement("WXCD");//创建一个<Node>节点  
            xe320.InnerText = wgdata.WXCD;
            XmlElement xe321 = xmldoc.CreateElement("WXSJ");//创建一个<Node>节点   
            xe321.InnerText = wgdata.WXSJ;
            XmlElement xe322 = xmldoc.CreateElement("WXFY");//创建一个<Node>节点   
            xe322.InnerText = wgdata.WXFY;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe201.AppendChild(xe322);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendASMresultData(WGCommonTestData commondata,WGASMresultData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("WTGK");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("SBRZBM");//创建一个<Node>节点   
            xe301.InnerText = commondata.SBRZBM;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点     
            xe302.InnerText = commondata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点   
            xe303.InnerText = commondata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("SBZZC");//创建一个<Node>节点   
            xe304.InnerText = commondata.SBZZC;
            XmlElement xe305 = xmldoc.CreateElement("DPCGJ");//创建一个<Node>节点   
            xe305.InnerText = commondata.DPCGJ;
            XmlElement xe306 = xmldoc.CreateElement("PQFXY");//创建一个<Node>节点   
            xe306.InnerText = commondata.PQFXY;
            XmlElement xe307 = xmldoc.CreateElement("LLJ");//创建一个<Node>节点  
            xe307.InnerText = commondata.LLJ;
            XmlElement xe308 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点    
            xe308.InnerText = wgdata.JCBGBH;
            XmlElement xe309 = xmldoc.CreateElement("WD");//创建一个<Node>节点   
            xe309.InnerText = wgdata.WD;
            XmlElement xe310 = xmldoc.CreateElement("DQY");//创建一个<Node>节点   
            xe310.InnerText = wgdata.DQY;
            XmlElement xe311 = xmldoc.CreateElement("XDSD");//创建一个<Node>节点   
            xe311.InnerText = wgdata.XDSD;
            XmlElement xe312 = xmldoc.CreateElement("HC5025XZ");//创建一个<Node>节点  
            xe312.InnerText = wgdata.HC5025XZ;
            XmlElement xe313 = xmldoc.CreateElement("HC5025CLZ");//创建一个<Node>节点   
            xe313.InnerText = wgdata.HC5025CLZ;
            XmlElement xe314 = xmldoc.CreateElement("HC5025PDJG");//创建一个<Node>节点   
            xe314.InnerText = wgdata.HC5025PDJG;
            XmlElement xe315 = xmldoc.CreateElement("CO5025XZ");//创建一个<Node>节点    
            xe315.InnerText = wgdata.CO5025XZ;
            XmlElement xe316 = xmldoc.CreateElement("CO5025CLZ");//创建一个<Node>节点  
            xe316.InnerText = wgdata.CO5025CLZ;
            XmlElement xe317 = xmldoc.CreateElement("CO5025PDJG");//创建一个<Node>节点  
            xe317.InnerText = wgdata.CO5025PDJG;
            XmlElement xe318 = xmldoc.CreateElement("NO5025XZ");//创建一个<Node>节点   
            xe318.InnerText = wgdata.NO5025XZ;
            XmlElement xe319 = xmldoc.CreateElement("NO5025CLZ");//创建一个<Node>节点  
            xe319.InnerText = wgdata.NO5025CLZ;
            XmlElement xe320 = xmldoc.CreateElement("NO5025PDJG");//创建一个<Node>节点  
            xe320.InnerText = wgdata.NO5025PDJG;
            XmlElement xe321 = xmldoc.CreateElement("FDJZS5025");//创建一个<Node>节点   
            xe321.InnerText = wgdata.FDJZS5025;
            XmlElement xe322 = xmldoc.CreateElement("FDJYW5025");//创建一个<Node>节点   
            xe322.InnerText = wgdata.FDJYW5025;
            XmlElement xe323 = xmldoc.CreateElement("HC2540XZ");//创建一个<Node>节点    
            xe323.InnerText = wgdata.HC2540XZ;
            XmlElement xe324 = xmldoc.CreateElement("HC2540CLZ");//创建一个<Node>节点    
            xe324.InnerText = wgdata.HC2540CLZ;


            XmlElement xe325 = xmldoc.CreateElement("HC2540PDJG");//创建一个<Node>节点  
            xe325.InnerText = wgdata.HC2540PDJG;
            XmlElement xe326 = xmldoc.CreateElement("CO2540XZ");//创建一个<Node>节点  
            xe326.InnerText = wgdata.CO2540XZ;
            XmlElement xe327 = xmldoc.CreateElement("CO2540CLZ");//创建一个<Node>节点   
            xe327.InnerText = wgdata.CO2540CLZ;
            XmlElement xe328 = xmldoc.CreateElement("CO2540PDJG");//创建一个<Node>节点  
            xe328.InnerText = wgdata.CO2540PDJG;
            XmlElement xe329 = xmldoc.CreateElement("NO2540XZ");//创建一个<Node>节点  
            xe329.InnerText = wgdata.NO2540XZ;
            XmlElement xe330 = xmldoc.CreateElement("NO2540CLZ");//创建一个<Node>节点   
            xe330.InnerText = wgdata.NO2540CLZ;
            XmlElement xe331 = xmldoc.CreateElement("NO2540PDJG");//创建一个<Node>节点   
            xe331.InnerText = wgdata.NO2540PDJG;
            XmlElement xe332 = xmldoc.CreateElement("FDJZS2540");//创建一个<Node>节点    
            xe332.InnerText = wgdata.FDJZS2540;
            XmlElement xe333 = xmldoc.CreateElement("FDJYW2540");//创建一个<Node>节点    
            xe333.InnerText = wgdata.FDJYW2540;
            XmlElement xe334 = xmldoc.CreateElement("PDJG");//创建一个<Node>节点   
            xe334.InnerText = wgdata.PDJG;
            XmlElement xe335 = xmldoc.CreateElement("SHY");//创建一个<Node>节点   
            xe335.InnerText = wgdata.SHY;
            XmlElement xe336 = xmldoc.CreateElement("SynchDate");//创建一个<Node>节点    
            xe336.InnerText = wgdata.SynchDate;
            XmlElement xe337 = xmldoc.CreateElement("YW");//创建一个<Node>节点    
            xe337.InnerText = wgdata.YW;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe201.AppendChild(xe322);
            xe201.AppendChild(xe323);
            xe201.AppendChild(xe324);
            xe201.AppendChild(xe325);
            xe201.AppendChild(xe326);
            xe201.AppendChild(xe327);
            xe201.AppendChild(xe328);
            xe201.AppendChild(xe329);
            xe201.AppendChild(xe330);
            xe201.AppendChild(xe331);
            xe201.AppendChild(xe332);
            xe201.AppendChild(xe333);
            xe201.AppendChild(xe334);
            xe201.AppendChild(xe335);
            xe201.AppendChild(xe336);
            xe201.AppendChild(xe337);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendSDSresultData(WGCommonTestData commondata, WGSDSresultData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("SDS");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("SBRZBM");//创建一个<Node>节点   
            xe301.InnerText = commondata.SBRZBM;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点     
            xe302.InnerText = commondata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点   
            xe303.InnerText = commondata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("SBZZC");//创建一个<Node>节点   
            xe304.InnerText = commondata.SBZZC;
            XmlElement xe305 = xmldoc.CreateElement("DPCGJ");//创建一个<Node>节点   
            xe305.InnerText = commondata.DPCGJ;
            XmlElement xe306 = xmldoc.CreateElement("PQFXY");//创建一个<Node>节点   
            xe306.InnerText = commondata.PQFXY;
            XmlElement xe307 = xmldoc.CreateElement("LLJ");//创建一个<Node>节点  
            xe307.InnerText = commondata.LLJ;
            XmlElement xe308 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点    
            xe308.InnerText = wgdata.JCBGBH;
            XmlElement xe309 = xmldoc.CreateElement("WD");//创建一个<Node>节点   
            xe309.InnerText = wgdata.WD;
            XmlElement xe310 = xmldoc.CreateElement("DQY");//创建一个<Node>节点   
            xe310.InnerText = wgdata.DQY;
            XmlElement xe311 = xmldoc.CreateElement("XDSD");//创建一个<Node>节点   
            xe311.InnerText = wgdata.XDSD;
            XmlElement xe312 = xmldoc.CreateElement("GLKQXSZ");//创建一个<Node>节点  
            xe312.InnerText = wgdata.GLKQXSZ;
            XmlElement xe313 = xmldoc.CreateElement("GLKQXSPDJG");//创建一个<Node>节点   
            xe313.InnerText = wgdata.GLKQXSPDJG;
            XmlElement xe314 = xmldoc.CreateElement("DDSCOXZ");//创建一个<Node>节点   
            xe314.InnerText = wgdata.DDSCOXZ;
            XmlElement xe315 = xmldoc.CreateElement("DDSCOZ");//创建一个<Node>节点    
            xe315.InnerText = wgdata.DDSCOZ;
            XmlElement xe316 = xmldoc.CreateElement("DDSCOPDJG");//创建一个<Node>节点  
            xe316.InnerText = wgdata.DDSCOPDJG;
            XmlElement xe317 = xmldoc.CreateElement("DDSHCXZ");//创建一个<Node>节点  
            xe317.InnerText = wgdata.DDSHCXZ;
            XmlElement xe318 = xmldoc.CreateElement("DDSHCZ");//创建一个<Node>节点   
            xe318.InnerText = wgdata.DDSHCZ;
            XmlElement xe319 = xmldoc.CreateElement("DDSHCPDJG");//创建一个<Node>节点  
            xe319.InnerText = wgdata.DDSHCPDJG;
            XmlElement xe320 = xmldoc.CreateElement("FDJDSZS");//创建一个<Node>节点  
            xe320.InnerText = wgdata.FDJDSZS;
            XmlElement xe321 = xmldoc.CreateElement("DDSJYWD");//创建一个<Node>节点   
            xe321.InnerText = wgdata.DDSJYWD;
            XmlElement xe322 = xmldoc.CreateElement("GDSCOXZ");//创建一个<Node>节点   
            xe322.InnerText = wgdata.GDSCOXZ;
            XmlElement xe323 = xmldoc.CreateElement("GDSCOZ");//创建一个<Node>节点    
            xe323.InnerText = wgdata.GDSCOZ;
            XmlElement xe324 = xmldoc.CreateElement("GDSCOPDJG");//创建一个<Node>节点    
            xe324.InnerText = wgdata.GDSCOPDJG;


            XmlElement xe325 = xmldoc.CreateElement("GDSHCZ");//创建一个<Node>节点  
            xe325.InnerText = wgdata.GDSHCZ;
            XmlElement xe326 = xmldoc.CreateElement("GDSHCXZ");//创建一个<Node>节点  
            xe326.InnerText = wgdata.GDSHCXZ;
            XmlElement xe327 = xmldoc.CreateElement("GDSHCPDJG");//创建一个<Node>节点   
            xe327.InnerText = wgdata.GDSHCPDJG;
            XmlElement xe328 = xmldoc.CreateElement("GDSZS");//创建一个<Node>节点  
            xe328.InnerText = wgdata.GDSZS;
            XmlElement xe329 = xmldoc.CreateElement("GDSJYWD");//创建一个<Node>节点  
            xe329.InnerText = wgdata.GDSJYWD;
            XmlElement xe330 = xmldoc.CreateElement("PDJG");//创建一个<Node>节点   
            xe330.InnerText = wgdata.PDJG;
            XmlElement xe331 = xmldoc.CreateElement("SHY");//创建一个<Node>节点   
            xe331.InnerText = wgdata.SHY;
            XmlElement xe332 = xmldoc.CreateElement("SynchDate");//创建一个<Node>节点    
            xe332.InnerText = wgdata.SynchDate;
            XmlElement xe333 = xmldoc.CreateElement("YW");//创建一个<Node>节点    
            xe333.InnerText = wgdata.YW;
            XmlElement xe334 = xmldoc.CreateElement("GLKQXSSX");//创建一个<Node>节点   
            xe334.InnerText = wgdata.GLKQXSSX;
            XmlElement xe335 = xmldoc.CreateElement("GLKQXSXX");//创建一个<Node>节点   
            xe335.InnerText = wgdata.GLKQXSXX;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe201.AppendChild(xe322);
            xe201.AppendChild(xe323);
            xe201.AppendChild(xe324);
            xe201.AppendChild(xe325);
            xe201.AppendChild(xe326);
            xe201.AppendChild(xe327);
            xe201.AppendChild(xe328);
            xe201.AppendChild(xe329);
            xe201.AppendChild(xe330);
            xe201.AppendChild(xe331);
            xe201.AppendChild(xe332);
            xe201.AppendChild(xe333);
            xe201.AppendChild(xe334);
            xe201.AppendChild(xe335);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendLugdwonresultData(WGCommonTestData commondata, WGLUGDOWNresultData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JZJS");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("SBRZBM");//创建一个<Node>节点   
            xe301.InnerText = commondata.SBRZBM;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点     
            xe302.InnerText = commondata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点   
            xe303.InnerText = commondata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("SBZZC");//创建一个<Node>节点   
            xe304.InnerText = commondata.SBZZC;
            XmlElement xe305 = xmldoc.CreateElement("DPCGJ");//创建一个<Node>节点   
            xe305.InnerText = commondata.DPCGJ;
            XmlElement xe306 = xmldoc.CreateElement("PQFXY");//创建一个<Node>节点   
            xe306.InnerText = commondata.PQFXY;
            XmlElement xe307 = xmldoc.CreateElement("LLJ");//创建一个<Node>节点  
            xe307.InnerText = commondata.LLJ;
            XmlElement xe308 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点    
            xe308.InnerText = wgdata.JCBGBH;
            XmlElement xe309 = xmldoc.CreateElement("WD");//创建一个<Node>节点   
            xe309.InnerText = wgdata.WD;
            XmlElement xe310 = xmldoc.CreateElement("DQY");//创建一个<Node>节点   
            xe310.InnerText = wgdata.DQY;
            XmlElement xe311 = xmldoc.CreateElement("XDSD");//创建一个<Node>节点   
            xe311.InnerText = wgdata.XDSD;
            XmlElement xe312 = xmldoc.CreateElement("VELMAXHP");//创建一个<Node>节点  
            xe312.InnerText = wgdata.VELMAXHP;
            XmlElement xe313 = xmldoc.CreateElement("VELMAXHPZS");//创建一个<Node>节点   
            xe313.InnerText = wgdata.VELMAXHPZS;
            XmlElement xe314 = xmldoc.CreateElement("ZDLBGL");//创建一个<Node>节点   
            xe314.InnerText = wgdata.ZDLBGL;
            XmlElement xe315 = xmldoc.CreateElement("ZDLBGLXZ");//创建一个<Node>节点    
            xe315.InnerText = wgdata.ZDLBGLXZ;
            XmlElement xe316 = xmldoc.CreateElement("ZDLBGLPDJG");//创建一个<Node>节点  
            xe316.InnerText = wgdata.ZDLBGLPDJG;
            XmlElement xe317 = xmldoc.CreateElement("VELMAXHPYDZ100");//创建一个<Node>节点  
            xe317.InnerText = wgdata.VELMAXHPYDZ100;
            XmlElement xe318 = xmldoc.CreateElement("VELMAXHPYDZ90");//创建一个<Node>节点   
            xe318.InnerText = wgdata.VELMAXHPYDZ90;
            XmlElement xe319 = xmldoc.CreateElement("VELMAXHPYDZ80");//创建一个<Node>节点  
            xe319.InnerText = wgdata.VELMAXHPYDZ80;
            XmlElement xe320 = xmldoc.CreateElement("YDXZ");//创建一个<Node>节点  
            xe320.InnerText = wgdata.YDXZ;
            XmlElement xe321 = xmldoc.CreateElement("YDPDJG");//创建一个<Node>节点   
            xe321.InnerText = wgdata.YDPDJG;
            XmlElement xe322 = xmldoc.CreateElement("PDJG");//创建一个<Node>节点   
            xe322.InnerText = wgdata.PDJG;
            XmlElement xe323 = xmldoc.CreateElement("SHY");//创建一个<Node>节点    
            xe323.InnerText = wgdata.SHY;
            XmlElement xe324 = xmldoc.CreateElement("SynchDate");//创建一个<Node>节点    
            xe324.InnerText = wgdata.SynchDate;


            XmlElement xe325 = xmldoc.CreateElement("YW");//创建一个<Node>节点  
            xe325.InnerText = wgdata.YW;
            XmlElement xe326 = xmldoc.CreateElement("FDJEDZSSX");//创建一个<Node>节点  
            xe326.InnerText = wgdata.FDJEDZSSX;
            XmlElement xe327 = xmldoc.CreateElement("FDJEDZSXX");//创建一个<Node>节点   
            xe327.InnerText = wgdata.FDJEDZSXX;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe201.AppendChild(xe322);
            xe201.AppendChild(xe323);
            xe201.AppendChild(xe324);
            xe201.AppendChild(xe325);
            xe201.AppendChild(xe326);
            xe201.AppendChild(xe327);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendBtgresultData(WGCommonTestData commondata, WGBTGresultData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("BTGYD");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("SBRZBM");//创建一个<Node>节点   
            xe301.InnerText = commondata.SBRZBM;
            XmlElement xe302 = xmldoc.CreateElement("SBMC");//创建一个<Node>节点     
            xe302.InnerText = commondata.SBMC;
            XmlElement xe303 = xmldoc.CreateElement("SBXH");//创建一个<Node>节点   
            xe303.InnerText = commondata.SBXH;
            XmlElement xe304 = xmldoc.CreateElement("SBZZC");//创建一个<Node>节点   
            xe304.InnerText = commondata.SBZZC;
            XmlElement xe305 = xmldoc.CreateElement("DPCGJ");//创建一个<Node>节点   
            xe305.InnerText = commondata.DPCGJ;
            XmlElement xe306 = xmldoc.CreateElement("PQFXY");//创建一个<Node>节点   
            xe306.InnerText = commondata.PQFXY;
            XmlElement xe307 = xmldoc.CreateElement("LLJ");//创建一个<Node>节点  
            xe307.InnerText = commondata.LLJ;
            XmlElement xe308 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点    
            xe308.InnerText = wgdata.JCBGBH;
            XmlElement xe309 = xmldoc.CreateElement("WD");//创建一个<Node>节点   
            xe309.InnerText = wgdata.WD;
            XmlElement xe310 = xmldoc.CreateElement("DQY");//创建一个<Node>节点   
            xe310.InnerText = wgdata.DQY;
            XmlElement xe311 = xmldoc.CreateElement("XDSD");//创建一个<Node>节点   
            xe311.InnerText = wgdata.XDSD;
            XmlElement xe312 = xmldoc.CreateElement("FDJDSZS");//创建一个<Node>节点  
            xe312.InnerText = wgdata.FDJDSZS;
            XmlElement xe313 = xmldoc.CreateElement("ZHDSCCSZ");//创建一个<Node>节点   
            xe313.InnerText = wgdata.ZHDSCCSZ;
            XmlElement xe314 = xmldoc.CreateElement("ZHDECCSZ");//创建一个<Node>节点   
            xe314.InnerText = wgdata.ZHDECCSZ;
            XmlElement xe315 = xmldoc.CreateElement("ZHDYCCSZ");//创建一个<Node>节点    
            xe315.InnerText = wgdata.ZHDYCCSZ;
            XmlElement xe316 = xmldoc.CreateElement("PJZ");//创建一个<Node>节点  
            xe316.InnerText = wgdata.PJZ;
            XmlElement xe317 = xmldoc.CreateElement("XZ");//创建一个<Node>节点  
            xe317.InnerText = wgdata.XZ;
            XmlElement xe318 = xmldoc.CreateElement("PDJG");//创建一个<Node>节点   
            xe318.InnerText = wgdata.PDJG;
            XmlElement xe319 = xmldoc.CreateElement("SHY");//创建一个<Node>节点  
            xe319.InnerText = wgdata.SHY;
            XmlElement xe320 = xmldoc.CreateElement("SynchDate");//创建一个<Node>节点  
            xe320.InnerText = wgdata.SynchDate;
            XmlElement xe321 = xmldoc.CreateElement("YW");//创建一个<Node>节点   
            xe321.InnerText = wgdata.YW;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe201.AppendChild(xe305);
            xe201.AppendChild(xe306);
            xe201.AppendChild(xe307);
            xe201.AppendChild(xe308);
            xe201.AppendChild(xe309);
            xe201.AppendChild(xe310);
            xe201.AppendChild(xe311);
            xe201.AppendChild(xe312);
            xe201.AppendChild(xe313);
            xe201.AppendChild(xe314);
            xe201.AppendChild(xe315);
            xe201.AppendChild(xe316);
            xe201.AppendChild(xe317);
            xe201.AppendChild(xe318);
            xe201.AppendChild(xe319);
            xe201.AppendChild(xe320);
            xe201.AppendChild(xe321);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendTakePictureData(WGTakePictureData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("JCGWPHOTO_NEW");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("GWZT");//创建一个<Node>节点     
            xe302.InnerText = wgdata.GWZT;
            XmlElement xe303 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点   
            xe303.InnerText = wgdata.JCGWH;
            XmlElement xe304 = xmldoc.CreateElement("CREATEDATE");//创建一个<Node>节点   
            xe304.InnerText = wgdata.CREATEDATE;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
        public bool SendTakeVideoData(WGTakeVideoData wgdata)
        {
            //socket.Connect(point);
            XmlDocument xmldoc, xlmrecivedoc;
            XmlNode xmlnode;
            XmlElement xmlelem;
            DataTable dt = null;
            xmldoc = new XmlDocument();
            xmlelem = xmldoc.CreateElement("", "TestData", "");
            xmldoc.AppendChild(xmlelem);
            XmlNode root = xmldoc.SelectSingleNode("TestData");//查找<Employees> 
            XmlElement xe101 = xmldoc.CreateElement("VIDEOINFO");//创建一个<Node>节点  
            XmlElement xe201 = xmldoc.CreateElement("Records");//创建一个<Node>节点  
            XmlElement xe301 = xmldoc.CreateElement("JCBGBH");//创建一个<Node>节点   
            xe301.InnerText = wgdata.JCBGBH;
            XmlElement xe302 = xmldoc.CreateElement("JCGWH");//创建一个<Node>节点     
            xe302.InnerText = wgdata.JCGWH;
            XmlElement xe303 = xmldoc.CreateElement("LXKSSJ");//创建一个<Node>节点   
            xe303.InnerText = wgdata.LXKSSJ;
            XmlElement xe304 = xmldoc.CreateElement("ZT");//创建一个<Node>节点   
            xe304.InnerText = wgdata.ZT;
            xe201.AppendChild(xe301);
            xe201.AppendChild(xe302);
            xe201.AppendChild(xe303);
            xe201.AppendChild(xe304);
            xe101.AppendChild(xe201);
            root.AppendChild(xe101);
            if (SendData(ConvertXmlToString(xmldoc)) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
