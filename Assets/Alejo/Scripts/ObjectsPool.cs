using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject[] elementPrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private List<GameObject> objectsList;
   
       static ObjectsPool instance;
       public static ObjectsPool Instance { get { return instance; } }
   
       private void Awake() {
          if(instance == null) {
               instance = this;
          }
          else {
   
               Destroy(gameObject);
          }
       }
   
       void Start()
       {
           AddObjectsToPool(poolSize);
       }
   
       void AddObjectsToPool(int amount) {
           for (ushort i = 0; i < poolSize; i++) {
               GameObject item = Instantiate(elementPrefab[i]);
               item.SetActive(false);
               objectsList.Add(item);
               item.transform.parent = transform;
           }
       }
   
       public GameObject RequestObject() {
           for(int i = 0; i < objectsList.Count; i++) {
               if (!objectsList[i].activeSelf) {
                   objectsList[i].SetActive(true);
                   return objectsList[i];
               }
           }
           AddObjectsToPool(1);
           objectsList[objectsList.Count - 1].SetActive(true);
           return objectsList[objectsList.Count - 1];
       }
}
