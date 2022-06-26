namespace KArmedBandit;

public class Environment
{
    private int _time;

    public int TakeAction(int action)
    {
        _time++;
        return RewardForAction(action);
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
}