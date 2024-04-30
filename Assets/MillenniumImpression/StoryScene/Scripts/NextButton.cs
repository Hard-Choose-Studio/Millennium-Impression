using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MillenniumImpression.StoryScene
{
    public class NextButton : GenericButton
    {
        [SerializeField]
        private Image background;

        public override void OnClick()
        {
            button.enabled = false;
            StartCoroutine(LoadSceneTransition());
        }

        private IEnumerator LoadSceneTransition()
        {
            yield return null;
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(StoryScene.targetScene.ToString());
            asyncOperation.allowSceneActivation = false;
            for (float newAlpha = 1.0F; newAlpha >= 0.0F; newAlpha -= 0.1F)
            {
                Color newColor = background.color;
                newColor.a = newAlpha;
                background.color = newColor;
                yield return new WaitForSeconds(0.1F);
            }
            asyncOperation.allowSceneActivation = true;
        }
    }
}