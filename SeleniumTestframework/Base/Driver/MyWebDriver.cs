using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V105.Target;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumWebtestFramework.Base;
using System.Collections.ObjectModel;


namespace SeleniumTestframework.Base.Driver
{
    public class MyWebDriver 
    {

        public IMyWebDriver GetInstance(string name)
        {
            return new MyWebDriverBase(name).Driver;
        }
       

      
    }
}
