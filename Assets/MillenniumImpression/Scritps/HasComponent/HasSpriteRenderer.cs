using UnityEngine;

namespace MillenniumImpression
{
    public class HasSpriteRenderer : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeSprite(Sprite sprite) => spriteRenderer.sprite = sprite;

        public void Flip(XYZ xyz)
        {
            switch (xyz)
            {
                case XYZ.X:
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    break;

                case XYZ.Y:
                    spriteRenderer.flipY = !spriteRenderer.flipY;
                    break;

                case XYZ.Z:
                default:
                    break;
            }
        }
    }
}