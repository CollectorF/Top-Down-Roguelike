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
    [SerializeField]
    private InputAction posInputAction;

    private Camera playerCamera;
    private Vector3 aimPoint;
    private Vector3 tapPoint;

    public PlayerState State => (PlayerState)stats.State;

    protected override void Awake()
    {
        base.Awake();
        clickInputAction.Enable();
        posInputAction.Enable();
        clickInputAction.performed += OnClick;
        playerCamera = GetComponentInChildren<Camera>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnDisable()
    {
        clickInputAction.performed -= OnClick;
        clickInputAction.Disable();
        posInputAction.Disable();
    }

    protected override BaseState InitializeState()
    {
        return new PlayerState(starterInfo);
    }

    public void OnClick(InputAction.CallbackContext callback)
    {
#if UNITY_ANDROID || UNITY_IOS
        tapPoint = Touchscreen.current.primaryTouch.position.ReadValue();
#elif UNITY_STANDALONE
        tapPoint = Mouse.current.position.ReadValue();
#endif
        tapPoint += playerCamera.transform.forward * 10f;
        aimPoint = playerCamera.ScreenToWorldPoint(tapPoint);
        agent.SetDestination(aimPoint);
    }
}