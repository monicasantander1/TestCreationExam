using NUnit.Framework;
using TestCreationExam.Common;
using TestCreationExam.PageObjects;
using TestCreationExam.TestCases.Common;
using static System.Net.WebRequestMethods;

namespace TestCreationExam.TestCases
{
    class StudentRegistrationForm : BaseTestLocal
    {
        [Test]
        [Category("Student Registration Form")]
        public void StudentRegistrationFormCase()
        {
            // 1)  Navigate to https://demoqa.com/automation-practice-form
            Driver.Value.Url = "https://demoqa.com/automation-practice-form";

            string firstName = Utils.GenerateRandomString(6);
            string lastName = Utils.GenerateRandomString(8);
            string email = firstName + lastName + "@example.com";
            string phoneNumber = Utils.GenerateRandomNumber(100, 1000) + "555" + Utils.GenerateRandomNumber(1000, 10000);
            string currentAddress = Utils.GenerateRandomNumber(1000, 10000) + " " + "Main St";
            
            string[] genderOptions = new string[] { "Male", "Female", "Other" };
            int genderIndex = Utils.Random.Next(genderOptions.Length);
            string targetGender = genderOptions[genderIndex];
           
            string[] hobbiesOptions = new string[] { "Sports", "Reading", "Music" };
            int hobbyIndex = Utils.Random.Next(hobbiesOptions.Length);
            string targetHobby = hobbiesOptions[hobbyIndex];
            
            DateOnly startDate = new DateOnly(2000, 1, 1);
            DateOnly endDate = DateOnly.FromDateTime(DateTime.Now);
            Random random = new Random();
            int range = endDate.DayNumber - startDate.DayNumber;
            int randomDays = random.Next(range);
            DateOnly birthday = startDate.AddDays(randomDays);
          
            PracticeFormPage practiceFormPage = new PracticeFormPage(Driver.Value);
            practiceFormPage.firstName(firstName);
            practiceFormPage.lastName(lastName);
            practiceFormPage.email(email);
            practiceFormPage.SetGender(targetGender);
            practiceFormPage.SetMobile(phoneNumber);
            practiceFormPage.SetDateOfBirth(birthday);
            practiceFormPage.SetHobbies(targetHobby);
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
            string stateAndCity = $"{state} {city}";

   
            practiceFormPage.Submit();
            ConfirmationDialogPage submissionFormPage = new ConfirmationDialogPage(Driver.Value);

            string actualStudentName = submissionFormPage.GetStudentName();
            Assert.AreEqual(studentName, actualStudentName, "Verify student name.");
            string actualStudentEmail = submissionFormPage.GetStudentEmail();
            Assert.AreEqual(studentEmail, actualStudentEmail, "Verify student email.");
            string actualGender = submissionFormPage.GetGender();
            Assert.AreEqual(gender, actualGender, "Verify gender.");
            string actualMobile = submissionFormPage.GetMobile();
            Assert.AreEqual(mobile, actualMobile, "Verify mobile.");
            DateOnly actualDob = submissionFormPage.GetDateOfBirth();
            Assert.AreEqual(dateOfBirth, actualDob, "Verify date of birth.");
            string actualHobbies = submissionFormPage.GetHobbies();
            Assert.AreEqual(hobbies, actualHobbies, "Verify hobbies.");
            string actualAddress = submissionFormPage.GetAddress();
            Assert.AreEqual(address, actualAddress, "Verify address.");
            string actualStateAndCity = submissionFormPage.GetStateAndCity();
            Assert.AreEqual(stateAndCity, actualStateAndCity, "Verify state and city.");
        }
    }
}