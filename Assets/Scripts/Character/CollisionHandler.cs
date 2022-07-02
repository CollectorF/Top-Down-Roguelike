using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private GameObject collisionObject;
    private StatsSystem statsSystem;
    private BaseCharacterController controller;

    public delegate void OnCollideWithoutStatSystem(GameObject enteredObject);
    public delegate void OnEffectedActivated(StatsSystem activatedStatsSystem);

    public event OnCollideWithoutStatSystem OnCollide;
    public event OnEffectedActivated OnActivate;

    private void Awake()
    {
        controller = GetComponent<BaseCharacterController>();
    }

    private int healthChangeValue
    {
        get => controller.starterInfo.Damage * -1;
    }
    private int bonusChangeValue
    {
        get => controller.starterInfo.Bonus;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionObject = collision.gameObject;
        statsSystem = collisionObject.GetComponent<StatsSystem>();
        if (statsSystem == null)
        {
            OnCollide?.Invoke(collisionObject);
            return;
        }
        
        OnActivate?.Invoke(statsSystem);
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (gameObject.tag)
            {
                case "Enemy":
                    statsSystem.ApplyStateChange(GetHeahthStateChange());
                    break;
                case "Friend":
                    statsSystem.ApplyStateChange(GetBonusStateChange());
                    break;
                default:
                    break;
            }
        }
    }

    private BaseStateChange GetHeahthStateChange()
    {
        return new HealthStateChange(healthChangeValue);
    }

    private BaseStateChange GetBonusStateChange()
    {
        return new BonusStateChange(bonusChangeValue);
    }
}
