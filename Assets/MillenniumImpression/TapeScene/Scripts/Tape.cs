using System;
using UnityEngine;

namespace MillenniumImpression.TapeScene
{
    public class Tape : MonoBehaviour
    {
        [SerializeField]
        private Transform cassetteMachineTransform;

        private Vector3 originPosition;
        private Quaternion originRotation;
        private Vector2 lastPosition = Vector2.zero;

        private Action updateAction;
        private Action moveAction;

        internal bool touchedMachine = false;

        private void Awake()
        {
            originPosition = transform.localPosition;
            originRotation = transform.localRotation;

            updateAction = GenericGameManager.EMPTY_ACTION;
            moveAction = () =>
            {
                Touch[] touches = Input.touches;
                if (touches.Length == 0)
                    return;
                Touch touch = touches[0];
                Vector2 touchPosition = touch.position;
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        lastPosition = touchPosition;
                        break;

                    case TouchPhase.Moved:
                        transform.localPosition = new(transform.localPosition.x + (touchPosition.x - lastPosition.x) * 0.001F,
                            transform.localPosition.y + (touchPosition.y - lastPosition.y) * 0.001F);
                        lastPosition = touchPosition;
                        break;

                    case TouchPhase.Ended:
                        transform.localPosition = originPosition;
                        break;
                }

                if (touchedMachine)
                    GameManager.instance.OnTapeReachedMachine();
            };
        }

        private void Update()
        {
            updateAction();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == cassetteMachineTransform)
                touchedMachine = true;
        }

        internal void OnTapeReachedMachine()
        {
            updateAction = GenericGameManager.EMPTY_ACTION;
            transform.SetLocalPositionAndRotation(new(0.2707F, -0.0171F, 0.0637F), Quaternion.Euler(0, -110, 90));
        }

        public void OnTargetFound()
        {
            updateAction = moveAction;
            transform.SetLocalPositionAndRotation(originPosition, originRotation);
        }

        public void OnTargetLost()
        {
            updateAction = GenericGameManager.EMPTY_ACTION;
            transform.SetLocalPositionAndRotation(originPosition, originRotation);
        }
    }
}