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
            "�w�w �A�n �X�� ���",
            "�Ҹղש�ҧ��F= =",
            "���z���ѤU�ҫ�n�h���H",
            "�n�O�o�a���㥽XD"
        };

        private int chosenMessage = 0;
        private readonly string[,] sendMessages =
        {
            {
                "�A�u���ܦ̭a��XDD",
                "��è��XDD"
            },
            {
                "�z���ǡA�o�����ƾǦ�����",
                "��A�D�ضW���xOrz"
            },
            {
                "�ڭn�h���@���@���Ұ�^_^",
                "��ڳ¦N�h�������a�I"
            },
            {
                "�ڪ��D�A�]���O�㥽����I",
                "�������ѩ�ǴN�h�R"
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
            receivedMessageTexts[messageIndex].SendMessage(); //��Start �קKAwake���ǰ��D
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