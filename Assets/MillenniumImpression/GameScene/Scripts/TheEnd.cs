using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class TheEnd : MonoBehaviour, IResettable
    {
        private bool touched = false;

        private HasAnimator hasAnimator;

        private void Awake()
        {
            hasAnimator = GetComponent<HasAnimator>();
            hasAnimator.AddAnimationEvent("the_end", () => GameManager.instance.OnEnd());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (touched)
                return;
            touched = true;
            hasAnimator.SetAnimatorValue("theEnd");
            collision.gameObject.SetActive(false);
        }

        public void ResetObject()
        {
            touched = false;
        }
    }
}