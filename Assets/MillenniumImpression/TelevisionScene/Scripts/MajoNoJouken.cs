using UnityEngine;

namespace MillenniumImpression.TelevisionScene
{
    public class MajoNoJouken : MonoBehaviour
    {
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
        }

        private void Start()
        {
            hasVideoPlayer.ClearRenderTexture();
        }

        public void OnTargetFound()
        {
            hasVideoPlayer.Play();
        }

        public void OnTargetLost()
        {
            hasVideoPlayer.Stop();
        }
    }
}