namespace MillenniumImpression.StoryScene
{
    public static class StoryData
    {
        internal static string[] story = { };
        internal static Scenes targetScene = Scenes.PonkyScene;
        public static void SetStory(string[] story) => StoryData.story = story;
        public static void SetTargetScene(Scenes targetScene) => StoryData.targetScene = targetScene;
    }
}