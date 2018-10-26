using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class apiTiming
    {

        public apiTiming()
        {
            elapsedTimes = new List<long>();
        }

        public List<long> elapsedTimes { get; set; }
        public string jsonTimes { get; set; }
        public long totalTime { get; set; }
    }
}
