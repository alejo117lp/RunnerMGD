using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] levelParts;

    [SerializeField] private float minDistance;

    [SerializeField] private Transform finalPoint;

    [SerializeField] private int initialAmount;
    private Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < initialAmount; i++)
        {
            GenerateLevelPart();
        }
    }
    
    void Update()
    {
        if (Vector2.Distance(player.position, finalPoint.position) < minDistance)
        {
            GenerateLevelPart();
        }
    }

    void GenerateLevelPart()
    {
        int randomNum = Random.Range(0, levelParts.Length);
        GameObject level = Instantiate(levelParts[randomNum], finalPoint.position, Quaternion.identity);
        finalPoint = SearchFinalPoint(level,"FinalPoint");
    }

    private Transform SearchFinalPoint(GameObject levelPart, string tag)
    {
        Transform point = null;

        foreach (Transform location in levelPart.transform)
        {
            if (location.CompareTag(tag))
            {
                point = location;
                break;
            }
        }

        return point;
    }
}
