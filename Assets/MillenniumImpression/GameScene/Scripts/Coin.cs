using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class Coin : MonoBehaviour
    {
        private HasAnimator hasAnimator;

        private void Awake()
        {
            hasAnimator = GetComponent<HasAnimator>();
            hasAnimator.AddAnimationEvent("end_float", () => Destroy(gameObject));
        }
    }
}