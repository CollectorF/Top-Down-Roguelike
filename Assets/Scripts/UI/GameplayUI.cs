using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI lifesText;

    private float tolerance = 0.001f;

    private void UpdateScore(float value)
    {
        scoreText.text = $"Score: {value}";
    }

    private void UpdateLifes(float value, float maxValue)
    {
        lifesText.text = $"Lives: {value}/{maxValue}";
    }

    internal void OnStateUpdate(BaseState oldState, BaseState newState)
    {
        if (oldState == null ||
            Mathf.Abs(oldState.Health - newState.Health) > tolerance ||
            Mathf.Abs(oldState.Bonus - newState.Bonus) > tolerance)
        {
            UpdateScore(newState.Bonus);
            UpdateLifes(newState.Health, newState.MaxHealth);
        }
    }
}
