using System;
using UnityEngine;

namespace LarkinTestTask_2_2
{
    [RequireComponent(typeof(RearWheelDrive))]
    public class Truck : MonoBehaviour, IDrivable, IRefueble
    {
        public Transform Trunk { get; private set; }

        [SerializeField] private ParticleSystem smoke;
        private RearWheelDrive wheels;
        private float accelerator;
        private float steeringWheel;
        private readonly float fuelConsumption = 0.2f;

        public FuelTank Tank { get; private set; }
        public Action<float> OnChangedFuelRatio { get; set; }

        private void Start()
        {
            Trunk = transform.Find("trunkPosition");
            wheels = GetComponent<RearWheelDrive>();

            Tank = new();
            Tank.OnChangedFuelRatio += CheckFuelRate;
            FillUpTank();

            Sounds.Instance.Engine.Play();
            smoke.Play();
        }

        private void Update()
        {
            wheels.Move(accelerator, steeringWheel);
        }

        /// <summary>
        /// set value -1....1
        /// </summary>
        /// <param name="accelerator"></param>
        public void SetAccelerator(float accelerator)
        {
            if (Tank.IsThereFuel())
            {
                Tank.UseFuel(fuelConsumption * Time.deltaTime);
                this.accelerator = accelerator;
            }
            else
            {
                this.accelerator = 0;
            }

            Sounds.Instance.SetEnginePitch(MathF.Abs(this.accelerator));
        }

        /// <summary>
        /// set value -1....1
        /// </summary>
        /// <param name="accelerator"></param>
        public void SetSteeringWheel(float steeringWheel)
        {
            this.steeringWheel = Mathf.Clamp(steeringWheel, -1, 1);
        }

        public void FillUpTank()
        {
            Tank.FillUp();
        }

        private void CheckFuelRate(float rate)
        {
            OnChangedFuelRatio?.Invoke(rate);
            
            if(rate <= 0)
            {
                Sounds.Instance.Engine.Pause();
                smoke.Stop();
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Cargo>(out var cargo))
            {
                if(cargo.OnGround)
                {
                    cargo.OnGround = false;
                    cargo.transform.position = Trunk.position;
                    Sounds.Instance.DropCargo.Play();
                }
            }
        }
    }
} 