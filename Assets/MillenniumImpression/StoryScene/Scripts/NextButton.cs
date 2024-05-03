namespace MillenniumImpression.StoryScene
{
    public class NextButton : GenericButton
    {
        public override void OnClick()
        {
            GameManager.instance.LoadScene();
            gameObject.SetActive(false);
        }
    }
}