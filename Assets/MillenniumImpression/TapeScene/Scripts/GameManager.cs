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

        protected override void Awake()
        {
            base.Awake();

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
            if (tape.touchedMachine) //已經碰過了 就無所謂了
                return;
            base.OnTargetFound();
            instructmentsCanvas.SetActive(false); //本來是true 讓他們可以先播放 做為緩衝
            foreach (ITapeEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (tape.touchedMachine) //已經碰過了 就無所謂了
                return;
            base.OnTargetLost();
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
            yield return new WaitForSeconds(10.0F); //至少聽10秒的歌
            OnSceneFinish();
        }
    }
}