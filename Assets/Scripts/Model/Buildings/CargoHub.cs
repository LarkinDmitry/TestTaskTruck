using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class CargoHub : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {            
            if (other.gameObject.TryGetComponent<Cargo>(out var cargo))
            {
                GameBuilder.Instance.MoveCargo(cargo);
                Sounds.Instance.DropCargo.Play();
            }
        }
    }
}