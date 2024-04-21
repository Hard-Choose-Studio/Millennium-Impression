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
        private GameObject arrow;

        private readonly ITapeEvent[] eventObjects = new ITapeEvent[2];

        private void Awake()
        {
            instance = this;
            eventObjects[0] = tape;
            eventObjects[1] = cassetteMachineDoor;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            if (tape.touchedMachine) //已經碰過了 就無所謂了
                return;
            hintText.gameObject.SetActive(false);
            foreach (ITapeEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (tape.touchedMachine) //已經碰過了 就無所謂了
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
            nextButton.gameObject.SetActive(true);
        }
    }
}