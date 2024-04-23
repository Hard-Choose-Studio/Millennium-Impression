using System;
using System.Collections.Generic;
using UnityEngine;

namespace MillenniumImpression
{
    public class HasAnimator : MonoBehaviour
    {
        protected Animator animator;

        protected readonly Dictionary<string, Action> eventFunctions = new();

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetAnimatorValue(string name) => animator.SetTrigger(name);

        public void SetAnimatorValue(string name, bool b) => animator.SetBool(name, b);

        public void SetAnimatorValue(string name, int i) => animator.SetInteger(name, i);

        public void SetAnimatorValue(string name, float f) => animator.SetFloat(name, f);

        public void AddAnimationEvent(string name, Action callback) => eventFunctions.Add(name, callback);

        public void OnAnimationEvent(string name) => eventFunctions[name](); //eventFunctions[name]?.Invoke();
    }
}