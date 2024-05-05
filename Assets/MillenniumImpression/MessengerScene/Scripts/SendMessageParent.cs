namespace MillenniumImpression.MessengerScene
{
    public class SendMessageParent : MessageParent
    {
        public void SendMessage()
        {
            author.text = authorNameWithColon;
            message.text = GameManager.instance.GetSendMessage();
        }
    }
}