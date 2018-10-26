using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APITester.Models;
using APITester.APIUtilities;
using Newtonsoft.Json;

namespace APITester.Controllers
{
    public class HomeController : Controller
    {
        private IAPIUtils _utils;

        public HomeController(IAPIUtils utils)
        {
            _utils = utils;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> startAPITest([FromBody] APIVMod apiDat)
        {

            apiDat = await _utils.testAPI(apiDat);
            //var dict = apiDat.timings.elapsedTimes.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);
            apiDat.timings.jsonTimes = JsonConvert.SerializeObject(apiDat.timings.elapsedTimes);
            return Json(apiDat);
        }
       

    }
}
