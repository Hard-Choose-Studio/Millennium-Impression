namespace MillenniumImpression.MessengerScene
{
    public class SendButton : GenericButton
    {
        public override void OnClick()
        {
            GameManager.instance.OnMessageSend();
            gameObject.SetActive(false);
        }
    }
}