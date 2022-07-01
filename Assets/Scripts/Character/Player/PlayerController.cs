using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : BaseCharacterController
{
    [SerializeField]
    private InputAction clickInputAction;

    internal bool isDead = false;
    private Camera playerCamera;
    private Vector3 tapPoint;
    private GameManager gameManager;

    public PlayerState State => (PlayerState)stats.State;

    protected override void Awake()
    {
        base.Awake();
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError($"GameManager cannot be found on scene, make sure you've created it");
        }
        OnDie += controller => isDead = true;
        clickInputAction.Enable();
        clickInputAction.performed += OnClick;
        playerCamera = Camera.main;
        stats.OnStateChanged += gameManager.UpdateStats;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnDisable()
    {
        clickInputAction.performed -= OnClick;
        clickInputAction.Disable();
    }

    protected override BaseState InitializeState()
    {
        return new PlayerState(starterInfo);
    }

    public void OnClick(InputAction.CallbackContext callback)
    {
        if (isActive)
        {
#if UNITY_ANDROID || UNITY_IOS
            tapPoint = Touchscreen.current.primaryTouch.position.ReadValue();
#elif UNITY_STANDALONE
            tapPoint = Mouse.current.position.ReadValue();
#endif
            Ray ray = playerCamera.ScreenPointToRay(tapPoint);
            if (Physics.Raycast(ray, out RaycastHit raycastHitInfo))
            {
                agent.SetDestination(raycastHitInfo.point);
            }
        }
    }
}