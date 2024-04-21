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
            hintText.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);

            musicPlayer.OnTargetLost();
        }
    }
}