using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemSettings : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float timeToDestroyItem;

    private void Start() {
        //StartCoroutine(DestroyPipe());
    }

    private void OnEnable() {
        StartCoroutine(DestroyItem());
    }

    private void Update(){
        //if (GameManager.Instance.isGameOver) return;
        transform.position += (Vector3.left * Time.deltaTime * speed);
    }

    IEnumerator DestroyItem() {
        yield return new WaitForSeconds(timeToDestroyItem);
        gameObject.SetActive(false);
    }
}
