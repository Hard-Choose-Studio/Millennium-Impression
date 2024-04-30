using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public class ChangeButton : GenericButton
    {
        [SerializeField]
        private Scenes targetScene;
        [SerializeField]
        private RawImage transitionImage;

        public override void OnClick()
        {
            button.enabled = false;
            StartCoroutine(LoadSceneTransition());
        }

        private IEnumerator LoadSceneTransition()
        {
            yield return null;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(targetScene.ToString());
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