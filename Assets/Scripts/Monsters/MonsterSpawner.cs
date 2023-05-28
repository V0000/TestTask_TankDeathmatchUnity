using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Monsters
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private int maxMonsters = 10; // Максимальное количество монстров на сцене
        [SerializeField] private Transform target; // Цель, за которой следуют монстры
        [SerializeField] private List<GameObject> monsterPrefabs;
        
        private float _minDistance = 5f;
        private float _maxDistance = 50f;
        private float _minCoordinate = -40f;
        private float _maxCoordinate = 40f;

        private List<GameObject> activeMonsters = new List<GameObject>(); // Список активных монстров
        
        private void Update()
        {
            if (activeMonsters.Count < maxMonsters)
            {
                SpawnMonster();
            }
        }

        private void SpawnMonster()
        {
            GameObject randomMonsterPrefab = GetRandomMonsterPrefab();
            GameObject monsterObj = Instantiate(randomMonsterPrefab, GetSpawnPosition(), Quaternion.identity, transform);
            MonsterHealth monsterHealth = monsterObj.GetComponent<MonsterHealth>();
            monsterHealth.OnDeath += HandleMonsterDeath;
            MonsterMovement monsterMovement = monsterObj.GetComponent<MonsterMovement>();
            monsterMovement.Target = target;
            activeMonsters.Add(monsterObj);
        }

        private GameObject GetRandomMonsterPrefab()
        {
            int randomIndex = Random.Range(0, monsterPrefabs.Count);
            return monsterPrefabs[randomIndex];
        }

        private void HandleMonsterDeath(GameObject monster)
        {
            // Удаляем мертвого монстра из списка активных монстров
            activeMonsters.Remove(monster);
        }

        private Vector3 GetSpawnPosition()
        {
            float playerX = target.position.x;
            float playerZ = target.position.z;
            float playerRotation = target.rotation.eulerAngles.y;

            float distanceX = Random.Range(_minDistance, _maxDistance); 
            float distanceZ = Random.Range(_minDistance, _maxDistance); 

            
            float playerRotationRadians = playerRotation * Mathf.Deg2Rad;
            
            float offsetX = Mathf.Sin(playerRotationRadians) * distanceX;
            float offsetZ = Mathf.Cos(playerRotationRadians) * distanceZ;
            
            float randomX = playerX - offsetX;
            randomX = Mathf.Clamp(randomX, _minCoordinate, _maxCoordinate);
            float randomZ = playerZ - offsetZ;
            randomZ = Mathf.Clamp(randomZ, _minCoordinate, _maxCoordinate);

            Vector3 randomVector = new Vector3(randomX, _minDistance, randomZ);

            return randomVector;
        }
    }
}