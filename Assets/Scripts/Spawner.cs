﻿using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyHealth _tankPrefab;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private int _tanksPerSpawn;
    [SerializeField] private int _maxTanksOnScreen;
    [SerializeField] private int _totalTanks;
    [SerializeField] private CoinsChanger _coinsChanger;
    private float _generatedSpawnTime;
    private int _tanksOnScreen;
    private float _currentSpawnTime;

    public void TankDestroyed()
    {
        _tanksOnScreen -= 1;
        _totalTanks -= 1;
    }

    private void FixedUpdate()
    {
        _currentSpawnTime += Time.deltaTime;
        if (_currentSpawnTime > _generatedSpawnTime)
        {
            _currentSpawnTime = 0;
            _generatedSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            if (_tanksPerSpawn > -1 && _tanksOnScreen < _totalTanks)
            {
                List<int> previousSpawnLocations = new List<int>();
                if (_tanksPerSpawn > _spawnPoints.Length)
                {
                    _tanksPerSpawn = _spawnPoints.Length - 1;
                }
                _tanksPerSpawn = (_tanksPerSpawn > _totalTanks) ? _tanksPerSpawn - _totalTanks : _tanksPerSpawn;
                for (int i = 0; i < _tanksPerSpawn; i++)
                {
                    if (_tanksOnScreen < _maxTanksOnScreen)
                    {
                        _tanksOnScreen += 1;
                        int spawnPoint = -1;
                        while (spawnPoint == -1)
                        {
                            int randomNumber = Random.Range(0, _spawnPoints.Length);
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }
                        EnemyHealth newTank = Instantiate(_tankPrefab);
                        newTank.transform.position = _spawnPoints[spawnPoint].position;
                        newTank.transform.rotation = _spawnPoints[spawnPoint].rotation;
                        newTank.OnDestroy.AddListener(TankDestroyed);
                        newTank.OnDestroyFromBullet.AddListener(_coinsChanger.ChangeCoinsText);
                    }
                }
            }
        }
    }

}