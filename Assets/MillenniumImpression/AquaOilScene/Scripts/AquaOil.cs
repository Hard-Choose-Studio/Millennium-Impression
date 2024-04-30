using System;
using UnityEngine;

namespace MillenniumImpression.AquaOilScene
{
    public class AquaOil : MonoBehaviour, IAquaOilEvent
    {
        private HasVideoPlayer hasVideoPlayer;

        private Action updateAction;
        private Action playingAction;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
            playingAction = () =>
            {
                if (hasVideoPlayer.GetVideoPlayer().frame == 58L) //在第2秒11影格的時候開啟 48 + 11 = 59
                    GameManager.instance.OnBottleOpened();
            };
        }

        private void Update()
        {
            updateAction();
        }

        public void OnTargetFound()
        {
            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play();
            updateAction = playingAction;
        }

        public void OnTargetLost()
        {
            updateAction = GenericGameManager.EMPTY_ACTION;
            hasVideoPlayer.Stop();
        }

        public void OnBottleOpened()
        {
            updateAction = GenericGameManager.EMPTY_ACTION;
            hasVideoPlayer.GetVideoPlayer().Pause();
        }
    }
}