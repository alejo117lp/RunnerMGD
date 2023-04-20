using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed;
    public float destoyTime;

    private void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyProjectile() {
        yield return new WaitForSeconds(destoyTime);
        Destroy(this.gameObject);
    }
}
