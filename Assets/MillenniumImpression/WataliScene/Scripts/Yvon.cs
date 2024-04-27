using UnityEngine;
using UnityEngine.Video;

namespace MillenniumImpression.WataliScene
{
    public class Yvon : MonoBehaviour, IWataliEvent
    {
        [SerializeField]
        private VideoClip questionVideo;
        [SerializeField]
        private VideoClip goodVideo;

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
            hasVideoPlayer.GetVideoPlayer().clip = questionVideo;
        }

        public void OnGood()
        {
            hasVideoPlayer.Stop();
            hasVideoPlayer.GetVideoPlayer().clip = goodVideo;
            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play();
        }
    }
}