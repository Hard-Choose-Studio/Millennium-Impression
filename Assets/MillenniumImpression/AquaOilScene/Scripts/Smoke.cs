using UnityEngine;

namespace MillenniumImpression.AquaOilScene
{
    public class Smoke : MonoBehaviour, IAquaOilEvent
    {
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
        }

        public void OnTargetFound()
        {
            hasVideoPlayer.Stop();
        }

        public void OnTargetLost()
        {
            hasVideoPlayer.Stop();
        }

        public void OnBottleOpened()
        {
            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play();
        }
    }
}