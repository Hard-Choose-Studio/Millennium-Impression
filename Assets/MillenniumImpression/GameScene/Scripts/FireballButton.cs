using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class FireballButton : GenericButton
    {
        [SerializeField]
        private Mary mary;

        public override void OnClick()
        {
            mary.ShootFireBall();
        }
    }
}