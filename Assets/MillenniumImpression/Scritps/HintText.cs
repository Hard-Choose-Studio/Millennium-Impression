using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression
{
    public class HintText : MonoBehaviour, IResettable
    {
        private Text text;
        private float tick = 0;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            tick += Time.deltaTime;
            if (tick < 2)
                return;
            tick -= 2;

            // 1/3 -> 2/3 -> 1/3 -> 2/3 ...
            Color newColor = text.color;
            newColor.a = 1 - text.color.a;
            text.color = newColor;
        }

        public void ResetObject()
        {
            gameObject.SetActive(true);
        }
    }
}