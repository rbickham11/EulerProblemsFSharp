module EulerProblemsFSharp.Euler1_10

open System

type Problems() =
    member x.problem1 =  //Find the sum of all the multiples of 3 or 5 below 1000.
        printf "Problem 1: "
        [1..999]
        |> Seq.sumBy(fun n -> (if (n % 3 = 0) || (n % 5 = 0) then n else 0))

    member x.problem2 =  //By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
        printf "Problem 2: "
        Seq.unfold(fun (this, next) -> Some(this, (next, this + next))) (0, 1)
        |> Seq.takeWhile(fun x -> x <= 4000000)
        |> Seq.filter(fun x -> x % 2 = 0)
        |> Seq.sum
