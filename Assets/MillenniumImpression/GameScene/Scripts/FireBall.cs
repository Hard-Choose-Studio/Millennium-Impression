using UnityEngine;

namespace MillenniumImpression.GameScene
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class FireBall : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Rigidbody2D>().AddForce(new(90.0F - transform.localEulerAngles.y, 0.0F));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject obj = collision.gameObject;
            if (GameManager.instance.IsGround(obj))
                return;
            if (obj.CompareTag("Enemy"))
                collision.transform.parent.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}