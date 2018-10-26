using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APITester.Models;
using System.Diagnostics;
namespace APITester.APIUtilities
{
    public class APIUtils : IAPIUtils
    {
        //method for performing the test.
        public async Task<APIVMod> testAPI(APIVMod apiDat)
        {
            List<string> tresults = new List<string>();
            List<long> elapsedTimes = new List<long>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < apiDat.testNum; i += apiDat.conNum)
            {
                
                List<Task<HttpResponseMessage>> calls = new List<Task<HttpResponseMessage>>();
                for (int d = 0; d < apiDat.conNum; d++)
                {                   
                        try
                        {
                                var client = new HttpClient();
                                StringContent stringContent = new StringContent(apiDat.jsonBody, UnicodeEncoding.UTF8, "application/json");
                            if (apiDat.requestType == "Post")
                            {
                                calls.Add(client.PostAsync(apiDat.apiUrl, stringContent));
                            }else if(apiDat.requestType == "Get")
                            {
                            calls.Add(client.GetAsync(apiDat.apiUrl));
                            }
                        }

                        catch (HttpRequestException ex)
                        {

                        }
                }

                Task.WhenAny(calls).ContinueWith(t => elapsedTimes.Add(stopwatch.ElapsedMilliseconds));
                var results = await Task.WhenAll(calls);
                foreach(var call in results)
                {
                    var test = call.StatusCode;
                    tresults.Add(test.ToString());
                }
                apiDat.finalResponseText = results.LastOrDefault().Content.ReadAsStringAsync().Result;
                apiDat.testData.successCount = tresults.Count(p => p.Contains("OK"));
                if (!(i >= apiDat.testNum))
                {
                    Thread.Sleep(apiDat.testDelay);
                }
            }
            var totalTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            apiDat.timings.elapsedTimes = getTimeDifs(elapsedTimes);
            apiDat.timings.totalTime = totalTime;
            
            
            return apiDat;
        }

        public List<long> getTimeDifs(List<long> times)
        {
            List<long> temp = new List<long>(times);

            for(var i = 1; i < times.Count(); i++)
            {
                temp[i] = times[i] - times[i - 1];
            }
            return temp;
        }

    }
}
