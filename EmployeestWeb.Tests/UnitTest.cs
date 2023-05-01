namespace EmployeesWeb.Tests
{
    public class UnitTest
    {
        [Theory]
        [InlineData(1, 1, 2)]
        public void Test(int x, int y, int result)
        {
            Assert.Equal(result, Add(x, y));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
    }
}