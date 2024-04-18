using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public class ChangeButton : GenericButton
    {
        /*[SerializeField]
        private ChangeButton anotherButton;*/
        [SerializeField]
        private string targetScene;
        [SerializeField]
        private RawImage transitionImage;

        private Button thisButton;
        //private Button thatButton;

        private void Awake()
        {
            thisButton = GetComponent<Button>();
            //thatButton = anotherButton.GetComponent<Button>();
        }

        public override void OnClick()
        {
            thisButton.enabled/* = thatButton.enabled*/ = false;
            StartCoroutine(LoadSceneTransition());
        }

        private IEnumerator LoadSceneTransition()
        {
            yield return null;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(targetScene);
            while (!asyncOperation.isDone)
            {
                Color newColor = transitionImage.color;
                newColor.a = 1.0F - asyncOperation.progress;
                transitionImage.color = newColor;
                yield return null;
            }
        }
    }
}