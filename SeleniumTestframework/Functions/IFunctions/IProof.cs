using SeleniumTestframework.Functions.Interactables;
using SeleniumWebtestFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Func.IFuncs
{
    internal interface IProof
    {
        public void Proof(IInteractables interactble, string beschriftung, string sollWert, IArea Area);
    }
}
