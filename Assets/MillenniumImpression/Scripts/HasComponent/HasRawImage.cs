using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public class HasRawImage : MonoBehaviour
    {
        private RawImage rawImage;
        private Coroutine fadeOut = null;

        private void Awake()
        {
            rawImage = GetComponent<RawImage>();
        }

        public void FadeOut()
        {
            if (fadeOut == null)
            {
                fadeOut = StartCoroutine(FadeOutCoroutine());
                return;
            }

            StopCoroutine(fadeOut);
            fadeOut = null;
            RestoreAlpha();
        }

        private void RestoreAlpha()
        {
            Color restoreColor = rawImage.color;
            restoreColor.a = 1.0F;
            rawImage.color = restoreColor;
        }

        private IEnumerator FadeOutCoroutine()
        {
            RestoreAlpha();
            for (int i = 0; i < 20; i++)
            {
                Color newColor = rawImage.color;
                newColor.a -= 0.05F;
                rawImage.color = newColor;
                yield return new WaitForSeconds(0.1F);
            }
        }
    }
}