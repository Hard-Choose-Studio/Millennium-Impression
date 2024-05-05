using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.MessengerScene
{
    public class ReceivedMessageText : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = transform.GetComponent<Text>();
        }

        public void SendMessage()
        {
            StartCoroutine(SendingMessage());
        }

        private IEnumerator SendingMessage()
        {
            text.text = "...";
            yield return new WaitForSeconds(3.0F);
            text.text = GameManager.instance.GetReceivedMessage();
            GameManager.instance.OnMessageReceived();
        }
    }
}