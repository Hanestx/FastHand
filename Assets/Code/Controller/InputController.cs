using UnityEngine;


namespace FastHand
{
    internal class InputController : MonoBehaviour , IUpdatable
    {
        [SerializeField] private GameObject _gameObject;
        private IControllable _controllableObject;
        [SerializeField] private MouseLook _mouseLookX;
        [SerializeField] private MouseLook _mouseLookY;

        private void Start()
        {
            _controllableObject = _gameObject.GetComponent<IControllable>();
        }

        private void Update()
        {
            _controllableObject.Move();
            _mouseLookX.Look();
            _mouseLookY.Look();
        }
 
        public void Execute()
        {
            //
        }
        
    }
}
