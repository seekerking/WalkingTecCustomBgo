using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSys.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectFastBgo.Test
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void TestVersion()
        {
          int a=  "1.1.0".ConvertVersionToInt();
            int b = "1.10.1".ConvertVersionToInt();
            int c = "1.1.1000".ConvertVersionToInt();
            int f = "1.1.100".ConvertVersionToInt();
           Assert.IsTrue(a>b);

        }
    }
}
