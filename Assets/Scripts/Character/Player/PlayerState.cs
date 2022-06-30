public class PlayerState : BaseState
{
    public PlayerState(float speed, float health, float maxHealth, float bonus) : base(speed, health, maxHealth, bonus)
    {
    }

    public PlayerState(CharacterStarterInfo starerInfo) : base(starerInfo)
    {
    }

    public override BaseState Mutate(
        float? speed = null,
        float? health = null,
        float? maxHealth = null,
        float? bonus = null)
    {
        return new PlayerState(
            speed ?? Speed,
            health ?? Health,
            maxHealth ?? MaxHealth,
            bonus ?? Bonus
        );
    }
}