#I @"../../packages/FSharp.Data/lib/net40/"
#r @"../../packages/Deedle/lib/net40/Deedle.dll"
#r "FSharp.Data.dll"


open FSharp.Data
open Deedle

type WHO = CsvProvider<"http://www.who.int/childgrowth/standards/lhfa_girls_p_exp.txt", "\t">

let lhfa = WHO.Load("http://www.who.int/childgrowth/standards/lhfa_girls_p_exp.txt")

