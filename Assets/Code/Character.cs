using System;
using UnityEngine;


namespace FastHand
{
    [RequireComponent(typeof(CharacterController))]
    internal class Character : MonoBehaviour, IControllable
    {
        #region Fields

        private readonly Vector3 _jumpDirection = Vector3.up;
        [SerializeField] private float _speed = 6.0f;
        [SerializeField] private float _speedBoost = 4.0f;
        [SerializeField] private float _jumpPower = 10.0f; 
        private float _gravity = -9.8f;
        private CharacterController _characterController;
        
        #endregion
        

        #region UnityMethods
        
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }
        
        #endregion

        
        #region Methods
        
        private void Walk(float speed = 0.0f)
        {
            speed += _speed;
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = _gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _characterController.Move(movement);
        }

        private void Run()
        {
            Walk(_speedBoost);
        }
        
        private void Jump()
        {
            
            _characterController.Move(_jumpDirection * _jumpPower);
            Debug.Log("Jump");
        }

        #endregion
        
        
        #region IControllable
        
        public void Move()
        {
            if (Input.GetKey(KeyCode.LeftShift))
                    Run();
            
            Walk();
        }
        
        #endregion
    }
}
