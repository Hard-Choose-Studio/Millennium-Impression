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
            playAudio = StartCoroutine(PlayAudio()); //開始播放音訊
        }
        public void OnTargetLost()
        {
            if (playAudio != null)
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