using NUnit.Framework;

namespace kukin.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var testVariable1 = 28;
            var testVariable = 54 * testVariable1;

            Assert.AreEqual(testVariable, testVariable1);
        }
    }
}