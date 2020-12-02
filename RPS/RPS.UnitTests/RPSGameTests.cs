using System;
using Xunit;

namespace RPS.UnitTests
{
    public class RPSGameTests
    {
        [Theory]
        [InlineData("r")]
        [InlineData("p")]
        [InlineData("s")]
        public void PlayingTiesShouldReturnTieAndUpdateScore(string move)
        {
            // structuring a good unit test

            // 1. arrange
            var game = new RPSgame();
            var score = new Score();
            int initialLossCount = score.lossCount;
            int initialWinCount = score.winCount;
            int initialTieCount = score.tieCount;

            // 2. act
            string result = game.Play(move, move, score);

            // 3. assert
            Assert.Equal("tie", result);
            Assert.Equal(0, score.lossCount - initialLossCount);
            Assert.Equal(0, score.winCount - initialWinCount);
            Assert.Equal(1, score.tieCount - initialTieCount);

        }
    }
}
