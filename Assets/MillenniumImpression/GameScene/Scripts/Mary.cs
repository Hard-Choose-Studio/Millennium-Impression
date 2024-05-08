using System.Collections;
using UnityEngine;

namespace MillenniumImpression.GameScene
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mary : MonoBehaviour, IResettable, IGameEvent
    {
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb2D;
        private HasFoundLost hasFoundLost;
        private AudioSource audioSource;

        [SerializeField]
        private GameButton leftButton;
        [SerializeField]
        private GameButton rightButton;
        [SerializeField]
        private GameButton jumpButton;
        [SerializeField]
        private FireballButton fireButton;

        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private GameObject fireBall;

        [SerializeField]
        private AudioClip jumpClip;
        [SerializeField]
        private AudioClip deathClip;

        private Vector3 originalPosition;
        private bool isOnGround;
        private bool fire;
        private bool invicinble;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb2D = GetComponent<Rigidbody2D>();
            hasFoundLost = GetComponent<HasFoundLost>();
            audioSource = GetComponent<AudioSource>();

            originalPosition = transform.localPosition;
        }

        private void Start() //裡面有用到hasFoundLost 然而無法確定誰先Awake
        {
            ResetObject();
        }

        private void FixedUpdate()
        {
            Vector2 newVelocity = rb2D.velocity;
            if (leftButton.IsPressed()) //往左
            {
                spriteRenderer.flipX = true;
                newVelocity.x = -moveSpeed;
                hasFoundLost.SetAnimatorValue("isWalking", true);
            }
            else if (rightButton.IsPressed()) //往右
            {
                spriteRenderer.flipX = false;
                newVelocity.x = moveSpeed;
                hasFoundLost.SetAnimatorValue("isWalking", true);
            }
            else
            {
                newVelocity.x = 0.0F;
                hasFoundLost.SetAnimatorValue("isWalking", false);
            }

            if (isOnGround && jumpButton.IsPressed()) //跳
            {
                newVelocity.y = jumpForce;
                hasFoundLost.SetAnimatorValue("isJumping", true);
                audioSource.clip = jumpClip;
                audioSource.Play();
            }

            rb2D.velocity = newVelocity;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.GetContact(0).normal.y > 0 && GameManager.instance.IsGround(collision.gameObject))
            {
                hasFoundLost.SetAnimatorValue("isJumping", false);
                isOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (GameManager.instance != null && GameManager.instance.IsGround(collision.gameObject))
                isOnGround = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject obj = collision.gameObject;
            if (!invicinble && obj.CompareTag("Enemy"))
                Damage();
            else if (obj.CompareTag("Enemy Top"))
                obj.transform.parent.gameObject.SetActive(false);
            else if (obj.CompareTag("Flower"))
            {
                Fire(true);
                Destroy(obj);
            }
        }

        public void OnTargetFound()
        {
            hasFoundLost.SetTargetFound();
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost();
        }

        private void Damage()
        {
            //受傷
            if (fire)
            {
                Fire(false);
                StartCoroutine(Invincible());
            }
            else
            {
                audioSource.clip = deathClip;
                audioSource.Play();
                GameManager.instance.ResetObject();
            }
        }

        private void Fire(bool fire)
        {
            this.fire = fire;
            fireButton.gameObject.SetActive(fire);
            hasFoundLost.SetAnimatorValue("isFire", fire);
        }

        private IEnumerator Invincible()
        {
            invicinble = true; //無敵
            Color newColor;
            for (int i = 0; i < 10; i++)
            {
                newColor = spriteRenderer.color;
                newColor.a = Mathf.Abs(newColor.a - 1.0F); //閃爍
                spriteRenderer.color = newColor;
                yield return new WaitForSeconds(0.2F);
            }
            newColor = spriteRenderer.color;
            newColor.a = 1.0F;
            spriteRenderer.color = newColor;
            invicinble = false;
        }

        public void ShootFireBall()
        {
            if (fire) //根據Mary的方向決定前進方向
                GameManager.instance.AddResetGameObject(Instantiate(fireBall, transform.TransformPoint((spriteRenderer.flipX ? Vector3.left : Vector3.right) * 6.0F),
                    Quaternion.Euler(0.0F, spriteRenderer.flipX ? 180.0F : 0.0F, 0.0F), transform.parent));
        }

        public void ResetObject()
        {
            gameObject.SetActive(true);
            transform.localPosition = originalPosition;
            spriteRenderer.flipX = false;
            rb2D.velocity = Vector2.zero;
            isOnGround = false;
            Fire(false);
            invicinble = false;
        }
    }
}