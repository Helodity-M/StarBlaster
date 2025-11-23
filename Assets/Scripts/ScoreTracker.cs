using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score { get; private set; }


    public void AddScore(int amount)
    {
        score = Mathf.Max(score + amount, 0);
    }
}
