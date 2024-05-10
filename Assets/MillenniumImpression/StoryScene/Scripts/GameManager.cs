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
        private Sprite backgroundSprite;
        [SerializeField]
        private Sprite tapeSprite;
        [SerializeField]
        private Sprite gameSprite;
        [SerializeField]
        private Sprite wataliSprite;
        [SerializeField]
        private Sprite ponkySprite;
        [SerializeField]
        private Sprite aquaOilSprite;
        [SerializeField]
        private Sprite messengerSprite;
        [SerializeField]
        private Sprite televisionSprite;

        [SerializeField]
        private AudioClip emptyAudio;
        [SerializeField]
        private AudioClip tapeAudio;
        [SerializeField]
        private AudioClip gameAudio;
        [SerializeField]
        private AudioClip wataliAudio;
        [SerializeField]
        private AudioClip aquaOilAudio;
        [SerializeField]
        private AudioClip messengerAudio;

        private readonly Graphic[] alphaNeedChange = new Graphic[3]; //Graphic是Image和Text共同的親類別 擁有color變數

        private AudioSource audioSource;

        private void Awake()
        {
            instance = this;

            //會在「繼續」按鈕被按下後變淡
            alphaNeedChange[0] = background;
            alphaNeedChange[1] = buttonText;
            alphaNeedChange[2] = storyText;

            audioSource = GetComponent<AudioSource>();
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Start()
        {
            switch (StoryData.targetScene)
            {
                case Scenes.TapeScene:
                    background.sprite = tapeSprite;
                    audioSource.clip = tapeAudio;
                    break;
                case Scenes.GameScene:
                    background.sprite = gameSprite;
                    audioSource.clip = gameAudio;
                    break;
                case Scenes.WataliScene:
                    background.sprite = wataliSprite;
                    audioSource.clip = wataliAudio;
                    break;
                case Scenes.PonkyScene:
                    background.sprite = ponkySprite;
                    audioSource.clip = emptyAudio;
                    break;
                case Scenes.AquaOilScene:
                    background.sprite = aquaOilSprite;
                    audioSource.clip = aquaOilAudio;
                    break;
                case Scenes.MessengerScene:
                    background.sprite = messengerSprite;
                    audioSource.clip = messengerAudio;
                    break;
                case Scenes.TelevisionScene:
                    background.sprite = televisionSprite;
                    audioSource.clip = emptyAudio;
                    break;
                default:
                    background.sprite = backgroundSprite;
                    audioSource.clip = emptyAudio;
                    break;
            }
            audioSource.Play();

            StartCoroutine(FadeIn());
        }

        public void LoadScene()
        {
            StartCoroutine(LoadSceneTransition());
        }

        private IEnumerator FadeIn()
        {
            for (float newAlpha = 0.0F; newAlpha <= 1.0F; newAlpha += 0.1F) //淡入
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
            asyncOperation.allowSceneActivation = false; //暫時不允許轉場
            for (float newAlpha = 1.0F; newAlpha >= 0.0F; newAlpha -= 0.1F) //淡出
            {
                foreach (Graphic graphic in alphaNeedChange)
                {
                    Color newColor = graphic.color;
                    newColor.a = newAlpha;
                    graphic.color = newColor;
                }
                yield return new WaitForSeconds(0.1F);
            }
            asyncOperation.allowSceneActivation = true; //允許轉場
        }
    }
}