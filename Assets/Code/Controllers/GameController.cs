using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FastHand
{
    public class GameController : MonoBehaviour, IDisposable
    {
        private ListExecuteObject _interactiveObject;
        private DisplayBonuses _displayBonuses;
        private DisplayEndGame _displayEndGame;
        private CameraController _cameraController;
        private InputController _inputController;
        private int _countBonuses;
        private Reference _reference;

        private void Awake()
        {
            _reference = new Reference();
            _interactiveObject = new ListExecuteObject();
            _inputController = new InputController(_reference.Character);
            _cameraController = new CameraController(_reference.Character);
            _displayBonuses = new DisplayBonuses(_reference.EasterEgg);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _interactiveObject.AddExecuteObject(_cameraController);
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

            _interactiveObject.AddExecuteObject(_inputController);

            foreach (var interactiveObject in _interactiveObject)
            {
                if (interactiveObject is Bonus bonus)
                {
                    bonus.OnPointChange += AddBonus;
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];
                
                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }
        
        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        
        private void AddBonus(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
        }

        public void Dispose()
        {
            foreach (var interactiveObject in _interactiveObject)
            {
                if (interactiveObject is Bonus bonus)
                {
                    bonus.OnPointChange -= AddBonus;
                }
            }

        }
    }
}