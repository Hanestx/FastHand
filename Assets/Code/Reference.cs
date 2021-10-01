using UnityEngine;
using UnityEngine.UI;

namespace FastHand
{
    public class Reference
    {
        private Character _character;
        private Canvas _canvas;
        private GameObject _easterEgg;
        private GameObject _endGame;
        private Button _restartButton;


        public Character Character
        {
            get
            {
                if (_character == null)
                {
                    var gameObject = Resources.Load<Character>("Player");
                    _character = Object.Instantiate(gameObject);
                }

                return _character;
            }
        }
        
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                
                return _canvas;
            }
        }
        
        public GameObject EasterEgg
        {
            get
            {
                if (_easterEgg == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EasterEgg");
                    _easterEgg = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _easterEgg;
            }
        }
        
        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/EndGame");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _endGame;
            }
        }
        
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                return _restartButton;
            }
        }

    }
}