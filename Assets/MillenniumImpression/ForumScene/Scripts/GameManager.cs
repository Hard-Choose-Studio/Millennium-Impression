namespace MillenniumImpression.ForumScene
{
    public class GameManager : GenericGameManager
    {
        public override void OnTargetFound()
        {
            base.OnTargetFound();
            TellAfterStory();
        }
    }
}