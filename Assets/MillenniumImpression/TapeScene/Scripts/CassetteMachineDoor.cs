using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class CassetteMachineDoor : MonoBehaviour, ITapeEvent
    {
        private HasFoundLost hasFoundLost;

        private void Awake()
        {
            hasFoundLost = GetComponent<HasFoundLost>();
            hasFoundLost.AddAnimationEvent("finish_closing", () => GameManager.instance.OnMachineClose());
        }

        public void OnTargetFound()
        {
            hasFoundLost.SetTargetFound(); //�}��
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost(); //�^��idle
        }

        public void OnTapeReachedMachine()
        {
            hasFoundLost.SetAnimatorValue("closeDoor"); //����
        }
    }
}