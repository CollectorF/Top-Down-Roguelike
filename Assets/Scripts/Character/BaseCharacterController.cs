using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(StatsSystem))]
[RequireComponent(typeof(NavMeshAgent))]
public class BaseCharacterController : MonoBehaviour
{
    [SerializeField]
    protected CharacterStarterInfo starterInfo;

    protected StatsSystem stats; 
    protected NavMeshAgent agent;

    public delegate void DieEvent(BaseCharacterController controller);

    public event DieEvent OnDie;

    protected virtual void Awake()
    {
        stats = GetComponent<StatsSystem>();
        agent = GetComponent<NavMeshAgent>();
        stats.OnStateChanged += OnStateUpdate;
    }

    protected virtual void Start()
    {
        stats.State = InitializeState();
        agent.enabled = true;
    }

    protected virtual BaseState InitializeState()
    {
        return new BaseState(starterInfo);
    }

    protected virtual void OnStateUpdate(BaseState oldState, BaseState newState)
    {
        if (newState.Health <= 0)
        {
            OnDie?.Invoke(this);
        }
    }
}