using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LarkinTestTask_2_2
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Image Fuel;
        [SerializeField] private Image Up;
        [SerializeField] private Image Down;
        [SerializeField] private Image Left;
        [SerializeField] private Image Right;

        private DrivableViewModel viewModel = null;

        private int accelerator;
        private int steeringWheel;

        private void Awake()
        {
            Up.gameObject.AddComponent<UpDownAction>().OnChangedState += (i) => accelerator = i;
            Down.gameObject.AddComponent<UpDownAction>().OnChangedState += (i) => accelerator = -i;
            Right.gameObject.AddComponent<UpDownAction>().OnChangedState += (i) => steeringWheel = i;
            Left.gameObject.AddComponent<UpDownAction>().OnChangedState += (i) => steeringWheel = -i;
        }

        public void InputInitialization(DrivableViewModel driveViewModel)
        {
            viewModel = driveViewModel;
        }

        public void RefuelInitialization(RefuebleViewModel refuelViewModel)
        {
            refuelViewModel.OnChangedFuelRatio += (f) => Fuel.fillAmount = f;
        }

        private void Update()
        {
            viewModel?.SetAccelerator(accelerator);
            viewModel?.SetSteeringWheel(steeringWheel);
        }

        private class UpDownAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
        {
            public Action<int> OnChangedState;

            public void OnPointerDown(PointerEventData eventData)
            {
                OnChangedState?.Invoke(1);
            }

            public void OnPointerUp(PointerEventData eventData)
            {
                OnChangedState?.Invoke(0);
            }
        }
    }
}