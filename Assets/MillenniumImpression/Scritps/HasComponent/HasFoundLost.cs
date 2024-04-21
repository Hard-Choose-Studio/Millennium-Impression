namespace MillenniumImpression
{
    public class HasFoundLost : HasAnimator
    {
        internal void SetTargetFound()
        {
            SetAnimatorValue("isTargetFound", true);
        }

        internal void SetTargetLost()
        {
            SetAnimatorValue("isTargetFound", false);
        }
    }
}