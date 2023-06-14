using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class Cargo : MonoBehaviour
    {
        public bool OnGround { get; set; }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                OnGround = true;
            }
        }
    }
}