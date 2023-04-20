using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private float scorePoints;

    private void Update()
    {
        scorePoints += 2 * Time.deltaTime;
        scoreText.text = "SCORE:  " + UnityEngine.Mathf.Round(scorePoints);
    }

}
