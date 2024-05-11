using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.MessengerScene
{
    [RequireComponent(typeof(Text))]
    [RequireComponent(typeof(AudioSource))]
    public class MessengerInputField : MonoBehaviour, IMessengerEvent
    {
        [SerializeField]
        private SendButton sendButton;

        private AudioSource typingAudio;

        private Text text;
        private bool pauseCoroutine = false;

        private void Awake()
        {
            text = GetComponent<Text>();
            typingAudio = GetComponent<AudioSource>();
        }

        public void OnTargetFound()
        {
            pauseCoroutine = false; //繼續輸入
        }

        public void OnTargetLost()
        {
            pauseCoroutine = true; //暫停輸入
        }

        public void OnMessageReceived() { }

        public void OnMessageChoosed()
        {
            StartCoroutine(Typing());
        }

        private IEnumerator Typing()
        {
            StringBuilder builder = new();
            string message = GameManager.instance.GetSendMessage();
            for (int i = 0, len = message.Length; i < len;)
            {
                if (!pauseCoroutine)
                {
                    if (!typingAudio.isPlaying)
                        typingAudio.Play();
                    text.text = builder.Append(message[i]).ToString();
                    i++;
                }
                yield return new WaitForSeconds(0.05F);
            }
            sendButton.gameObject.SetActive(true);
            typingAudio.Stop();
        }

        public void OnMessageSend()
        {
            text.text = string.Empty; //送出訊息
        }
    }
}