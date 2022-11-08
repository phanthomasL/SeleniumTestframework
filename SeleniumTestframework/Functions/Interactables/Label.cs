﻿using OpenQA.Selenium.Internal;
using SeleniumTestframework.Functions.Interactables;
using SeleniumWebtestFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebtestFramework.Func.Interactables
{
    public class Label : IInteractables
    {
        public string Xpath { get; set; }

       public Label()
        {
            Xpath = "//ion-label";
        }
    }
}
