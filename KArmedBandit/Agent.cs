namespace KArmedBandit;

public class Agent
{
    private readonly Environment _environment;
    private readonly int[] _actions;
    private readonly double _exploreProbability;
    private readonly List<int> _actionHistory = new();
    private readonly List<int> _rewardHistory = new();

    private readonly int[] _actionRewardSums;
    private readonly int[] _actionFrequency;

    public Agent(Environment environment, IEnumerable<int> actions, double exploreProbability)
    {
        _environment = environment;
        _actions = actions.ToArray();
        _exploreProbability = exploreProbability;
        
        _actionRewardSums = new int[_actions.Length];
        _actionFrequency = new int[_actions.Length];
    }

    public void TakeAction()
    {
        var actionValues =
            (from a in _actions
            select AverageActionValue(a)).ToList();

        var maxValue = actionValues.Max();
        var greedy = actionValues.IndexOf(maxValue);

        var action = GetAction(greedy);
        var reward = _environment.TakeAction(action);

        _actionFrequency[action]++;
        _actionRewardSums[action] += reward;
        _rewardHistory.Add(reward);
        _actionHistory.Add(action);
    }

    private int GetAction(int greedy)
    {
        var rand = new Random();
        var r = rand.NextDouble();

        return r > _exploreProbability ? greedy : rand.Next(0, _actions.Count());
    }

    private double AverageActionValue(int action)
    {
        if (_actionFrequency[action] == 0) return 0;

        return (double)_actionRewardSums[action] / _actionFrequency[action];
    }

    public IEnumerable<int> ActionHistory => _actionHistory;
    public IEnumerable<int> RewardHistory => _rewardHistory;
}