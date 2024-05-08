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

        [SerializeField]
        private Sprite ponky;
        [SerializeField]
        private Sprite aquaOil;
        [SerializeField]
        private Sprite tape;
        [SerializeField]
        private Sprite messenger;
        [SerializeField]
        private Sprite watali;
        [SerializeField]
        private Sprite television;

        private readonly Graphic[] alphaNeedChange = new Graphic[3]; //Graphic是Image和Text共同的親類別 擁有color變數

        private void Awake()
        {
            instance = this;

            //會在「繼續」按鈕被按下後變淡
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
            switch (StoryData.targetScene)
            {
                case Scenes.PonkyScene:
                    background.sprite = ponky;
                    break;
                case Scenes.AquaOilScene:
                    background.sprite = aquaOil;
                    break;
                case Scenes.TapeScene:
                    background.sprite = tape;
                    break;
                case Scenes.MessengerScene:
                    background.sprite = messenger;
                    break;
                case Scenes.WataliScene:
                    background.sprite = watali;
                    break;
                case Scenes.TelevisionScene:
                    background.sprite = television;
                    break;
            }

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