using UnityEngine;


public class EnemyController : BaseCharacterController
{
    public BaseState State => stats.State;
    internal bool isDead = false;


    protected override void Awake()
    {
        base.Awake();
        OnDie += controller => isDead = true;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnStateUpdate(BaseState oldState, BaseState newState)
    {
        base.OnStateUpdate(oldState, newState);
    }
}