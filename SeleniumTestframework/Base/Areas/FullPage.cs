using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Base.Area
{
    internal class FullPage : IArea
    {
        public FullPage() { _xpath = "//body/app-root"; }
        private readonly string _xpath;
        public string Xpath { get { return _xpath; } }
    }
}
