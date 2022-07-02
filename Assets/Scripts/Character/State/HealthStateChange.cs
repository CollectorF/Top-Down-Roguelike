public class HealthStateChange : BaseStateChange
{
    protected int healthAdjustment;

    public HealthStateChange(int healthAdjustment)
    {
        this.healthAdjustment = healthAdjustment;
    }

    public override BaseState ApplyChange(BaseState targetState)
    {
        return base.ApplyChange(targetState).Mutate(
            health: targetState.Health + healthAdjustment
        );
    }
}