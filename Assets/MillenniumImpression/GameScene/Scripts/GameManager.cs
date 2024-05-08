using System.Collections.Generic;
using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class GameManager : GenericGameManager, IGameEvent
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
        private TheEnd theEnd;

        [SerializeField]
        private LayerMask groundLayer;

        private readonly IResettable[] resetObjects = new IResettable[5];
        private readonly HashSet<GameObject> destroyWhenReset = new();

        private AudioSource bgm;

        private void Awake()
        {
            instance = this;

            resetObjects[0] = mary;
            resetObjects[1] = goomba;
            resetObjects[2] = brick1;
            resetObjects[3] = brick2;
            resetObjects[4] = theEnd;

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
            bgm.Play();

            mary.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            base.OnTargetLost();
            maryGame.SetActive(false);
            bgm.Stop();
            ResetObject();

            mary.OnTargetLost();
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
            foreach (GameObject obj in destroyWhenReset)
                if (obj != null)
                    Destroy(obj);
            destroyWhenReset.Clear();
        }

        public bool IsGround(GameObject obj) => (1 << obj.layer | groundLayer) == groundLayer;

        public void AddResetGameObject(GameObject obj) => destroyWhenReset.Add(obj);
    }
}