using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerPrefsManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private BaseCharacterController[] characterControllers;
    private RandomPointGenerator[] pointGenerators;

    private BaseState currentPlayerState;
    private PlayerPrefsManager prefsManager;

    private int bestScore;

    private void Awake()
    {
        uiManager.OnStart += StartGame;
        characterControllers = FindObjectsOfType<BaseCharacterController>();
        pointGenerators = FindObjectsOfType<RandomPointGenerator>();
        prefsManager = GetComponent<PlayerPrefsManager>();
        foreach (var item in characterControllers)
        {
            item.isActive = false;
        }
    }

    private void Start()
    {
        uiManager.ActivateStartUI();
        prefsManager.LoadPlayerPrefs(out bestScore);
    }

    public void StartGame()
    {
        uiManager.ActivateGameplayUI();
        foreach (var item in characterControllers)
        {
            item.isActive = true;
        }
        foreach (var item in pointGenerators)
        {
            item.SetRandomDestination();
        }
    }

    internal void UpdateStats(BaseState oldState, BaseState newState)
    {
        uiManager.UpdateStats(oldState, newState);
        currentPlayerState = newState;
    }

    internal void EndGame(BaseCharacterController controller)
    {
        if (currentPlayerState.Bonus > bestScore)
        {
            bestScore = currentPlayerState.Bonus;
        }
        prefsManager.SavePlayerPrefs(bestScore);
        controller.isActive = false;
        uiManager.ShowScoreboard(currentPlayerState, bestScore);
        uiManager.ActivateEndUI();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
