using UnityEngine;

namespace MillenniumImpression.GameScene
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Goomba : MonoBehaviour, IResettable
    {
        private Vector3 originalPosition;
        private Vector3 originalScale;
        private Rigidbody2D rb2D;

        private void Awake()
        {
            originalPosition = transform.localPosition;
            originalScale = transform.localScale;
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            rb2D.velocity = new(-transform.localScale.x * 3.0F, 0);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (GameManager.instance.IsGround(collision.gameObject))
                return;
            Vector3 newScale = transform.localScale;
            newScale.x = -newScale.x;
            transform.localScale = newScale;
        }

        public void ResetObject()
        {
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
            gameObject.SetActive(true);
        }
    }
}