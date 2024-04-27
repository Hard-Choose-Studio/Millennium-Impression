using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class SportCar : MonoBehaviour, IPonkyEvent
    {
        private HasFoundLost hasFoundLost;
        private HasVideoPlayer hasVideoPlayer;

        private void Awake()
        {
            hasFoundLost = GetComponent<HasFoundLost>();
            hasFoundLost.AddAnimationEvent("stop_drive", () => GameManager.instance.OnCarStopDrive());

            hasVideoPlayer = GetComponent<HasVideoPlayer>();
        }

        public void OnTargetFound()
        {
            hasFoundLost.SetTargetFound(); //�}�l�}��

            hasVideoPlayer.ClearRenderTexture();
            hasVideoPlayer.Play(); //����v��
        }

        public void OnTargetLost()
        {
            hasFoundLost.SetTargetLost();

            hasVideoPlayer.Stop();
        }

        public void OnCarStopDrive()
        {
            hasVideoPlayer.GetVideoPlayer().Pause();
        }
    }
}