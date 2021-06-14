using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;
using TechTalk.SpecFlow.Tracing;
using  System.IO;
using System.Reflection;
using NUnit.Framework;
using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowParallel
{
    public sealed class WebDriverContext
    {
        public IWebDriver webdriver;

        public WebDriverContext()
        {
            webdriver = new ChromeDriver();
        }

    }    
}