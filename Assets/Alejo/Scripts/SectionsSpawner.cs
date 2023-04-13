using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionsSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeToSpawnFirstSection;
    [SerializeField]
    private float timeToSpawnSection;
    //[SerializeField, Range(-1, 1)]
    //float minHeight, maxHeight;

    private void Start()
    {
        StartCoroutine(SpawnSections());
    }

    private Vector3 GetSpawnPosition() {
        return new Vector3
            (spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
    }

    private IEnumerator SpawnSections()
    {
        yield return new WaitForSeconds(timeToSpawnFirstSection);

        //Instantiate(pipe, GetSpawnPosition(), Quaternion.identity);
        GameObject section = SectionsPool.Instance.RequestPipe();
        section.transform.position = GetSpawnPosition();

        do
        {
            yield return new WaitForSeconds(timeToSpawnSection);

            section = SectionsPool.Instance.RequestPipe();
            section.transform.position = GetSpawnPosition();
        } while (true);
    }

    public void Stop() {
        StopAllCoroutines();
    }
}
