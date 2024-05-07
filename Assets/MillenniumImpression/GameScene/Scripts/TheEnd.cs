using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class TheEnd : MonoBehaviour
    {
        private HasAnimator hasAnimator;

        private void Awake()
        {
            hasAnimator = GetComponent<HasAnimator>();
            hasAnimator.AddAnimationEvent("the_end", () => GameManager.instance.OnEnd());
        }
    }
}