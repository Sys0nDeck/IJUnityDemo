using System.Collections.Generic;
using UnityEngine;

namespace SpawnEnemiesAdvanced
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private int _maxSizePerUnit = 5;

        private List<Enemy> _enemies;
      
        private void Awake()
        {
            _enemies = new List<Enemy>();
        }

        public Enemy Get(Enemy enemyPrefab)
        {
            return FindAvaiableEnemy(enemyPrefab);
        }

        public void Repease(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private Enemy Create(Enemy enemy)
        {
            var newEnemy = Instantiate(enemy);
            newEnemy.gameObject.SetActive(false);
            _enemies.Add(newEnemy);

            return newEnemy;
        }

        private Enemy FindAvaiableEnemy(Enemy enemyPrefab)
        {
            var findedEnemies = _enemies.FindAll(enemy => enemy.Id == enemyPrefab.Id);

            foreach (var enemy in findedEnemies)
                if (enemy.gameObject.activeSelf == false)
                    return enemy;

            if (findedEnemies.Count < _maxSizePerUnit)
                return Create(enemyPrefab);
            else
                return null;
        }   
    }
}


