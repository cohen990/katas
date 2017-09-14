using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public class Converter
    {
        private readonly Dictionary<int, string> _arabicToRomanNumerals =
        new Dictionary<int, string> {
            {1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD"},
            {500, "D"},
            {900, "CM"},
            {1000, "M"},
        };
        
        public string Convert(int numberToConvert)
        {
            var result = new StringBuilder();

            var arabicNumerals = _arabicToRomanNumerals.Keys.OrderByDescending(x => x);

            foreach (var arabicNumeral in arabicNumerals)
            {
                var romanNumeral = _arabicToRomanNumerals[arabicNumeral];

                while (numberToConvert >= arabicNumeral)
                {
                    numberToConvert -= arabicNumeral;
                    result.Append(romanNumeral);
                }
            }

            return result.ToString();
        }
    }
}
