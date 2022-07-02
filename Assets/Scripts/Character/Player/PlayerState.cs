public class PlayerState : BaseState
{
    public PlayerState(float speed, int health, int maxHealth, int bonus) : base(speed, health, maxHealth, bonus)
    {
    }

    public PlayerState(CharacterStarterInfo starerInfo) : base(starerInfo)
    {
    }

    public override BaseState Mutate(
        float? speed = null,
        int? health = null,
        int? maxHealth = null,
        int? bonus = null)
    {
        return new PlayerState(
            speed ?? Speed,
            health ?? Health,
            maxHealth ?? MaxHealth,
            bonus ?? Bonus
        );
    }
}