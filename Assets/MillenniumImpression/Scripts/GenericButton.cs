using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public abstract class GenericButton : MonoBehaviour
    {
        protected Button button;
        protected Image image;
        protected Text text;
        protected bool hasText;

        private void Awake()
        {
            button = GetComponent<Button>();
            image = GetComponent<Image>();
            hasText = transform.childCount != 0 && transform.GetChild(0).TryGetComponent(out text);
        }

        public abstract void OnClick();
    }
}