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
            "叮咚，有人在家嗎~~~~",
            "考試終於考完了= =",
            "那明天下課後要去哪？",
            "要記得帶條芥末XD"
        };

        private readonly string[] sendMessages =
        {
            "白癡喔，當然在啊~",
            "這次的數學有夠難Orz",
            "我要去網咖打世紀帝國^_^",
            "我知道，因為是芥末日嘛！"
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