Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TechTalk.SpecFlow
Imports Bowling.Bowling

Namespace Bowling.Specflow
    <Binding()> _
    Public Class BowlingSteps
        Private _game As Game

        <Given("a new bowling game")> _
        Public Sub GivenANewBowlingGame()
            _game = New Game()
        End Sub

        <[When]("all of my balls are landing in the gutter")> _
        Public Sub WhenAllOfMyBallsAreLandingInTheGutter()
            For i As Integer = 0 To 19
                _game.Roll(0)
            Next
        End Sub

        <[When]("all of my rolls are strikes")> _
        Public Sub WhenAllOfMyRollsAreStrikes()
            For i As Integer = 0 To 11
                _game.Roll(10)
            Next
        End Sub

        <[Then]("my total score should be (\d+)")> _
        Public Sub ThenMyTotalScoreShouldBe(ByVal score As Integer)
            Assert.AreEqual(score, _game.Score)
        End Sub

        <[When]("I roll (\d+)")> _
        Public Sub WhenIRoll(ByVal pins As Integer)
            _game.Roll(pins)
        End Sub

        <[When]("I roll (\d+) and (\d+)")> _
        Public Sub WhenIRoll(ByVal pins1 As Integer, ByVal pins2 As Integer)
            _game.Roll(pins1)
            _game.Roll(pins2)
        End Sub

        '        [When(@"(\d+) times I roll (\d+) and (\d+)")]
        '        public void WhenIRollSeveralTimes(int rollCount, int pins1, int pins2)
        '        {
        '            for (int i = 0; i < rollCount; i++)
        '            {
        '                _game.Roll(pins1);
        '                _game.Roll(pins2);
        '            }
        '        }

        <[When]("I roll (\d+) times (\d+) and (\d+)")> _
        Public Sub WhenIRollSeveralTimes2(ByVal rollCount As Integer, ByVal pins1 As Integer, ByVal pins2 As Integer)
            For i As Integer = 0 To rollCount - 1
                _game.Roll(pins1)
                _game.Roll(pins2)
            Next
        End Sub

        <[When]("I roll the following series:(.*)")> _
        Public Sub WhenIRollTheFollowingSeries(ByVal series As String)
            For Each roll As String In series.Trim().Split(","c)
                _game.Roll(Integer.Parse(roll))
            Next
        End Sub

        <[When]("I roll")> _
        Public Sub WhenIRoll(ByVal rolls As Table)
            For Each row As TableRow In rolls.Rows
                _game.Roll(Integer.Parse(row("Pins")))
            Next
        End Sub
    End Class
End Namespace


