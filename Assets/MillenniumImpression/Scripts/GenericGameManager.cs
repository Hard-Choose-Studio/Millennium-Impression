using System;
using UnityEngine;

namespace MillenniumImpression
{
    public class GenericGameManager : MonoBehaviour, IEvent
    {
        public static readonly Action EMPTY_ACTION = () => { };

        [SerializeField]
        protected GameObject hintText;
        [SerializeField]
        protected string[] nextStory;
        [SerializeField]
        protected Scenes nextScene;
        [SerializeField]
        protected ChangeButton nextButton;

        private bool isFinished = false;

        public virtual void OnTargetFound()
        {
            if (!isFinished)
                hintText.SetActive(false);
        }

        public virtual void OnTargetLost()
        {
            if (!isFinished)
                hintText.SetActive(true);
        }

        protected virtual void OnSceneFinish()
        {
            isFinished = true;
            ShowNextButton();
        }

        private void ShowNextButton()
        {
            StoryScene.StoryScene.SetStory(nextStory);
            StoryScene.StoryScene.SetTargetScene(nextScene);
            nextButton.gameObject.SetActive(true);
        }
    }
}