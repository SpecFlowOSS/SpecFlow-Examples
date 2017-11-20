namespace Bowling.Extensions

open System.Runtime.CompilerServices
open Bowling.Game
open JetBrains.Annotations

[<Extension>]
type public RollListExtensions () =
    [<Pure>]
    static let rec GetScoreRec (rolls:Roll list) currentScore : int option =
        match rolls with
        | [] -> Some currentScore
        | [s; x; y] when IsStrike s -> (currentScore + 10 + x.Score + y.Score) |> Some
        | [x; y; z] when IsSpare [x; y] -> (currentScore + 10 + z.Score) |> Some
        | s::x::y::t when IsStrike s -> (currentScore + 10 + x.Score + y.Score) |> GetScoreRec (x::y::t)
        | x::y::z::t when IsSpare [x; y] -> (currentScore + 10 + z.Score) |> GetScoreRec (z::t)
        | x::y::t when [x; y] |> IsValidCombination -> (currentScore + x.Score + y.Score) |> GetScoreRec t
        | x::t when IsValidRoll x.Score -> (currentScore + x.Score) |> GetScoreRec t
        | _ -> None

    [<Extension>]
    [<Pure>]
    static member public GetScore(self : Roll list) = GetScoreRec self 0
