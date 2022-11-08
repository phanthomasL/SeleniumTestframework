using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Base.Area
{
    internal class CardArea : IArea
    {

        private readonly string _xpath;
        public CardArea(string title) { _xpath = "//ion-card" + $"[@title = '{title}']"; }
        public string Xpath { get { return _xpath; } }
    }
}
