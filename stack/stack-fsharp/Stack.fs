namespace stack_fsharp

type public 'a Stack =
        | EmptyStack
        | StackNode of 'a * 'a Stack
        
module public Stack =
    let Push item stack =
        StackNode(item, stack)
    let Pop stack = 
         match stack with
            | StackNode(head, tail) -> Some(head, tail)
            | EmptyStack -> None