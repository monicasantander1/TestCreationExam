using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        private readonly By _closeSubmissionFormLocator = By.Id("closeLargeModal");
        private readonly By _currentAddreessLocator = By.Id("currentAddress");
        private readonly By _dateOfBirthLocator = By.Id("dateOfBirthInput");
        private readonly By _emailLocator = By.Id("userEmail");
        private readonly By _femaleGenderLocator = By.XPath("//label[text()='Female']");
        private readonly By _firstNameLocator = By.Id("firstName");
        private readonly By _genderInputLocator = By.XPath("//input[@type='radio']");
        private readonly By _genderOptionLocator = By.XPath("//label[contains(@for,'gender-radio')]");
        private readonly By _hobbiesOptionLocator = By.XPath("//label[contains(@for,'hobbies-checkbox')]");
        private readonly By _hobbiesInputLocator = By.XPath("//input[@type='checkbox']");
        private readonly By _lastNameLocator = By.Id("lastName");
        private readonly By _maleGenderLocator = By.XPath("//label[text()='Male']");
        private readonly By _mobileLocator = By.Id("userNumber");
        private readonly By _musicHobbyLocator = By.XPath("//label[text()='Music']");
        private readonly By _otherGenderLocator = By.XPath("//label[text()='Other']");
        private readonly By _readingHobbyLocator = By.XPath("//label[text()='Reading']");
        private readonly By _selectCityLocator = By.Id("city");
        private readonly By _selectStateLocator = By.Id("state");
        private readonly By _sportsHobbyLocator = By.XPath("//label[text()='Sports']");
        private readonly By _stateDropdownLocator = By.Id("state");
        private readonly By _stateNcrLocator = By.XPath("//div[text()='NCR']");
        private readonly By _submitLocator = By.Id("submit");

        public PracticeFormPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Enters student's first name.
        /// </summary>
        /// <param name="firstName"></param>
        public void SetFirstName(string firstName)
        {
            EditBoxSendKeysAndVerify(_firstNameLocator, firstName);
        }

        /// <summary>
        /// Returns the student's first name
        /// </summary>
        /// <returns>The first name</returns>
        public string GetFirstName()
        {
            return GetValue(_firstNameLocator);
        }

        /// <summary>
        /// Enters student's last name
        /// </summary>
        /// <param name="lastName"></param>
        public void LastName(string lastName)
        {
            EditBoxSendKeysAndVerify(_lastNameLocator, lastName);
        }

        /// <summary>
        /// Returns the student's last name
        /// </summary>
        /// <returns>The last name</returns>
        public string GetLastName()
        {
            return GetValue(_lastNameLocator);
        }

        /// <summary>
        /// Enters student's email address
        /// </summary>
        /// <param name="email"></param>
        public void Email(string email)
        {
            EditBoxSendKeysAndVerify(_emailLocator, email);
        }

        /// <summary>
        /// Returns the student's email address
        /// </summary>
        /// <returns>The email address</returns>
        public string GetEmail()
        {
            return GetValue(_emailLocator);
        }

        /// <summary>
        /// Sets a random Gender option
        /// </summary>
        public void SetGender()
        {
            IWebElement option1 = FindElement(_maleGenderLocator);
            IWebElement option2 = FindElement(_femaleGenderLocator);
            IWebElement option3 = FindElement(_otherGenderLocator);
            int choice = Utils.Random.Next(1, 4);
            switch (choice)
            {
                case 1:
                    option1.Click();
                    break;
                case 2:
                    option2.Click();
                    break;
                case 3:
                    option3.Click();
                    break;
            }
        }

        /// <summary>
        /// Get Gender
        /// </summary>
        /// <returns>The Gender selection</returns>
        public string GetGender()
        {
            IReadOnlyCollection<IWebElement> genderLabels = FindElements(_genderOptionLocator);
            IReadOnlyCollection<IWebElement> genderRadios = FindElements(_genderInputLocator);

            for (int i = 0; i < genderLabels.Count; i++)
            {
                IWebElement label = genderLabels.ElementAt(i);
                IWebElement radio = genderRadios.ElementAt(i);
                if (radio.Selected)
                {
                    return label.Text;
                }
            }
            return null;
        }

        /// <summary>
        /// Enters a random mobile phone
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void SetMobileNumber(string phoneNumber)
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
        /// input Date of Birth
        /// </summary>
        public void SetDateOfBirth(DateOnly dob)
        {
            string dobString = dob.ToString("dd MMM yyyy");
            SendKeys(_dateOfBirthLocator, dobString);
        }

        /// <summary>
        /// Get Date of Birth
        /// </summary>
        /// <returns>The Date of Birth</returns>
        public DateOnly GetDateOfBirth()
        {
            string dobString = GetValue(_dateOfBirthLocator);
            return DateOnly.ParseExact(dobString, "dd MMM yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sets a random Hobby option
        /// </summary>
        public void SetHobby()
        {
            IWebElement option1 = FindElement(_sportsHobbyLocator);
            IWebElement option2 = FindElement(_musicHobbyLocator);
            IWebElement option3 = FindElement(_readingHobbyLocator);
            int choice = Utils.Random.Next(1, 4);
            switch (choice)
            {
                case 1:
                    option1.Click();
                    break;
                case 2:
                    option2.Click();
                    break;
                case 3:
                    option3.Click();
                    break;
            }
        }

        /// <summary>
        /// Return Hobbies option
        /// </summary>
        /// <returns>The Hobby</returns>
        public string GetHobbies()
        {
            IReadOnlyCollection<IWebElement> hobbyLabels = FindElements(_hobbiesOptionLocator);
            IReadOnlyCollection<IWebElement> hobbyCheckboxes = FindElements(_hobbiesInputLocator);
            for (int i = 0; i < hobbyLabels.Count; i++)
            {
                IWebElement label = hobbyLabels.ElementAt(i);
                IWebElement checkbox = hobbyCheckboxes.ElementAt(i);
                if (checkbox.Selected)
                {
                    return label.Text;
                }
            }
            return null;
        }

        /// <summary>
        /// Enters student's street address and number
        /// </summary>
        /// <param name="currentAddress"></param>
        public void SetCurrentAddress(string currentAddress)
        {
            EditBoxSendKeysAndVerify(_currentAddreessLocator, currentAddress);
        }

        /// <summary>
        /// Return the current address
        /// </summary>
        /// <returns>The current address</returns>
        public string GetCurrentAddress()
        {
            return GetValue(_currentAddreessLocator);
        }

        /// <summary>
        /// Clicks NCR for state and Dehi for city
        /// </summary>
        public void SetStateAndCity()
        {
            Click(_selectStateLocator);
            Click(_stateNcrLocator);
            Click(_selectCityLocator);
            Click(_cityDelhiLocator);
        }

        /// <summary>
        /// Return NCR State
        /// </summary>
        /// <returns>The State</returns>
        public string GetState()
        {
            return GetText(_stateNcrLocator);
        }

        /// <summary>
        /// Return Delhi City
        /// </summary>
        /// <returns>The City</returns>
        public string GetCity()
        {
            return GetText(_cityDelhiLocator);
        }

        /// <summary>
        /// Click Submit
        /// </summary>
        public void Submit()
        {
            Click(_submitLocator);
            IWebElement submissionForm = Driver.FindElement(_closeSubmissionFormLocator);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(50000));
            wait.Until(ExpectedConditions.ElementToBeClickable(submissionForm));
        }
    }
}