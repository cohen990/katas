using RomanNumerals;
using Xunit;
using Xunit.Sdk;

namespace RomanNumeralsTests
{
    public class ConverterShould
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(14, "XIV")]
        [InlineData(15, "XV")]
        [InlineData(40, "XL")]
        [InlineData(50, "L")]
        [InlineData(51, "LI")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(1000, "M")]
        [InlineData(1498, "MCDXCVIII")]
        [InlineData(1498, "MCDXCVIII")]
        [InlineData(3999, "MMMCMXCIX")]
        public void ReturnsRomanNumeralsWhenGivenArabicNumerals(int arabicNumeral, string romanNumeral)
        {
            var converter = new Converter();
            
            var result = converter.Convert(arabicNumeral);
            Assert.Equal(romanNumeral, result);
        }
    }
}
