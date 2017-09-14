module YearShould

open System
open Xunit
open LeapYearFSharp

[<Fact>]
let ``Not be a leap year if not divisible by 4`` () =
    Assert.False(Year.IsLeapYear 1997)
    
[<Theory>]
[<InlineData(1996)>]
[<InlineData(2004)>]
let ``Be a leap year if divisible by 4`` (year) =
    Assert.True(Year.IsLeapYear year)
    
[<Fact>]
let ``Be a leap year if divisible by 400`` () =
    Assert.True(Year.IsLeapYear 1600)
    
[<Fact>]
let ``Not be a leap year if divisible by 100 but not 400`` () =
    Assert.False(Year.IsLeapYear 1800)