using UnityEngine;

namespace MillenniumImpression.GameScene
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class FireFlower : MonoBehaviour
    {
        private Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            rb2D.AddForce(new(120, 120));
        }
    }
}