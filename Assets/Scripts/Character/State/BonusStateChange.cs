public class BonusStateChange : BaseStateChange
{
    protected float bonusAdjustment;

    public BonusStateChange(float bonusAdjustment)
    {
        this.bonusAdjustment = bonusAdjustment;
    }

    public override BaseState ApplyChange(BaseState targetState)
    {
        return base.ApplyChange(targetState).Mutate(
            bonus: targetState.Bonus + bonusAdjustment
        );
    }
}