#I @"../../packages/FSharp.Data/lib/net40/"
// #r @"../../packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"
#r @"../../packages/Deedle/lib/net40/Deedle.dll"
#r "FSharp.Data.dll"


#load @"../../packages/FSharp.Charting/FSharp.Charting.fsx"

open FSharp.Data
open Deedle
open System
open FSharp.Charting




type WHOL = CsvProvider<"http://www.who.int/childgrowth/standards/lhfa_girls_p_exp.txt", "\t">
type WHOW = CsvProvider<"http://www.who.int/childgrowth/standards/wfa_girls_p_exp.txt", "\t">

let lhfa = WHOL.Load("http://www.who.int/childgrowth/standards/lhfa_girls_p_exp.txt")
let wfa = WHOW.Load("http://www.who.int/childgrowth/standards/wfa_girls_p_exp.txt")

let oneMth e = (fst e) <=31
let twoMth e = (fst e) <=61
let threeMth e = (fst e) <=92

let p50 = [for row in lhfa.Rows -> row.Day, row.P50]
let p25 = [for row in lhfa.Rows -> row.Day, row.P25]
let p75 = [for row in lhfa.Rows -> row.Day, row.P75]

let w50 = [for row in wfa.Rows -> row.Age, row.P50] |> List.filter twoMth
let w25 = [for row in wfa.Rows -> row.Age, row.P25] |> List.filter twoMth
let w75 = [for row in wfa.Rows -> row.Age, row.P75] |> List.filter twoMth


Chart.Combine ([
    Chart.Line (p25 |> List.filter oneMth)
    Chart.Line (p50 |> List.filter oneMth)
    Chart.Line (p75 |> List.filter oneMth)])




Chart.Combine ([
    Chart.Line (w25 )
    Chart.Line (w50)
    Chart.Line (w75)])





