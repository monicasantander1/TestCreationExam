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

        /// <summary>
        /// Convert Random number into a string
        /// </summary>
        /// <returns>random number</returns>
        public string SetRandomNumberToString() 
        {
            int randomNumber = Utils.Random.Next(10);
            return randomNumber.ToString();
        }
    }
}