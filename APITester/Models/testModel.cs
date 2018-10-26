using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class testModel
    {
        public testModel()
        {
            travelTimes = new List<float>();
        }
        public int successCount { get; set; }
        public int failCount { get; set; }
        public List<float> travelTimes { get; set; }
    }
}
