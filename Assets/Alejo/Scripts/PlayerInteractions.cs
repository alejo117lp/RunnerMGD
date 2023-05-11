using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
   
    [SerializeField] private GameOverManager _gameOverManager;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Box")) _gameOverManager.GameOver();
    }
}
