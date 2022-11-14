using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumWebtestFramework.Base;
using System.Collections.ObjectModel;


namespace SeleniumTestframework.Base.Driver
{
    public class MyWebDriverBase : IMyWebDriver
    {

        private readonly Sync _sync = new();
        public IMyWebDriver Driver { get; set; }
        public string Url { get => Driver.Url; set => Driver.Url = value; }

        public string Title => Driver.Title;

        public string PageSource => Driver.PageSource;

        public string CurrentWindowHandle => Driver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => Driver.WindowHandles;
        public MyWebDriverBase(string browserType) 
        {
            IMyWebDriver instance = browserType switch
            {
                "Firefox" => new MyFireFoxWebDriver(),
                "Chrome" => new MyChromeWebDriver(),
                "Edge" => new MyEdgeWebDriver(),
                //TODO headless => Extra Case => setOptions
                _ => throw new Exception("Kein valider Browser in den AppSettings"),
            };

            Driver = instance;
        }
     

        public void Close()
        {
            Driver.Close();
        }

        public void Dispose()
        {
            _sync.WaitForAngular(Driver);
            Driver.Dispose();
        }

        public new IWebElement FindElement(By by)
        {
            _sync.WaitForAngular(Driver);
            return Driver.FindElement(by);
        }

        public new ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            _sync.WaitForAngular(Driver);
            return Driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return Driver.Manage();
        }

        public INavigation Navigate()
        {
            _sync.WaitForAngular(Driver);
            return Driver.Navigate();
        }

        public void Quit()
        {
            Driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            _sync.WaitForAngular(Driver);
            return Driver.SwitchTo();
        }

        class MyChromeWebDriver : ChromeDriver, IMyWebDriver
        {
            public MyChromeWebDriver() : base() {}         
        }

        class MyFireFoxWebDriver : FirefoxDriver, IMyWebDriver
        {
            public MyFireFoxWebDriver() : base() { }
        }
        class MyEdgeWebDriver : EdgeDriver, IMyWebDriver
        {
            public MyEdgeWebDriver() : base() { }
        }

      
    }
}
