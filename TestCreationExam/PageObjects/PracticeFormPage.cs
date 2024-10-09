using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Security.Cryptography;
using TestCreationExam.Common;
using TestCreationExam.PageObjects.Common;

namespace TestCreationExam.PageObjects
{
    public class PracticeFormPage : BasePageLocal
    {

        private readonly By _cityDelhiLocator = By.XPath("//div[text()='Delhi']");
        private readonly By _cityDropdownLocator = By.Id("city");
        private readonly By _closeSubimissionFormLocator = By.Id("closeLargeModal");
        private readonly By _currentAddreessLocator = By.Id("currentAddress");
        private readonly By _dateOfBirthLocator = By.Id("dateOfBirthInput");
        private readonly By _emailLocator = By.Id("userEmail");
        private readonly By _femaleGender = By.XPath("//label[text()='Female']");
        private readonly By _firstNameLocator = By.Id("firstName");
        private readonly By _genderOptionLocator = By.CssSelector("input[type='radio']");
        private readonly By _hobbiesOptionLocator = By.XPath("//label[contains(@for,'hobbies-checkbox')]");
        private readonly By _lastNameLocator = By.Id("lastName");
        private readonly By _maleGender = By.XPath("//label[text()='Male']");
        private readonly By _mobileLocator = By.Id("userNumber");
        private readonly By _musicHobby = By.XPath("//label[text()='Music']");
        private readonly By _otherGender = By.XPath("//label[text()='Other']");
        private readonly By _readingHobby = By.XPath("//label[text()='Reading']");
        private readonly By _selectCityLocator = By.Id("city");
        private readonly By _selectStateLocator = By.Id("state");
        private readonly By _sportsHobby = By.XPath("//label[text()='Sports']");
        private readonly By _stateDropdownLocator = By.Id("state");
        private readonly By _stateNCRLocator = By.XPath("//div[text()='NCR']");
        private readonly By _submitLocator = By.Id("submit");

        public PracticeFormPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Enters students firstname.
        /// </summary>
        /// <param name="firstname"></param>
        public void SetFirstName(string firstname)
        {
            EditBoxSendKeysAndVerify(_firstNameLocator, firstname);
        }

        /// <summary>
        /// Returns Firstname
        /// </summary>
        /// <returns>The Firstname</returns>
        public string GetFirstName()
        {
            return GetValue(_firstNameLocator);
        }

        /// <summary>
        /// Enters students lastname
        /// </summary>
        /// <param name="lastName"></param>
        public void SetLastName(string lastName) 
        {
            EditBoxSendKeysAndVerify(_lastNameLocator, lastName);
        }

        /// <summary>
        /// Returns LastName
        /// </summary>
        /// <returns>The Lastname</returns>
        public string GetLastName()
        {
            return GetValue(_lastNameLocator);
        }

        /// <summary>
        /// Enters students email address
        /// </summary>
        /// <param name="email"></param>
        public void SetEmail(string email) 
        {
            EditBoxSendKeysAndVerify(_emailLocator, email);
        }

        /// <summary>
        /// Returns Email address
        /// </summary>
        /// <returns>The email address</returns>
        public string GetEmail()
        {
            return GetValue(_emailLocator);
        }

        /// <summary>
        /// Holds selected Gender
        /// </summary>
        private string _selectedGender;

        /// <summary>
        /// Gender options. 
        /// Randomly click a Gender
        /// find what randon gender we selected
        /// </summary>
        public void SetGender()
        {
            IWebElement genderOption1 = FindElement(_maleGender);
            IWebElement genderOption2 = FindElement(_femaleGender);
            IWebElement genderOption3 = FindElement(_otherGender);
            IWebElement[] genderOptions = { genderOption1, genderOption2, genderOption3 };
            int index = Utils.Random.Next(genderOptions.Length);
            IWebElement genderElement = genderOptions[index];
            genderElement.Click();
            IReadOnlyCollection<IWebElement> genderRadios = FindElements(_genderOptionLocator);
            _selectedGender = genderRadios.ElementAt(index).GetAttribute("value");
        }

        /// <summary>
        /// Return Gender
        /// </summary>
        /// <returns>The Gender selection</returns>
        public string GetGender()
        {
            return _selectedGender;
        }

        /// <summary>
        /// Enters a random mobile phone
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void SetMobile(string phoneNumber)
        {
            EditBoxSendKeysAndVerify(_mobileLocator, phoneNumber);
        }

        /// <summary>
        /// Return Mobile 
        /// </summary>
        /// <returns>The mobile</returns>
        public string GetMobile()
        {
            return GetValue(_mobileLocator);
        }

        /// <summary>
        /// hold date of birth selection
        /// </summary>
        DateOnly _dateOfBirth;

        /// <summary>
        /// Random date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Random date days</returns>
        public static DateOnly GenerateRandomDate(DateOnly startDate, DateOnly endDate)
        {
            Random random = new Random();
            int range = endDate.DayNumber - startDate.DayNumber;
            int randomDays = random.Next(range);
            return startDate.AddDays(randomDays);
        }

        /// <summary>
        /// Random date year
        /// </summary>
        /// <returns>Random date year</returns>
        public static DateOnly GenerateRandomDateFrom2000()
        {
            DateOnly startDate = new DateOnly(2000, 1, 1);
            DateOnly endDate = DateOnly.FromDateTime(DateTime.Now);
            return GenerateRandomDate(startDate, endDate);
        }

        /// <summary>
        /// generate Date of Birth
        /// </summary>
        public void SetDateOfBirth()
        {
            _dateOfBirth = GenerateRandomDateFrom2000();
            SendKeys(_dateOfBirthLocator, _dateOfBirth.ToString("yyyy-MM-dd"));
            _dateOfBirth = _dateOfBirth.AddDays(-1);
        }

        /// <summary>
        /// Return Date of Birth
        /// </summary>
        /// <returns>The Date of Birth</returns>
        public DateOnly GetDateOfBirth()
        {
            return _dateOfBirth;
        }

        /// <summary>
        /// Holds selected Hobby
        /// </summary>
        private string _selectedHobbies;

        /// <summary>
        /// Hobbies Options.
        /// Randomly click a hobby
        /// find out what random selected we clicked
        /// </summary>
        public void SetHobbies()
        {
            IWebElement hobbiesOption1 = FindElement(_sportsHobby);
            IWebElement hobbiesOption2 = FindElement(_readingHobby);
            IWebElement hobbiesOption3 = FindElement(_musicHobby);
            IWebElement[] hobbiesOptions = { hobbiesOption1, hobbiesOption2, hobbiesOption3 };
            int index = Utils.Random.Next(hobbiesOptions.Length);
            IWebElement hobbiesElement = hobbiesOptions[index];
            hobbiesElement.Click();
            IReadOnlyCollection<IWebElement> hobbiesCheckBox = FindElements(_hobbiesOptionLocator);
            _selectedHobbies = hobbiesCheckBox.ElementAt(index).Text;
        }

        /// <summary>
        /// Return Hobbies option
        /// </summary>
        /// <returns>The Hobby</returns>
        public string GetHobbies()
        {
            return _selectedHobbies;
        }

        /// <summary>
        /// Enters students street address and number
        /// </summary>
        /// <param name="currentAddress"></param>
        public void SetCurrentAddress(string currentAddress)
        {
            EditBoxSendKeysAndVerify(_currentAddreessLocator, currentAddress);
        }

        /// <summary>
        /// Return the current address
        /// </summary>
        /// <returns>The Address</returns>
        public string GetCurrentAddress()
        {
            return GetValue(_currentAddreessLocator);
        }

        /// <summary>
        /// hold state and city selected
        /// </summary>
        private string _selectedState, _selectedCity;

        /// <summary>
        /// click State NCR
        /// click city Delhi
        /// </summary>
        public void SetStateAndCity()
        {
            Click(_selectStateLocator);
            Click(_stateNCRLocator);
            _selectedState = FindElement(_stateNCRLocator).Text;

            Click(_selectCityLocator);
            Click(_cityDelhiLocator);
            _selectedCity = FindElement(_cityDelhiLocator).Text;
        }

        /// <summary>
        /// Return NCR State
        /// </summary>
        /// <returns>The State</returns>
        public string GetState()
        {
            return _selectedState;
        }

        /// <summary>
        /// Return Delhi City
        /// </summary>
        /// <returns>The City</returns>
        public string GetCity()
        {
            return _selectedCity;
        }

        /// <summary>
        /// Click Submit
        /// </summary>
        public void Submit()
        {
            Click(_submitLocator);
            IWebElement submissionForm = Driver.FindElement(_closeSubimissionFormLocator);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50000));
            wait.Until(ExpectedConditions.ElementToBeClickable(submissionForm));
        }
    }
}