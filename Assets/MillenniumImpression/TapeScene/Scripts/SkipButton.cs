using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class SkipButton : GenericButton
    {
        [SerializeField]
        private MusicPlayers musicPlayers;
        [SerializeField]
        private bool isPrevious;

        public override void OnClick()
        {
            if (isPrevious)
                musicPlayers.PreviousSong();
            else
                musicPlayers.NextSong();
        }
    }
}