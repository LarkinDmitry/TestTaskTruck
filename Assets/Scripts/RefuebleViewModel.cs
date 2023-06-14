using System;

namespace LarkinTestTask_2_2
{
    public class RefuebleViewModel
    {
        public Action<float> OnChangedFuelRatio { get; set; }

        public RefuebleViewModel(IRefueble model)
        {
            model.OnChangedFuelRatio += (f) => OnChangedFuelRatio?.Invoke(f);
        }
    }
}