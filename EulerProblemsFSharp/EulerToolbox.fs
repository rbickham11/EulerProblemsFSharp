module EulerToolbox

open System
open System.Collections

let isPrime n =
    [2L..float n |> Math.Sqrt |> int64]
    |> Seq.filter (fun m -> n % m = 0L)
    |> Seq.length = 0

let getPrimes limit =
    let prime = new BitArray(int limit, true)
    for n in 2L..limit - 1L do
        if prime.Get(int n) then
            for m in n * 2L..n..limit - 1L do prime.Set(int m, false)
    seq {for n in 2L..limit - 1L do if prime.Get(int n) then yield n}
