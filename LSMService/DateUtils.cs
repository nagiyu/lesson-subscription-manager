namespace LSMService
{
    /// <summary>
    /// Date utilities
    /// </summary>
    public class DateUtils
    {
        /// <summary>
        /// Get the number of months between two dates
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <param name="specialStartDate">Special Start Date</param>
        /// <param name="specialEndDate">Special End Date</param>
        /// <returns>Tuple of special months and other months</returns>
        public static (int, int) GetMonthCount(DateTime startDate, DateTime endDate, DateTime specialStartDate, DateTime specialEndDate)
        {
            var specialMonths = 0;
            var otherMonths = 0;

            for (var date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                if (date >= specialStartDate && date <= specialEndDate)
                {
                    specialMonths++;
                }
                else
                {
                    otherMonths++;
                }
            }

            return (specialMonths, otherMonths);
        }
    }
}
