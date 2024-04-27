using UnityEngine;

namespace MillenniumImpression.ConcertScene
{
    public class GameManager : GenericGameManager
    {
        [SerializeField]
        private MusicPlayer musicPlayer;

        public override void OnTargetFound()
        {
            hintText.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);

            musicPlayer.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            if (hintText != null)
                hintText.gameObject.SetActive(true);
            if (nextButton != null)
                nextButton.gameObject.SetActive(false);

            musicPlayer.OnTargetLost();
        }
    }
}