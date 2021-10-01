using System;
using UnityEngine;
using static UnityEngine.Random;

namespace FastHand
{
    internal sealed class Bonus : InteractiveObject, IFly, IRotation
    {
        public event Action<int> OnPointChange = delegate(int i) {  };
        private float _lenghtFly;
        private float _speedRotation;
        [SerializeField] private int _point;

        private void Awake()
        {
            _lenghtFly = Range(1.0f, 3.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            OnPointChange.Invoke(_point);
        }

        public override void Execute()
        {
            if(!IsInteractable){return;}
            Fly();
            Rotation();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lenghtFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}