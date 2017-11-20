# BowlingKata-Fsharp example

This example demonstrates using [SpecFlow](http://specflow.org) 2.2.x within F#.

Please read the [SpecFlow documentation page](http://specflow.org/documentation/FSharp-Support/) for a general description of how to create SpecFlow tests with F#.

Maybe you have wondered why you should use a functional-first language for SpecFlow-tests (or unit tests in general).
Besides giving an example of how to work with F# and SpecFlow, this question should also be answered.

As this is not simply a port of the other *BowlingKata* examples using C# or VB, the program flow is different.
For example, the `Game` module is written in a rather functional style.
All methods (besides object constructors) in the `Game` module are pure functions.
Further, the step definitions are written using some syntactic sugar provided by F#.

In difference to the other BowlingKata example solutions in this repo, this example needs three projects:

* Bowling
* Bowling.SpecFlow
* Bowling.SpecFlow.Bindings


## Bowling

This project provides the game logic.
It is written entirely in F#.

The code behind the game is strongly F#-flavored.
The `Game` object itself is immutable.
Additionally, it is not a class in senses of C# or VB.
Instead, it is an option type that holds different data for each game state.
To get to the next round, the `Roll()` method of `NewGameState` or `InGameState` must be invoked.
In difference to the other implementations in C# or VB, this method returns the new game state.
This ensures data consistency and immutability.


## Bowling.SpecFlow

As shown in the other examples, the *Bowling.SpecFlow* project holds the step definitions and the drivers.
This project demonstrates some huge benefits of F# for writing steps.

Consider the following C# step definition from *BowlingKata-XUnit*:

```C#
[When(@"all of my rolls are strikes")]
public void WhenAllOfMyRollsAreStrikes()
{
    _driver.Roll(10, 12);
}
```

In F#, you can write arbitrary strings as well as regular expressions as method names.
The following snippet is functionally identical for SpecFlow to the one above.

```F#
let [<When>]``all of my rolls are strikes``() =
    _driver.Throw(10, 12)
```

But that's not the whole story.
SpecFlow can use the regex name of a method marked with `GivenAttribute`, `WhenAttribute` or `ThenAttribute` in the same way as the attribute parameter.

Consider the following examples:

```F#
let [<Then>]``my total score should be (\d+)`` score =
    _driver.CheckScore score
```

is handled by SpecFlow in the same way as

```F#
[<Then("my total score should be (\d+)")>]
let MyTotalScoreShouldBe score =
    _driver.CheckScore score
```


## Bowling.SpecFlow.Bindings

This project contains the feature files defining the user stories, as well as the code bindings.
Because SpecFlow v2.2.x is not capable of generating code-behind files in F#, this C# project is needed for working with SpecFlow in F#.
This project does not contain code written by a developer, as it is only necessary for generating the code bindings for the feature files.
