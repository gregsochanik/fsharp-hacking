namespace Tests
open NUnit.Framework
open FsUnit
open System.Numerics

type Fib() = 
 static member GetFirstWithLength(number) = 
  Seq.unfold(fun (current,next) -> Some(current, (next, current + next)))(0I,1I)
   |> Seq.takeWhile(fun n -> n.ToString().Length < number)
   |> Seq.length
 

[<TestFixture>]
type ``Given a fib`` () =
 let fib = new Fib()

 [<Test>] member x.
  ``when I ask for the first with length of 10`` () =
    Fib.GetFirstWithLength(10) |> should equal 45

 [<Test>] member x.
  ``Euler 25 : when I ask for the first with length of 1000`` () =
    Fib.GetFirstWithLength(1000) |> should equal 4782
