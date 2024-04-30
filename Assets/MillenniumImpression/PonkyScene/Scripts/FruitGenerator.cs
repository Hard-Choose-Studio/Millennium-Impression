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
                fruitPrefabs[i] = Instantiate(fruitPrefab, transform); //�ƥ��إߦn
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
                fruitObject.SetActive(false); //��_����
        }

        public void OnCarStopDrive()
        {
            foreach (GameObject fruitObject in fruitPrefabs)
                fruitObject.SetActive(true); //�N�L�̥����Ѱ�����
        }
    }
}