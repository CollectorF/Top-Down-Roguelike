using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private string SCORE = "Score";

    public void LoadPlayerPrefs(out int score)
    {
        score = PlayerPrefs.GetInt(SCORE, 0);
    }

    public void SavePlayerPrefs(int score)
    {
        PlayerPrefs.SetInt(SCORE, score);
        PlayerPrefs.Save();
    }
}
