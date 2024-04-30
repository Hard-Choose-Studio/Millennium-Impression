namespace MillenniumImpression.StoryScene
{
    public class StoryScene
    {
        internal static string[] story = { };
        internal static Scenes targetScene = Scenes.PonkyScene;
        public static void SetStory(string[] story) => StoryScene.story = story;
        public static void SetTargetScene(Scenes targetScene) => StoryScene.targetScene = targetScene;
    }
}