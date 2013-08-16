module EulerProblemsFSharp.Euler1_10

open System

type Problems() =
    let isPrime n =
        [2L..float n |> Math.Sqrt |> int64]
        |> Seq.filter (fun m -> n % m = 0L)
        |> Seq.length = 0

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

    member x.problem4 = //Find the largest palindrome made from the product of two 3-digit numbers.
        printf "Problem 4: "
        let isPalindrome num =
            let forward = (string num).ToCharArray()
            let reversed = forward |> Array.rev
            forward = reversed
        
        [for x in 100..999 do for y in x..999 do if isPalindrome (x * y) then yield x * y] 
        |> List.max
        
    member x.problem5 = //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        printf "Problem 5: "
        let divByAll num =
            {1..20} |> Seq.forall (fun x -> num % x = 0)

        Seq.unfold (fun n -> Some(n, n + 1)) 1
        |> Seq.map (fun n -> n * 20)
        |> Seq.filter (fun n -> divByAll n)
        |> Seq.head

    member x.problem6 = //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        printf "Problem 6: "
        let nums = {1..100}
        
        let sumOfSquares =
            nums
            |> Seq.map (fun n -> n * n)
            |> Seq.sum
        let seqSum = Seq.sum nums

        (seqSum * seqSum) - sumOfSquares

    member x.problem7 = //What is the 10001st prime number?
        printf "Problem 7: "
        Seq.unfold(fun n -> Some(n, n + 2L)) 3L
        |> Seq.filter(fun n -> isPrime n)
        |> Seq.nth 9999