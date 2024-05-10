using System.Collections;
using UnityEngine;

namespace MillenniumImpression.TelevisionScene
{
    public class GameManager : GenericGameManager
    {
        private Coroutine endVideo = null;

        [SerializeField]
        private MajoNoJouken majoNoJouken;

        public override void OnTargetFound()
        {
            if (isFinished)
                return;
            base.OnTargetFound();
            endVideo = StartCoroutine(EndVideo());
            majoNoJouken.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (isFinished)
                return;
            base.OnTargetLost();
            if (endVideo != null)
                StopCoroutine(endVideo);
        }

        private IEnumerator EndVideo()
        {
            yield return new WaitForSeconds(15.0F);
            OnSceneFinish();
        }
    }
}