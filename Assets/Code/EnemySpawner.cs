using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FastHand
{
    public class EnemySpawner : MonoBehaviour
    {
        private int _levelNumber = 1;
        [SerializeField] private Transform[] _enemySpawners;
        [SerializeField] private int _poolCount = 3;
        [SerializeField] private bool _autoExpand = true;
        [SerializeField] private Enemy _enemyPrefab;

        private PoolMono<Enemy> _pool;

        private void Start()
        {
            _pool = new PoolMono<Enemy>(_enemyPrefab, _poolCount, transform);
            _pool.AutoExpand = _autoExpand;
            CreateWave(_levelNumber);
        }

        private void Update()
        {
            if (_pool.HasAllFreeElement())
            {
                _levelNumber++;
                CreateWave(_levelNumber);
            }
        }

        private void CreateEnemy(int countEnemy)
        { 
            for (int i = 0; i < countEnemy; i++)
            {
                var enemy = _pool.GetFreeElement();
                enemy.transform.position = _enemySpawners[Random.Range(0, _enemySpawners.Length - 1)].transform.position;
            }
        }

        private void CreateWave(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    CreateEnemy(3);
                    break;                
                case 2:
                    CreateEnemy(6);
                    break;                
                case 3:
                    CreateEnemy(8);
                    break;                
                case 4:
                    CreateEnemy(12);
                    break;                
                case 5:
                    CreateEnemy(15);
                    break;
                
            }
        }
    }
}