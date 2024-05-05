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

        protected bool isFinished = false;

        public virtual void OnTargetFound()
        {
            if (!isFinished) //�p�G�|������
                hintText.SetActive(false); //������ܴ���
            //�p�G�w�g�����F�N��F
        }

        public virtual void OnTargetLost()
        {
            if (!isFinished) //�p�G�|������
                hintText.SetActive(true); //���s��ܴ���
            //�p�G�w�g�����F�N��F
        }

        protected virtual void OnSceneFinish() //scene�������ɭ�
        {
            //���Ѩ�L�ƥ�I�s�ϥ�
            isFinished = true;
            ShowNextButton();
        }

        private void ShowNextButton()
        {
            StoryScene.StoryData.SetStory(nextStory);
            StoryScene.StoryData.SetTargetScene(nextScene);
            nextButton.gameObject.SetActive(true);
        }
    }
}