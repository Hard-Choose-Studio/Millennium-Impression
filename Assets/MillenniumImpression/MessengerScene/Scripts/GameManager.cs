using UnityEngine;

namespace MillenniumImpression.MessengerScene
{
    public class GameManager : GenericGameManager, IMessengerEvent
    {
        public static GameManager instance;

        [SerializeField]
        private MessengerInputField messengerInputField;
        [SerializeField]
        private MessageChoose messageChooseButton1;
        [SerializeField]
        private MessageChoose messageChooseButton2;

        [SerializeField]
        private ReceivedMessageParent[] receivedMessageTexts;
        [SerializeField]
        private SendMessageParent[] sendMessageTexts;

        private AudioSource sendAudio;

        private readonly IMessengerEvent[] eventObjects = new IMessengerEvent[3];

        private int messageIndex = 0;

        private readonly string[] receivedMessages =
        {
            "安安 你好 幾歲 住哪",
            "考試終於考完了= =",
            "那ㄋ明天下課後要去哪？",
            "要記得帶條芥末XD"
        };

        private int chosenMessage = 0;
        private readonly string[,] sendMessages =
        {
            {
                "你真的很米苔目XDD",
                "白癡喔XDD"
            },
            {
                "哇哩勒，這次的數學有夠難",
                "對ㄚ，題目超難ㄉOrz"
            },
            {
                "我要去網咖打世紀帝國^_^",
                "跟我麻吉去夾娃娃吧！"
            },
            {
                "我知道，因為是芥末日嘛！",
                "哈哈明天放學就去買"
            }
        };

        public string GetReceivedMessage() => receivedMessages[messageIndex];

        public string GetSendMessage(int chosenMessage) => sendMessages[messageIndex, chosenMessage];

        public string GetSendMessage() => sendMessages[messageIndex, chosenMessage];

        protected override void Awake()
        {
            base.Awake();

            instance = this;

            eventObjects[0] = messengerInputField;
            eventObjects[1] = messageChooseButton1;
            eventObjects[2] = messageChooseButton2;

            sendAudio = GetComponent<AudioSource>();
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Start()
        {
            receivedMessageTexts[messageIndex].SendMessage(); //用Start 避免Awake順序問題
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

        public void OnMessageChoosed(int which)
        {
            chosenMessage = which;
            OnMessageChoosed();
        }

        public void OnMessageChoosed()
        {
            foreach (IMessengerEvent eventObject in eventObjects)
                eventObject.OnMessageChoosed();
        }

        public void OnMessageSend()
        {
            sendAudio.Play();

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