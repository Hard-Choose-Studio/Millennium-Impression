using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class GameManager : GenericGameManager, IPonkyEvent
    {
        [SerializeField]
        private SportCar sportCar;

        public override void OnTargetFound()
        {
            hintText.gameObject.SetActive(false);
            sportCar.OnTargetFound();
        }

        public override void OnTargetLost()
        {
            sportCar.OnTargetLost();
        }

        public void OnCarStopDrive()
        {
            sportCar.OnCarStopDrive();
        }
    }
}