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
        /// Convert a random number into a string.
        /// </summary>
        /// <returns>random number string</returns>
        public string GenerateRandomNumber()
        {
            int randomNumber = Utils.GenerateRandomNumber(1, 11);
            return randomNumber.ToString();
        }
    }
}