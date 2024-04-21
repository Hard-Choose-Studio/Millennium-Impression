using System;
using UnityEngine;

namespace MillenniumImpression
{
    public abstract class GenericGameManager : MonoBehaviour, IEvent
    {
        public static readonly Action EMPTY_ACTION = () => { };

        [SerializeField]
        protected HintText hintText;
        [SerializeField]
        protected ChangeButton nextButton;

        public abstract void OnTargetFound();

        public abstract void OnTargetLost();
    }
}