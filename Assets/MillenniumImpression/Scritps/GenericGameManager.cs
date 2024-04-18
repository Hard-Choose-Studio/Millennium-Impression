using System;
using UnityEngine;
using UnityEngine.Video;

namespace MillenniumImpression
{
    public class GenericGameManager : MonoBehaviour
    {
        public static readonly Action EMPTY_ACTION = () => { };

        [SerializeField]
        protected HintText beforeHint;
        /*[SerializeField]
        protected ChangeButton previousButton;*/
        [SerializeField]
        protected ChangeButton nextButton;
        
        protected virtual void Awake()
        {
            beforeHint.gameObject.SetActive(true);
            //previousButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }

        public virtual void OnTargetFound()
        {
            beforeHint.gameObject.SetActive(false);
        }

        public virtual void OnTargetLost()
        {
            beforeHint.gameObject.SetActive(true);
        }

        public static void ClearRenderTexture(VideoPlayer videoPlayer)
        {
            RenderTexture renderTexture = RenderTexture.active;
            RenderTexture.active = videoPlayer.targetTexture;
            GL.Clear(true, true, Color.clear);
            RenderTexture.active = renderTexture;
        }
    }
}