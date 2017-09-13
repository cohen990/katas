module Tests

open System
open Xunit
open stack_fsharp

[<Fact>]
let ``Return Pushed Item When Popped`` () =
    let expected = "only"
    let stack = Stack.Push (expected, Stack.EmptyStack)
    let head = fst (Stack.Pop stack)
    Assert.Equal(expected, head)
    
[<Fact>]
let ``Return items in reverse order when popped`` () =
    let expectedFirst = "first"
    let expectedSecond = "second"
    let stack = Stack.Push (expectedSecond, Stack.EmptyStack)
    let stack = Stack.Push (expectedFirst, stack)
    let returnedFirst, stack = Stack.Pop stack
    let returnedSecond = fst (Stack.Pop stack)
    Assert.Equal(expectedFirst,  returnedFirst)
    Assert.Equal(expectedSecond, returnedSecond)
