using UnityEngine;

namespace MillenniumImpression.TelevisionScene
{
    [RequireComponent(typeof(AudioSource))]
    public class MajoNoJouken : MonoBehaviour
    {
        private HasVideoPlayer hasVideoPlayer;
        private AudioSource audioSource;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            hasVideoPlayer.ClearRenderTexture();
        }

        public void OnTargetFound()
        {
            hasVideoPlayer.Play();
            audioSource.Play();
        }

        public void OnTargetLost()
        {
            hasVideoPlayer.Stop();
            audioSource.Stop();
        }
    }
}