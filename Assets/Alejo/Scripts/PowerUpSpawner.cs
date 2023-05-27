using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] private int     minTimeToSpawnItem, maxTimeToSpawnItem;
    float timer = 0;
    int random;

    private void Start() {
        random = Random.Range(minTimeToSpawnItem, maxTimeToSpawnItem);
    }

    private void Update() {
        timer += Time.deltaTime;
        if(timer >= random) {
            SpawnItem();
            random = Random.Range(minTimeToSpawnItem, maxTimeToSpawnItem);
            timer = 0;
        }
    }


    void SpawnItem() {
        Instantiate(powerUpPrefab, spawnPoint);
    }
}
