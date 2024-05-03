using System.Collections;
using UnityEngine;

namespace MillenniumImpression.WataliScene
{
    public class SoundPlayer : MonoBehaviour, IWataliEvent
    {
        private AudioSource audioSource;
        private Coroutine playAudio;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void OnTargetFound()
        {
            playAudio = StartCoroutine(PlayAudio()); //�}�l���񭵰T
        }
        public void OnTargetLost()
        {
            if (playAudio != null)
                StopCoroutine(playAudio); //����񭵰T
            audioSource.Stop();
        }

        public void OnGood() { }

        private IEnumerator PlayAudio()
        {
            audioSource.Play();
            yield return new WaitForSeconds(11.0F); //���� �b��11��
            GameManager.instance.OnGood();
        }
    }
}