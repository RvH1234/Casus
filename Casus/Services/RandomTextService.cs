using System.Text;

namespace Casus.Services
{
    /// <summary>
    /// Service to create random string
    /// </summary>
    public class RandomTextService : IRandomTextService
    {

        public override string ToString()
        {
            return CreateRandomString(10);
        }

        /// <summary>
        /// Creates an random alfanumerical string with a default length of 10
        /// </summary>
        /// <param name="randomStringLength">Length of the string</param>
        /// <returns>Random string of specified length</returns>
        private string CreateRandomString(int randomStringLength = 10)

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


    }
}
