module Tests

open System
open Xunit
open RomanNumeralsFSharp
open FsUnit
open FsUnit.Xunit

[<Theory>]
[<InlineData(1, "I")>]
[<InlineData(2, "II")>]
[<InlineData(3, "III")>]
[<InlineData(4, "IV")>]
[<InlineData(5, "V")>]
[<InlineData(6, "VI")>]
[<InlineData(7, "VII")>]
[<InlineData(8, "VIII")>]
[<InlineData(9, "IX")>]
[<InlineData(10, "X")>]
[<InlineData(11, "XI")>]
[<InlineData(14, "XIV")>]
[<InlineData(18, "XVIII")>]
[<InlineData(19, "XIX")>]
[<InlineData(24, "XXIV")>]
[<InlineData(40, "XL")>]
[<InlineData(50, "L")>]
[<InlineData(90, "XC")>]
[<InlineData(100, "C")>]
[<InlineData(400, "CD")>]
[<InlineData(900, "CM")>]
[<InlineData(1000, "M")>]
[<InlineData(2017, "MMXVII")>]
[<InlineData(3419, "MMMCDXIX")>]
[<InlineData(3999, "MMMCMXCIX")>]
let ``Return Roman Numerals When Given Arabic Numerals`` (arabicNumeral, romanNumeral) =
    arabicNumeral 
    |> RomanNumerals.FromArabic 
    |> should equal romanNumeral