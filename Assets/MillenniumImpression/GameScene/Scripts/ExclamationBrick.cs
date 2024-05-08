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

        private bool fade;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            ResetObject();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (fade || collision.GetContact(0).normal.y <= 0 || !collision.gameObject.CompareTag("Player"))
                return;
            GameObject newObject = Instantiate(containsItem, transform.TransformPoint(Vector3.up * 10), Quaternion.identity, transform.parent);
            GameManager.instance.AddResetGameObject(newObject);
            spriteRenderer.sprite = fadeBrick;
            fade = true;
        }

        public void ResetObject()
        {
            spriteRenderer.sprite = brightBrick;
            fade = false;
        }
    }
}