using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class GasStation : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IRefueble>(out var car))
            {
                car.FillUpTank();
                Sounds.Instance.DropFuel.Play();
            }
        }
    }
}