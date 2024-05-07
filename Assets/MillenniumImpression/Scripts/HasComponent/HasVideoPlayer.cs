using UnityEngine;
using UnityEngine.Video;

namespace MillenniumImpression
{
    [RequireComponent(typeof(VideoPlayer))]
    public class HasVideoPlayer : MonoBehaviour
    {
        //VideoPlayer的包裹類別
        private VideoPlayer videoPlayer;

        private void Awake()
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        public void ClearRenderTexture()
        {
            RenderTexture renderTexture = RenderTexture.active;
            RenderTexture.active = videoPlayer.targetTexture;
            GL.Clear(true, true, Color.clear);
            RenderTexture.active = renderTexture;
        }

        public void Play() => videoPlayer.Play();

        public void Stop() => videoPlayer.Stop();

        public VideoPlayer GetVideoPlayer() => videoPlayer;
    }
}