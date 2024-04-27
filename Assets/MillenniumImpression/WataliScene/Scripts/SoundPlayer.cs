using System.Collections;
using UnityEngine;

namespace MillenniumImpression.WataliScene
{
    public class SoundPlayer : MonoBehaviour, IWataliEvent
    {
        private AudioSource audioSource;
        private IEnumerator playAudio;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            playAudio = PlayAudio();
        }
        public void OnTargetFound()
        {
            StartCoroutine(playAudio); //�}�l���񭵰T
        }
        public void OnTargetLost()
        {
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