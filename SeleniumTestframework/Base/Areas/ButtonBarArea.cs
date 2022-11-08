using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SeleniumWebtestFramework.Base.Area
{
   
    internal class ButtonBarArea : IArea
    {
        private readonly string _xpath;

        public ButtonBarArea(string title)
        {
            _xpath = "//ion-list" + $"[@title = '{title}']";
        }
       
        public string Xpath { get { return _xpath; } }
    }
}
