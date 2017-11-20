﻿namespace Bowling.SpecFlow.Drivers

open System
open Bowling.Game
open Bowling.Extensions
open FluentAssertions;
open TechTalk.SpecFlow

type public BowlingDriver() =
    let mutable _currentGame : Game = NotStarted;

    member public __.NewGame() = _currentGame <- NewGame NextNewGame

    member public this.Throw(pins, rollCount) : unit =
        if rollCount > 1 then this.Throw(pins, rollCount - 1)
        _currentGame <- match _currentGame with
                        | NotStarted -> "Game has not been started" |> InvalidOperationException |> raise
                        | NewGame next -> pins |> Roll |> next
                        | InGame(rolls, next) -> next (pins |> Roll) rolls

    member public this.Throw(pins1, pins2, rollCount) : unit =
        match rollCount with
        | 0 -> ()
        | x when x > 0 -> this.Throw(pins1, 1)
                          this.Throw(pins2, 1)
                          this.Throw(pins1, pins2, rollCount - 1)
        | _ -> "rollCount" |> ArgumentOutOfRangeException |> raise
    
    member public this.ThrowSeries(series:string) : unit =
        series.Trim().Split(',')
        |> Seq.map Int32.Parse
        |> Seq.map (fun x -> (x, 1))
        |> Seq.iter this.Throw
    
    member public this.ThrowSeries(series:Table) : unit =
        series.Rows
        |> Seq.map (fun r -> r.Item("Pins"))
        |> Seq.map Int32.Parse
        |> Seq.map (fun x -> (x, 1))
        |> Seq.iter this.Throw

    member public __.CheckScore expected : unit =
        let actualScore =
            match _currentGame with
            | NotStarted -> None
            | NewGame _ -> None
            | InGame (rolls, _) -> rolls.GetScore()

        match actualScore with
        | Some a -> a.Should<int>().Be(expected, String.Empty) |> ignore
        | None -> (0).Should<int>().Be(expected, String.Empty) |> ignore