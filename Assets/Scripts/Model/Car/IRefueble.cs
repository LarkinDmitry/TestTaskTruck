using System;

namespace LarkinTestTask_2_2
{
    public interface IRefueble
    {
        FuelTank Tank { get; }
        Action<float> OnChangedFuelRatio { get; set; }
        void FillUpTank();
    }
}