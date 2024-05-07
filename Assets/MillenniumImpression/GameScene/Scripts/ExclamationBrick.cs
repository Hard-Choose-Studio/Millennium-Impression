using UnityEngine;

namespace MillenniumImpression.GameScene
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ExclamationBrick : MonoBehaviour, IResettable
    {
        [SerializeField]
        private GameObject containsItem;
        [SerializeField]
        private Sprite brightBrick;
        [SerializeField]
        private Sprite fadeBrick;

        private bool bright;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            ResetObject();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (bright && collision.GetContact(0).normal.y > 0 && collision.gameObject.CompareTag("Player"))
            {
                Instantiate(containsItem, transform.TransformPoint(Vector3.up * 6), Quaternion.identity, transform.parent);
                spriteRenderer.sprite = fadeBrick;
                bright = false;
            }
        }

        public void ResetObject()
        {
            spriteRenderer.sprite = brightBrick;
            bright = true;
        }
    }
}