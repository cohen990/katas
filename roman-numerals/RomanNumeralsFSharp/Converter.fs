namespace RomanNumeralsFSharp

module RomanNumerals =
    let map arabic = 
        match arabic with
            | x when x >= 1000 -> "M", 1000
            | x when x >= 900 -> "CM", 900
            | x when x >= 400 -> "CD", 400
            | x when x >= 100 -> "C", 100
            | x when x >= 90 -> "XC", 90
            | x when x >= 50 -> "L", 50
            | x when x >= 40 -> "XL", 40
            | x when x >= 10 -> "X", 10
            | x when x >= 9 -> "IX", 9
            | x when x >= 5 -> "V", 5
            | x when x >= 4 -> "IV", 4
            | x when x >= 1 -> "I", 1
            | 0 -> "", 0
            | _ -> failwith "Roman Numerals only support postive integers"
     
    let rec FromArabic numeralToMap =
        let romanNumeral, arabicNumeral = map numeralToMap
        match arabicNumeral with
            | 0 -> ""
            | _ -> romanNumeral + FromArabic (numeralToMap - arabicNumeral)
