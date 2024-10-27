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
            Driver.Value.Url = "https://the-internet.herokuapp.com/challenging_dom";
            ChallengingDomPage challengingDomPage = new ChallengingDomPage(Driver.Value);

            int rowNumber = Utils.Random.Next(0, 10);

            string expectedIpsumColumn = $"Apeirian{rowNumber}";
            string expectedAmetColumn = $"Consequuntur{rowNumber}";

            string IpsumColumn = challengingDomPage.GetCell(rowNumber, 2);
            string modifiedIpsumColumn = IpsumColumn.Substring(0, IpsumColumn.Length - 1);
            string actualIpsumColumn = $"{modifiedIpsumColumn}{rowNumber}";
            Assert.AreEqual(expectedIpsumColumn, actualIpsumColumn, "Returned Value are correct.");

            string AmetColumn = challengingDomPage.GetCell(rowNumber, 5);
            string modifiedAmetColumn = AmetColumn.Substring(0, AmetColumn.Length - 1);
            string actualAmetColumn = $"{modifiedAmetColumn}{rowNumber}";
            Assert.AreEqual(expectedAmetColumn, actualAmetColumn, "Returned Value are correct.");
        }
    }
}