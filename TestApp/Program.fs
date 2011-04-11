open System
open System.Numerics

let start = BigInteger 0
let limit = BigInteger 1

let fib = 
 Seq.unfold(fun (current,next) -> Some(current, (next, current + next)))(start,limit)
 |> Seq.takeWhile(fun n -> n.ToString().Length < 1000)
 |> Seq.length
 |> printfn "%i"
 
Console.Read()