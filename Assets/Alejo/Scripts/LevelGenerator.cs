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
    }
}
