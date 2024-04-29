using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class CassetteMachineDoor : MonoBehaviour, ITapeEvent
    {
        [SerializeField]
        private Tape tape;

        private HasFoundLost hasFoundLost;

        private void Awake()
        {
            hasFoundLost = GetComponent<HasFoundLost>();
            hasFoundLost.AddAnimationEvent("finish_closing", () => GameManager.instance.OnMachineClose());
        }

        public void OnTargetFound()
        {
            if (!tape.touchedMachine)
                hasFoundLost.SetTargetFound(); //�}��
        }

        public void OnTargetLost()
        {
            if (!tape.touchedMachine)
                hasFoundLost.SetTargetLost(); //�^��idle
        }

        public void OnTapeReachedMachine()
        {
            hasFoundLost.SetAnimatorValue("closeDoor"); //����
        }

        public void OnMachineClose() { }
    }
}