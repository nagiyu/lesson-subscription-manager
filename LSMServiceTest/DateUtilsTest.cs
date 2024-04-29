using LSMService;

namespace LSMServiceTest
{
    [TestClass]
    public class DateUtilsTest
    {
        [TestMethod]
        public void TestGetMonthCount_BeforeSpecialDate()
        {
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2020, 3, 1);
            var specialStartDate = new DateTime(2020, 4, 1);
            var specialEndDate = new DateTime(2021, 3, 1);

            var (specialMonths, otherMonths) = DateUtils.GetMonthCount(startDate, endDate, specialStartDate, specialEndDate);

            Assert.AreEqual(0, specialMonths);
            Assert.AreEqual(3, otherMonths);
        }

        [TestMethod]
        public void TestGetMonthCount_EndInSpecialDate()
        {
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2021, 3, 1);
            var specialStartDate = new DateTime(2020, 4, 1);
            var specialEndDate = new DateTime(2021, 3, 1);

            var (specialMonths, otherMonths) = DateUtils.GetMonthCount(startDate, endDate, specialStartDate, specialEndDate);

            Assert.AreEqual(12, specialMonths);
            Assert.AreEqual(3, otherMonths);
        }

        [TestMethod]
        public void TestGetMonthCount_InSpecialDate()
        {
            var startDate = new DateTime(2020, 4, 1);
            var endDate = new DateTime(2021, 3, 1);
            var specialStartDate = new DateTime(2020, 4, 1);
            var specialEndDate = new DateTime(2021, 3, 1);

            var (specialMonths, otherMonths) = DateUtils.GetMonthCount(startDate, endDate, specialStartDate, specialEndDate);

            Assert.AreEqual(12, specialMonths);
            Assert.AreEqual(0, otherMonths);
        }

        [TestMethod]
        public void TestGetMonthCount_StartInSpecialDate()
        {
            var startDate = new DateTime(2020, 4, 1);
            var endDate = new DateTime(2021, 5, 1);
            var specialStartDate = new DateTime(2020, 4, 1);
            var specialEndDate = new DateTime(2021, 3, 1);

            var (specialMonths, otherMonths) = DateUtils.GetMonthCount(startDate, endDate, specialStartDate, specialEndDate);

            Assert.AreEqual(12, specialMonths);
            Assert.AreEqual(2, otherMonths);
        }

        [TestMethod]
        public void TestGetMonthCount_AfterSpecialDate()
        {
            var startDate = new DateTime(2021, 4, 1);
            var endDate = new DateTime(2021, 6, 1);
            var specialStartDate = new DateTime(2020, 4, 1);
            var specialEndDate = new DateTime(2021, 3, 1);

            var (specialMonths, otherMonths) = DateUtils.GetMonthCount(startDate, endDate, specialStartDate, specialEndDate);

            Assert.AreEqual(0, specialMonths);
            Assert.AreEqual(3, otherMonths);
        }

        [TestMethod]
        public void TestGetMonthCount_OverSpecialDate()
        {
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2021, 6, 1);
            var specialStartDate = new DateTime(2020, 4, 1);
            var specialEndDate = new DateTime(2021, 3, 1);

            var (specialMonths, otherMonths) = DateUtils.GetMonthCount(startDate, endDate, specialStartDate, specialEndDate);

            Assert.AreEqual(12, specialMonths);
            Assert.AreEqual(6, otherMonths);
        }
    }
}