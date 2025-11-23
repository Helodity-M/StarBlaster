using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreTracker.Instance.score.ToString();
    }
}
