using LeapYear;
using Xunit;

namespace LeapYearTests
{
    public class YearShould
    {
        [Fact]
        public void NotBeALeapYearIfNotDivisbleBy4() 
        {
            Assert.False(LeapYear(1997));
        }

        [Theory]
        [InlineData(1996)]
        [InlineData(2004)]
        public void BeALeapYearIfDivisibleBy4(int year)
        {
            Assert.True(LeapYear(year));
        }

        [Fact]
        public void BeALeapYearIfDivisibleBy400()
        {
            Assert.True(LeapYear(1600));
        }

        [Fact]
        public void NotBeALeapYearIfDivisibleBy100ButNot400()
        {
            Assert.False(LeapYear(1800));
        }

        private bool LeapYear(int year)
        {
            return new Year(year).IsLeapYear();
        }
    }
}
