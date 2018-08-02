using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYS_DAL
{
    public class time
    {
       
        int i = 0;
        int j = 0;
        int k = 6;
        int l = 0;
        int m = 0;
        int n = 0;
        int o = 0;
        int p = 11;
     
        /// <summary>
        /// 获取工况时间
        /// </summary>
        /// <returns>时间数</returns>
        
        public int getTime1()
        {
            i += 1;
            return i;
        }

        public int getTime2()
        {
            j += 1;
            return j;
        }


    
        public int getTime3()
        {
           
            l += 1;
            return l;
        }
        public int getTime4()
        {

            m += 1;
            return m;
        }
        public int getTime5()
        {

            n += 1;
            return n;
        }
        public int getTime6()
        {

            o += 1;
            return o;
        }
        public int getTimeTo0()
        {
            k -= 1;
            return k;
        }
        public int getTime10To0()
        {
            p -= 1;
            return p;
        }
    }
}
