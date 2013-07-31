﻿module EulerProblemsFSharp.Euler1_10

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

    member x.problem3 = //What is the largest prime factor of the number 600851475143 ?
        printf "Problem 3: "
       
        let rec divideByTwo (num: int64) =
            match System.Math.DivRem(num, 2L) with
            | (1L, _) -> 2L
            | (x, 0L) -> divideByTwo x
            | _       -> num

        let getMaxFactor (num: int64) =
            let num = divideByTwo num
            let rec divide (num: int64) (div: int64) =
                match System.Math.DivRem(num, div) with
                | (x, 0L) -> if div = num then num else divide x div
                | _       -> if div * div >= num then num else divide num (div + 2L)
            
            divide num 3L
            
        getMaxFactor 600851475143L