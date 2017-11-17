module Bowling.SpecFlow.StepDefinitions

open Bowling.SpecFlow.Drivers
open TechTalk.SpecFlow

[<Binding>]
type public BowlingSteps(driver : BowlingDriver) =
    let _driver : BowlingDriver = driver
    let [<Given>]``a new bowling game``() =
       _driver.NewGame()

    let [<When>]``all of my balls are landing in the gutter``() =
        _driver.Throw(0, 20)

    let [<When>]``all of my rolls are strikes``() =
        _driver.Throw(10, 12)
     
    let [<Then>]``my total score should be (\d+)`` score =
        _driver.CheckScore score

    let [<When>]``I roll (\d+)`` pins =
         _driver.Throw(pins, 1)
     
    let [<When>]``I roll (\d+) and (\d+)`` pins1 pins2 =
        _driver.Throw(pins1, pins2, 1)
     
    let [<When>]``I roll (\d+) times (\d+) and (\d+)`` count pins1 pins2 =
        _driver.Throw(pins1, pins2, count)
     
    let [<When>]``I roll the following series:(.*)`` (series:string) =
        _driver.ThrowSeries(series)
     
    let [<When>]``I roll`` (rolls:Table) =
        _driver.ThrowSeries(rolls)