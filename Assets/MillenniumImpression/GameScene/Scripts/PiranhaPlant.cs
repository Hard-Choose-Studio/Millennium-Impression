using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class PiranhaPlant : MonoBehaviour, IResettable
    {
        public void ResetObject()
        {
            transform.parent.gameObject.SetActive(true); //因為要配合Goomba 所以必須是parent
            gameObject.SetActive(true);
        }
    }
}