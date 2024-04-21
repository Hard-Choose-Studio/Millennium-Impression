using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public class ChangeButton : GenericButton
    {
        [SerializeField]
        private string targetScene;
        [SerializeField]
        private RawImage transitionImage;

        private Button thisButton;

        private void Awake()
        {
            thisButton = GetComponent<Button>();
        }

        public override void OnClick()
        {
            thisButton.enabled = false;
            StartCoroutine(LoadSceneTransition());
        }

        private IEnumerator LoadSceneTransition()
        {
            yield return null;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(targetScene);
            while (!asyncOperation.isDone)
            {
                Color newColor = transitionImage.color;
                newColor.a = asyncOperation.progress;
                transitionImage.color = newColor;
                yield return new WaitForSeconds(1.0F);
            }
        }
    }
}