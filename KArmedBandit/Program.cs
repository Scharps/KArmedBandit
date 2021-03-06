using KArmedBandit;
using KArmedBandit.Reward;
using Environment = KArmedBandit.Environment;

var actions = new[] { 0, 1, 2, 3 };
var env = new Environment();
IRewardEstimator estimator = new RecencyWeightedAverageEstimator(actions, 0.9);
var agent = new Agent(env, estimator, actions, 0.1);

for (var i = 0; i < 100; i++)
{
    agent.TakeAction();
}

var firstThousandAverage = env.RewardHistory.Take(10).Average();
var lastThousandAverage = env.RewardHistory.TakeLast(10).Average();

Console.WriteLine($"First 10 actions had an average reward of {firstThousandAverage}.");
Console.WriteLine($"Last 10 actions had an average reward of {lastThousandAverage}.");