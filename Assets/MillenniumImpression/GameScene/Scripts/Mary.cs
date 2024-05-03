using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MillenniumImpression.GameScene
{
    public class Mary : MonoBehaviour
    {
        private bool isOnGround = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ground"))
                isOnGround = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ground"))
                isOnGround = false;
        }
    }
}