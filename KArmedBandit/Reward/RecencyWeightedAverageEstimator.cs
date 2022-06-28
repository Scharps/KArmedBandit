namespace KArmedBandit.Reward;

public class RecencyWeightedAverageEstimator : IRewardEstimator
{
    private readonly double _stepSize;
    private readonly double[] _rewardEstimation;
    private double _beta;

    public RecencyWeightedAverageEstimator(IEnumerable<int> actions, double stepSize, int initialActionValue = 0)
    {
        _stepSize = stepSize;
        var actionLength = actions.Count();
        _rewardEstimation = new double[actionLength];
        Array.Fill(_rewardEstimation, initialActionValue);
    }
    public double EstimatedReward(int action)
    {
        return _rewardEstimation[action];
    }

    public void AddReward(int action, int reward)
    {
        _beta += _stepSize * (1 - _beta);
        var variableStepSize = _stepSize / _beta;
        _rewardEstimation[action] += variableStepSize * (reward - _rewardEstimation[action]);
    }
}