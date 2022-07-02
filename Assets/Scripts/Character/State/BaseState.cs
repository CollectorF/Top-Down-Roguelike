using System;
using UnityEngine;

[Serializable]
public class BaseState
{
    public float Speed { get; }
    public int Health { get; }
    public int MaxHealth { get; }
    public int Bonus { get; }

    public BaseState(float speed, int health, int maxHealth, int bonus)
    {
        Speed = Mathf.Clamp(speed, 0, Mathf.Infinity);
        MaxHealth = maxHealth;
        Health = Mathf.Clamp(health, 0, maxHealth);
        Bonus = (int)Mathf.Clamp(bonus, 0, Mathf.Infinity);
    }

    public BaseState(CharacterStarterInfo starerInfo) : this(starerInfo.Speed, starerInfo.MaxHealth, starerInfo.MaxHealth, starerInfo.Bonus)
    {

    }

    public virtual BaseState Mutate(
        float? speed = null,
        int? health = null,
        int? maxHealth = null,
        int? bonus = null
    )
    {
        return new BaseState(
            speed ?? Speed,
            health ?? Health,
            maxHealth ?? MaxHealth,
            bonus ?? Bonus
        );
    }
}