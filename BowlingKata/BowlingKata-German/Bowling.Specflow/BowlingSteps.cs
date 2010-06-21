
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Bowling.Specflow
{
    [Binding]
    public class BowlingSteps
    {
        private Game _game;

        [Given(@"eine neue Bowling Partie")]
        public void GivenANewBowlingGame()
        {
            _game = new Game();
        }

        [When(@"alle meine Kugeln in der Seitenrinne landen")]
        public void WhenAllOfMyBallsAreLandingInTheGutter()
        {
            for (int i = 0; i < 20; i++)
            {
                _game.Roll(0);
            }
        }

        [When(@"ich alles Strikes werfe")]
        public void WhenAllOfMyRollsAreStrikes()
        {
            for (int i = 0; i < 12; i++)
            {
                _game.Roll(10);
            }
        }

        [Then(@"soll meine Punktzahl (\d+) sein")]
        public void ThenMyTotalScoreShouldBe(int score)
        {
            Assert.AreEqual(score, _game.Score);
        }

        [When(@"ich (\d+) werfe")]
        public void WhenIRoll(int pins)
        {
            _game.Roll(pins);
        }

        [When(@"ich (\d+) und (\d+) werfe")]
        public void WhenIRoll(int pins1, int pins2)
        {
            _game.Roll(pins1);
            _game.Roll(pins2);
        }

        [When(@"ich (\d+) mal (\d+) und (\d+) werfe")]
        public void WhenIRollSeveralTimes2(int rollCount, int pins1, int pins2)
        {
            for (int i = 0; i < rollCount; i++)
            {
                _game.Roll(pins1);
                _game.Roll(pins2);
            }
        }

        [When(@"ich die folgende Serie werfe:(.*)")]
        public void WhenIRollTheFollowingSeries(string series)
        {
            foreach (var roll in series.Trim().Split(','))
            {
                _game.Roll(int.Parse(roll));
            }
        }

        [When(@"I roll")]
        public void WhenIRoll(Table rolls)
        {
            foreach (var row in rolls.Rows)
            {
                _game.Roll(int.Parse(row["Pins"]));
            }
        }
    }
}
