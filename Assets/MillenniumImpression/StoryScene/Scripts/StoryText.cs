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

            if (StoryData.targetScene == Scenes.PreviouslyScene)
                transform.localPosition = Vector3.zero;
            else
            {
                if (StoryData.targetScene == Scenes.WataliScene)
                    StartCoroutine(DrinkWatali());
                transform.localPosition = new(300.0F, 0.0F, 0.0F);
            }
        }

        private IEnumerator StoryTeller()
        {
            nextButton.SetActive(false);
            StringBuilder builder = new();
            string story = string.Join('\n', StoryData.story);
            foreach (char c in story)
            {
                if (Input.touchCount != 0)
                {
                    text.text = story;
                    break;
                }
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