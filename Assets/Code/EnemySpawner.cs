using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FastHand
{
    public class EnemySpawner : MonoBehaviour
    {
        private enum WaveEnemies
        {
            First,
            Second,
            Third,
            Fourth,
            Fifth
        }

        [SerializeField] private WaveEnemies _wave = WaveEnemies.First;
        [SerializeField] private int _poolCount = 3;
        [SerializeField] private bool _autoExpand = false;
        [SerializeField] private Enemy _enemyPrefab;

        private PoolMono<Enemy> _pool;

        private void Start()
        {
            _pool = new PoolMono<Enemy>(_enemyPrefab, _poolCount, transform);
            _pool.AutoExpand = _autoExpand;
            
            switch (_wave)
            {
                case WaveEnemies.First:
                    CreateEnemy(3);
                    break;                
                case WaveEnemies.Second:
                    CreateEnemy(6);
                    break;                
                case WaveEnemies.Third:
                    CreateEnemy(8);
                    break;                
                case WaveEnemies.Fourth:
                    CreateEnemy(12);
                    break;                
                case WaveEnemies.Fifth:
                    CreateEnemy(15);
                    break;
                
            }

        }

        private void Update()
        {
            
        }

        private void CreateEnemy(int countEnemy)
        { 
            for (int i = 0; i < countEnemy; i++)
            {
                var enemy = _pool.GetFreeElement();
                enemy.transform.position = transform.position;
            }
        }
    }
}