using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> poolObjects = new List<GameObject>();

    private int amountToPool = 20;

    [SerializeField] private GameObject levelPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
