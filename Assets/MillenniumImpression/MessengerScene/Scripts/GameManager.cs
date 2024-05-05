using UnityEngine;

namespace MillenniumImpression.MessengerScene
{
    public class GameManager : GenericGameManager, IMessengerEvent
    {
        public static GameManager instance;

        [SerializeField]
        private MessengerInputField messengerInputField;
        [SerializeField]
        private MessageChoose messageChooseButton;

        [SerializeField]
        private ReceivedMessageText[] receivedMessageTexts;
        [SerializeField]
        private SendMessageText[] sendMessageTexts;

        private readonly IMessengerEvent[] eventObjects = new IMessengerEvent[2];

        private int messageIndex = 0;

        private readonly string[] receivedMessages =
        {
            "�m�N�A���H�b�a��~~~~",
            "�Ҹղש�ҧ��F= =",
            "�����ѤU�ҫ�n�h���H",
            "�n�O�o�a���㥽XD"
        };

        private readonly string[] sendMessages =
        {
            "��è��A��M�b��~",
            "�o�����ƾǦ�����Orz",
            "�ڭn�h���@���@���Ұ�^_^",
            "�ڪ��D�A�]���O�㥽����I"
        };

        public string GetReceivedMessage() => receivedMessages[messageIndex];

        public string GetSendMessage() => sendMessages[messageIndex];

        private void Awake()
        {
            instance = this;

            eventObjects[0] = messengerInputField;
            eventObjects[1] = messageChooseButton;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Start()
        {
            receivedMessageTexts[messageIndex].SendMessage();
        }

        public override void OnTargetFound()
        {
            base.OnTargetFound();
            foreach (IMessengerEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            base.OnTargetLost();
            foreach (IMessengerEvent eventObject in eventObjects)
                eventObject.OnTargetLost();
        }

        public void OnMessageReceived()
        {
            foreach (IMessengerEvent eventObject in eventObjects)
                eventObject.OnMessageReceived();
        }

        public void OnMessageChoosed()
        {
            foreach (IMessengerEvent eventObject in eventObjects)
                eventObject.OnMessageChoosed();
        }

        public void OnMessageSend()
        {
            sendMessageTexts[messageIndex].SendMessage();

            foreach (IMessengerEvent eventObject in eventObjects)
                eventObject.OnMessageSend();

            messageIndex++;
            if (messageIndex == receivedMessages.Length)
                OnSceneFinish();
            else
                receivedMessageTexts[messageIndex].SendMessage();
        }
    }
}