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
            if (touched || !collision.CompareTag("Player"))
                return;
            touched = true;
            hasAnimator.SetAnimatorValue("theEnd");
            if (collision.TryGetComponent(out SpriteRenderer spriteRenderer))
                spriteRenderer.enabled = false;
        }

        public void ResetObject()
        {
            touched = false;
        }
    }
}