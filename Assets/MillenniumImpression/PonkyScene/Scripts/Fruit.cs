using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;

        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb2D;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb2D = GetComponent<Rigidbody2D>();
            ResetObject();
        }

        private void Update()
        {
            if (transform.localPosition.y < -5) //水果會自然掉落
                ResetObject(); //超過-5就回去
        }

        private void ResetObject()
        {
            transform.localPosition = new(Random.Range(-10.0F, 10.0F), Random.Range(5.0F, 10.0F), 0.0F);
            rb2D.velocity = Vector3.zero;
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)]; //隨機換材質
        }
    }
}