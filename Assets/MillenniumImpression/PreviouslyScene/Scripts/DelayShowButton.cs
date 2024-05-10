using System.Collections;
using UnityEngine;

namespace MillenniumImpression.PreviouslyScene
{
    public class DelayShowButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject startButton;

        private void Awake()
        {
            StartCoroutine(EnableButton());
        }

        private IEnumerator EnableButton()
        {
            startButton.SetActive(false);
            yield return new WaitForSeconds(7.0F);
            startButton.SetActive(true);
        }
    }
}