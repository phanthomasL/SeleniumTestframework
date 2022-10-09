using SeleniumWebtestFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Func.IFuncs
{
    internal interface IPerform<T>
    {
        public void Perform(T obj, string title, IArea Area);
     


    }
}
