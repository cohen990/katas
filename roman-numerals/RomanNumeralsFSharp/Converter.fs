namespace RomanNumeralsFSharp

module RomanNumerals =

    let (|GreaterThan|_|) comparison x = 
        if x >= comparison 
        then Some GreaterThan 
        else None
    
    let map arabic = 
        match arabic with
            | GreaterThan 1000 -> "M", 1000
            | GreaterThan 900 -> "CM", 900
            | GreaterThan 400 -> "CD", 400
            | GreaterThan 100 -> "C", 100
            | GreaterThan 90 -> "XC", 90
            | GreaterThan 50 -> "L", 50
            | GreaterThan 40 -> "XL", 40
            | GreaterThan 10 -> "X", 10
            | GreaterThan 9 -> "IX", 9
            | GreaterThan 5 -> "V", 5
            | GreaterThan 4 -> "IV", 4
            | GreaterThan 1 -> "I", 1
            | GreaterThan 0 -> "", 0
            | _ -> failwith "Roman Numerals only support postive integers"
     
    let rec FromArabic numeralToMap =
        let romanNumeral, arabicNumeral = map numeralToMap
        match arabicNumeral with
            | 0 -> ""
            | _ -> romanNumeral + FromArabic (numeralToMap - arabicNumeral)
