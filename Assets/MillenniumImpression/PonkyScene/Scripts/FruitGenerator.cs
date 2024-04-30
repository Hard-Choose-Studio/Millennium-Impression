using UnityEngine;

namespace MillenniumImpression.PonkyScene
{
    public class FruitGenerator : MonoBehaviour, IPonkyEvent
    {
        [SerializeField]
        private GameObject fruitPrefab;

        private const uint FRUITS_COUNT = 10U;
        private readonly GameObject[] fruitPrefabs = new GameObject[FRUITS_COUNT];

        private void Awake()
        {
            for (uint i = 0; i < FRUITS_COUNT; i++)
                fruitPrefabs[i] = Instantiate(fruitPrefab, transform); //事先建立好
            OnTargetLost();
        }

        public void OnTargetFound()
        {
            gameObject.SetActive(true);
        }

        public void OnTargetLost()
        {
            gameObject.SetActive(false);
            foreach (GameObject fruitObject in fruitPrefabs)
                fruitObject.SetActive(false); //恢復隱藏
        }

        public void OnCarStopDrive()
        {
            foreach (GameObject fruitObject in fruitPrefabs)
                fruitObject.SetActive(true); //將他們全部解除隱藏
        }
    }
}