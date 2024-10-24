using OpenQA.Selenium;
using System.Globalization;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class ConfirmationDialogPage : BasePageLocal
    {
        private readonly By _addressLocator = By.XPath("//tr[td[text()='Address']]/td[2]");
        private readonly By _dateOfBirthLocator = By.XPath("//tr[td[text()='Date of Birth']]/td[2]");
        private readonly By _genderLocator = By.XPath("//tr[td[text()='Gender']]/td[2]");
        private readonly By _hobbiesLocator = By.XPath("//tr[td[text()='Hobbies']]/td[2]");
        private readonly By _mobileLocator = By.XPath("//tr[td[text()='Mobile']]/td[2]");
        private readonly By _stateAndCityLocator = By.XPath("//tr[td[text()='State and City']]/td[2]");
        private readonly By _studentEmailLocator = By.XPath("//tr[td[text()='Student Email']]/td[2]");
        private readonly By _studentNameLocator = By.XPath("//tr[td[text()='Student Name']]/td[2]");

        public ConfirmationDialogPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Returns the student's name.
        /// </summary>
        /// <returns>The student's name</returns>
        public string GetStudentName()
        {
            return GetText(_studentNameLocator);
        }

        /// <summary>
        /// Returns the student's email address.
        /// </summary>
        /// <returns>The student's email</returns>
        public string GetStudentEmail()
        {
            return GetText(_studentEmailLocator);
        }

        /// <summary>
        /// Returns the gender of the student.
        /// </summary>
        /// <returns>The student's gender</returns>
        public string GetGender()
        {
            return GetText(_genderLocator);
        }

        /// <summary>
        /// Returns the student's mobile number.
        /// </summary>
        /// <returns>The student's mobile number</returns>
        public string GetMobile()
        {
            return GetText(_mobileLocator);
        }

        /// <summary>
        /// Returns the student's date of birth.
        /// </summary>
        /// <returns>The student's date of birth</returns>
        public DateOnly GetDateOfBirth()
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string dobString = GetText(_dateOfBirthLocator);
            return DateOnly.ParseExact(dobString, "dd MMMM,yyyy", cultureInfo);
        }

        /// <summary>
        /// Returns the student's hobbies.
        /// </summary>
        /// <returns>The student's hobbies</returns>
        public string GetHobbies()
        {
            return GetText(_hobbiesLocator);
        }

        /// <summary>
        /// Returns the student's address.
        /// </summary>
        /// <returns>The student's address</returns>
        public string GetAddress()
        {
            return GetText(_addressLocator);
        }

        /// <summary>
        /// Returns the student's state and city.
        /// </summary>
        /// <returns>The student's state and city</returns>
        public string GetStateAndCity()
        {
            return GetText(_stateAndCityLocator);
        }
    }
}