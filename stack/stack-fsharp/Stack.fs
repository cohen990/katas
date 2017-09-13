namespace stack_fsharp

type public 'a Stack =
        | EmptyStack
        | StackNode of 'a * 'a Stack
        
module public Stack =
    let Push (item: 'a, stack: 'a Stack) =
        StackNode(item, stack)
    let Pop (stack: 'a Stack) = 
         match stack with
            | StackNode(head, tail) -> head, tail
            | EmptyStack -> failwith "empty stack"