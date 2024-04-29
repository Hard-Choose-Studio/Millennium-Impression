using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class MusicPlayer : MonoBehaviour, ITapeEvent
    {
        [SerializeField]
        private Tape tape;
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
            foreach (HasVideoPlayer instrument in instruments)
            {
                instrument.ClearRenderTexture();
                instrument.Play();
            }
        }

        private void Update()
        {
            if (found && tape.touchedMachine && !audioSource.isPlaying)
                ChangeSong(false);
        }

        public void OnTargetFound()
        {
            found = true;
            if (tape.touchedMachine)
                audioSource.Play();
            else
                gameObject.SetActive(false);
        }

        public void OnTargetLost()
        {
            found = false;
            if (tape.touchedMachine)
                audioSource.Stop();
        }

        public void OnTapeReachedMachine() { }

        public void OnMachineClose()
        {
            gameObject.SetActive(true);
            audioSource.Play();
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