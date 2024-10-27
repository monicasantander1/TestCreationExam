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
        /// Random row and column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>The Row and column element</returns>
        public string GetCell(int row, int column)
        {
            By locator = By.XPath($"//tbody/tr[{row}]/td[{column}]");
            return FindElement(locator).Text;
        }
    }
}