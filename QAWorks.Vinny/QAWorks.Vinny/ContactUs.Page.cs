using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace QAWorks.Vinny
{
    public class ContactUsPage : TestInitializer
    {
        protected static void NavigateToContactUsPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + "/contact.aspx");
        }

        protected static IWebElement NameBox
        {
            get { return Driver.FindElement(By.Id("ctl00_MainContent_NameBox")); }
        }

        protected static IWebElement EmailBox
        {
            get { return Driver.FindElement(By.Id("ctl00_MainContent_EmailBox")); }
        }

        protected static IWebElement MessageBox
        {
           get { return Driver.FindElement(By.Id("ctl00_MainContent_MessageBox"));}
        }

        protected static IWebElement NameValidation
        {
            get { return Driver.FindElement(By.Id("ctl00_MainContent_rfvName")); }
        }

        protected static IWebElement EmailValidation
        {
            get { return Driver.FindElement(By.Id("ctl00_MainContent_revEmailAddress")); }
        }

        protected static IWebElement EmailBoxValidation
        {
            get { return Driver.FindElement(By.Id("ctl00_MainContent_rfvEmailAddress")); }
        }

        public static IWebElement MessageValidation
        {
            get { return Driver.FindElement(By.Id("ctl00_MainContent_rfvMessage")); }
        }

        public static List<IWebElement> ValidationMessages()
        {
            List<IWebElement> list = new List<IWebElement>() { NameValidation, EmailBoxValidation, EmailValidation, MessageValidation };
                return list;
            
        }


        protected static IWebElement SendButton
        {
            get { return Driver.FindElement(By.XPath("//*[@id='ctl00_MainContent_SendButton']")); }
        }



        public class ContactUsForm
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        }
       

    }
}
