module Bowling.BowlingGame

open System

let IsValidRoll x = x >= 0 && x <= 10

type public Roll(score:int) =
    do if score |> IsValidRoll |> not then "score" |> ArgumentOutOfRangeException |> raise
    member val public Score = score

let IsStrike (x:Roll) = x.Score = 10
let IsSpare (l:Roll list) =
    match l with
    | [x; y] -> IsValidRoll y.Score
                && x |> IsStrike |> not
                && x.Score + y.Score = 10
    | _ -> false

let IsValidCombination (l:Roll list) =
    match l with
    | [x; y] -> l |> IsSpare || (x.Score + y.Score) |> IsValidRoll
    | [x] -> IsStrike x
    | _ -> false

[<AbstractClass>]
type public GameState(rolls:Roll list) =
    let score = lazy(
        let rec GetScoreRec (pins:Roll list) currentScore =
            match pins with
            | [] -> currentScore
            | [s; x; y] when IsStrike s -> currentScore + 10 + x.Score + y.Score
            | [x; y; z] when IsSpare [x; y] -> currentScore + 10 + z.Score
            | s::x::y::t when IsStrike s -> (currentScore + 10 + x.Score + y.Score) |> GetScoreRec (x::y::t)
            | x::y::z::t when IsSpare [x; y] -> (currentScore + 10 + z.Score) |> GetScoreRec (z::t)
            | x::y::t when [x; y] |> IsValidCombination -> (currentScore + x.Score + y.Score) |> GetScoreRec t
            | x::t when IsValidRoll x.Score -> (currentScore + x.Score) |> GetScoreRec t
            | _ -> InvalidOperationException() |> raise
        GetScoreRec rolls 0)
    
    member val public Rolls = rolls
    member public __.Score with get() = score.Value

type public InGameState(rolls:Roll list) =
    inherit GameState(rolls)
    member public __.Roll(pins:Roll) =
        (rolls, [pins])
        ||> List.append
        |> InGameState

type public NewGameState private() =
    inherit GameState([])
    static let _instance = NewGameState()
    static member public Instance with get() = _instance
    member public __.Roll(pins:Roll) = [pins] |> InGameState

type public Game = NotStarted | NewGame of state:NewGameState | InGame of state:InGameState
