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
        private Image buttonImage;
        [SerializeField]
        private Text buttonText;
        [SerializeField]
        private Text storyText;

        private readonly Graphic[] alphaNeedChange = new Graphic[4]; //Graphic是Image和Text共同的親類別 擁有color變數

        private void Awake()
        {
            instance = this;

            //會在「繼續」按鈕被按下後變淡
            alphaNeedChange[0] = background;
            alphaNeedChange[1] = buttonImage;
            alphaNeedChange[2] = buttonText;
            alphaNeedChange[3] = storyText;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public void LoadScene()
        {
            StartCoroutine(LoadSceneTransition());
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