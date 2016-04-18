#I @"../../packages/FSharp.Data/lib/net40/"
// #r @"../../packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"
#r @"../../packages/Deedle/lib/net40/Deedle.dll"
#r "FSharp.Data.dll"


#load @"../../packages/FSharp.Charting/FSharp.Charting.fsx"

open FSharp.Data
open Deedle
open System
open FSharp.Charting




type WHO = CsvProvider<"http://www.who.int/childgrowth/standards/lhfa_girls_p_exp.txt", "\t">

let lhfa = WHO.Load("http://www.who.int/childgrowth/standards/lhfa_girls_p_exp.txt")

let p50 = [for row in lhfa.Rows -> row.Day, row.P50]
let p25 = [for row in lhfa.Rows -> row.Day, row.P25]
let p75 = [for row in lhfa.Rows -> row.Day, row.P75]

Chart.Combine ([
    Chart.FastLine p25
    Chart.FastLine p50
    Chart.FastLine p75])


