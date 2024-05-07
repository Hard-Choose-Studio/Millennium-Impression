using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class GameManager : GenericGameManager
    {
        public static GameManager instance;

        [SerializeField]
        private GameObject maryGame;
        [SerializeField]
        private Mary mary;
        [SerializeField]
        private Goomba goomba;
        [SerializeField]
        private ExclamationBrick brick1;
        [SerializeField]
        private ExclamationBrick brick2;

        [SerializeField]
        private LayerMask groundLayer;

        private readonly IResettable[] resetObjects = new IResettable[5];

        private AudioSource bgm;

        private void Awake()
        {
            instance = this;

            resetObjects[0] = mary;
            resetObjects[1] = goomba;
            resetObjects[2] = brick1;
            resetObjects[3] = brick2;

            bgm = GetComponent<AudioSource>();
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public override void OnTargetFound()
        {
            base.OnTargetFound();
            maryGame.SetActive(true);
            ResetObject();
            bgm.Play();
        }

        public override void OnTargetLost()
        {
            base.OnTargetLost();
            maryGame.SetActive(false);
            bgm.Stop();
        }

        public void OnEnd()
        {
            OnSceneFinish();
            ResetObject();
        }

        public void ResetObject()
        {
            foreach (IResettable resettable in resetObjects)
                resettable.ResetObject();
        }

        public bool IsGround(GameObject obj) => (1 << obj.layer | groundLayer) == groundLayer;
    }
}