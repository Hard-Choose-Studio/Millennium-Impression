using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class MusicPlayers : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] songs;
        private AudioSource audioSource;
        private int index = 0;
        private bool found = false;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = songs[index];
        }

        private void Update()
        {
            if (found && !audioSource.isPlaying)
                NextSong();
        }

        public void OnChineseTargetFound()
        {
            found = true;
            audioSource.Play();
        }

        public void OnChineseTargetLost()
        {
            found = false;
            audioSource.Stop();
        }

        internal void NextSong()
        {
            audioSource.Stop();
            index++;
            if (index == songs.Length)
                index = 0;
            audioSource.clip = songs[index];
            audioSource.Play();
        }

        internal void PreviousSong()
        {
            audioSource.Stop();
            index--;
            if (index < 0)
                index = songs.Length - 1;
            audioSource.clip = songs[index];
            audioSource.Play();
        }
    }
}