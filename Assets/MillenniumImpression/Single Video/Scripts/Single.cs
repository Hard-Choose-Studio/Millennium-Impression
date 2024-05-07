using UnityEngine;

namespace MillenniumImpression
{
    public class Single : MonoBehaviour
    {
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
        }

        private void Start()
        {
            hasVideoPlayer.Play();
        }
    }
}