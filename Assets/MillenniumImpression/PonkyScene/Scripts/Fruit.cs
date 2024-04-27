using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;

        private HasSpriteRenderer hasSpriteRenderer;
        private Rigidbody2D rb2D;

        private void Awake()
        {
            hasSpriteRenderer = GetComponent<HasSpriteRenderer>();
            rb2D = GetComponent<Rigidbody2D>();
            ResetObject();
        }

        private void Update()
        {
            if (transform.localPosition.y < -5) //���G�|�۵M����
                ResetObject(); //�W�L-5�N�^�h
        }

        private void ResetObject()
        {
            transform.localPosition = new(Random.Range(-10.0F, 10.0F), Random.Range(5.0F, 10.0F), 0.0F);
            rb2D.velocity = Vector3.zero;
            hasSpriteRenderer.ChangeSprite(sprites[Random.Range(0, sprites.Length)]); //�H��������
        }
    }
}