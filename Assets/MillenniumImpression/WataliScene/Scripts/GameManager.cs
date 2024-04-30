using UnityEngine;

namespace MillenniumImpression.WataliScene
{
    public class GameManager : GenericGameManager, IWataliEvent
    {
        public static GameManager instance;

        [SerializeField]
        private Yvon yvon;

        [SerializeField]
        private SoundPlayer soundPlayer;

        private readonly IWataliEvent[] evnetObjects = new IWataliEvent[2];

        private void Awake()
        {
            instance = this;

            evnetObjects[0] = yvon;
            evnetObjects[1] = soundPlayer;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            base.OnTargetFound();
            foreach (IWataliEvent e in evnetObjects)
                e.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            base.OnTargetLost();
            foreach (IWataliEvent e in evnetObjects)
                e.OnTargetLost();
        }

        public void OnGood()
        {
            foreach (IWataliEvent e in evnetObjects)
                e.OnGood();
            OnSceneFinish();
        }
    }
}