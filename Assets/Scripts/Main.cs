using UnityEngine;

namespace LarkinTestTask_2_2
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private UIView uIView;

        private void Awake()
        {
            gameObject.AddComponent<Sounds>();
            uIView = GetComponent<UIView>();
        }

        void Start()
        {   
            IDrivable drivable = player.GetComponentInChildren<IDrivable>();
            DrivableViewModel drivableViewModel = new(drivable);

            IRefueble refueble = player.GetComponentInChildren<IRefueble>();
            RefuebleViewModel refuebleViewModel = new(refueble);

            uIView.InputInitialization(drivableViewModel);
            uIView.RefuelInitialization(refuebleViewModel);

            GameBuilder.Instance.CreateCargo(10);            
        }
    }
}