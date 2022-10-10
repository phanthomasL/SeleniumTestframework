using SeleniumTestframework.Functions.Interactables;
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
        public string Read(IInteractables interactble, string beschriftung, IArea Area);
    }
}
