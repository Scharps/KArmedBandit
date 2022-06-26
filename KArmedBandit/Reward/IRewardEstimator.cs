namespace KArmedBandit.Reward;

public interface IRewardEstimator
{
    public double EstimatedReward(int action);
    public void AddReward(int action, int reward);
}