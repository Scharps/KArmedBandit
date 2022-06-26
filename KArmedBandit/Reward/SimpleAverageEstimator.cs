namespace KArmedBandit.Reward;

public class SimpleAverageEstimator : IRewardEstimator
{
    private readonly int _initialActionValue;
    private readonly int[] _actionRewardSums;
    private readonly int[] _actionFrequency;

    public SimpleAverageEstimator(IEnumerable<int> actions, int initialActionValue = 0)
    {
        var actionLength = actions.Count();
        _initialActionValue = initialActionValue;
        _actionRewardSums = new int[actionLength];
        _actionFrequency = new int[actionLength];
    }
    
    public double EstimatedReward(int action)
    {
        if (_actionFrequency[action] == 0) return _initialActionValue;

        return (double)_actionRewardSums[action] / _actionFrequency[action];
    }

    public void AddReward(int action, int reward)
    {
        _actionRewardSums[action] += reward;
        _actionFrequency[action]++;
    }
}