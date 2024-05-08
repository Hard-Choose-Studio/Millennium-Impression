using UnityEngine;
using UnityEngine.SceneManagement;

namespace MillenniumImpression.PreviouslyScene
{
    public class StartButton : GenericButton
    {
        [SerializeField]
        private string[] nextStory;
        [SerializeField]
        private Scenes nextScene;

        public override void OnClick()
        {
            StoryScene.StoryData.SetStory(nextStory);
            StoryScene.StoryData.SetTargetScene(nextScene);
            SceneManager.LoadScene(Scenes.StoryScene.ToString());
        }
    }
}