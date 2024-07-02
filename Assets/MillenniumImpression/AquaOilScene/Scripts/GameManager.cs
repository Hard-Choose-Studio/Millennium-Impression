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
        [SerializeField]
        private AudioSource aquaOilAudio;

        private readonly IAquaOilEvent[] eventObjects = new IAquaOilEvent[3];

        private bool vanishing = false;

        protected override void Awake()
        {
            base.Awake();

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
            if (vanishing) //正在消失
                return; //不執行了
            base.OnTargetFound();
            aquaOilAudio.Play();
            foreach (IAquaOilEvent e in eventObjects)
                e.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (vanishing) //正在消失
                return; //不執行了
            aquaOilAudio.Stop();
            foreach (IAquaOilEvent e in eventObjects)
                e.OnTargetLost();
        }

        public void OnBottleOpened()
        {
            foreach (IAquaOilEvent e in eventObjects)
                e.OnBottleOpened();
        }

        public void OnVanishing()
        {
            foreach (IAquaOilEvent e in eventObjects)
                e.OnVanishing();
            vanishing = true;
            OnSceneFinish();
        }
    }
}