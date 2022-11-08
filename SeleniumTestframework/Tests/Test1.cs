using SeleniumWebtestFramework.Base;
using SeleniumWebtestFramework.Base.Area;
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
            #region Variablen
            IArea buttonBar1 = new ButtonBarArea("ButtonBar bier");
            #endregion

            Perform(Button,"plus bier", buttonBar1);
            Perform(Button, "minus bier", buttonBar1);
        }
    }
}

