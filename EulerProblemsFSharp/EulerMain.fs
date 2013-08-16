module EulerProblemsFSharp.EulerMain

open System

[<EntryPoint>]
let main argv = 
    let stopWatch = new System.Diagnostics.Stopwatch()
    let eu1 = new EulerProblemsFSharp.Euler1_10.Problems()

    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem1 stopWatch.ElapsedMilliseconds
    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem2 stopWatch.ElapsedMilliseconds
    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem3 stopWatch.ElapsedMilliseconds
    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem4 stopWatch.ElapsedMilliseconds
    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem5 stopWatch.ElapsedMilliseconds
    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem6 stopWatch.ElapsedMilliseconds
    stopWatch.Restart()
    printfn "%d (%dms)" eu1.problem7 stopWatch.ElapsedMilliseconds
    Console.ReadKey() |> ignore
    0
