using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYS_MODEL
{
    public class 设备自检数据
    {
        public string JCZBH { set; get; }
        public string JCGWH { set; get; }
        public string SBBH { set; get; }
        public string ZJLX { set; get; }
        public DateTime ZJSJ { set; get; }
        public string DATA1 { set; get; }
        public string DATA2 { set; get; }
        public string DATA3 { set; get; }
        public string DATA4 { set; get; }
        public string DATA5 { set; get; }
        public string DATA6 { set; get; }
        public string DATA7 { set; get; }
        public string DATA8 { set; get; }
        public string DATA9 { set; get; }
        public string DATA10 { set; get; }
        public string DATA11 { set; get; }
        public string DATA12 { set; get; }
        public string DATA13 { set; get; }
        public string DATA14 { set; get; }
        public string DATA15 { set; get; }
        public string DATA16 { set; get; }
        public string DATA17 { set; get; }
        public string DATA18 { set; get; }
        public string DATA19 { set; get; }
        public string DATA20 { set; get; }
        public string DATA21 { set; get; }
        public string DATA22 { set; get; }
        public string DATA23 { set; get; }
        public string DATA24 { set; get; }
        public string DATA25 { set; get; }
        public string DATA26 { set; get; }
        public string DATA27 { set; get; }
        public string DATA28 { set; get; }
        public string DATA29 { set; get; }
        public string DATA30 { set; get; }
        public string DATA31 { set; get; }
        public string DATA32 { set; get; }
        public string DATA33 { set; get; }
        public string DATA34 { set; get; }
        public string DATA35 { set; get; }
        public string DATA36 { set; get; }
        public string DATA37 { set; get; }
        public string DATA38 { set; get; }
        public string DATA39 { set; get; }
        public string DATA40 { set; get; }
        public string DATA41 { set; get; }
        public string DATA42 { set; get; }
        public string ZJJG { set; get; }
        public string ZT { set; get; }

    }
    public class 设备标定数据
    {
        public string JCZBH { set; get; }
        public string JCGWH { set; get; }
        public string SBBH { set; get; }
        public string BDLX { set; get; }
        public string BDR { set; get; }
        public DateTime BDSJ { set; get; }
        public string DATA1 { set; get; }
        public string DATA2 { set; get; }
        public string DATA3 { set; get; }
        public string DATA4 { set; get; }
        public string DATA5 { set; get; }
        public string DATA6 { set; get; }
        public string DATA7 { set; get; }
        public string DATA8 { set; get; }
        public string DATA9 { set; get; }
        public string DATA10 { set; get; }
        public string DATA11 { set; get; }
        public string DATA12 { set; get; }
        public string DATA13 { set; get; }
        public string DATA14 { set; get; }
        public string DATA15 { set; get; }
        public string DATA16 { set; get; }
        public string DATA17 { set; get; }
        public string DATA18 { set; get; }
        public string DATA19 { set; get; }
        public string DATA20 { set; get; }
        public string DATA21 { set; get; }
        public string DATA22 { set; get; }
        public string DATA23 { set; get; }
        public string DATA24 { set; get; }
        public string DATA25 { set; get; }
        public string DATA26 { set; get; }
        public string DATA27 { set; get; }
        public string DATA28 { set; get; }
        public string DATA29 { set; get; }
        public string DATA30 { set; get; }
        public string DATA31 { set; get; }
        public string DATA32 { set; get; }
        public string DATA33 { set; get; }
        public string DATA34 { set; get; }
        public string DATA35 { set; get; }
        public string DATA36 { set; get; }
        public string DATA37 { set; get; }
        public string DATA38 { set; get; }
        public string DATA39 { set; get; }
        public string DATA40 { set; get; }
        public string DATA41 { set; get; }
        public string DATA42 { set; get; }
        public string BDJG { set; get; }
        public string ZT { set; get; }

    }
    public class 车辆检测状态
    {
        
        public string JCZBH { set; get; }//检测站编号
        public string LINEID { set; get; }//检测工位号
        public string JYLSH { set; get; }//检验流水号
        public string JYCS { set; get; }//检测次数
        public DateTime JCSJ { set; get; }//检测时间或者是该字段的更新时间
        public string CLHP { set; get; }//车辆号牌
        public string HPZL { set; get; }//号牌种类
        public string ZT { set; get; }//状态，定义如上所示
        public string YCLZT { set; get; }//由后台联网程序写入，已处理状态，定义如上所示
        public string BZ { set; get; }//备注
        public string JCFF { set; get; }
        public string JCCZY { set; get; }
        public string YCY { set; get; }
        public string DLY { set; get; }

    }
}
