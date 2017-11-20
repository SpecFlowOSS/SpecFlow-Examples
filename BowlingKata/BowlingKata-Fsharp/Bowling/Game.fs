module Bowling.Game

open System
open JetBrains.Annotations

[<Pure>]
let IsValidRoll x = x >= 0 && x <= 10

type public Roll(score:int) =
    do if score |> IsValidRoll |> not then "score" |> ArgumentOutOfRangeException |> raise
    member val public Score = score

[<Pure>]
let IsStrike (x:Roll) = x.Score = 10

[<Pure>]
let IsSpare (l:Roll list) =
    match l with
    | [_; _] ->
        l |> List.forall (fun e -> IsValidRoll(e.Score) && not(IsStrike(e)))
        && l |> List.sumBy (fun e -> e.Score) = 10
    | _ -> false

[<Pure>]
let IsValidCombination (l:Roll list) =
    match l with
    | [x] -> IsStrike x
    | [x; y] -> (x.Score + y.Score) |> IsValidRoll
    | _ -> false

type public Game =
    | NotStarted
    | NewGame of Next : (Roll -> Game)
    | InGame of Rolls : Roll list * Next : (Roll -> Roll list -> Game)

[<Pure>]
let rec NextInGame roll (rolls : Roll list) = InGame([roll] |> List.append rolls, NextInGame)

[<Pure>]
let inline NextNewGame roll = InGame([roll], NextInGame)
