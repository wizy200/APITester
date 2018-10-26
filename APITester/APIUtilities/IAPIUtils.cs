using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITester.Models;
namespace APITester.APIUtilities
{
    public interface IAPIUtils
    {
        Task<APIVMod> testAPI(APIVMod apiDat);
    }
}
