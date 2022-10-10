using OpenQA.Selenium;
using SeleniumTestframework.Functions.Interactables;
using SeleniumWebtestFramework.Base;
using SeleniumWebtestFramework.Func.IFuncs;
using SeleniumWebtestFramework.Func.Interactables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Func.perform
{
    public class BaseFunctions:  BaseTestClazz, IPerform, IProof, IRead
    {
        public Button button = new();
       


        public void Perform(IInteractables interactable, string title, IArea area)
        { 
            Driver!.FindElement(By.XPath(area.ToString() + interactable.Xpath /*+Etwas damit der Titel erkannt wird*/)).Click();
        }

        public void Proof(IInteractables interactble, string beschriftung, string sollWert, IArea Area)
        {
            throw new NotImplementedException();
        }

        public string Read(IInteractables interactble, string beschriftung, IArea Area)
        {
            throw new NotImplementedException();
        }
    }
}
