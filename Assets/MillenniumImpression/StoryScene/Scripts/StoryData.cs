using System;

namespace MillenniumImpression.StoryScene
{
    public static class StoryData
    {
        internal static string[] story = { };
        internal static Scenes targetScene = Scenes.PonkyScene;
        public static void SetStory(string[] story) => StoryData.story = story;
        public static void SetTargetScene(Scenes targetScene) => StoryData.targetScene = targetScene;

        private static int advertisement = new Random().Next(3);

        public static int NextAdvertisement()
        {
            int ad = advertisement;
            advertisement++;
            if (advertisement == 3)
                advertisement = 0;
            return ad;
        }
    }
}