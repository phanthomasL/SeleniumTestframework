using SeleniumWebtestFramework.Base;
using SeleniumWebtestFramework.Func.IFuncs;
using SeleniumWebtestFramework.Func.Interactables;
using SeleniumWebtestFramework.Func.perform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestframework.Tests
{
    
    [TestClass]
    public class UnitTest1 : BaseFunctions
    {
        [TestMethod]
        public void TestMethod1()
        {
            Perform(button,"", null);
        }
    }
}

