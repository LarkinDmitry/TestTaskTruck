using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class GameBuilder : MonoBehaviour
    {
        [SerializeField] GameObject haystackPrefab;

        public static GameBuilder Instance;

        GameObject CargosParent;
        private float minPositionX = -40;
        private float maxPositionX = 10;
        private float minPositionZ = -20;
        private float maxPositionZ = 30;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            CargosParent = new("Cargos");
        }

        public void CreateCargo(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject cargo = Instantiate(haystackPrefab, CargosParent.transform);
                MoveCargo(cargo.AddComponent<Cargo>());
            }
        }

        public void MoveCargo(Cargo cargo)
        {
            cargo.gameObject.transform.SetPositionAndRotation(GetRandomPosition(), GetRandomRotation());
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(minPositionX, maxPositionX);
            float z = Random.Range(minPositionZ, maxPositionZ);
            return new(x, 5f, z);
        }

        private Quaternion GetRandomRotation()
        {
            float x = Random.Range(0, 360);
            float y = Random.Range(0, 360);
            float z = Random.Range(0, 360);
            return Quaternion.Euler(x, y, z);
        }
    }
}