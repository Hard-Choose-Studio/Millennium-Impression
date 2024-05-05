using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.MessengerScene
{
    public class MessengerInputField : MonoBehaviour, IMessengerEvent
    {
        private Text text;
        private bool pauseCoroutine = false;

        private void Awake()
        {
            text = GetComponent<Text>();
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
                    text.text = builder.Append(message[i]).ToString();
                    i++;
                }
                yield return new WaitForSeconds(0.1F);
            }
            GameManager.instance.OnMessageSend();
        }

        public void OnMessageSend()
        {
            text.text = string.Empty; //送出訊息
        }
    }
}