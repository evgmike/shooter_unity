using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private float _secondsBeetwenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elepsedTime = 0;

    private void Awake()
    {
        Initialize(_enemyTemplates);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _secondsBeetwenSpawn) {

            Debug.Log("Ёлипсайд больше");

            if (TryGetObject(out GameObject enemy)) {
                _elepsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

            }
          
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint) {

        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;


    }


}
