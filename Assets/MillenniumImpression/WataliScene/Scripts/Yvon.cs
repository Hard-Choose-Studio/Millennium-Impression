using UnityEngine;

namespace MillenniumImpression.WataliScene
{
    public class Yvon : MonoBehaviour, IWataliEvent
    {
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
        }

        public void OnTargetFound()
        {
            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play();
        }

        public void OnTargetLost()
        {
            hasVideoPlayer.Stop();
        }

        public void OnGood()
        {
        }
    }
}