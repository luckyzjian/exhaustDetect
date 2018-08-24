using System;
namespace SYS.Model
{
    /// <summary>
    /// ASM:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class selfcheckdata
    {
        public selfcheckdata()
        { }
        public string ID;
        public DateTime WORKTIME;//自检时间
        public string WORKER;//操作员
        public string ISQXZCHECK;//是否检查了气象站(Y,N)
        public string ISFQYCHECK;//是否检查了废气仪(Y,N)
        public string ISBTGCHECK;//是否检查了烟度计(Y,N)
        public string ISCGJCHECK;//是否检查了测功机(Y,N)
        public string ISLLJCHECK;//是否检查了流量计(Y,N)
        public string ISZSJCHECK;//是否检查了转速计(Y,N)
        public string TEMPOK;//温度自检是否通过(Y,N)
        public string HUMIOK;//湿度自检是否通过(Y,N)
        public string AIRPOK;//大气压自检是否通过(Y,N)
        public string TEMP;//环境温度(数字)
        public string HUMI;//相对湿度(数字)
        public string AIRP;//大气压(数字)
        public string FQYTX;//废气仪通讯(Y,N)
        public string FQYYR;//废气仪预热(Y,N)
        public string FQYTL;//废气仪调零(Y,N)
        public string FQYJL;//废气仪检漏(Y,N)
        public string FQYLC;//废气仪量程检查(Y,N)
        public string FQYO2;//废气仪氧气(数字)
        public string BTGTX;//烟度计通讯(Y,N)
        public string BTGYR;//烟度计预热(Y,N)
        public string BTGTL;//烟度计调零(Y,N)
        public string BTGLC;//烟度计量程检查(Y,N)
        public string BTGJZ;//烟度计线性校正(Y,N)
        public string CGJTX;//测功机通讯(Y,N)
        public string CGJYR;//测功机预热(Y,N)
        public string CGJQL;//
        public string CGJJSGL;//测功机寄生 功率是否合格(Y,N)
        public string CGJJZHX;//测功机加载滑行是否合格(Y,N)
        public string CGJEDGL;//测功机加载功率
        public string CGJSJGL;//测功机实际加载功率
        public string CGJGLWC;//测功机功率加载误差
        public string CGJVITRUALTIME;//加载滑行理论时间
        public string CGJREALTIME;//加载滑行实际时间
        public string CGJTIMEWC;//加载滑行时间误差(%)
        public string LLJTX;//流量计通讯检查(Y,N)
        public string LLJLL;//流量计流量(L/s)
        public string ZSJTX;//转速计通讯检查(Y,N)
        public string ZSJLC;//转速计量程检查(Y,N)
        public string HSSlideBeginTime;//加载滑行高区间开始时间
        public string HSSlideEndTime;//加载滑行高区间结束时间
        public string HSSlideTheoreticalTime;//加载滑行高区间理论时间
        public string HSSlideActualTime;//加载滑行高区间实际时间
        public string HSSlideLoadPower;//加载滑行高区间加载功率
        public string LSSlideBeginTime;//加载滑行低区间开始时间
        public string LSSlideEndTime;//加载滑行低区间结束时间
        public string LSSlideTheoreticalTime;//加载滑行低区间理论时间
        public string LSSlideActualTime;//加载滑行低区间实际时间
        public string LSSlideLoadPower;//加载滑行低区间加载功率
        public string WattlessMaxSpeed1;//寄生功率区间1起始速度
        public string WattlessMinSpeed1;//寄生功率区间1结束速度
        public string WattlessNorminalSpeed1;//寄生功率区间1名义速度
        public string WattlessBeginTime1;//寄生功率区间1开始时间
        public string WattlessEndTime1;//寄生功率区间1结束时间
        public string WattlessOutput1;//寄生功率1
        public string WattlessMaxSpeed2;//寄生功率区间2起始速度
        public string WattlessMinSpeed2;//寄生功率区间2结束速度
        public string WattlessNorminalSpeed2;//寄生功率区间2名义速度
        public string WattlessBeginTime2;//寄生功率区间2开始时间
        public string WattlessEndTime2;//寄生功率区间2结束时间
        public string WattlessOutput2;//寄生功率2
        public string WattlessMaxSpeed3;//寄生功率区间3起始速度
        public string WattlessMinSpeed3;//寄生功率区间3结束速度
        public string WattlessNorminalSpeed3;//寄生功率区间3名义速度
        public string WattlessBeginTime3;//寄生功率区间3开始时间
        public string WattlessEndTime3;//寄生功率区间3结束时间
        public string WattlessOutput3;//寄生功率3
        public string WattlessMaxSpeed4;//寄生功率区间4起始速度
        public string WattlessMinSpeed4;//寄生功率区间4结束速度
        public string WattlessNorminalSpeed4;//寄生功率区间4名义速度
        public string WattlessBeginTime4;//寄生功率区间4开始时间
        public string WattlessEndTime4;//寄生功率区间4结束时间
        public string WattlessOutput4;//寄生功率4
        public string O2MRBeginTime;
        public string O2MREndTime;
        public string WQBeginTime;//废气仪检查开始时间
        public string WQEndTime;//废气仪检查结束时间
        public string SlideJudge;//加载滑行是否合格（1：合格，2：不合格)
        public string WattlessJudge;//寄生功率是否合格（1：合格，2：不合格)
        public string O2MRJudge;
        public string WQJudge;
        public string AllJudge;//自检总判定（1:合格，2：不合格）



    }
}

