using UnityEngine;


public class EnemyController : BaseCharacterController
{
    public BaseState State => stats.State;
    private Animator animator;
    internal bool isDead = false;


    protected override void Awake()
    {
        base.Awake();
        OnDie += controller => isDead = true;
        animator = GetComponent<Animator>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected void Update()
    {
        if (!isDead)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude, 0.05f, Time.deltaTime);
        }
        else
        {
            agent.enabled = false;
        }
    }

    protected override void OnStateUpdate(BaseState oldState, BaseState newState)
    {
        base.OnStateUpdate(oldState, newState);
    }
}