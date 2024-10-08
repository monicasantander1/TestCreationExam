using OpenQA.Selenium;
using System.Globalization;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class SubmissionFormPage : BasePageLocal
    {
        private readonly By _addressLocator = By.XPath("//tr[9]/td[2]");
        private readonly By _dateOfBirthLocator = By.XPath("//tr[5]/td[2]");
        private readonly By _genderLocator = By.XPath("//tr[3]/td[2]");
        private readonly By _hobbiesLocator = By.XPath("//tr[7]/td[2]");
        private readonly By _mobileLocator = By.XPath("//tr[4]/td[2]");
        private readonly By _stateAndCityLocator = By.XPath("//tr[10]/td[2]");
        private readonly By _studentEmailLocator = By.XPath("//tr[2]/td[2]");
        private readonly By _studentNameLocator = By.XPath("//tr[1]/td[2]");

        public SubmissionFormPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Return name
        /// </summary>
        /// <returns>name</returns>
        public string GetStudentName()
        {
            return GetText(_studentNameLocator);
        }

        /// <summary>
        /// Return Student Email
        /// </summary>
        /// <returns>The email</returns>
        public string GetStudentEmail()
        {
            return GetText(_studentEmailLocator);
        }

        /// <summary>
        /// Return Gender
        /// </summary>
        /// <returns>The Gender</returns>
        public string GetGender()
        {
            return GetText(_genderLocator);
        }

        /// <summary>
        /// Return Mobile number
        /// </summary>
        /// <returns>The Mobile</returns>
        public string GetMobile()
        {
            return GetText(_mobileLocator);
        }

        /// <summary>
        /// Return Date of Birth
        /// </summary>
        /// <returns>The Date of Birth</returns>
        public DateOnly GetDateOfBirth()
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string dobString = GetText(_dateOfBirthLocator);
            return DateOnly.ParseExact(dobString, "dd MMMM,yyyy", cultureInfo);
        }

        /// <summary>
        /// Return Hobbies options
        /// </summary>
        /// <returns>The Hobbies</returns>
        public string GetHobbies()
        {
            return GetText(_hobbiesLocator);
        }

        /// <summary>
        /// Return Address
        /// </summary>
        /// <returns>The Address</returns>
        public string GetAddress()
        {
            return GetText(_addressLocator);
        }

        /// <summary>
        /// Return State and City
        /// </summary>
        /// <returns>The State and City</returns>
        public string GetStateAndCity()
        {
            return GetText(_stateAndCityLocator);
        }
    }
}