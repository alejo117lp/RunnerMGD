using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] float timeToDestroySection;

    private void Start() {
        //StartCoroutine(DestroyPipe());
    }

    private void OnEnable() {
        StartCoroutine(DestroySection());
    }

    private void Update(){
        //if (GameManager.Instance.isGameOver) return;
        transform.position += (Vector3.left * Time.deltaTime * speed);
    }

    IEnumerator DestroySection() {
        yield return new WaitForSeconds(timeToDestroySection);
        gameObject.SetActive(false);

    }
}
