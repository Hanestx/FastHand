using UnityEngine;

namespace FastHand
{
    internal sealed class InputController : IExecute
    {
        private readonly IControllable _controllableObject;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.F5;
        private readonly KeyCode _loadPlayer = KeyCode.F9;


        public InputController(IControllable controllableObject)
        {
            _controllableObject = controllableObject;
            _saveDataRepository = new SaveDataRepository();
        }
        
        public void Execute()
        {
            _controllableObject.Move();
            
            if (Input.GetKeyDown(_savePlayer))
            {
                if(_controllableObject is Character character) 
                    _saveDataRepository.Save(character);
            }
            
            if (Input.GetKeyDown(_loadPlayer))
            {
                if(_controllableObject is Character character) 
                    _saveDataRepository.Load(character);
            }

        }
        
    }
}
