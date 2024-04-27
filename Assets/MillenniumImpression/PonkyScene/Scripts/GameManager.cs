using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class GameManager : GenericGameManager, IPonkyEvent
    {
        public static GameManager instance;

        [SerializeField]
        private SportCar sportCar;
        [SerializeField]
        private FruitGenerator fruitGenerator;

        private readonly IPonkyEvent[] eventObjects = new IPonkyEvent[2];

        private void Awake()
        {
            instance = this;
            eventObjects[0] = sportCar;
            eventObjects[1] = fruitGenerator;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            hintText.gameObject.SetActive(false);
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (hintText != null)
                hintText.gameObject.SetActive(true);
            if (nextButton != null)
                nextButton.gameObject.SetActive(false);

            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnTargetLost();
        }

        public void OnCarStopDrive()
        {
            nextButton.gameObject.SetActive(true);

            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnCarStopDrive();
        }
    }
}