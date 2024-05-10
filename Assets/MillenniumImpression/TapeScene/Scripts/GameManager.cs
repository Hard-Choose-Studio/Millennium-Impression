using System.Collections;
using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class GameManager : GenericGameManager, ITapeEvent
    {
        public static GameManager instance;

        [SerializeField]
        private Tape tape;
        [SerializeField]
        private CassetteMachineDoor cassetteMachineDoor;
        [SerializeField]
        private GameObject instructmentsCanvas;
        [SerializeField]
        private MusicPlayer musicPlayer;

        [SerializeField]
        private GameObject arrow;

        private readonly ITapeEvent[] eventObjects = new ITapeEvent[3];

        private void Awake()
        {
            instance = this;

            eventObjects[0] = tape;
            eventObjects[1] = cassetteMachineDoor;
            eventObjects[2] = musicPlayer;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            base.OnTargetFound();
            if (tape.touchedMachine) //�w�g�I�L�F �N�L�ҿפF
                return;
            instructmentsCanvas.SetActive(false); //���ӬOtrue ���L�̥i�H������ �����w��
            foreach (ITapeEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (tape.touchedMachine) //�w�g�I�L�F �N�L�ҿפF
                return;
            foreach (ITapeEvent eventObject in eventObjects)
                eventObject.OnTargetLost();
        }

        public void OnTapeReachedMachine()
        {
            arrow.SetActive(false);
            foreach (ITapeEvent eventObject in eventObjects)
                eventObject.OnTapeReachedMachine();
        }

        public void OnMachineClose()
        {
            instructmentsCanvas.SetActive(true);
            foreach (ITapeEvent eventObject in eventObjects)
                eventObject.OnMachineClose();
            StartCoroutine(FinishAfter10Seconds());
        }

        private IEnumerator FinishAfter10Seconds()
        {
            yield return new WaitForSeconds(20.0F);
            OnSceneFinish();
        }
    }
}