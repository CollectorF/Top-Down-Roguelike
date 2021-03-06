using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject gameplayUI;
    [SerializeField]
    private GameObject endUI;
    [SerializeField]
    private GameplayUI gameplayUiManager;
    [SerializeField]
    private EndUI endUiManager;


    public delegate void StartEvent();

    public event StartEvent OnStart;

    internal void ActivateStartUI()
    {
        startUI.SetActive(true);
        gameplayUI.SetActive(false);
        endUI.SetActive(false);
    }

    internal void ActivateGameplayUI()
    {
        startUI.SetActive(false);
        gameplayUI.SetActive(true);
        endUI.SetActive(false);
    }

    internal void ActivateEndUI()
    {
        startUI.SetActive(false);
        gameplayUI.SetActive(false);
        endUI.SetActive(true);
    }

    public void OnStartClick()
    {
        OnStart?.Invoke();
    }

    internal void UpdateStats(BaseState oldState, BaseState newState)
    {
        gameplayUiManager.OnStateUpdate(oldState, newState);
    }

    internal void ShowScoreboard(BaseState state, int bestScore)
    {
        endUiManager.DisplayScore(state, bestScore);
    }
}
