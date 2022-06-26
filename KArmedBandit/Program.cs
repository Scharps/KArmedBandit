using KArmedBandit;
using KArmedBandit.Reward;
using Environment = KArmedBandit.Environment;

var actions = new[] { 0, 1, 2, 3 };
var env = new Environment();
IRewardEstimator estimator = new SimpleAverageEstimator(actions, 10);
var actor = new Agent(env, estimator, actions);

for (var i = 0; i < 1000; i++)
{
    actor.TakeAction();
}

var firstThousandAverage = actor.RewardHistory.Take(10).Average();
var lastThousandAverage = actor.RewardHistory.TakeLast(10).Average();

Console.WriteLine($"First 10 actions had an average reward of {firstThousandAverage}.");
Console.WriteLine($"Last 10 actions had an average reward of {lastThousandAverage}.");

foreach (var action in actor.ActionHistory)
{
    Console.Write(action);
}