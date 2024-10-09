using NUnit.Framework;
using TestCreationExam.Common;
using TestCreationExam.PageObjects;
using TestCreationExam.TestCases.Common;

namespace TestCreationExam.TestCases
{
    class StudentRegistrationForm : BaseTestLocal
    {
        [Test]
        [Category("Student Registration Form")]
        public void StudentRegistrationFormCase()
        {
            string firstName = Utils.GenerateRandomString(6);
            string lastName = Utils.GenerateRandomString(8);
            string email = firstName + lastName + "@example.com";
            string phoneNumber = Utils.GenerateRandomNumber(100, 1000) + "555" + Utils.GenerateRandomNumber(1000, 10000);
            string currentAddress = Utils.GenerateRandomNumber(1000, 10000) + " " + "Main St";

            PracticeFormPage practiceFormPage = new PracticeFormPage(Driver.Value);
            practiceFormPage.SetFirstName(firstName);
            practiceFormPage.SetLastName(lastName);
            practiceFormPage.SetEmail(email);
            practiceFormPage.SetGender();
            practiceFormPage.SetMobile(phoneNumber);
            practiceFormPage.SetDateOfBirth();
            practiceFormPage.SetHobbies();
            practiceFormPage.SetCurrentAddress(currentAddress);
            practiceFormPage.SetStateAndCity();
            string studentFirstName = practiceFormPage.GetFirstName();
            string studentLastName = practiceFormPage.GetLastName();
            string studentName = studentFirstName + " " + studentLastName;
            string studentEmail = practiceFormPage.GetEmail();
            string gender = practiceFormPage.GetGender();
            string mobile = practiceFormPage.GetMobile();
            DateOnly dateOfBirth = practiceFormPage.GetDateOfBirth();
            string hobbies = practiceFormPage.GetHobbies();
            string address = practiceFormPage.GetCurrentAddress();
            string state = practiceFormPage.GetState();
            string city = practiceFormPage.GetCity();
            string stateAndCity = state + " " + city;
            practiceFormPage.Submit();

            ConfirmationDialogPage submissionFormPage = new ConfirmationDialogPage(Driver.Value);
            string actualStudentName = submissionFormPage.GetStudentName();
            Assert.AreEqual(studentName, actualStudentName, "Student Names are verified.");

            string actualStudentEmail = submissionFormPage.GetStudentEmail();
            Assert.AreEqual(studentEmail, actualStudentEmail, "Verify Student Email");

            string actualGender = submissionFormPage.GetGender();
            Assert.AreEqual(gender, actualGender, "Gender is verified.");

            string actualMobile = submissionFormPage.GetMobile();
            Assert.AreEqual(mobile, actualMobile, "Verify Mobile");

            DateOnly actualDob = submissionFormPage.GetDateOfBirth();
            Assert.AreEqual(dateOfBirth, actualDob, "selected date of birth is not same as modal window");

            string actualHobbies = submissionFormPage.GetHobbies();
            Assert.AreEqual(hobbies, actualHobbies, "Verify Hobbies");

            string actualAddress = submissionFormPage.GetAddress();
            Assert.AreEqual(address, actualAddress, "Verify Address");

            string actualStateAndCity = submissionFormPage.GetStateAndCity();
            Assert.AreEqual(stateAndCity, actualStateAndCity, "Verify State and City");
        }
    }
}