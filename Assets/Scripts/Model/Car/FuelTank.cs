using System;
using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class FuelTank
    {
        /// <summary>
        /// return the ratio of fuelVolume to tankVolume (0...1)
        /// </summary>
        public Action<float> OnChangedFuelRatio { get; set; }

        private float fuelVolume;
        private float tankVolume;

        /// <summary>
        /// default tank volume 40
        /// </summary>
        /// <param name="tankVolume"></param>
        public FuelTank(float tankVolume = 40)
        {
            this.tankVolume = tankVolume;
        }

        public bool IsThereFuel()
        {
            return fuelVolume > 0;
        }

        public void UseFuel(float fuel)
        {
            fuelVolume = Mathf.Clamp(fuelVolume -= fuel, 0, tankVolume);
            OnChangedFuelRatio?.Invoke(fuelVolume / tankVolume);
        }

        public void FillUp()
        {
            fuelVolume = tankVolume;
            OnChangedFuelRatio?.Invoke(fuelVolume / tankVolume);
        }
    }
}