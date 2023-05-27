using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
   
    [SerializeField] private GameOverManager _gameOverManager;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] Animator _animator;
    [SerializeField] float animDuration;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Box")) _gameOverManager.GameOver();
        if(col.gameObject.CompareTag("PowerUp"))PowerUp(col.gameObject);
    }

    void PowerUp(GameObject powerUp) {
        powerUp.SetActive(false);
        StartCoroutine(ControlPowerUP());
    }

    IEnumerator ControlPowerUP() {
        //_animator.SetBool("", true);
        Debug.Log("Activa Anim");
        _scoreManager.rateScore = 3f;
        yield return new WaitForSeconds(animDuration);
        _scoreManager.rateScore = 2f;
        Debug.Log("DEsactiva Anim");
        //_animator.SetBool("", false);
    }

}
