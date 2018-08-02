using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
namespace carinfor
{
    public class acNetInf
    {
        public static string acArea;
        public const string acArea_NN = "辽宁";
        public const string acArea_Other = "其他";
        public const string ACAREA_v132 = "v1.3.2";

    }
    public class netLoginData
    {
        public string JCGWH;//(检测工位编号)
        public string JCZBH;//检测站编号(地区编号(6位)+站编号(2位))
        public string STATION_PROGRAM;//程序名称，如：lungdown排放检测程序；ASM排放检测程序等
        public string STATION_KIND;//工位类型1：简易瞬态工况法2：稳态工况法；3：双怠速法；4加载减速法：5.不透光烟度6、滤纸烟度法7：滤纸烟度法(农)；8：双怠速法(摩) 若该工位能从事多种方法的检测，代码间用逗号分隔
        public string STATION_STATUS;//待命(W)
        public string OPERATOR_NO;//操作员编号
        public string OPERATOR_PSW;//操作员密码
        public string SynchDate;//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public bool writeNetLoginData()
        {
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                return (SocketControlNn.SetRegisterDataEx('R', 0, "JCGWH=" + JCGWH + "\r\n" + "JCZBH=" + JCZBH + "\r\n" + "STATION_PROGRAM=" + STATION_PROGRAM + "\r\n"
                    + "STATION_KIND=" + STATION_KIND + "\r\n" + "STATION_STATUS=" + STATION_STATUS + "\r\n" +
                   "OPERATOR_NO=" + OPERATOR_NO + "\r\n" + "OPERATOR_PSW=" + OPERATOR_PSW + "\r\n" + "SynchDate=" + SynchDate + "\r\n"));
            }
            else
            {
                return (SocketControl.SetRegisterDataEx('R', 0, "JCGWH=" + JCGWH + "\r\n" + "JCZBH=" + JCZBH + "\r\n" + "STATION_PROGRAM=" + STATION_PROGRAM + "\r\n"
                    + "STATION_KIND=" + STATION_KIND + "\r\n" + "STATION_STATUS=" + STATION_STATUS + "\r\n" +
                   "OPERATOR_NO=" + OPERATOR_NO + "\r\n" + "OPERATOR_PSW=" + OPERATOR_PSW + "\r\n" + "SynchDate=" + SynchDate + "\r\n"));
            }
        }

    }
    public class netLoginAck
    {
        public string JCGWH;	//锁止检测工位号
        public string SUMMARY;	//备注说明，如：nType=A，则为系统锁止原因
        public string OPERATOR_GRAUDE;//操作员权限等级
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)

    }
    public class netLoginTime
    {
        public string Date;	//当前日期：如：2008年1月1日
        public string Timer;	//当前时间（精确到毫秒）：22点33分3秒800毫秒
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)

    }
    public class netRegCarWait
    {
        public string JCBGBH;//=150101010111308010001	//统一格式为：检测站编号(地区编号(6位)+站编号(2位))(organ 8位) 线号（2位） 检测方法（1位） 日期（6位 yymmdd） 四位流水（4） 19位
        public string JCGWH;//=01	//(检测工位号)
        public string JCZBH;//=15010101	检测站编号(地区编号(6位)+站编号(2位))
        public string JCRQ;//=2006-07-31 09:25:53	//检测日期
        public string JCLB;//=01	01在用车年检，02转入检验 03转出检验 04 新车检验
        public string JCLRY;//=张三	//录入员
        public string JCCZY;//=李四	//操作员
        public string JCJSY;//=王五	//引车员
        public string CPHM;//=蓝蒙B98608//(农用车为农黄蒙B98608)	//车牌号码（车牌颜色+车牌号码 如为农用车或摩托车，则车牌颜色为农黄、摩黄、摩蓝）（实验比对车辆请在此注明，格式为：蓝黑B98608实验，即在车牌号码后面加实验两个字，不能为其他汉字。也不能在单位名称里面加相关汉字来区分）
        public string CLZL;//=1	//车辆种类(1-客车，2-货车，3-摩托车)
        public string CLLX;//=K33	//车辆类型（按 GA24.4 ，如K33，参照附录A1.3)
        public string HPZL;//=01 	号牌种类(只用传编号即可,参照附录A1.1)
        public string CZMC;//=深圳西珍纸箱制品有限公司	//车主名称
        public string LXDZ;//=深圳市南山区南山大道888号	//联系地址
        public string LXDH;//= 15954889898	//联系电话
        public string CPMC;//=桑塔纳	//厂牌名称
        public string CPXH;//=3000	//厂牌型号
        public string SYXZ;//=A	//使用性质(按公安 GA24.3 如A，参照附录A1.4) 
        public string CLSBM;//= LHA12D3D96AV00929	//车辆识别码
        public string CLSCQY;//=上海大众汽车有限公司	//生产企业
        public string ZDZZL;//= 2800.0	//最大总质量（单位KG）
        public string JZZL;//=1000	//基准质量（单位KG）
        public string CCDJRQ;//=2007-01-01	//初次登记日期
        public string CCRQ;//=2005-01-01	//出厂日期
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
        public string GYXTXS;//供油系统形式
        public string PQHCLZZ;//=1	//排气后处理装置(0-无 1-有）
        public string RYPH;//=90	//燃油牌号
        public string SFCJ;//=复检	//检测状态（初检\复检）
        public string JCCS;//=3	//检测次数（初检为1，第一次复检为2，依次递加）
        public string SFWDZR;//=0	//是否外地转入（0-否,1-是）
        public string SFYQBF;//=0	//是否延期报废（0-否,1-是）
        public string SynchDate;//=2008-01-21 18:18:18.888	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string SJCYS;//=5	//设计乘员数
        public string SBRZBM;//=HY00037	//设备认证编码
        public string SBMC;//=ASM汽车尾气检测系统	//设备名称
        public string SBXH;//=QWJ-3000	//设备型号
        public string SBZZC;//=深圳市安车检测技术有限公司	//制造厂
        public string DPCGJ;//=德国马哈	//底盘测功机
        public string PQFXY;//=MULTI-GAS pro-P5550	//排气分析仪
        public string LLJ;//=浙大鸣泉	//流量计
        public string SSXQ;//=150101	//所属区域(6位)
        public string SFLJ;//是否路检（是/否)
        public string FWLX;//服务类型（正常)
        public string JCFS;//=0	//检测方式 0-上线检测，1-路检，2-服务，3-抽检
        public string SFCS;//=0	//是否测试(0-否，1-是)
        public string FDJEDZS;//=2000	发动机额定转速 
        public string FDJEDGL;//=50	发动机额定功率
        public string ECRYPT;//=DA4FB5C6E93E74D3DF8527599FA62642	//调用控件提交信息成功后会生成验证码，此验证码需要在检测发送车辆信息的时候进行发送（长度不固定，若未调用控件登录此项可为空） 
        public string BGJCFFYY;//=	//变更检测方法原因（四驱车无法转换两驱、安装有电子保护设备且无法关闭、柴油车加载功率不足、多轮轴柴油车）\
        public string JYLSH;
        public string ICCardNo;// =
        public string ZBZL;// = 900
        public string DPFS;// = 单点电喷
        public string OBD;// = 是
        public string DKGYYB;// = 是
        public string DLSP;// = 否
        public string CHZZ;// = ASR
        public string WXBJ;// =
        public string WXCD;// =
        public string WXSJ;// = 2006-07-31 09:10:50
        public string WXFY;// = 200.00

        public string writenetRegCarWait(int jcff)
        {
            string ackstring="";
            string CODE;
            string MESSAGE;
            try
            {
                if (acNetInf.acArea == acNetInf.acArea_NN)
                {

                    if (SocketControlNn.SendToServerEx('T', (char)jcff, "JCBGBH=" + JCBGBH + "\r\n" + "JCGWH=" + JCGWH + "\r\n" + "JCZBH=" + JCZBH + "\r\n"
                    + "JCRQ=" + JCRQ + "\r\n" + "JCLB=" + JCLB + "\r\n" + "JCLRY=" + JCLRY + "\r\n" + "JCCZY=" + JCCZY + "\r\n" + "JCJSY=" + JCJSY + "\r\n" + "CPHM=" + CPHM + "\r\n"
                    + "CLZL=" + CLZL + "\r\n" + "CLLX=" + CLLX + "\r\n" + "HPZL=" + HPZL + "\r\n" + "CZMC=" + CZMC + "\r\n" + "LXDZ=" + LXDZ + "\r\n" + "LXDH=" + LXDH + "\r\n"
                    + "CPMC=" + CPMC + "\r\n" + "CPXH=" + CPXH + "\r\n" + "SYXZ=" + SYXZ + "\r\n" + "CLSBM=" + CLSBM + "\r\n" + "CLSCQY=" + CLSCQY + "\r\n" + "ZDZZL=" + ZDZZL + "\r\n"
                    + "JZZL=" + JZZL + "\r\n" + "CCDJRQ=" + CCDJRQ + "\r\n" + "CCRQ=" + CCRQ + "\r\n" + "DCZZ=" + DCZZ + "\r\n" + "DPXH=" + DPXH + "\r\n" + "QDFS=" + QDFS + "\r\n"
                    + "QDLTQY=" + QDLTQY + "\r\n" + "RYXS=" + RYXS + "\r\n" + "RYGG=" + RYGG + "\r\n" + "LJXSLC=" + LJXSLC + "\r\n" + "CHZHQ=" + CHZHQ + "\r\n" + "JQFS=" + JQFS + "\r\n"
                    + "PQHCLZZ=" + PQHCLZZ + "\r\n" + "RYPH=" + RYPH + "\r\n" + "SFCJ=" + SFCJ + "\r\n" + "JCCS=" + JCCS + "\r\n" + "SFWDZR=" + SFWDZR + "\r\n" + "SFYQBF=" + SFYQBF + "\r\n"
                    + "SynchDate=" + SynchDate + "\r\n" + "SJCYS=" + SJCYS + "\r\n" + "SBRZBM=" + SBRZBM + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n" + "SBZZC=" + SBZZC + "\r\n"
                    + "DPCGJ=" + DPCGJ + "\r\n" + "PQFXY=" + PQFXY + "\r\n" + "LLJ=" + LLJ + "\r\n" + "SSXQ=" + SSXQ + "\r\n" + "JCFS=" + JCFS + "\r\n" + "SFCS=" + SFCS + "\r\n"
                    + "GYXTXS=" + GYXTXS + "\r\n" + "SFLJ=" + SFLJ + "\r\n" + "FWLX=" + FWLX + "\r\n" //辽宁协议新加
                    + "FDJEDZS=" + FDJEDZS + "\r\n" + "FDJEDGL=" + FDJEDGL + "\r\n" + "ECRYPT=" + ECRYPT + "\r\n" + "BGJCFFYY=" + BGJCFFYY + "\r\n" + "JYLSH=" + JYLSH + "\r\n"//辽宁协议新加
                     + "ICCardNo=" + ICCardNo + "\r\n" + "ZBZL=" + ZBZL + "\r\n" + "DPFS=" + DPFS + "\r\n" + "OBD=" + OBD + "\r\n" + "DKGYYB=" + DKGYYB + "\r\n"//辽宁协议新加
                     + "DLSP=" + DLSP + "\r\n" + "CHZZ=" + CHZZ + "\r\n" + "WXBJ=" + WXBJ + "\r\n" + "WXCD=" + WXCD + "\r\n" + "WXSJ=" + WXFY + "\r\n" + WXFY + "\r\n"))
                    { return "成功"; }
                    else
                    { return "发送失败"; }
                }
                else
                {
                    ini.INIIO.saveLogInf("[SendToServerEx]:("+"T,"+ jcff.ToString()+ ",JCBGBH=" + JCBGBH + "\r\n" + "JCGWH=" + JCGWH + "\r\n" + "JCZBH=" + JCZBH + "\r\n"
                    + "JCRQ=" + JCRQ + "\r\n" + "JCLB=" + JCLB + "\r\n" + "JCLRY=" + JCLRY + "\r\n" + "JCCZY=" + JCCZY + "\r\n" + "JCJSY=" + JCJSY + "\r\n" + "CPHM=" + CPHM + "\r\n"
                    + "CLZL=" + CLZL + "\r\n" + "CLLX=" + CLLX + "\r\n" + "HPZL=" + HPZL + "\r\n" + "CZMC=" + CZMC + "\r\n" + "LXDZ=" + LXDZ + "\r\n" + "LXDH=" + LXDH + "\r\n"
                    + "CPMC=" + CPMC + "\r\n" + "CPXH=" + CPXH + "\r\n" + "SYXZ=" + SYXZ + "\r\n" + "CLSBM=" + CLSBM + "\r\n" + "CLSCQY=" + CLSCQY + "\r\n" + "ZDZZL=" + ZDZZL + "\r\n"
                    + "JZZL=" + JZZL + "\r\n" + "CCDJRQ=" + CCDJRQ + "\r\n" + "CCRQ=" + CCRQ + "\r\n" + "DCZZ=" + DCZZ + "\r\n" + "DPXH=" + DPXH + "\r\n" + "QDFS=" + QDFS + "\r\n"
                    + "QDLTQY=" + QDLTQY + "\r\n" + "RYXS=" + RYXS + "\r\n" + "RYGG=" + RYGG + "\r\n" + "LJXSLC=" + LJXSLC + "\r\n" + "CHZHQ=" + CHZHQ + "\r\n" + "JQFS=" + JQFS + "\r\n"
                    + "PQHCLZZ=" + PQHCLZZ + "\r\n" + "RYPH=" + RYPH + "\r\n" + "SFCJ=" + SFCJ + "\r\n" + "JCCS=" + JCCS + "\r\n" + "SFWDZR=" + SFWDZR + "\r\n" + "SFYQBF=" + SFYQBF + "\r\n"
                    + "SynchDate=" + SynchDate + "\r\n" + "SJCYS=" + SJCYS + "\r\n" + "SBRZBM=" + SBRZBM + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n" + "SBZZC=" + SBZZC + "\r\n"
                    + "DPCGJ=" + DPCGJ + "\r\n" + "PQFXY=" + PQFXY + "\r\n" + "LLJ=" + LLJ + "\r\n" + "SSXQ=" + SSXQ + "\r\n" + "JCFS=" + JCFS + "\r\n" + "SFCS=" + SFCS + "\r\n"
                    + "GYXTXS=" + GYXTXS + "\r\n" + "SFLJ=" + SFLJ + "\r\n" + "FWLX=" + FWLX + "\r\n" //辽宁协议新加
                    + "FDJEDZS=" + FDJEDZS + "\r\n" + "FDJEDGL=" + FDJEDGL + "\r\n" + "ECRYPT=" + ECRYPT + "\r\n" + "BGJCFFYY=" + BGJCFFYY + "\r\n" + "JYLSH=" + JYLSH + "\r\n"//辽宁协议新加
                     + "ICCardNo=" + ICCardNo + "\r\n" + "ZBZL=" + ZBZL + "\r\n" + "DPFS=" + DPFS + "\r\n" + "OBD=" + OBD + "\r\n" + "DKGYYB=" + DKGYYB + "\r\n"//辽宁协议新加
                     + "DLSP=" + DLSP + "\r\n" + "CHZZ=" + CHZZ + "\r\n" + "WXBJ=" + WXBJ + "\r\n" + "WXCD=" + WXCD + "\r\n" + "WXSJ=" + WXFY + "\r\n" + WXFY + "\r\n"+")");
                    ackstring = SocketControl.SendToServerEx('T', jcff, "JCBGBH=" + JCBGBH + "\r\n" + "JCGWH=" + JCGWH + "\r\n" + "JCZBH=" + JCZBH + "\r\n"
                    + "JCRQ=" + JCRQ + "\r\n" + "JCLB=" + JCLB + "\r\n" + "JCLRY=" + JCLRY + "\r\n" + "JCCZY=" + JCCZY + "\r\n" + "JCJSY=" + JCJSY + "\r\n" + "CPHM=" + CPHM + "\r\n"
                    + "CLZL=" + CLZL + "\r\n" + "CLLX=" + CLLX + "\r\n" + "HPZL=" + HPZL + "\r\n" + "CZMC=" + CZMC + "\r\n" + "LXDZ=" + LXDZ + "\r\n" + "LXDH=" + LXDH + "\r\n"
                    + "CPMC=" + CPMC + "\r\n" + "CPXH=" + CPXH + "\r\n" + "SYXZ=" + SYXZ + "\r\n" + "CLSBM=" + CLSBM + "\r\n" + "CLSCQY=" + CLSCQY + "\r\n" + "ZDZZL=" + ZDZZL + "\r\n"
                    + "JZZL=" + JZZL + "\r\n" + "CCDJRQ=" + CCDJRQ + "\r\n" + "CCRQ=" + CCRQ + "\r\n" + "DCZZ=" + DCZZ + "\r\n" + "DPXH=" + DPXH + "\r\n" + "QDFS=" + QDFS + "\r\n"
                    + "QDLTQY=" + QDLTQY + "\r\n" + "RYXS=" + RYXS + "\r\n" + "RYGG=" + RYGG + "\r\n" + "LJXSLC=" + LJXSLC + "\r\n" + "CHZHQ=" + CHZHQ + "\r\n" + "JQFS=" + JQFS + "\r\n"
                    + "PQHCLZZ=" + PQHCLZZ + "\r\n" + "RYPH=" + RYPH + "\r\n" + "SFCJ=" + SFCJ + "\r\n" + "JCCS=" + JCCS + "\r\n" + "SFWDZR=" + SFWDZR + "\r\n" + "SFYQBF=" + SFYQBF + "\r\n"
                    + "SynchDate=" + SynchDate + "\r\n" + "SJCYS=" + SJCYS + "\r\n" + "SBRZBM=" + SBRZBM + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n" + "SBZZC=" + SBZZC + "\r\n"
                    + "DPCGJ=" + DPCGJ + "\r\n" + "PQFXY=" + PQFXY + "\r\n" + "LLJ=" + LLJ + "\r\n" + "SSXQ=" + SSXQ + "\r\n" + "JCFS=" + JCFS + "\r\n" + "SFCS=" + SFCS + "\r\n"
                    + "GYXTXS=" + GYXTXS + "\r\n" + "SFLJ=" + SFLJ + "\r\n" + "FWLX=" + FWLX + "\r\n" //辽宁协议新加
                    + "FDJEDZS=" + FDJEDZS + "\r\n" + "FDJEDGL=" + FDJEDGL + "\r\n" + "ECRYPT=" + ECRYPT + "\r\n" + "BGJCFFYY=" + BGJCFFYY + "\r\n" + "JYLSH=" + JYLSH + "\r\n"//辽宁协议新加
                     + "ICCardNo=" + ICCardNo + "\r\n" + "ZBZL=" + ZBZL + "\r\n" + "DPFS=" + DPFS + "\r\n" + "OBD=" + OBD + "\r\n" + "DKGYYB=" + DKGYYB + "\r\n"//辽宁协议新加
                     + "DLSP=" + DLSP + "\r\n" + "CHZZ=" + CHZZ + "\r\n" + "WXBJ=" + WXBJ + "\r\n" + "WXCD=" + WXCD + "\r\n" + "WXSJ=" + WXFY + "\r\n" + WXFY + "\r\n");//辽宁协议新加

                if (ackstring.Contains("<"))
                {
                    return "成功"; 
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
                }
            }
            catch
            {
                return ("发生异常，发送失败,ackstring:" + ackstring);
            }
        }
    }
    public class equipmentSelfDetectStart
    {
        public string JCGWH;	//检测工位号
        public string SBBH;	//1：测功机，2：废气仪，3：烟度计  4：电子环境信息仪  5：发动机转速仪  6：流量计
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;		//标定设备型号
        public string SJXL;	//时间序列（从自检开始到结束，以秒为单位的相对时间）
        public string SynchDate;//发送时间(表示：2008年1月21日18点18分1秒888毫秒精确到毫秒)
        public string writeequipmentSelfDetectStart()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('S', (int)'V', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                { return "成功"; }
                else
                { return "发送失败"; }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('S', (int)'V', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];

                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }

    }
    public class equipmentSelfDetectFinish
    {
        public string JCGWH;//检测工位号
        public string SBBH;	//1：测功机，2：废气仪，3：烟度计  4：电子环境信息仪  5：发动机转速仪
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;		//标定设备型号
        public string SJXL;	//时间序列（从自检开始到结束，以秒为单位的相对时间）
        public string SynchDate;//发送时间(表示：2008年1月21日18点18分1秒888毫秒精确到毫秒)
        public string writeequipmentSelfDetectFinish()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('S', (int)'K', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('S', (int)'K', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];

                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;

                    }
                }
            }
        }
    }
    public class cgjSelfDetectInf
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writecgjSelfDetectInf()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('V', 1, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "JSQJC=" + JSQJC + "\r\n" + "TTYRKSSJ=" + TTYRKSSJ + "\r\n" + "TTYRJSSJ=" + TTYRJSSJ + "\r\n"
                + "GXDL=" + GXDL + "\r\n" + "JZHXDS=" + JZHXDS + "\r\n" + "CS1=" + CS1 + "\r\n"
                + "JZGL1=" + JZGL1 + "\r\n" + "JSGL1=" + JSGL1 + "\r\n" + "LLHXSJ1=" + LLHXSJ1 + "\r\n"
                + "SJHXSJ1=" + SJHXSJ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "CS2=" + CS2 + "\r\n"
                + "JZGL2=" + JZGL2 + "\r\n" + "JSGL2=" + JSGL2 + "\r\n" + "LLHXSJ2=" + LLHXSJ2 + "\r\n"
                + "SJHXSJ2=" + SJHXSJ2 + "\r\n" + "PC2=" + PC2 + "\r\n" + "ZJJG=" + ZJJG + "\r\n"
                 + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('V', 1, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "JSQJC=" + JSQJC + "\r\n" + "TTYRKSSJ=" + TTYRKSSJ + "\r\n" + "TTYRJSSJ=" + TTYRJSSJ + "\r\n"
                + "GXDL=" + GXDL + "\r\n" + "JZHXDS=" + JZHXDS + "\r\n" + "CS1=" + CS1 + "\r\n"
                + "JZGL1=" + JZGL1 + "\r\n" + "JSGL1=" + JSGL1 + "\r\n" + "LLHXSJ1=" + LLHXSJ1 + "\r\n"
                + "SJHXSJ1=" + SJHXSJ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "CS2=" + CS2 + "\r\n"
                + "JZGL2=" + JZGL2 + "\r\n" + "JSGL2=" + JSGL2 + "\r\n" + "LLHXSJ2=" + LLHXSJ2 + "\r\n"
                + "SJHXSJ2=" + SJHXSJ2 + "\r\n" + "PC2=" + PC2 + "\r\n" + "ZJJG=" + ZJJG + "\r\n"
                 + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class fqySelfDetectInf
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
        public string SynchDate;//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string ZJJG;	//自检结果（通过/不通过）
        public string writefqySelfDetectInf()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('V', 2, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "YQYR=" + YQYR + "\r\n" + "YQJL=" + YQJL + "\r\n" + "YQTL=" + YQTL + "\r\n"
                + "YQLL=" + YQLL + "\r\n" + "YQYQ=" + YQYQ + "\r\n" + "SynchDate=" + SynchDate + "\r\n" + "ZJJG=" + ZJJG + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('V', 2, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "YQYR=" + YQYR + "\r\n" + "YQJL=" + YQJL + "\r\n" + "YQTL=" + YQTL + "\r\n"
                + "YQLL=" + YQLL + "\r\n" + "YQYQ=" + YQYQ + "\r\n" + "SynchDate=" + SynchDate + "\r\n" + "ZJJG=" + ZJJG + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class ydjSelfDetectInf
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeydjSelfDetectInf()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('V', 3, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "YQYR=" + YQYR + "\r\n" + "YQTL=" + YQTL + "\r\n"
                + "LCJC=" + LCJC + "\r\n" + "JCDS=" + JCDS + "\r\n" + "BTGSDZ1=" + BTGSDZ1 + "\r\n" + "BTGSCZ1=" + BTGSCZ1 + "\r\n"
                + "BTGPC1=" + BTGPC1 + "\r\n" + "BTGSDZ2=" + BTGSDZ2 + "\r\n"
                + "BTGSCZ2=" + BTGSCZ2 + "\r\n" + "BTGPC2=" + BTGPC2 + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('V', 3, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "YQYR=" + YQYR + "\r\n" + "YQTL=" + YQTL + "\r\n"
                + "LCJC=" + LCJC + "\r\n" + "JCDS=" + JCDS + "\r\n" + "BTGSDZ1=" + BTGSDZ1 + "\r\n" + "BTGSCZ1=" + BTGSCZ1 + "\r\n"
                + "BTGPC1=" + BTGPC1 + "\r\n" + "BTGSDZ2=" + BTGSDZ2 + "\r\n"
                + "BTGSCZ2=" + BTGSCZ2 + "\r\n" + "BTGPC2=" + BTGPC2 + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class dzhjSelfDetectInf
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writedzhjSelfDetectInf()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('V', 4, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "HJWD=" + HJWD + "\r\n" + "YQWD=" + YQWD + "\r\n"
                + "HJSD=" + HJSD + "\r\n" + "YQSD=" + YQSD + "\r\n" + "HJQY=" + HJQY + "\r\n" + "YQQY=" + YQQY + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('V', 4, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "HJWD=" + HJWD + "\r\n" + "YQWD=" + YQWD + "\r\n"
                + "HJSD=" + HJSD + "\r\n" + "YQSD=" + YQSD + "\r\n" + "HJQY=" + HJQY + "\r\n" + "YQQY=" + YQQY + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class zsjSelfDetecInf
    {
        public string JCGWH;	//检测工位号
        public string SBMC;	//设备名称
        public string SBXH;	//设备型号
        public string JCZBH;		//检测站编号(地区编号(6位)+站编号(2位))
        public string Date;	//自检时间如：2008年1月1日8点33分3秒
        public string TXJC;	//通讯检查 1：成功 0：失败
        public string DSZS;	//怠速转速
        public string ZJJG;	//自检结果（通过/不通过）
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writezsjSelfDetecInf()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('V', 5, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "DSZS=" + DSZS + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('V', 5, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "DSZS=" + DSZS + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class lljSelfDetectInf
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writedlljSelfDetectInf()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('V', 6, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "YQYR=" + YQYR + "\r\n" + "LLJC=" + LLJC + "\r\n"
                + "YQLL=" + YQLL + "\r\n" + "QYLC=" + QYLC + "\r\n" + "YQYQ=" + YQYQ + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('V', 6, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "Date=" + Date + "\r\n" + "TXJC=" + TXJC + "\r\n" + "YQYR=" + YQYR + "\r\n" + "LLJC=" + LLJC + "\r\n"
                + "YQLL=" + YQLL + "\r\n" + "QYLC=" + QYLC + "\r\n" + "YQYQ=" + YQYQ + "\r\n"
                + "ZJJG=" + ZJJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class asmProcessData
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
        public string JCZT;
        public string writeasmProcessData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 11, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "HCCLZ=" + HCCLZ + "\r\n" + "NOCLZ=" + NOCLZ + "\r\n" + "COCLZ=" + COCLZ + "\r\n" + "CO2CLZ=" + CO2CLZ + "\r\n" + "O2CLZ=" + O2CLZ + "\r\n"
                + "CS=" + CS + "\r\n" + "ZS=" + ZS + "\r\n" + "XSXZXS=" + XSXZXS + "\r\n" + "SDXZXS=" + SDXZXS + "\r\n"
                + "JSGL=" + JSGL + "\r\n" + "ZSGL=" + ZSGL + "\r\n" + "HJWD=" + HJWD + "\r\n" + "DQYL=" + DQYL + "\r\n" + "XDSD=" + XDSD + "\r\n" + "YW=" + YW + "\r\n" + "JCZT=" + JCZT + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 11, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "HCCLZ=" + HCCLZ + "\r\n" + "NOCLZ=" + NOCLZ + "\r\n" + "COCLZ=" + COCLZ + "\r\n" + "CO2CLZ=" + CO2CLZ + "\r\n" + "O2CLZ=" + O2CLZ + "\r\n"
                + "CS=" + CS + "\r\n" + "ZS=" + ZS + "\r\n" + "XSXZXS=" + XSXZXS + "\r\n" + "SDXZXS=" + SDXZXS + "\r\n"
                + "JSGL=" + JSGL + "\r\n" + "ZSGL=" + ZSGL + "\r\n" + "HJWD=" + HJWD + "\r\n" + "DQYL=" + DQYL + "\r\n" + "XDSD=" + XDSD + "\r\n" + "YW=" + YW + "\r\n" + "JCZT=" + JCZT + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class ASMresultData
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
        public string JCKSSJ;	//检测开始时间
        public string JCJSSJ;	//检测结束时间
        public string KSTG5025;	//检测开始时间
        public string KSTG2540;	//检测结束时间
        public string writeASMresultData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 2, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "HC5025XZ=" + HC5025XZ + "\r\n" + "HC5025CLZ=" + HC5025CLZ + "\r\n" + "HC5025PDJG=" + HC5025PDJG + "\r\n" + "CO5025XZ=" + CO5025XZ + "\r\n" + "CO5025CLZ=" + CO5025CLZ + "\r\n"
                + "CO5025PDJG=" + CO5025PDJG + "\r\n" + "NO5025XZ=" + NO5025XZ + "\r\n" + "NO5025CLZ=" + NO5025CLZ + "\r\n" + "NO5025PDJG=" + NO5025PDJG + "\r\n" + "FDJZS5025=" + FDJZS5025 + "\r\n"
                + "FDJYW5025=" + FDJYW5025 + "\r\n" + "HC2540XZ=" + HC2540XZ + "\r\n" + "HC2540CLZ=" + HC2540CLZ + "\r\n" + "HC2540PDJG=" + HC2540PDJG + "\r\n" + "CO2540XZ=" + CO2540XZ + "\r\n"
                + "CO2540CLZ=" + CO2540CLZ + "\r\n" + "CO2540PDJG=" + CO2540PDJG + "\r\n" + "NO2540XZ=" + NO2540XZ + "\r\n" + "NO2540CLZ=" + NO2540CLZ + "\r\n" + "NO2540PDJG=" + NO2540PDJG + "\r\n"
                + "FDJZS2540=" + FDJZS2540 + "\r\n" + "FDJYW2540=" + FDJYW2540 + "\r\n" + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n" + "SynchDate=" + SynchDate + "\r\n"
                + "YW=" + YW + "\r\n" + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n" + "5025KSTG=" + KSTG5025 + "\r\n" + "2540KSTG=" + KSTG2540 + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 2, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "HC5025XZ=" + HC5025XZ + "\r\n" + "HC5025CLZ=" + HC5025CLZ + "\r\n" + "HC5025PDJG=" + HC5025PDJG + "\r\n" + "CO5025XZ=" + CO5025XZ + "\r\n" + "CO5025CLZ=" + CO5025CLZ + "\r\n"
                + "CO5025PDJG=" + CO5025PDJG + "\r\n" + "NO5025XZ=" + NO5025XZ + "\r\n" + "NO5025CLZ=" + NO5025CLZ + "\r\n" + "NO5025PDJG=" + NO5025PDJG + "\r\n" + "FDJZS5025=" + FDJZS5025 + "\r\n"
                + "FDJYW5025=" + FDJYW5025 + "\r\n" + "HC2540XZ=" + HC2540XZ + "\r\n" + "HC2540CLZ=" + HC2540CLZ + "\r\n" + "HC2540PDJG=" + HC2540PDJG + "\r\n" + "CO2540XZ=" + CO2540XZ + "\r\n"
                + "CO2540CLZ=" + CO2540CLZ + "\r\n" + "CO2540PDJG=" + CO2540PDJG + "\r\n" + "NO2540XZ=" + NO2540XZ + "\r\n" + "NO2540CLZ=" + NO2540CLZ + "\r\n" + "NO2540PDJG=" + NO2540PDJG + "\r\n"
                + "FDJZS2540=" + FDJZS2540 + "\r\n" + "FDJYW2540=" + FDJYW2540 + "\r\n" + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n" + "SynchDate=" + SynchDate + "\r\n"
                + "YW=" + YW + "\r\n" + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n" + "5025KSTG=" + KSTG5025 + "\r\n" + "2540KSTG=" + KSTG2540 + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class vmasProcessData
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
        public string LLJO2;
        public string LLJSJLL;
        public string LLJBZLL;
        public string QCWQLL;
        public string XSB;
        public string LLJWD;
        public string LLJQY;
        public string HCPFZL;
        public string NOPFZL;
        public string COPFZL;
        public string XSXZXS;	//稀释修正系数
        public string SDXZXS;	//湿度修正系数
        public string JSGL;//寄生功率（KW）
        public string ZSGL;	//指示功率（KW）
        public string HJWD;//环境温度（℃）
        public string DQYL;	//大气压力（Kpa）
        public string XDSD;		//相对湿度（%）
        public string YW;	//油温（℃）
        public string JCZT;
        public string writevmasProcessData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 10,
                "JCBGBH=" + JCBGBH + "\r\n" +
                "DJCCY=" + DJCCY + "\r\n" +
                "SJXL=" + SJXL + "\r\n" +
                "HCCLZ=" + HCCLZ + "\r\n" +
                "NOCLZ=" + NOCLZ + "\r\n" +
                "COCLZ=" + COCLZ + "\r\n" +
                "CO2CLZ=" + CO2CLZ + "\r\n" +
                "O2CLZ=" + O2CLZ + "\r\n" +
                "CS=" + CS + "\r\n" +
                "ZS=" + ZS + "\r\n" +
                "LLJO2=" + LLJO2 + "\r\n" +
                "LLJSJLL=" + LLJSJLL + "\r\n" +
                "LLJBZLL=" + LLJBZLL + "\r\n" +
                "QCWQLL=" + QCWQLL + "\r\n" +
                "XSB=" + XSB + "\r\n" +
                "LLJWD=" + LLJWD + "\r\n" +
                "LLJQY=" + LLJQY + "\r\n" +
                "HCPFZL=" + HCPFZL + "\r\n" +
                "NOPFZL=" + NOPFZL + "\r\n" +
                "COPFZL=" + COPFZL + "\r\n" +
                "XSXZXS=" + XSXZXS + "\r\n" +
                "SDXZXS=" + SDXZXS + "\r\n" +
                "JSGL=" + JSGL + "\r\n" +
                "ZSGL=" + ZSGL + "\r\n" +
                "HJWD=" + HJWD + "\r\n" +
                "DQYL=" + DQYL + "\r\n" +
                "XDSD=" + XDSD + "\r\n" +
                "YW=" + YW + "\r\n" +
                "JCZT=" + JCZT + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 10,
                "JCBGBH=" + JCBGBH + "\r\n" +
                "DJCCY=" + DJCCY + "\r\n" +
                "SJXL=" + SJXL + "\r\n" +
                "HCCLZ=" + HCCLZ + "\r\n" +
                "NOCLZ=" + NOCLZ + "\r\n" +
                "COCLZ=" + COCLZ + "\r\n" +
                "CO2CLZ=" + CO2CLZ + "\r\n" +
                "O2CLZ=" + O2CLZ + "\r\n" +
                "CS=" + CS + "\r\n" +
                "ZS=" + ZS + "\r\n" +
                "LLJO2=" + LLJO2 + "\r\n" +
                "LLJSJLL=" + LLJSJLL + "\r\n" +
                "LLJBZLL=" + LLJBZLL + "\r\n" +
                "QCWQLL=" + QCWQLL + "\r\n" +
                "XSB=" + XSB + "\r\n" +
                "LLJWD=" + LLJWD + "\r\n" +
                "LLJQY=" + LLJQY + "\r\n" +
                "HCPFZL=" + HCPFZL + "\r\n" +
                "NOPFZL=" + NOPFZL + "\r\n" +
                "COPFZL=" + COPFZL + "\r\n" +
                "XSXZXS=" + XSXZXS + "\r\n" +
                "SDXZXS=" + SDXZXS + "\r\n" +
                "JSGL=" + JSGL + "\r\n" +
                "ZSGL=" + ZSGL + "\r\n" +
                "HJWD=" + HJWD + "\r\n" +
                "DQYL=" + DQYL + "\r\n" +
                "XDSD=" + XDSD + "\r\n" +
                "YW=" + YW + "\r\n" +
                "JCZT=" + JCZT + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class VMASresultData
    {
        public string JCBGBH;//检测报告编号（关联对应检测车辆注册信息）
        public string WD;	//温度（℃）
        public string DQY;	//大气压(Kpa)
        public string XDSD;	//相对湿度(%)
        public string COXZ;//HC5025限值
        public string COCZL;	//HC5025测量值
        public string COPDJG;	//HC5025判定结果（合格/不合格）
        public string HCXZ;	//CO5025限值
        public string HCCLZ;	//CO5025测量值
        public string HCPDJG;	//CO5025判定结果（合格/不合格）
        public string NOXZ;	//NO5025限值
        public string NOCLZ;	//NO5025测量值
        public string NOPDJG;	//NO5025判定结果（合格/不合格）
        public string HCNOXZ;	//5025发动机转速(r/min)
        public string HCNOCLZ;	//5025油温（℃）；可取5025检测过程中过程数据油温的平均值
        public string HCNOPDJG;	//HC2540限值
        public string PDJG;	//判定结果（合格/不合格）
        public string SHY;	//审核员
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string CSLJCCSJ;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string YW;	//油温（℃）；可取对应过程数据油温的平均值
        public string JCKSSJ;	//检测开始时间
        public string JCJSSJ;	//检测结束时间
        public string XSLC;	//检测开始时间
        public string CGJSDGL;//测功机设定功率(辽宁协议新增)
        public string writeVMASresultData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 1,
                "JCBGBH=" + JCBGBH + "\r\n" +
                "WD=" + WD + "\r\n" +
                "DQY=" + DQY + "\r\n" +
                "XDSD=" + XDSD + "\r\n" +
                "COXZ=" + COXZ + "\r\n" +
                "COCZL=" + COCZL + "\r\n" +
                "COPDJG=" + COPDJG + "\r\n" +
                "HCXZ=" + HCXZ + "\r\n" +
                "HCCLZ=" + HCCLZ + "\r\n" +
                "HCPDJG=" + HCPDJG + "\r\n" +
                "NOXZ=" + NOXZ + "\r\n" +
                "NOCLZ=" + NOCLZ + "\r\n" +
                "NOPDJG=" + NOPDJG + "\r\n" +
                "HCNOXZ=" + HCNOXZ + "\r\n" +
                "HCNOCLZ=" + HCNOCLZ + "\r\n" +
                "HCNOPDJG=" + HCNOPDJG + "\r\n" +
                "PDJG=" + PDJG + "\r\n" +
                "SHY=" + SHY + "\r\n" +
                "SynchDate=" + SynchDate + "\r\n" +
                "CSLJCCSJ=" + CSLJCCSJ + "\r\n" +
                "YW=" + YW + "\r\n" +
                "JCKSSJ=" + JCKSSJ + "\r\n" +
                "JCJSSJ=" + JCJSSJ + "\r\n" +
                "CGJSDGL=" + CGJSDGL + "\r\n" +
                "XSLC=" + XSLC + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 1,
                "JCBGBH=" + JCBGBH + "\r\n" +
                "WD=" + WD + "\r\n" +
                "DQY=" + DQY + "\r\n" +
                "XDSD=" + XDSD + "\r\n" +
                "COXZ=" + COXZ + "\r\n" +
                "COCZL=" + COCZL + "\r\n" +
                "COPDJG=" + COPDJG + "\r\n" +
                "HCXZ=" + HCXZ + "\r\n" +
                "HCCLZ=" + HCCLZ + "\r\n" +
                "HCPDJG=" + HCPDJG + "\r\n" +
                "NOXZ=" + NOXZ + "\r\n" +
                "NOCLZ=" + NOCLZ + "\r\n" +
                "NOPDJG=" + NOPDJG + "\r\n" +
                "HCNOXZ=" + HCNOXZ + "\r\n" +
                "HCNOCLZ=" + HCNOCLZ + "\r\n" +
                "HCNOPDJG=" + HCNOPDJG + "\r\n" +
                "PDJG=" + PDJG + "\r\n" +
                "SHY=" + SHY + "\r\n" +
                "SynchDate=" + SynchDate + "\r\n" +
                "CSLJCCSJ=" + CSLJCCSJ + "\r\n" +
                "YW=" + YW + "\r\n" +
                "JCKSSJ=" + JCKSSJ + "\r\n" +
                "JCJSSJ=" + JCJSSJ + "\r\n" +
                "CGJSDGL=" + CGJSDGL + "\r\n" +
                "XSLC=" + XSLC + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class SDSprocessData
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
        public string CO2CLZ;
        public string O2CLZ;
        public string JCZT;
        public string writeSDSprocessData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 13, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "HCCLZ=" + HCCLZ + "\r\n" + "COCLZ=" + COCLZ + "\r\n" + "ZS=" + ZS + "\r\n" + "GLKQXSZ=" + GLKQXSZ + "\r\n" + "GKLX=" + GKLX +
                "\r\n" + "YW=" + YW + "\r\n" + "CO2CLZ=" + CO2CLZ + "\r\n" + "O2CLZ=" + O2CLZ + "\r\n" + "JCZT=" + JCZT + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 13, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "HCCLZ=" + HCCLZ + "\r\n" + "COCLZ=" + COCLZ + "\r\n" + "ZS=" + ZS + "\r\n" + "GLKQXSZ=" + GLKQXSZ + "\r\n" + "GKLX=" + GKLX +
                "\r\n" + "YW=" + YW + "\r\n" + "CO2CLZ=" + CO2CLZ + "\r\n" + "O2CLZ=" + O2CLZ + "\r\n" + "JCZT=" + JCZT + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class SDSresultData
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
        public string JCKSSJ;	//检测开始时间
        public string JCJSSJ;//	检测结束时间
        public string writeSDSresultData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 3, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "GLKQXSZ=" + GLKQXSZ + "\r\n" + "GLKQXSPDJG=" + GLKQXSPDJG + "\r\n" + "DDSCOXZ=" + DDSCOXZ + "\r\n" + "DDSCOZ=" + DDSCOZ + "\r\n" + "DDSCOPDJG=" + DDSCOPDJG + "\r\n"
                + "DDSHCXZ=" + DDSHCXZ + "\r\n" + "DDSHCZ=" + DDSHCZ + "\r\n" + "DDSHCPDJG=" + DDSHCPDJG + "\r\n" + "FDJDSZS=" + FDJDSZS + "\r\n" + "DDSJYWD=" + DDSJYWD + "\r\n"
                + "GDSCOXZ=" + GDSCOXZ + "\r\n" + "GDSCOZ=" + GDSCOZ + "\r\n" + "GDSCOPDJG=" + GDSCOPDJG + "\r\n" + "GDSHCZ=" + GDSHCZ + "\r\n" + "GDSHCXZ=" + GDSHCXZ + "\r\n"
                + "GDSHCPDJG=" + GDSHCPDJG + "\r\n" + "GDSZS=" + GDSZS + "\r\n" + "GDSJYWD=" + GDSJYWD + "\r\n" + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n"
                + "SynchDate=" + SynchDate + "\r\n" + "YW=" + YW + "\r\n" + "GLKQXSSX=" + GLKQXSSX + "\r\n" + "GLKQXSXX=" + GLKQXSXX + "\r\n" + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 3, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "GLKQXSZ=" + GLKQXSZ + "\r\n" + "GLKQXSPDJG=" + GLKQXSPDJG + "\r\n" + "DDSCOXZ=" + DDSCOXZ + "\r\n" + "DDSCOZ=" + DDSCOZ + "\r\n" + "DDSCOPDJG=" + DDSCOPDJG + "\r\n"
                + "DDSHCXZ=" + DDSHCXZ + "\r\n" + "DDSHCZ=" + DDSHCZ + "\r\n" + "DDSHCPDJG=" + DDSHCPDJG + "\r\n" + "FDJDSZS=" + FDJDSZS + "\r\n" + "DDSJYWD=" + DDSJYWD + "\r\n"
                + "GDSCOXZ=" + GDSCOXZ + "\r\n" + "GDSCOZ=" + GDSCOZ + "\r\n" + "GDSCOPDJG=" + GDSCOPDJG + "\r\n" + "GDSHCZ=" + GDSHCZ + "\r\n" + "GDSHCXZ=" + GDSHCXZ + "\r\n"
                + "GDSHCPDJG=" + GDSHCPDJG + "\r\n" + "GDSZS=" + GDSZS + "\r\n" + "GDSJYWD=" + GDSJYWD + "\r\n" + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n"
                + "SynchDate=" + SynchDate + "\r\n" + "YW=" + YW + "\r\n" + "GLKQXSSX=" + GLKQXSSX + "\r\n" + "GLKQXSXX=" + GLKQXSXX + "\r\n" + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class BTGprocessData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string DJCCY;	//第几次采样（1.2.3…..递增）
        public string SJXL;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string YDZDS;	//HC测量值[HC10-6]
        public string FDJDSZS;	//CO测量值[CO10-6]
        public string YW;	//转速（r/min）
        public string JCZT;
        public string writeBTGprocessData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 14, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "YDZDS=" + YDZDS + "\r\n" + "FDJDSZS=" + FDJDSZS + "\r\n" + "YW=" + YW + "\r\n" + "JCZT=" + JCZT + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else if(acNetInf.acArea == acNetInf.ACAREA_v132)
            {
                return "成功";                
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 14, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "YDZDS=" + YDZDS + "\r\n" + "FDJDSZS=" + FDJDSZS + "\r\n" + "YW=" + YW + "\r\n" + "JCZT=" + JCZT + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class BTGresultData
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
        public string JCKSSJ;//	检测开始时间
        public string JCJSSJ;//	检测结束时间
        public string writeBTGresultData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 5, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "FDJDSZS=" + FDJDSZS + "\r\n" + "ZHDSCCSZ=" + ZHDSCCSZ + "\r\n" + "ZHDECCSZ=" + ZHDECCSZ + "\r\n" + "ZHDYCCSZ=" + ZHDYCCSZ + "\r\n" + "PJZ=" + PJZ + "\r\n"
                + "XZ=" + XZ + "\r\n" + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n" + "SynchDate=" + SynchDate + "\r\n" + "YW=" + YW + "\r\n"
                + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 5, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "FDJDSZS=" + FDJDSZS + "\r\n" + "ZHDSCCSZ=" + ZHDSCCSZ + "\r\n" + "ZHDECCSZ=" + ZHDECCSZ + "\r\n" + "ZHDYCCSZ=" + ZHDYCCSZ + "\r\n" + "PJZ=" + PJZ + "\r\n"
                + "XZ=" + XZ + "\r\n" + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n" + "SynchDate=" + SynchDate + "\r\n" + "YW=" + YW + "\r\n"
                + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class JZJSprocessData
    {
        public string JCBGBH;	//检测报告编码，对应检测方法中的JCBGBH
        public string DJCCY;	//第几次采样（1.2.3…..递增）
        public string SJXL;	//时间序列（从检测开始到结束，以秒为单位的相对时间，如：SJXL=10表示从检测开始第10秒的过程数据）
        public string GXSXS;
        public string BTGD;
        public string ZSGL;
        public string CS;
        public string ZS;
        public string HJWD;
        public string DQYL;
        public string XDSD;
        public string YW;	//转速（r/min）
        public string GLXZXS;
        public string JSGL;
        public string JCZT;
        public string writeJZJSprocessData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 12, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "GXSXS=" + GXSXS + "\r\n" + "BTGD=" + BTGD + "\r\n" + "ZSGL=" + ZSGL + "\r\n" + "CS=" + CS + "\r\n"
                + "ZS=" + ZS + "\r\n" + "HJWD=" + HJWD + "\r\n" + "DQYL=" + DQYL + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "YW=" + YW + "\r\n" + "GLXZXS=" + GLXZXS + "\r\n" + "JSGL=" + JSGL + "\r\n" + "JCZT=" + JCZT + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 12, "JCBGBH=" + JCBGBH + "\r\n" + "DJCCY=" + DJCCY + "\r\n" + "SJXL=" + SJXL + "\r\n"
                + "GXSXS=" + GXSXS + "\r\n" + "BTGD=" + BTGD + "\r\n" + "ZSGL=" + ZSGL + "\r\n" + "CS=" + CS + "\r\n"
                + "ZS=" + ZS + "\r\n" + "HJWD=" + HJWD + "\r\n" + "DQYL=" + DQYL + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "YW=" + YW + "\r\n" + "GLXZXS=" + GLXZXS + "\r\n" + "JSGL=" + JSGL + "\r\n" + "JCZT=" + JCZT + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class JZJSresultData
    {
        public string JCBGBH;// = 150101010141308010001	//检测报告编号（关联对应检测车辆注册信息）
        public string WD;// = 14.2	//温度（℃）
        public string DQY;// = 101.7	//大气压(Kpa)
        public string XDSD;// = 65	//相对湿度(%)
        public string VELMAXHP;// = 65	//VELMAXHP   单位(km/h)
        public string VELMAXHPZS;// = 3521	//VELMAXHPZS 单位(r/min)
        public string ZDLBGL;// = 54.3	//最大轮边功率   kw
        public string ZDLBGLXZ;// = 48	//最大轮边功率限值
        public string ZDLBGLPDJG;//= 合格	//最大轮边功率判定结果
        public string VELMAXHPYDZ100;//=1.23	//100%VELMAXHP烟度值
        public string VELMAXHPYDZ90;//=1.43	//90%VELMAXHP烟度值
        public string VELMAXHPYDZ80;//=1.31	//80%VELMAXHP烟度值
        public string YDXZ;// = 1.39	//烟度限值
        public string YDPDJG;// = 合格	//烟度判定结果
        public string PDJG;// = 合格	//判定结果（合格/不合格）
        public string SHY;// = 张晓明	//审核员
        public string SynchDate;// = 2008 - 01 - 21 18:18:18.888	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string YW;// = 88	//油温；取对应过程数据油温的平均值（℃）
        public string FDJEDZSSX;//= 100	发动机额定转速上限
        public string FDJEDZSXX;// = 50    发动机额定转速下限
        public string JCKSSJ;// = 2008 - 01 - 21 18:18:18.888	检测开始时间
        public string JCJSSJ;// = 2008 - 01 - 21 18:18:18.888	检测结束时间

        public string writeJZJSresultData()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('D', 4, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "VELMAXHP=" + VELMAXHP + "\r\n" + "VELMAXHPZS=" + VELMAXHPZS + "\r\n" + "ZDLBGL=" + ZDLBGL + "\r\n" + "ZDLBGLXZ=" + ZDLBGLXZ + "\r\n" + "ZDLBGLPDJG=" + ZDLBGLPDJG + "\r\n"
                + "100VELMAXHPYDZ=" + VELMAXHPYDZ100 + "\r\n" + "90VELMAXHPYDZ=" + VELMAXHPYDZ90 + "\r\n" + "80VELMAXHPYDZ=" + VELMAXHPYDZ80 + "\r\n" + "YDXZ=" + YDXZ + "\r\n" + "YDPDJG=" + YDPDJG + "\r\n"
                + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n" + "SynchDate=" + SynchDate + "\r\n" + "YW=" + YW + "\r\n" + "FDJEDZSSX=" + FDJEDZSSX + "\r\n" + "FDJEDZSXX=" + FDJEDZSXX + "\r\n"
                + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('D', 4, "JCBGBH=" + JCBGBH + "\r\n" + "WD=" + WD + "\r\n" + "DQY=" + DQY + "\r\n" + "XDSD=" + XDSD + "\r\n"
                + "VELMAXHP=" + VELMAXHP + "\r\n" + "VELMAXHPZS=" + VELMAXHPZS + "\r\n" + "ZDLBGL=" + ZDLBGL + "\r\n" + "ZDLBGLXZ=" + ZDLBGLXZ + "\r\n" + "ZDLBGLPDJG=" + ZDLBGLPDJG + "\r\n"
                + "100VELMAXHPYDZ=" + VELMAXHPYDZ100 + "\r\n" + "90VELMAXHPYDZ=" + VELMAXHPYDZ90 + "\r\n" + "80VELMAXHPYDZ=" + VELMAXHPYDZ80 + "\r\n" + "YDXZ=" + YDXZ + "\r\n" + "YDPDJG=" + YDPDJG + "\r\n"
                + "PDJG=" + PDJG + "\r\n" + "SHY=" + SHY + "\r\n" + "SynchDate=" + SynchDate + "\r\n" + "YW=" + YW + "\r\n" + "FDJEDZSSX=" + FDJEDZSSX + "\r\n" + "FDJEDZSXX=" + FDJEDZSXX + "\r\n"
                + "JCKSSJ=" + JCKSSJ + "\r\n" + "JCJSSJ=" + JCJSSJ + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class demarcateStart
    {
        public string JCGWH;	//检测工位号
        public string SBBH;	// 设备编号,1：车速标定，2：扭力标定，3：寄生功率，4：加载滑行，5：废气仪标定，6：烟度计标定
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;		//标定设备型号
        public string SJXL;	//时间序列（从标定开始到结束，以秒为单位的相对时间）
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分1秒888毫秒精确到毫秒)
        public string writeDemarcateStart()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('S', (int)'C', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('S', (int)'C', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class demarcateStop
    {
        public string JCGWH;	//检测工位号
        public string SBBH;	// 设备编号,1：车速标定，2：扭力标定，3：寄生功率，4：加载滑行，5：废气仪标定，6：烟度计标定
        public string BDSBMC;	//标定设备名称
        public string BDSBXH;		//标定设备型号
        public string SJXL;	//时间序列（从标定开始到结束，以秒为单位的相对时间）
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分1秒888毫秒精确到毫秒)
        public string writeDemarcateStop()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('S', (int)'J', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('S', (int)'J', "JCGWH=" + JCGWH + "\r\n" + "SBBH=" + SBBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n"
                + "BDSBXH=" + BDSBXH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class speedDemarcate
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeSpeeddemarcate()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('B', 1, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "SDZ1=" + SDZ1 + "\r\n" + "SCZ1=" + SCZ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "SDZ2=" + SDZ2 + "\r\n" + "SCZ2=" + SCZ2 + "\r\n"
                + "PC2=" + PC2 + "\r\n" + "SDZ3=" + SDZ3 + "\r\n" + "SCZ3=" + SCZ3 + "\r\n" + "PC3=" + PC3 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('B', 1, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "SDZ1=" + SDZ1 + "\r\n" + "SCZ1=" + SCZ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "SDZ2=" + SDZ2 + "\r\n" + "SCZ2=" + SCZ2 + "\r\n"
                + "PC2=" + PC2 + "\r\n" + "SDZ3=" + SDZ3 + "\r\n" + "SCZ3=" + SCZ3 + "\r\n" + "PC3=" + PC3 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class forceDemarcate
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeForcedemarcate()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('B', 2, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "SDZ1=" + SDZ1 + "\r\n" + "SCZ1=" + SCZ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "SDZ2=" + SDZ2 + "\r\n" + "SCZ2=" + SCZ2 + "\r\n"
                + "PC2=" + PC2 + "\r\n" + "SDZ3=" + SDZ3 + "\r\n" + "SCZ3=" + SCZ3 + "\r\n" + "PC3=" + PC3 + "\r\n" + "SDZ4=" + SDZ4 + "\r\n"
                + "SCZ4=" + SCZ4 + "\r\n" + "PC4=" + PC4 + "\r\n" + "SDZ5=" + SDZ5 + "\r\n" + "SCZ5=" + SCZ5 + "\r\n" + "PC5=" + PC5 + "\r\n"
                + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('B', 2, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "SDZ1=" + SDZ1 + "\r\n" + "SCZ1=" + SCZ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "SDZ2=" + SDZ2 + "\r\n" + "SCZ2=" + SCZ2 + "\r\n"
                + "PC2=" + PC2 + "\r\n" + "SDZ3=" + SDZ3 + "\r\n" + "SCZ3=" + SCZ3 + "\r\n" + "PC3=" + PC3 + "\r\n" + "SDZ4=" + SDZ4 + "\r\n"
                + "SCZ4=" + SCZ4 + "\r\n" + "PC4=" + PC4 + "\r\n" + "SDZ5=" + SDZ5 + "\r\n" + "SCZ5=" + SCZ5 + "\r\n" + "PC5=" + PC5 + "\r\n"
                + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class JSGLdemarcate
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeJSGLdemarcate()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('B', 3, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "CS1=" + CS1 + "\r\n" + "HXSJ1=" + HXSJ1 + "\r\n" + "JSGL1=" + JSGL1 + "\r\n" + "CS2=" + CS2 + "\r\n" + "HXSJ2=" + HXSJ2 + "\r\n"
                + "JSGL2=" + JSGL2 + "\r\n" + "CS3=" + CS3 + "\r\n" + "HXSJ3=" + HXSJ3 + "\r\n" + "JSGL3=" + JSGL3 + "\r\n" + "CS4=" + CS4 + "\r\n"
                + "HXSJ4=" + HXSJ4 + "\r\n" + "JSGL4=" + JSGL4 + "\r\n" + "CS5=" + CS5 + "\r\n" + "HXSJ5=" + HXSJ5 + "\r\n" + "JSGL5=" + JSGL5 + "\r\n"
                + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('B', 3, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "CS1=" + CS1 + "\r\n" + "HXSJ1=" + HXSJ1 + "\r\n" + "JSGL1=" + JSGL1 + "\r\n" + "CS2=" + CS2 + "\r\n" + "HXSJ2=" + HXSJ2 + "\r\n"
                + "JSGL2=" + JSGL2 + "\r\n" + "CS3=" + CS3 + "\r\n" + "HXSJ3=" + HXSJ3 + "\r\n" + "JSGL3=" + JSGL3 + "\r\n" + "CS4=" + CS4 + "\r\n"
                + "HXSJ4=" + HXSJ4 + "\r\n" + "JSGL4=" + JSGL4 + "\r\n" + "CS5=" + CS5 + "\r\n" + "HXSJ5=" + HXSJ5 + "\r\n" + "JSGL5=" + JSGL5 + "\r\n"
                + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class JZHXdemarcate
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeJZHXdemarcate()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('B', 4, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "CS1=" + CS1 + "\r\n" + "JZGL1=" + JZGL1 + "\r\n" + "JSGL1=" + JSGL1 + "\r\n" + "LLHXSJ1=" + LLHXSJ1 + "\r\n"
                + "SJHXSJ1=" + SJHXSJ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "CS2=" + CS2 + "\r\n" + "JZGL2=" + JZGL2 + "\r\n" + "JSGL2=" + JSGL2 + "\r\n"
                + "LLHXSJ2=" + LLHXSJ2 + "\r\n" + "SJHXSJ2=" + SJHXSJ2 + "\r\n" + "PC2=" + PC2 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('B', 4, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n"
                + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n"
                + "CS1=" + CS1 + "\r\n" + "JZGL1=" + JZGL1 + "\r\n" + "JSGL1=" + JSGL1 + "\r\n" + "LLHXSJ1=" + LLHXSJ1 + "\r\n"
                + "SJHXSJ1=" + SJHXSJ1 + "\r\n" + "PC1=" + PC1 + "\r\n" + "CS2=" + CS2 + "\r\n" + "JZGL2=" + JZGL2 + "\r\n" + "JSGL2=" + JSGL2 + "\r\n"
                + "LLHXSJ2=" + LLHXSJ2 + "\r\n" + "SJHXSJ2=" + SJHXSJ2 + "\r\n" + "PC2=" + PC2 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class FQYdemarcate
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeFqydemarcate()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('B', 5, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n" + "JCZBH=" + JCZBH + "\r\n"
                + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n" + "HCSDZ1=" + HCSDZ1 + "\r\n"
                + "HCSCZ1=" + HCSCZ1 + "\r\n" + "HCPC1=" + HCPC1 + "\r\n" + "COSDZ1=" + COSDZ1 + "\r\n" + "COSCZ1=" + COSCZ1 + "\r\n" + "COPC1=" + COPC1 + "\r\n"
                + "CO2SDZ1=" + CO2SDZ1 + "\r\n" + "CO2SCZ1=" + CO2SCZ1 + "\r\n" + "CO2PC1=" + CO2PC1 + "\r\n" + "NOSDZ1=" + NOSDZ1 + "\r\n" + "NOSCZ1=" + NOSCZ1 + "\r\n"
                + "NOPC1=" + NOPC1 + "\r\n" + "HCSDZ2=" + HCSDZ2 + "\r\n" + "HCSCZ2=" + HCSCZ2 + "\r\n" + "HCPC2=" + HCPC2 + "\r\n" + "COSDZ2=" + COSDZ2 + "\r\n"
                + "COSCZ2=" + COSCZ2 + "\r\n" + "COPC2=" + COPC2 + "\r\n" + "CO2SDZ2=" + CO2SDZ2 + "\r\n" + "CO2SCZ2=" + CO2SCZ2 + "\r\n" + "CO2PC2=" + CO2PC2 + "\r\n"
                + "NOSDZ2=" + NOSDZ2 + "\r\n" + "NOSCZ2=" + NOSCZ2 + "\r\n" + "NOPC2=" + NOPC2 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('B', 5, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n" + "SBXH=" + SBXH + "\r\n" + "JCZBH=" + JCZBH + "\r\n"
                + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n" + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n" + "HCSDZ1=" + HCSDZ1 + "\r\n"
                + "HCSCZ1=" + HCSCZ1 + "\r\n" + "HCPC1=" + HCPC1 + "\r\n" + "COSDZ1=" + COSDZ1 + "\r\n" + "COSCZ1=" + COSCZ1 + "\r\n" + "COPC1=" + COPC1 + "\r\n"
                + "CO2SDZ1=" + CO2SDZ1 + "\r\n" + "CO2SCZ1=" + CO2SCZ1 + "\r\n" + "CO2PC1=" + CO2PC1 + "\r\n" + "NOSDZ1=" + NOSDZ1 + "\r\n" + "NOSCZ1=" + NOSCZ1 + "\r\n"
                + "NOPC1=" + NOPC1 + "\r\n" + "HCSDZ2=" + HCSDZ2 + "\r\n" + "HCSCZ2=" + HCSCZ2 + "\r\n" + "HCPC2=" + HCPC2 + "\r\n" + "COSDZ2=" + COSDZ2 + "\r\n"
                + "COSCZ2=" + COSCZ2 + "\r\n" + "COPC2=" + COPC2 + "\r\n" + "CO2SDZ2=" + CO2SDZ2 + "\r\n" + "CO2SCZ2=" + CO2SCZ2 + "\r\n" + "CO2PC2=" + CO2PC2 + "\r\n"
                + "NOSDZ2=" + NOSDZ2 + "\r\n" + "NOSCZ2=" + NOSCZ2 + "\r\n" + "NOPC2=" + NOPC2 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }
    public class YDJdemarcate
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
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeYdjdemarcate()
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('B', 6, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n"
                + "SBXH=" + SBXH + "\r\n" + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n"
                + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n" + "BTGSDZ1=" + BTGSDZ1 + "\r\n" + "BTGSCZ1=" + BTGSCZ1 + "\r\n"
                + "BTGPC1=" + BTGPC1 + "\r\n" + "GXSSSDZ1=" + GXSSSDZ1 + "\r\n" + "GXSSSCZ1=" + GXSSSCZ1 + "\r\n"
                + "GXSSPC1=" + GXSSPC1 + "\r\n" + "BTGSDZ2=" + BTGSDZ2 + "\r\n" + "BTGSCZ2=" + BTGSCZ2 + "\r\n"
                + "BTGPC2=" + BTGPC2 + "\r\n" + "GXSSSDZ2=" + GXSSSDZ2 + "\r\n" + "GXSSSCZ2=" + GXSSSCZ2 + "\r\n"
                + "GXSSPC2=" + GXSSPC2 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('B', 6, "JCGWH=" + JCGWH + "\r\n" + "SBMC=" + SBMC + "\r\n"
                + "SBXH=" + SBXH + "\r\n" + "JCZBH=" + JCZBH + "\r\n" + "BDSBMC=" + BDSBMC + "\r\n" + "BDSBXH=" + BDSBXH + "\r\n"
                + "Date=" + Date + "\r\n" + "BDDS=" + BDDS + "\r\n" + "BTGSDZ1=" + BTGSDZ1 + "\r\n" + "BTGSCZ1=" + BTGSCZ1 + "\r\n"
                + "BTGPC1=" + BTGPC1 + "\r\n" + "GXSSSDZ1=" + GXSSSDZ1 + "\r\n" + "GXSSSCZ1=" + GXSSSCZ1 + "\r\n"
                + "GXSSPC1=" + GXSSPC1 + "\r\n" + "BTGSDZ2=" + BTGSDZ2 + "\r\n" + "BTGSCZ2=" + BTGSCZ2 + "\r\n"
                + "BTGPC2=" + BTGPC2 + "\r\n" + "GXSSSDZ2=" + GXSSSDZ2 + "\r\n" + "GXSSSCZ2=" + GXSSSCZ2 + "\r\n"
                + "GXSSPC2=" + GXSSPC2 + "\r\n" + "BDJG=" + BDJG + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];
                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
    }

    public class equipmentStatus
    {
        char[] statusString = { 'H', 'W', 'L', 'D', 'T', 'Z', 'I', 'A', 'U', 'P', 'F', 'C', 'V', 'L', 'E', 'J' };
        public enum EQUIPMENTSTATUS : byte { YURE = 0, KONGXIAN = 1, DAOWEI = 2, XIAJIANG = 3, JIANCEZHONG = 4, JIEZHUANSU = 5, CHATANTOU = 6, JIASU = 7, JUSHENG = 8, GUOCHE = 9, JIANCESHIBAI = 10, BIAODING = 11, ZIJIAN = 12, SUOZHI = 13, GUZHANG = 14, BIAODINGJIESHU = 15 };
        public string JCBGBH;//检测报告编码，对应检测方法中的JCBGBH
        public string JCGWH;	//检测工位号 
        public string SJXL;//时间序列（从检测开始到结束，以秒为单位的相对时间，如：nType =I，SJXL=100表示从检测开始第100秒的状态为插探头）
        public string SynchDate;	//发送时间(表示：2008年1月21日18点18分18秒888毫秒精确到毫秒)
        public string writeEquipmentStatus(char equipstatus)
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('S', equipstatus, "JCBGBH=" + JCBGBH + "\r\n" + "JCGWH=" + JCGWH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n"))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('S', equipstatus, "JCBGBH=" + JCBGBH + "\r\n" + "JCGWH=" + JCGWH + "\r\n" + "SJXL=" + SJXL + "\r\n" + "SynchDate=" + SynchDate + "\r\n");
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];

                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }
        public string writeEquipmentStatus(char equipstatus,string info)
        {
            string ackstring;
            string CODE;
            string MESSAGE;
            if (acNetInf.acArea == acNetInf.acArea_NN)
            {
                if (SocketControlNn.SendToServerEx('S', equipstatus, info))
                {
                    return "成功";
                }
                else
                {
                    return "发送失败";
                }
            }
            else
            {
                ackstring = SocketControl.SendToServerEx('S', equipstatus, info);
                if (ackstring.Contains("<"))
                {
                    return "成功";
                }
                else
                {
                    CODE = ackstring.Replace("\r\n", ";").Split(';')[0].Split('=')[1];
                    MESSAGE = ackstring.Replace("\r\n", ";").Split(';')[1].Split('=')[1];

                    switch (CODE)
                    {
                        case "0": return "成功"; break;
                        case "1": return CODE + ":" + MESSAGE; break;
                        case "-1": return CODE + ":" + MESSAGE; break;
                        default: return "发送失败"; break;
                    }
                }
            }
        }

    }
}
