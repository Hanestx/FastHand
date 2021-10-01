using UnityEngine;

namespace FastHand
{
    internal abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        private bool _isInteractable;
        
        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void Start()
        {
            IsInteractable = true;
        }

        
        private void OnTriggerEnter(Collider other)
        { 
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }
        
        protected abstract void Interaction();
        public abstract void Execute();
    }
}