module EulerProblemsFSharp.EulerMain

open System

[<EntryPoint>]
let main argv = 
    let stopWatch = new System.Diagnostics.Stopwatch()
    let eu1 = new Euler1_10.Problems()

    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem10 stopWatch.ElapsedMilliseconds

    Console.ReadKey() |> ignore
    0
