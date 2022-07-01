using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Running,
    End
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private GameState gameState;
    private BaseCharacterController[] characterControllers;
    private RandomPointGenerator[] pointGenerators;

    private void Awake()
    {
        uiManager.OnStart += StartGame;
        characterControllers = FindObjectsOfType<BaseCharacterController>();
        pointGenerators = FindObjectsOfType<RandomPointGenerator>();
        foreach (var item in characterControllers)
        {
            item.isActive = false;
        }
    }

    private void Start()
    {
        gameState = GameState.Start;
        uiManager.ActivateStartUI();
    }

    private void StartGame()
    {
        gameState = GameState.Running;
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
}
