using Newtonsoft.Json;

namespace TestCreationExam.Common
{
    public class Utils
    {
        // Any methods that aren't WebDriver specific and are used by more than one page object and/or test go here

        /// <summary>
        /// The path to the GlobalTestData.json file.
        /// </summary>
        public static string GlobalTestDataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) + @"\GlobalTestData.json";

        /// <summary>
        /// Holds the configuration data from the JSON file.
        /// </summary>
        public static Dictionary<string, string> ConfigData { get; } = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(GlobalTestDataPath)) ?? throw new InvalidOperationException("GlobalTestData.json contents must be valid.");

        /// <summary>
        /// Holds a static Random for use in the project.
        /// </summary>
        public static readonly Random Random = new Random();

        /// <summary>
        /// Generates a random number within a specified range. NOTE: The maximumNumber is excluded, e.g. if you want a number between 1 and 10 use GenerateRandomNumber(1, 11).
        /// </summary>
        /// <param name="minimumNumber">The inclusive lower bound.</param>
        /// <param name="maximumNumber">The *exclusive* upper bound.</param>
        /// <returns>The generated random number.</returns>
        public static int GenerateRandomNumber(int minimumNumber, int maximumNumber)
        {
            return Random.Next(minimumNumber, maximumNumber);
        }

        /// <summary>
        /// Generates a random string given the desired length.
        /// </summary>
        /// <param name="length">The desired length of string.</param>
        /// <returns>The generated random string.</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(chars, length).Select(str => str[Random.Next(str.Length)]).ToArray());
        }
    }
}