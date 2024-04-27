using UnityEngine;

namespace MillenniumImpression.AquaOilScene
{
    public class Bicycle : MonoBehaviour, IAquaOilEvent
    {
        private HasFoundLost hasFoundLost;
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasFoundLost = GetComponent<HasFoundLost>();
            hasFoundLost.AddAnimationEvent("end_ride", () => hasVideoPlayer.GetVideoPlayer().Pause());

            hasVideoPlayer = GetComponent<HasVideoPlayer>();
        }

        public void OnTargetFound()
        {
            hasFoundLost.SetTargetFound();

            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play();
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost();

            hasVideoPlayer.Stop();
        }

        public void OnBottleOpened() { }
    }
}