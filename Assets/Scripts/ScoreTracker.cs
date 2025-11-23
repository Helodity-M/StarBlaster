using UnityEngine;

public class ScoreTracker : PersistentSingleton<ScoreTracker>
{
    public int score { get; private set; }


    public void AddScore(int amount)
    {
        score = Mathf.Max(score + amount, 0);
    }
}
