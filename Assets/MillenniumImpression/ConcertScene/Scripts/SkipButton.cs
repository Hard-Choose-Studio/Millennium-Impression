using UnityEngine;

namespace MillenniumImpression.ConcertScene
{
    public class SkipButton : GenericButton
    {
        [SerializeField]
        private MusicPlayer musicPlayer;
        [SerializeField]
        private bool isPrevious;

        public override void OnClick()
        {
            musicPlayer.ChangeSong(isPrevious);
        }
    }
}