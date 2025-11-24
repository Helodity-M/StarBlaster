using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITracker : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider HealthUI;

    [Header("Score")]
    [SerializeField] TMP_Text ScoreUI;

    private void Awake()
    {
        HealthUI.maxValue = playerHealth.health;
    }
    private void Update()
    {
        HealthUI.value = playerHealth.health;
        ScoreUI.text = $"Score: {ScoreTracker.Instance.score}";
    }


}
