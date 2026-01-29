using CalculatorService;

namespace NUnitTestProject1
{
    public class Tests
    {
        Calculator calObj = null;
        [SetUp]
        public void Setup()
        {
            calObj = new Calculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [TearDown]
        public void Reset() {
            calObj = null;
        }
    }
}
