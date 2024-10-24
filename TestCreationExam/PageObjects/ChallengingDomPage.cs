using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.Page;
using System;
using System.Diagnostics;
using TestCreationExam.Common;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class ChallengingDomPage : BasePageLocal
    {
        public ChallengingDomPage(IWebDriver driver) : base(driver)
        {
        }
    }
}