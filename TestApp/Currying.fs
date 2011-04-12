namespace Tests
open NUnit.Framework
open FsUnit
open System.Numerics

[<TestFixture>]
type ``Given a Currying scenario`` () =
 
 let add x y = x+y
 let addFive = add 5 // shows a partial method call - we're only passing 1 param

 [<Test>] member x.
  ``Should add 5 because we have already passed that param in another method``() =
   Assert.That(addFive 12, Is.EqualTo(17)) 

[<TestFixture>]
type ``Given a scenario with 2 different pattern matching syntaxes`` () =

//trad syntax
 let getPrice food =
    match food with
    | "banana" -> 0.79
    | "watermelon" -> 3.49
    | "tofu" -> 1.09
    | _ -> nan

// shortcut syntax
 let getPrice2 = function
    | "banana" -> 0.79
    | "watermelon" -> 3.49
    | "tofu" -> 1.09
    | _ -> nan

