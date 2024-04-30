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

        protected override void Awake()
        {
            base.Awake();
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
            base.OnTargetFound();
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnTargetLost();
        }

        public void OnCarStopDrive()
        {
            afterStory.gameObject.SetActive(true);
            StartCoroutine(afterStory.StoryTeller());
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnCarStopDrive();
        }
    }
}