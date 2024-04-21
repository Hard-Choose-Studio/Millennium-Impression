using UnityEngine;

namespace MillenniumImpression.ConcertScene
{
    public class MusicPlayer : MonoBehaviour, IConcertEvent
    {
        [SerializeField]
        private AudioClip[] music;
        [SerializeField]
        private HasVideoPlayer[] instruments;

        private AudioSource audioSource;
        private int index = 0;
        private int musicCount;

        private bool found = false;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            musicCount = music.Length;
        }

        private void Start()
        {
            foreach (HasVideoPlayer player in instruments)
            {
                player.ClearRenderTexture();
                player.Play();
            }
        }

        private void Update()
        {
            if (found && !audioSource.isPlaying)
                ChangeSong(false);
        }

        public void OnTargetFound()
        {
            found = true;
            audioSource.Play();
        }

        public void OnTargetLost()
        {
            found = false;
            audioSource.Stop();
        }

        public void ChangeSong(bool previous)
        {
            if (previous)
            {
                index--;
                if (index == -1)
                    index = musicCount - 1;
            }
            else
            {
                index++;
                if (index == musicCount)
                    index = 0;
            }
            audioSource.Stop();
            audioSource.clip = music[index];
            audioSource.Play();
        }
    }
}