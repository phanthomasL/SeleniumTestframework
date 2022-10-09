using SeleniumWebtestFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Func.IFuncs
{
    internal interface IRead
    {
        public void Read<IInteractablesIInteractables>(string beschriftung, string sollWert, IArea Area);
    }
}
