using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public class StoryText : MonoBehaviour
    {
        [SerializeField]
        private string[] story;

        private Text text;

        public Action storyBegin = GenericGameManager.EMPTY_ACTION;
        public Action storyEnd = GenericGameManager.EMPTY_ACTION;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        public IEnumerator StoryTeller()
        {
            storyBegin();
            text.text = "";
            for (int i = 0; ;)
            {
                foreach (char c in story[i])
                {
                    text.text += c;
                    yield return new WaitForSeconds(0.1F);
                }
                if (++i == story.Length)
                    break;
                text.text += '\n';
                yield return new WaitForSeconds(0.1F);
            }
            storyEnd();
        }
    }
}