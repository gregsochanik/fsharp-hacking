let x = 10
let y = 5
// NOTE: functions are written in the same way as variable assignments
let add x y = x + y

let sub x y = x - y

let printThreeNumbers num1 num2 num3 =
    printfn "num1: %i" num1
    printfn "num2: %i" num2
    printfn "num3: %i" num3

// NOTE: parenthesis used to denote a single argument 
printThreeNumbers 5 (add 10 7) (sub 20 8)

// NOTE: Hello world example - its return type is unit - equiv of void in c#
let helloWorld = printfn "hello world"

// NOTE: Currying a function says int -> int -> int -> int - actually int -> (int -> (int-> int))
// f is a function that takes an int and returns a function that takes an int that returns a function that takes an int and returns an in
let f x y z = x + y + z

// NOTE: partial function