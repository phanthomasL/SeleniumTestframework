

using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using SeleniumTestframework.Base.Driver;
using System.Collections.Concurrent;
using System.Drawing;

namespace SeleniumWebtestFramework.Base.WebDriver
{
    public class DriverInstances
    {

        private readonly ConcurrentDictionary<IMyWebDriver, bool> _instances = new();
        private readonly object _locker = new();
        private int Worker { get; set; }
        public string? URL { get; set; }
        public Size BrowserSize { get; set; }
        public string? BrowserName { get; set; }

        public DriverInstances()
        {
            GetConfig();
            StartBrowser();
        }

        private void GetConfig()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

            var url = config["url"];
            if (url.Equals(null) || url.Equals("")) throw new ArgumentNullException("Fehlende Konfiguration der URL");
            this.URL = url;

            var x = config["BrowserSizeX"];
            var y = config["BrowserSizeY"];
            if (x.Equals(null) || y.Equals(null) || x.Equals("") || y.Equals("")) throw new ArgumentNullException("Fehlende Konfiguration der Browsersize");
            BrowserSize = new Size(int.Parse(x), int.Parse(y));

            BrowserName = config["BrowserTyp"];

            Worker = int.Parse(config["NumberOfWorkers"]);

            Console.WriteLine("Konfiguration geladen");
        }

        private void StartBrowser()
        {
            var drivers = new List<Task<IMyWebDriver>>();

            for (int i = 0; i < GetNumberOfWorkerThreads(); i++)
            {
                var tasks = Task.Run(() => InitDriver());
                drivers.Add(tasks);
            }

            Task.WhenAll(drivers).Wait();

            foreach (var driver in drivers)
            {
                lock (this._locker)
                {
                    _instances.TryAdd(driver.Result, false);
                }
            }
        }

        private IMyWebDriver InitDriver()
        {
            IMyWebDriver instance = new MyWebDriver(BrowserName).Driver;
            return instance;
        }

        private int GetNumberOfWorkerThreads()
        {
            return Worker != 0 ? Worker : Environment.ProcessorCount;

        }

        public IMyWebDriver Allocate()
        {
            IMyWebDriver? unusedDriver = null;

            while (unusedDriver == null)
            {
                lock (_locker)
                {
                    foreach (var instance in _instances)
                    {
                        if (!instance.Value)
                        {
                            unusedDriver = instance.Key;
                            break;
                        }
                    }

                    if (unusedDriver != null)
                    {
                        _instances[unusedDriver] = true;
                    }
                }
                Thread.Sleep(200); // no found repeat
            }
            return unusedDriver;
        }
        public void Release(IMyWebDriver driver)
        {
            _instances[driver] = false;
        }

        public void DisposeAll()
        {
            lock (_locker)
            {
                foreach (var instance in _instances)
                {
                    instance.Key.Dispose();
                }
            }
        }

    }
}
