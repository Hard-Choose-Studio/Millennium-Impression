using UnityEngine;

namespace MillenniumImpression.AquaOilScene
{
    public class Bicycle : MonoBehaviour, IAquaOilEvent
    {
        private HasFoundLost hasFoundLost;
        private HasVideoPlayer hasVideoPlayer;
        private HasRawImage hasRawImage;

        private void Awake()
        {
            hasFoundLost = GetComponent<HasFoundLost>();
            hasFoundLost.AddAnimationEvent("end_ride", () => GameManager.instance.OnVanishing());

            hasVideoPlayer = GetComponent<HasVideoPlayer>();

            hasRawImage = GetComponent<HasRawImage>();
        }

        private void Start()
        {
            hasVideoPlayer.ClearRenderTexture();
        }

        public void OnTargetFound()
        {
            hasFoundLost.SetTargetFound();

            hasVideoPlayer.Play();
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost();

            hasVideoPlayer.Stop();
        }

        public void OnBottleOpened() { }

        public void OnVanishing()
        {
            hasRawImage.FadeOut();
        }
    }
}