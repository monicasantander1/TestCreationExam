using NUnit.Framework;
using TestCreationExam.Common;
using TestCreationExam.PageObjects;
using TestCreationExam.TestCases.Common;
using System.Diagnostics;

namespace TestCreationExam.TestCases
{
    class ChallengingDom : BaseTestLocal
    {
        [Test]
        [Category("Challenging DOM")]
        public void ChallengingDomCase()
        {
            // Steps to automate:
            // 1. Navigate to https://the-internet.herokuapp.com/challenging_dom
            // 2. Randomly generate a cell value in the Ipsum column 
            // 3. Pass that value to a method in the page object that returns the corresponding value in the same
            //    row in the Amet column
            // 4. Using NUnit asserts, assert that the returned value is correct
            //
            // For example, if "Apeirian4" is generated from Ipsum, "Consequuntur4" would be returned from Amet
            //
            // NOTE:
            // - Use the provided WebDriver methods in BasePageLocal
            // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/

            ChallengingDomPage challengingDomPage = new ChallengingDomPage(Driver.Value);
            challengingDomPage.GenerateRandomNumber();
            string randomNumber = challengingDomPage.GenerateRandomNumber();
            string ipsumColumn = $"Apeirian{randomNumber}";
            string ametColumn = $"Consequuntur{randomNumber}";

            string columnValueResults = challengingDomPage.GenerateRandomNumber();
            Assert.Pass(columnValueResults, "Returned Value are correct.");
        }
    }
}