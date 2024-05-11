using UnityEngine;

namespace MillenniumImpression.MessengerScene
{
    public class MessageChoose : GenericButton, IMessengerEvent
    {
        [SerializeField]
        private int buttonIndex; //0��1

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
            button.enabled = true; //�}����
            image.enabled = true;
            text.text = GameManager.instance.GetSendMessage(buttonIndex);
        }

        public void OnMessageChoosed()
        {
            button.enabled = false; //�������
            image.enabled = false;
            text.text = string.Empty;
        }

        public void OnMessageSend() { }
    }
}