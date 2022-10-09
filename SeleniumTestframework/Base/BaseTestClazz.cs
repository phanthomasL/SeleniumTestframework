using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebtestFramework.Base.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Base
{


    public class BaseTestClazz
    {

        private static readonly DriverInstances driverInstances = new();
        public IWebDriver? Driver { get; set; }

        [AssemblyCleanup]
        public static void AssemblyClean()
        {
            driverInstances.DisposeAll();
        }

        [TestInitialize]
        public void Init()
        {
            Driver = driverInstances.Allocate();

            if (Driver == null)
            {
                throw new Exception("Es konnte kein Driver allokiert werden!?");
            }
            Console.WriteLine("Teststart: " + DateTime.Now);
        }

        [TestCleanup]
        public void End()
        {
            if (Driver != null)
            {
                Driver.Manage().Cookies.DeleteAllCookies();
                driverInstances.Release(Driver);
            }
        }
    }
}
