using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;

    internal void DisplayScore(BaseState state, int bestScore)
    {
        scoreText.text = $"Score: {state.Bonus}";
        bestScoreText.text = $"Best: {bestScore}";
    }
}
