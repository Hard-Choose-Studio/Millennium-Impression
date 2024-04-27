using UnityEngine;

namespace MillenniumImpression.AquaOilScene
{
    public class GameManager : GenericGameManager, IAquaOilEvent
    {
        public static GameManager instance;

        [SerializeField]
        private AquaOil aquaOil;
        [SerializeField]
        private Smoke smoke;
        [SerializeField]
        private Bicycle bicycle;

        private readonly IAquaOilEvent[] eventObjects = new IAquaOilEvent[3];

        private void Awake()
        {
            instance = this;

            eventObjects[0] = aquaOil;
            eventObjects[1] = smoke;
            eventObjects[2] = bicycle;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            hintText.gameObject.SetActive(false);
            foreach (IAquaOilEvent e in eventObjects)
                e.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            hintText.gameObject.SetActive(true);
            foreach (IAquaOilEvent e in eventObjects)
                e.OnTargetLost();
        }

        public void OnBottleOpened()
        {
            foreach (IAquaOilEvent e in eventObjects)
                e.OnBottleOpened();
        }
    }
}