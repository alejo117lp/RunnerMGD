using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionsPool : MonoBehaviour
{
       [SerializeField] GameObject [] sectionPrefab;
       [SerializeField] int poolSize = 5;
       [SerializeField] List<GameObject> sectionList;
   
       static SectionsPool instance;
       public static SectionsPool Instance { get { return instance; } }
   
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
           AddPipesToPool(poolSize);
       }
   
       void AddPipesToPool(int amount) {
           for (ushort i = 0; i < poolSize; i++) {
               GameObject section = Instantiate(sectionPrefab[i]);
               section.SetActive(false);
               sectionList.Add(section);
               section.transform.parent = transform;
           }
       }
   
       public GameObject RequestPipe() {
           for(int i = 0; i < sectionList.Count; i++) {
               if (!sectionList[i].activeSelf) {
                   sectionList[i].SetActive(true);
                   return sectionList[i];
               }
           }
           AddPipesToPool(1);
           sectionList[sectionList.Count - 1].SetActive(true);
           return sectionList[sectionList.Count - 1];
       }
}
