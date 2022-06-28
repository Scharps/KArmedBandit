namespace KArmedBandit;

public class Environment
{
    private int _time;
    private readonly List<int> _actionHistory = new();
    private readonly List<int> _rewardHistory = new();

    public int TakeAction(int action)
    {
        _actionHistory.Add(action);
        _time++;
        var reward = RewardForAction(action);
        _rewardHistory.Add(reward);
        return reward;
    }

    private static int RewardForAction(int action)
    {
        var rand = new Random();
        return action switch
        {
            0 => rand.Next(0, 10),
            1 => rand.Next(1, 10),
            2 => rand.Next(5, 8),
            3 => rand.Next(-2, 7),
            _ => throw new ArgumentException($"{nameof(action)} is not in range of available actions.")
        };
    }

    public int Time => _time;
    public IEnumerable<int> ActionHistory => _actionHistory;
    public IEnumerable<int> RewardHistory => _rewardHistory;
}