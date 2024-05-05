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
        [SerializeField]
        private AudioSource ponkyAudio;

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
            if (isFinished)
                return;
            base.OnTargetFound();
            ponkyAudio.Play();
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (isFinished)
                return;
            base.OnTargetLost();
            ponkyAudio.Stop();
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnTargetLost();
        }

        public void OnCarStopDrive()
        {
            foreach (IPonkyEvent eventObject in eventObjects)
                eventObject.OnCarStopDrive();
            OnSceneFinish();
        }
    }
}