using NUnit.Framework;
using CalcLibrary; // Assuming your calculator class is in this namespace

namespace NUnitTestProject
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [TestCase(2, 3, 5)]
        [TestCase(5, 7, 12)]
        [TestCase(0, 0, 0)]
        public void TestAddition(double a, double b, double expected)
        {
            var result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
        [TestCase(3, 1, 2)]
        [TestCase(5, 3, 2)]
        [TestCase(10, 7, 3)]
        public void TestSubtraction(double a, double b, double expected)
        {
            var result = _calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 6)]
        [TestCase(5, 7, 35)]
        public void TestMultiplication(double a, double b, double expected)
        {
            var result = _calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(6, 3, 2)]
        [TestCase(10, 2, 5)]
        public void TestDivision(double a, double b, double expected)
        {
            var result = _calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDivisionByZero()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Division(10, 0));
        }
    }
}
