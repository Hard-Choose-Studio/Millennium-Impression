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
            hasFoundLost.SetTargetFound(); //開門
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost(); //回到idle
        }

        public void OnTapeReachedMachine()
        {
            hasFoundLost.SetAnimatorValue("closeDoor"); //關門
        }
    }
}