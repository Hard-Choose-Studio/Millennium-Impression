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
            StartCoroutine(playAudio); //開始播放音訊
        }
        public void OnTargetLost()
        {
            StopCoroutine(playAudio); //停止播放音訊
            audioSource.Stop();
        }

        public void OnGood() { }

        private IEnumerator PlayAudio()
        {
            audioSource.Play();
            yield return new WaitForSeconds(11.0F); //水啦 在第11秒
            GameManager.instance.OnGood();
        }
    }
}