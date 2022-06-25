// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using KArmedBandit;
using Environment = KArmedBandit.Environment;

var env = new Environment();
var actor = new Agent(env, new[] { 0, 1, 2, 3 }, 0.05);

for (var i = 0; i < 100000; i++)
{
    actor.TakeAction();
}

var firstThousandAverage = actor.RewardHistory.Take(10).Average();
var lastThousandAverage = actor.RewardHistory.TakeLast(10).Average();

Console.WriteLine($"First 10 actions had an average reward of {firstThousandAverage}.");
Console.WriteLine($"Last 10 actions had an average reward of {lastThousandAverage}.");