using UnityEngine;
using UnityEngine.UI;

namespace MillenniumImpression.MessengerScene
{
    public class MessageParent : MonoBehaviour
    {
        [SerializeField]
        protected string authorName;
        protected string authorNameWithColon;

        protected Text author;
        protected Text message;

        private void Awake()
        {
            authorNameWithColon = authorName + ": ";

            Text[] texts = GetComponentsInChildren<Text>();
            author = texts[0];
            message = texts[1];
        }
    }
}