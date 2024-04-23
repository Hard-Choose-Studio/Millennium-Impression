using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class SportCar : MonoBehaviour, IPonkyEvent
    {
        private HasFoundLost hasFoundLost;
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasVideoPlayer = GetComponent<HasVideoPlayer>();
            hasFoundLost = GetComponent<HasFoundLost>();
        }

        public void OnTargetFound()
        {
            hasFoundLost.SetTargetFound();

            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play();
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost();

            hasVideoPlayer.Stop();
        }

        public void OnCarStopDrive()
        {
            throw new System.NotImplementedException();
        }
    }
}