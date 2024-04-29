using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MillenniumImpression.StoryScene
{
    public class StoryText : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
            StartCoroutine(PlayStory());
        }

        private IEnumerator PlayStory()
        {
            foreach (string story in StoryData.stories[StoryData.nextScene])
            {
                text.text += $"{story}\n";
                yield return new WaitForSeconds(3.0F);
            }
            SceneManager.LoadScene(StoryData.nextScene.ToString());
        }
    }
}