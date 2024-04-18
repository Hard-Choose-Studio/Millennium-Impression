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
            if (tape.touchedMachine) //�w�g�I�L�F �N�L�ҿפF
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