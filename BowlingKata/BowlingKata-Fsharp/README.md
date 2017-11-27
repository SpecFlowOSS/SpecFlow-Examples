# BowlingKata-Fsharp example

This example demonstrates using [SpecFlow](http://specflow.org) 2.2.x within F#.

Please read the [SpecFlow documentation page](http://specflow.org/documentation/FSharp-Support/) for a general description of how to create SpecFlow tests with F#.

Maybe you have wondered why you should use a functional-first language for SpecFlow-tests (or unit tests in general).
Besides giving an example of how to work with F# and SpecFlow, this question should also be answered.

As this is not simply a port of the other *BowlingKata* examples using C# or VB, the program flow is different.
For example, the `Bowling` library is written nearly entirely in a functional style.
The step definitions in the `Bowling.SpecFlow` library use some syntactic sugar provided by F# to improve readability.

In difference to the other BowlingKata example solutions in this repo, this example needs three projects:

* Bowling
* Bowling.SpecFlow
* Bowling.SpecFlow.Bindings

## Bowling

This project provides the game logic.
It is written entirely in F#.

The code behind the game is strongly F#-flavored.
The `Game` type is not a class in an object-oriented sense.
No mutable data is stored in the game state and no member methods are defined.
Instead, the `Game` type is an union type that holds different data for each situation of the game.
The only way to create a new game state is by using data from the old one and/or adding new data, like a new roll score.
This ensures data consistency and immutability.
Additionally, it makes it easier to implement tracing and backtracking logic.

In contrast to other code parts in this library, the `RoundListExtensions` type is a static class.
It defines the `GetScore : Round list -> int` extension method.
That means, that you can invoke this method like a member, and the compiler rewrites it automatically to a direct invocation of the static method.
Of course, you can still invoke the original static method, but if you do so, you need to pass the value as an argument to the method.

The concept of *Extension methods* is possibly already familiar to you if you write a lot of C# code.
For example, most classes in the `System.Linq` namespace define extension methods for the `IEnumerable<T>` interface.

As described above, this is a more object-oriented approach rather than a functional one.
The reason for preferring this code construct over F# type extensions is, that it it the only way to define an extension for a generic type (like `'a list`) with a defined type parameter (like `int list`) in the current F# version.

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
