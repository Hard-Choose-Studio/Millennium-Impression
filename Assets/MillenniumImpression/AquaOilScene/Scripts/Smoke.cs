using UnityEngine;

namespace MillenniumImpression.AquaOilScene
{
    public class Smoke : MonoBehaviour, IAquaOilEvent
    {
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
            hasVideoPlayer.ClearRenderTexture();
        }

        public void OnTargetFound()
        {
            hasVideoPlayer.Stop();
            gameObject.SetActive(false);
        }

        public void OnTargetLost()
        {
            hasVideoPlayer.Stop();
            gameObject.SetActive(false);
        }

        public void OnBottleOpened()
        {
            gameObject.SetActive(true);
            hasVideoPlayer.Play();
        }
    }
}