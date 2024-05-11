using UnityEngine;

namespace MillenniumImpression.MessengerScene
{
    public class MessageChoose : GenericButton, IMessengerEvent
    {
        [SerializeField]
        private int buttonIndex; //0或1

        /*private void Start()
        {
            text.text = GameManager.instance.GetSendMessage(buttonIndex);
        }*/

        public override void OnClick()
        {
            GameManager.instance.OnMessageChoosed(buttonIndex);
        }

        public void OnTargetFound() { }

        public void OnTargetLost() { }

        public void OnMessageReceived()
        {
            button.enabled = true; //開放選擇
            image.enabled = true;
            text.text = GameManager.instance.GetSendMessage(buttonIndex);
        }

        public void OnMessageChoosed()
        {
            button.enabled = false; //結束選擇
            image.enabled = false;
            text.text = string.Empty;
        }

        public void OnMessageSend() { }
    }
}