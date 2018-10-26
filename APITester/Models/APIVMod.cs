using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class APIVMod
    {
        public APIVMod()
        {
            testData = new testModel();
            timings = new apiTiming();
            this.testDelay = 0;
        }
        //Url to run the test against
        public string apiUrl { get; set; }
        //Number of test to run
        public int testNum { get; set; }
        //delay between consecutive test
        public int testDelay { get; set; }
        //how many to test consecutively
        public int conNum { get; set; }
        //request body for post request
        public string jsonBody { get; set; }
        //result from the server
        public string finalResponseText { get; set; }
        //get or post request
        public string requestType { get; set; }

        public apiTiming timings { get; set;}
        public testModel testData {get; set;}
    }
}
