using UnityEngine;

namespace MillenniumImpression.GameScene
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mary : MonoBehaviour, IResettable
    {
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb2D;
        private HasFoundLost hasFoundLost;

        [SerializeField]
        private GameButton leftButton;
        [SerializeField]
        private GameButton rightButton;
        [SerializeField]
        private GameButton jumpButton;
        [SerializeField]
        private GameButton fireButton;

        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float jumpForce;

        private Vector3 originalPosition;
        private bool isOnGround;
        private bool fire;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb2D = GetComponent<Rigidbody2D>();
            hasFoundLost = GetComponent<HasFoundLost>();

            originalPosition = transform.localPosition;
            ResetObject();
        }

        private void Update()
        {
            if (isOnGround)
                MoveControl();
        }

        private void MoveControl()
        {
            Vector2 newVelocity = rb2D.velocity;
            if (leftButton.IsPressed()) //©¹¥ª
            {
                spriteRenderer.flipX = true;
                newVelocity.x = -moveSpeed;
            }
            else if (rightButton.IsPressed()) //©¹¥k
            {
                spriteRenderer.flipX = false;
                newVelocity.x = moveSpeed;
            }
            else
                newVelocity = Vector2.zero;

            if (jumpButton.IsPressed()) //¸õ
                newVelocity.y = jumpForce;

            rb2D.velocity = newVelocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.GetContact(0).normal.y < 0 && GameManager.instance.IsGround(collision.gameObject))
                isOnGround = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.GetContact(0).normal.y < 0 && GameManager.instance.IsGround(collision.gameObject))
                isOnGround = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject obj = collision.gameObject;
            if (obj.CompareTag("Enemy"))
                Damage();
            else if (obj.CompareTag("Enemy Top"))
                obj.transform.parent.gameObject.SetActive(false);
            else if (obj.CompareTag("Flower"))
            {
                Fire(true);
                Destroy(obj);
            }
        }

        private void Damage()
        {
            if (fire)
            {
                Fire(false);
                Invincible();
            }
            else
            {
                ResetObject();
            }
        }

        private void Fire(bool fire)
        {
            this.fire = fire;
            fireButton.gameObject.SetActive(fire);
            hasFoundLost.SetAnimatorValue("isFire", fire);
        }

        private void Invincible()
        {

        }

        public void ResetObject()
        {
            transform.localPosition = originalPosition;
            spriteRenderer.flipX = false;
            rb2D.velocity = Vector2.zero;
            isOnGround = false;
            fire = false;
        }
    }
}