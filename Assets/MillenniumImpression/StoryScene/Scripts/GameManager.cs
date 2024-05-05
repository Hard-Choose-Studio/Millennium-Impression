using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MillenniumImpression.StoryScene
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField]
        private Image background;
        [SerializeField]
        private Text buttonText;
        [SerializeField]
        private Text storyText;

        private readonly Graphic[] alphaNeedChange = new Graphic[3]; //Graphic�OImage�MText�@�P�������O �֦�color�ܼ�

        private void Awake()
        {
            instance = this;

            //�|�b�u�~��v���s�Q���U���ܲH
            alphaNeedChange[0] = background;
            alphaNeedChange[1] = buttonText;
            alphaNeedChange[2] = storyText;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Start()
        {
            StartCoroutine(FadeIn());
        }

        public void LoadScene()
        {
            StartCoroutine(LoadSceneTransition());
        }

        private IEnumerator FadeIn()
        {
            for (float newAlpha = 0.0F; newAlpha <= 1.0F; newAlpha += 0.1F)
            {
                foreach (Graphic graphic in alphaNeedChange)
                {
                    Color newColor = graphic.color;
                    newColor.a = newAlpha;
                    graphic.color = newColor;
                }
                yield return new WaitForSeconds(0.1F);
            }
        }

        private IEnumerator LoadSceneTransition()
        {
            yield return null;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(StoryData.targetScene.ToString());
            asyncOperation.allowSceneActivation = false;
            for (float newAlpha = 1.0F; newAlpha >= 0.0F; newAlpha -= 0.1F)
            {
                foreach (Graphic graphic in alphaNeedChange)
                {
                    Color newColor = graphic.color;
                    newColor.a = newAlpha;
                    graphic.color = newColor;
                }
                yield return new WaitForSeconds(0.1F);
            }
            asyncOperation.allowSceneActivation = true;
        }
    }
}