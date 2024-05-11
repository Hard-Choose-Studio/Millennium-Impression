using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.StoryScene
{
    [RequireComponent(typeof(Text))]
    [RequireComponent(typeof(AudioSource))]
    public class StoryText : MonoBehaviour
    {
        private Text text;
        private AudioSource wataliAudioSource;

        [SerializeField]
        private GameObject nextButton;

        private const float TYPE_TIME = 0.05F;

        private void Awake()
        {
            text = GetComponent<Text>();
            wataliAudioSource = GetComponent<AudioSource>();
            StartCoroutine(StoryTeller());
            if (StoryData.targetScene == Scenes.WataliScene)
                StartCoroutine(DrinkWatali());
        }

        private IEnumerator StoryTeller()
        {
            nextButton.SetActive(false);
            StringBuilder builder = new();
            foreach (char c in string.Join('\n', StoryData.story))
            {
                text.text = builder.Append(c).ToString();
                yield return new WaitForSeconds(TYPE_TIME);
            }
            nextButton.SetActive(true);
        }

        private IEnumerator DrinkWatali()
        {
            yield return new WaitForSeconds((StoryData.story[0].Length + StoryData.story[1].Length + StoryData.story[2].Length + 3) * TYPE_TIME);
            wataliAudioSource.Play();
        }
    }
}