using UnityEngine.SceneManagement;

namespace MillenniumImpression
{
    public class ChangeButton : GenericButton
    {
        public override void OnClick()
        {
            SceneManager.LoadScene(Scenes.StoryScene.ToString()); //直接轉到StoryScene
        }
    }
}