using KArmedBandit.Reward;

namespace KArmedBandit;

public class Agent
{
    private readonly Environment _environment;
    private readonly IRewardEstimator _rewardEstimator;
    private readonly int[] _actions;
    private readonly double _exploreProbability;

    public Agent(Environment environment, IRewardEstimator rewardEstimator, IEnumerable<int> actions, double exploreProbability = 0)
    {
        _environment = environment;
        _rewardEstimator = rewardEstimator;
        _actions = actions.ToArray();
        _exploreProbability = exploreProbability;
    }

    public void TakeAction()
    {
        var actionValues =
            (from a in _actions
            select _rewardEstimator.EstimatedReward(a)).ToList();

        var maxValue = actionValues.Max();
        var greedy = actionValues.IndexOf(maxValue);

        var action = GetAction(greedy);
        var reward = _environment.TakeAction(action);
        
        _rewardEstimator.AddReward(action, reward);
    }

    private int GetAction(int greedy)
    {
        var rand = new Random();
        var r = rand.NextDouble();

        return r > _exploreProbability ? greedy : rand.Next(0, _actions.Count());
    }
}