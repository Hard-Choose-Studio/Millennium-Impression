using System;
using UnityEngine;

namespace MillenniumImpression
{
    public class GenericGameManager : MonoBehaviour, IEvent
    {
        public static readonly Action EMPTY_ACTION = () => { };

        [SerializeField]
        protected HintText hintText;
        [SerializeField]
        protected GameObject sceneTarget;
        [SerializeField]
        protected StoryText beforeStory;
        [SerializeField]
        protected StoryText afterStory;
        [SerializeField]
        protected ChangeButton nextButton;

        protected virtual void Awake()
        {
            sceneTarget.SetActive(false);

            beforeStory.gameObject.SetActive(true);
            beforeStory.storyEnd = () => BeforeStoryEnd();

            afterStory.gameObject.SetActive(false);
            afterStory.storyEnd = () => AfterStoryEnd();

            nextButton.gameObject.SetActive(false);
        }

        protected virtual void Start()
        {
            StartCoroutine(beforeStory.StoryTeller());
        }

        public virtual void OnTargetFound()
        {
            beforeStory.gameObject.SetActive(false);
        }

        public virtual void OnTargetLost() { }

        public virtual void BeforeStoryEnd()
        {
            sceneTarget.SetActive(true);
        }

        public virtual void AfterStoryEnd()
        {
            nextButton.gameObject.SetActive(true);
        }

        protected void TellAfterStory()
        {
            afterStory.gameObject.SetActive(true);
            StartCoroutine(afterStory.StoryTeller());
        }
    }
}