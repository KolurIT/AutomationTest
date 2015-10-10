using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace QAWorks.Vinny
{
    [SetUpFixture]
    public class TestInitializer
    {
        protected static readonly IWebDriver Driver = new FirefoxDriver();

        protected static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["Environment"]; }
        }

        [SetUp]
        public static void SetUp()
        {
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void DriverQuit()
        {
            Driver.Quit();
        }
    
    }
}
