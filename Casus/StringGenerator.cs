using System.Text;

namespace Casus
{
    public static class StringGenerator
    {

        /// <summary>
        /// Creates an random alfanumerical string with a default length of 10
        /// </summary>
        /// <param name="randomStringLength">Length of the string</param>
        /// <returns>Random string of specified length</returns>
        public static string CreateRandomString(int randomStringLength=10)

        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder result = new StringBuilder(randomStringLength);
           
          
            for (int i = 0; i < randomStringLength; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
           
            return result.ToString();
        }

        /// <summary>
        /// Creates a Timestamp string
        /// </summary>
        /// <returns>String containing date and time</returns>
        public static string CreateTimeStamp()

        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.ffff");
            return $"{timestamp}";

        }

    }
}
