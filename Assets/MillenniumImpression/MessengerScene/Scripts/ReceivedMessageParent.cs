using System.Collections;
using UnityEngine;

namespace MillenniumImpression.MessengerScene
{
    public class ReceivedMessageParent : MessageParent
    {
        public void SendMessage()
        {
            StartCoroutine(SendingMessage());
        }

        private IEnumerator SendingMessage()
        {
            yield return new WaitForSeconds(3.0F);
            author.text = authorNameWithColon;
            message.text = GameManager.instance.GetReceivedMessage();
            GameManager.instance.OnMessageReceived();
        }
    }
}