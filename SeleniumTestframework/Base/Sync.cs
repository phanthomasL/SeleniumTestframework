using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Base
{
    internal class Sync
    {
        private const int TIMEOUT = 10;
        public void WaitForAngular(IWebDriver instance)
        {
            try
            {
                WebDriverWait wait = new(instance, TimeSpan.FromSeconds(TIMEOUT));
                    wait.Until(instance => GetAngularState(instance));
            }
            catch (Exception e)
            {
                throw new Exception("Timeout waiting for Page Load Request to complete. " + e);
            }
        }


        private static bool GetAngularState(IWebDriver instance)
        {
#pragma warning disable CS8602 // Dereferenzierung eines möglichen Nullverweises.
            return ((IJavaScriptExecutor)instance).ExecuteAsyncScript(
                        "var callback = arguments[arguments.length - 1];" +
                        "if (document.readyState !== 'complete') {" +
                        "  callback('document not ready');" +
                        "} else {" +
                        "  try {" +
                        "    var testabilities = window.getAllAngularTestabilities();" +
                        "    var count = testabilities.length;" +
                        "    var decrement = function() {" +
                        "      count--;" +
                        "      if (count === 0) {" +
                        "        callback('complete');" +
                        "      }" +
                        "    };" +
                        "    testabilities.forEach(function(testability) {" +
                        "      testability.whenStable(decrement);" +
                        "    });" +
                        "  } catch (err) {" +
                        "    callback(err.message);" +
                        "  }" +
                        "}"
                    ).ToString().Equals("complete");
#pragma warning restore CS8602 // Dereferenzierung eines möglichen Nullverweises.
        }
    }


}
