using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeToSpawnFirstItem;
    [SerializeField, Range(0.1f, 10)]
    private float minTimeToSpawnItem, maxTimeToSpawnItem;
    //[SerializeField] private float timeToSpawnItem;

        private void Start()
    {
        StartCoroutine(SpawnItems());
    }

    private Vector3 GetSpawnPosition() {
        return new Vector3
            (spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
    }

    private IEnumerator SpawnItems()
    {
        yield return new WaitForSeconds(timeToSpawnFirstItem);

        //Instantiate(Item, GetSpawnPosition(), Quaternion.identity);
        GameObject item = ObjectsPool.Instance.RequestObject();
        item.transform.position = GetSpawnPosition();

        do
        {
            yield return new WaitForSeconds(Random.Range(minTimeToSpawnItem,maxTimeToSpawnItem));
            //yield return new WaitForSeconds(timeToSpawnItem);

            item = ObjectsPool.Instance.RequestObject();
            item.transform.position = GetSpawnPosition();
        } while (true);
    }

    public void Stop() {
        StopAllCoroutines();
    }
}
