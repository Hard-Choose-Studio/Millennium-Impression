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
            if (!isFinished) //�p�G�|������
                hintObject.SetActive(false); //������ܴ���
            //�p�G�w�g�����F�N��F
        }

        public virtual void OnTargetLost()
        {
            if (!isFinished) //�p�G�|������
                hintObject.SetActive(true); //���s��ܴ���
            //�p�G�w�g�����F�N��F
        }

        protected void OnSceneFinish() //scene�������ɭ�
        {
            //���Ѩ�L�ƥ�I�s�ϥ�
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