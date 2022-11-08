using OpenQA.Selenium;
using SeleniumTestframework.Functions.Interactables;
using SeleniumWebtestFramework.Base;
using SeleniumWebtestFramework.Func.IFuncs;
using SeleniumWebtestFramework.Func.Interactables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumWebtestFramework.Func.perform
{
    public class BaseFunctions : BaseTestClazz, IPerform, IProof, IRead
    {
        public Button Button;

        public Label Label;

        public Input Input;
        public BaseFunctions() { Button = new(); Label = new(); Input = new(); }

        // Die Funktion sind sehr generisch, natürlich können diese im Interface geändert werden und dadurch eine eigene Domain spezifische Sparache erzeugt werden,
        // die auf die eigene Anwendung abgestimmt ist.
        //click z.B. Button

        /// <summary>
        /// Performing a click on the Element with the specific title in the area
        /// </summary>
        /// <param name="interactable">The Element to interact e.g Button</param>
        /// <param name="title">title of the element</param>
        /// <param name="area">area of the element e.g a card</param>
        /// <exception cref="Exception"></exception>
        public void Perform(IInteractables interactable, string title, IArea area)
        {
            try
            {
                Driver!.FindElement(By.XPath(area.Xpath + interactable.Xpath + $"[@title = '{title}']")).Click();
            }
            catch (Exception ex)
            {
                throw new Exception("Oops, an error occured. " + ex);
            }
        }

        /// <summary>
        /// sending keys to an element e.g input
        /// </summary>
        /// <param name="title">title of the element</param>
        /// <param name="interactable">The Element to interact e.g Button</param>
        /// <param name="text">title of the element</param>
        /// <param name="area">area of the element e.g a card</param>
        /// <exception cref="Exception"></exception>
        public void Perform(IInteractables interactable, string title, string text, IArea area)
        {
            try
            {
                Driver!.FindElement(By.XPath(area.Xpath + interactable.Xpath + $"[@title = '{title}']")).SendKeys(text);
            }
            catch (Exception ex)
            {
                throw new Exception("Oops, an error occured. " + ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interactable"></param>
        /// <param name="title">title of the element</param>
        /// <param name="sollWert"></param>
        /// <param name="area"></param>
        /// <exception cref="Exception"></exception>
        public void Proof(IInteractables interactable, string title, string sollWert, IArea area)
        {
            string text;
            try
            {
                text = Driver!.FindElement(By.XPath(area.Xpath + interactable.Xpath + $"[@title = '{title}']")).Text;
            }
            catch (Exception ex)
            {
                throw new Exception("Oops, an error occured. The Text of the element c " + ex);

            }
            Assert.AreEqual(sollWert, text);

        }
        /// <summary>
        /// read a value
        /// </summary>
        /// <param name="interactable"></param>
        /// <param name="title"></param>
        /// <param name="area"></param>
        /// <returns>value string</returns>
        /// <exception cref="Exception"></exception>
        public string Read(IInteractables interactable, string title, IArea area)
        {
            try
            {
                return Driver!.FindElement(By.XPath(area.Xpath + interactable.Xpath + $"[@title = '{title}']")).Text;
            }
            catch (Exception ex)
            {
                throw new Exception("Oops, an error occured. The Text of the element c " + ex);

            }
        }
    }
}
