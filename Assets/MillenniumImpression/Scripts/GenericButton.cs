using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public abstract class GenericButton : MonoBehaviour
    {
        protected Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public abstract void OnClick();
    }
}