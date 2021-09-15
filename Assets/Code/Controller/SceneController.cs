/*using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace FastHand
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        private Enemy _enemy;

        private void Update()
        {
            if (_enemy == null)
            {
                _enemy = Instantiate(_enemyPrefab);
                _enemy.transform.position = new Vector3(0, 0, 0);
                float angle = Random.Range(0, 360);
                _enemy.transform.Rotate(0, angle, 0);
            }
        }
    }
}*/