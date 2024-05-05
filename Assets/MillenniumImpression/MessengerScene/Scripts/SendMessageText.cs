using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.MessengerScene
{
    public class SendMessageText : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = transform.GetComponent<Text>();
        }

        public void SendMessage()
        {
            text.text = GameManager.instance.GetSendMessage();
        }
    }
}