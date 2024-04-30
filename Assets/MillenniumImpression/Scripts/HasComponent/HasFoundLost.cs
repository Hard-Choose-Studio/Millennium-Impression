namespace MillenniumImpression
{
    public class HasFoundLost : HasAnimator
    {
        public void SetTargetFound() => animator.SetBool("isTargetFound", true);

        public void SetTargetLost() => animator.SetBool("isTargetFound", false);
    }
}