using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestframework.Base.Driver
{
     public interface IMyWebDriver : IWebDriver
    {
        new IWebElement FindElement(By by);
        new ReadOnlyCollection<IWebElement> FindElements(By by);
    }
}
