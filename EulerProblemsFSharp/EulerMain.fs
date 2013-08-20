module EulerProblemsFSharp.EulerMain

open System

[<EntryPoint>]
let main argv = 
    let stopWatch = new System.Diagnostics.Stopwatch()
    let eu1 = new EulerProblemsFSharp.Euler1_10.Problems()

    stopWatch.Restart()
    eu1.runAll
    printfn "(%dms)" stopWatch.ElapsedMilliseconds

    Console.ReadKey() |> ignore
    0
