namespace MillenniumImpression.MessengerScene
{
    public class MessageChoose : GenericButton, IMessengerEvent
    {
        private void Start()
        {
            text.text = GameManager.instance.GetSendMessage();
        }

        public override void OnClick()
        {
            GameManager.instance.OnMessageChoosed();
        }

        public void OnTargetFound() { }

        public void OnTargetLost() { }

        public void OnMessageReceived()
        {
            button.enabled = true;
            text.text = GameManager.instance.GetSendMessage();
        }

        public void OnMessageChoosed()
        {
            button.enabled = false;
            text.text = string.Empty;
        }

        public void OnMessageSend() { }
    }
}