using UnityEngine;

namespace MillenniumImpression.GameScene
{
    public class PiranhaPlant : MonoBehaviour, IResettable
    {
        public void ResetObject()
        {
            transform.parent.gameObject.SetActive(true); //�]���n�t�XGoomba �ҥH�����Oparent
            gameObject.SetActive(true);
        }
    }
}