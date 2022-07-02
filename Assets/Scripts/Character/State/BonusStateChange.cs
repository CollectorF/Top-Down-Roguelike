public class BonusStateChange : BaseStateChange
{
    protected int bonusAdjustment;

    public BonusStateChange(int bonusAdjustment)
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