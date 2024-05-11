using System;
using UnityEngine;

namespace MillenniumImpression
{
    public class GenericGameManager : MonoBehaviour, IEvent
    {
        public static readonly Action EMPTY_ACTION = () => { };

        [SerializeField]
        protected GameObject hintObject;
        [SerializeField]
        protected string[] nextStory;
        [SerializeField]
        protected Scenes nextScene;
        [SerializeField]
        protected ChangeButton nextButton;

        protected bool isFinished = false;

        protected virtual void Awake()
        {
            SetStoryAndTarget();
        }

        public virtual void OnTargetFound()
        {
            if (!isFinished) //如果尚未結束
                hintObject.SetActive(false); //停止顯示提示
            //如果已經結束了就算了
        }

        public virtual void OnTargetLost()
        {
            if (!isFinished) //如果尚未結束
                hintObject.SetActive(true); //重新顯示提示
            //如果已經結束了就算了
        }

        protected void OnSceneFinish() //scene結束的時候
        {
            //應由其他事件呼叫使用
            isFinished = true;
            nextButton.gameObject.SetActive(true);
        }

        protected void SetStoryAndTarget()
        {
            StoryScene.StoryData.SetStory(nextStory);
            StoryScene.StoryData.SetTargetScene(nextScene);
        }
    }
}