namespace MillenniumImpression.MessengerScene
{
    public interface IMessengerEvent : IEvent
    {
        void OnMessageReceived();
        void OnMessageChoosed();
        void OnMessageSend();
    }
}