namespace LarkinTestTask_2_2
{
    public class DrivableViewModel
    {
        private IDrivable model;

        public DrivableViewModel(IDrivable model)
        {
            this.model = model;
        }

        public void SetAccelerator(float accelerator)
        {
            model.SetAccelerator(accelerator);
        }

        public void SetSteeringWheel(float steeringWheel)
        {
            model.SetSteeringWheel(steeringWheel);
        }
    }
}