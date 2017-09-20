module Tests

open System
open Xunit
open stack_fsharp
open FsUnit
open FsUnit.Xunit

[<Fact>]
let ``Return Pushed Item When Popped`` () =
    let expected = "only"
    let stack = Stack.EmptyStack |> Stack.Push expected
    
    stack
    |> Stack.Pop
    |> Option.get
    |> fst 
    |> should equal expected
    
[<Fact>]
let ``Return items in reverse order when popped`` () =
    let expectedFirst = "first"
    let expectedSecond = "second"
    
    let head, stack =
        Stack.EmptyStack 
        |> Stack.Push expectedSecond
        |> Stack.Push expectedFirst
        |> Stack.Pop
        |> Option.get
    
    head
    |> should equal expectedFirst

    stack
    |> Stack.Pop
    |> Option.get 
    |> fst 
    |> should equal expectedSecond
