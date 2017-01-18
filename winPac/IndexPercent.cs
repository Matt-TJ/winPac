using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winPac
{
    class IndexPercent
    {
        int percent;
        string perName;
        public IndexPercent()
        {
            this.percent = 0;
            this.perName = "";
        }
        public IndexPercent(string perName,int percent)
        {
            this.perName = perName;
            this.percent = percent;
        }
        public string getPerctString()
        {
            string s = this.perName + "   " + percent.ToString();
            return s;
        }
    }

    public class IndexPercentArgs:EventArgs
    {
        public string indexName;
        public int percent;
        public IndexPercentArgs() { }
        public IndexPercentArgs(string indexName,int percent)
        {
            this.indexName = indexName;
            this.percent = percent;
        }
        
    } 


}
