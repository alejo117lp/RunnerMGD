using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovement : MonoBehaviour
{
    [SerializeField] private GameObject objetoAEspawnear;
    [SerializeField] private float velocidadMovimiento = 1f;
    [SerializeField] private float tiempoMinSpawn = 2f;
    [SerializeField] private float tiempoMaxSpawn = 10f;
    [SerializeField] private Vector3 puntoA;
    [SerializeField] private Vector3 puntoB;

    private Vector3 targetPosition;
    private float tiempoHastaSpawn;
    private GameObject ultimoObjetoCreado; 

    private void Start()
    {
        tiempoHastaSpawn = Random.Range(tiempoMinSpawn, tiempoMaxSpawn);
        targetPosition = puntoB;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocidadMovimiento * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (targetPosition == puntoA)
            {
                targetPosition = puntoB;
            }
            else
            {
                targetPosition = puntoA;
                Destroy(gameObject);
            }
        }

        if (!ultimoObjetoCreado) // Si no hay un objeto creado más reciente
        {
            tiempoHastaSpawn -= Time.deltaTime;
            if (tiempoHastaSpawn <= 0f)
            {
                tiempoHastaSpawn = Random.Range(tiempoMinSpawn, tiempoMaxSpawn);
                ultimoObjetoCreado = Spawn(objetoAEspawnear);
            }
        }
    }

    private void OnDestroy()
    {
        // Al destruir el objeto, se elimina la referencia al objeto más reciente creado
        ultimoObjetoCreado = null;
    }

    private GameObject Spawn(GameObject objeto)
    {
        Vector3 spawnPosition = new Vector3(15f, 0f, 0f); // posición fija en el espacio
        return Instantiate(objeto, spawnPosition, Quaternion.identity);
    }

}
