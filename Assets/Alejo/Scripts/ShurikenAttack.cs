using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Box")) {
            Debug.Log("DESTRUIR CAJA");
            gameObject.SetActive(false);
        }
    }
}