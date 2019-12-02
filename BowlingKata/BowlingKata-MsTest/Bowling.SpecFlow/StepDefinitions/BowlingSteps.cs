using Bowling.SpecFlow.Drivers;
using TechTalk.SpecFlow;

namespace Bowling.SpecFlow.StepDefinitions
{
    [Binding]
    public class BowlingSteps
    {
        private readonly BowlingDriver _bowlingDriver;

        public BowlingSteps(BowlingDriver bowlingDriver)
        {
            _bowlingDriver = bowlingDriver;
        }

        [Given(@"a new bowling game")]
        public void GivenANewBowlingGame()
        {
            _bowlingDriver.NewGame();
        }

        [When(@"all of my balls are landing in the gutter")]
        public void WhenAllOfMyBallsAreLandingInTheGutter()
        {
            _bowlingDriver.Roll(0, 20);
        }

        [When(@"all of my rolls are strikes")]
        public void WhenAllOfMyRollsAreStrikes()
        {
            _bowlingDriver.Roll(10, 12);
        }

        [Then(@"my total score should be (\d+)")]
        public void ThenMyTotalScoreShouldBe(int score)
        {
            _bowlingDriver.CheckScore(score);
        }

        [When(@"I roll (\d+)")]
        public void WhenIRoll(int pins)
        {
            _bowlingDriver.Roll(pins, 1);
        }

        [When(@"I roll (\d+) and (\d+)")]
        public void WhenIRoll(int pins1, int pins2)
        {
            _bowlingDriver.Roll(pins1, pins2, 1);
        }

        [When(@"I roll (\d+) times (\d+) and (\d+)")]
        public void WhenIRollSeveralTimes2(int rollCount, int pins1, int pins2)
        {
            _bowlingDriver.Roll(pins1, pins2, rollCount);
        }

        [When(@"I roll the following series:(.*)")]
        public void WhenIRollTheFollowingSeries(string series)
        {
            _bowlingDriver.RollSeries(series);
        }

        [When(@"I roll")]
        public void WhenIRoll(Table rolls)
        {
            _bowlingDriver.RollSeries(rolls);
        }
    }
}
