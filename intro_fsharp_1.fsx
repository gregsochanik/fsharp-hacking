let sqr x = x * x

let sumOfSquaresI nums = 
 let mutable acc = 0.0
 for x in nums do
  acc <- acc + sqr x
 acc

let rec sumOfSquaresF nums =
 match nums with
 |[] -> 0.0
 |h::t -> sqr h + sumOfSquaresF t

// a |> b |> c result of a is applied to function b and so on
let sumOfSquares nums = 
 nums
 |> Seq.map sqr
 |> Seq.sum