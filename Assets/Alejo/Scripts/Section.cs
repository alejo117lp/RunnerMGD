using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float timeToDestroyPipe;

    private void Start() {
        //StartCoroutine(DestroyPipe());
    }

    private void OnEnable() {
        StartCoroutine(DestroyPipe());
    }

    private void Update(){
        //if (GameManager.Instance.isGameOver) return;
        transform.position += (Vector3.left * Time.deltaTime * speed);
    }

    IEnumerator DestroyPipe() {
        yield return new WaitForSeconds(timeToDestroyPipe);
        gameObject.SetActive(false);

    }
}
