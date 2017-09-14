namespace LeapYearFSharp

module Year =
    let DivisibleBy number divisor =
        number % divisor = 0
    let NotDivisibleBy number divisor =
        number % divisor <> 0
        
    let IsLeapYear year =
        match year with
            | x when DivisibleBy year 100 
                && NotDivisibleBy year 400 -> false
            | x when DivisibleBy year 4 -> true
            | _ -> false
