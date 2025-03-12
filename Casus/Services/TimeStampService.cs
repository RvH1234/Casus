namespace Casus.Services
{
    public class TimeStampService : ITimeStampService
    {
        public override string ToString()
        {
            return CreateTimeStamp();
        }


        /// <summary>
        /// Creates a Timestamp string
        /// </summary>
        /// <returns>String containing date and time</returns>
        private string CreateTimeStamp()

        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.ffff");
            return $"{timestamp}";

        }

    }
}
