namespace MillenniumImpression.DeskScene
{
    public class GameManager : GenericGameManager, IDeskEvent
    {
        public override void OnTargetFound()
        {
            base.OnTargetFound();
            TellAfterStory();
        }
    }
}