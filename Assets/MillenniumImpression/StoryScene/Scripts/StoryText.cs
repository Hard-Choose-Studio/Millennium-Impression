using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.StoryScene
{
    public class StoryText : MonoBehaviour
    {
        private Text text;

        [SerializeField]
        private Button nextButton;

        private void Awake()
        {
            text = GetComponent<Text>();
            nextButton.enabled = false;
            StartCoroutine(StoryTeller());
        }

        private IEnumerator StoryTeller()
        {
            StringBuilder builder = new();
            foreach (char c in string.Join('\n', StoryData.story))
            {
                text.text = builder.Append(c).ToString();
                yield return new WaitForSeconds(0.1F);
            }
            nextButton.enabled = true;
        }
    }
}