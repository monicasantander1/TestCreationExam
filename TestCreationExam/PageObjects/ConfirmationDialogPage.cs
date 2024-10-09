﻿using OpenQA.Selenium;
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
        /// Returns the students name.
        /// </summary>
        /// <returns>name</returns>
        public string GetStudentName()
        {
            return GetText(_studentNameLocator);
        }

        /// <summary>
        /// Returns the students email address.
        /// </summary>
        /// <returns>The email</returns>
        public string GetStudentEmail()
        {
            return GetText(_studentEmailLocator);
        }

        /// <summary>
        /// Returns the gender of the student.
        /// </summary>
        /// <returns>The Gender</returns>
        public string GetGender()
        {
            return GetText(_genderLocator);
        }

        /// <summary>
        /// Returns the mobile number.
        /// </summary>
        /// <returns>The Mobile</returns>
        public string GetMobile()
        {
            return GetText(_mobileLocator);
        }

        /// <summary>
        /// Returns the students Date of Birth.
        /// </summary>
        /// <returns>The Date of Birth</returns>
        public DateOnly GetDateOfBirth()
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string dobString = GetText(_dateOfBirthLocator);
            return DateOnly.ParseExact(dobString, "dd MMMM,yyyy", cultureInfo);
        }

        /// <summary>
        /// Returns the students hobbies.
        /// </summary>
        /// <returns>The Hobbies</returns>
        public string GetHobbies()
        {
            return GetText(_hobbiesLocator);
        }

        /// <summary>
        /// Returns the students address.
        /// </summary>
        /// <returns>The Address</returns>
        public string GetAddress()
        {
            return GetText(_addressLocator);
        }

        /// <summary>
        /// Returns the students state and city.
        /// </summary>
        /// <returns>The State and City</returns>
        public string GetStateAndCity()
        {
            return GetText(_stateAndCityLocator);
        }
    }
}