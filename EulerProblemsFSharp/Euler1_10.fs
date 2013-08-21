module EulerProblemsFSharp.Euler1_10

open System
open System.Diagnostics
open EulerToolbox

type Problems() =
    let stopWatch = new Stopwatch()

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

    member x.problem8 = //Find the greatest product of five consecutive digits in the 1000-digit number.
        printf "Problem 8: "
        let bigNum = "73167176531330624919225119674426574742355349194934" +
                     "96983520312774506326239578318016984801869478851843" +
                     "85861560789112949495459501737958331952853208805511" +
                     "12540698747158523863050715693290963295227443043557" +
                     "66896648950445244523161731856403098711121722383113" +
                     "62229893423380308135336276614282806444486645238749" +
                     "30358907296290491560440772390713810515859307960866" +
                     "70172427121883998797908792274921901699720888093776" +
                     "65727333001053367881220235421809751254540594752243" +
                     "52584907711670556013604839586446706324415722155397" +
                     "53697817977846174064955149290862569321978468622482" +
                     "83972241375657056057490261407972968652414535100474" +
                     "82166370484403199890008895243450658541227588666881" +
                     "16427171479924442928230863465674813919123162824586" +
                     "17866458359124566529476545682848912883142607690042" +
                     "24219022671055626321111109370544217506941658960408" +
                     "07198403850962455444362981230987879927244284909188" +
                     "84580156166097919133875499200524063689912560717606" +
                     "05886116467109405077541002256983155200055935729725" +
                     "71636269561882670428252483600823257530420752963450"
        bigNum
        |> Seq.windowed 5
        |> Seq.map(fun x -> x |> Seq.fold(fun acc x -> acc * int (x.ToString())) 1)
        |> Seq.max

    member x.problem9 = //There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
        printf "Problem 9: "

        let isPythag (nums: int * int * int) =
            let a, b, c = nums
            let sorted = [a; b; c;] |> List.sort
            sorted.[0] * sorted.[0] + sorted.[1] * sorted.[1] = sorted.[2] * sorted.[2]

        let modCondition n = n % 3 = 0 || n % 4 = 0 || n % 5 = 0
        let range = [1..1000]
        let triplets = seq {for a in range do if modCondition a then for b in range do if modCondition b then 
                            for c in range do if modCondition c && c > a && c > b && c % 2 = 1 && a + b + c = 1000 then yield (a, b, c)}
                            |> Seq.filter isPythag
        
        let a, b, c = triplets |> Seq.head
        a * b * c
        
    member x.problem10 = //Find the sum of all the primes below two million.
        printf "Problem 10: "
        getPrimes 2000000L |> Seq.sum

    member x.runAll =
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem1 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem2 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem3 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem4 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem5 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem6 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem7 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem8 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem9 stopWatch.ElapsedMilliseconds
        stopWatch.Restart()
        printfn "%d (%dms)" x.problem10 stopWatch.ElapsedMilliseconds