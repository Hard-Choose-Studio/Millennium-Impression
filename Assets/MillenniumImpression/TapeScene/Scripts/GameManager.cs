using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class GameManager : GenericGameManager
    {
        public static GameManager instance;

        [SerializeField]
        private Tape tape;
        [SerializeField]
        private CassetteMachineDoor cassetteMachineDoor;

        [SerializeField]
        private GameObject tapeTarget;
        [SerializeField]
        private GameObject chineseTarget;

        [SerializeField]
        private MusicPlayers musicPlayers;

        protected override void Awake()
        {
            base.Awake();
            instance = this;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            base.OnTargetFound();
            tape.OnTargetFound();
            cassetteMachineDoor.OnTargetFound();
            chineseTarget.SetActive(false);
        }

        public override void OnTargetLost()
        {
            if (tape.touchedMachine) //已經碰過了 就無所謂了
                return;
            base.OnTargetLost();
            tape.OnTargetLost();
            cassetteMachineDoor.OnTargetLost();
        }

        public void OnTapeReachedMachine()
        {
            tape.OnTapeReachedMachine();
            cassetteMachineDoor.OnTapeReachedMachine();
        }

        public void OnMachineClose()
        {
            chineseTarget.SetActive(true);
            tapeTarget.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }

        public void OnChineseTargetFound()
        {
            musicPlayers.OnChineseTargetFound();
        }

        public void OnChineseTargetLost()
        {
            musicPlayers.OnChineseTargetLost();
        }
    }
}