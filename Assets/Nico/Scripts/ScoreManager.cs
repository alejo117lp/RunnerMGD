using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public float rateScore = 2f;
    public float scorePoints;

    private void Update()
    {
        scorePoints += rateScore * Time.deltaTime;
        scoreText.text = "SCORE:  " + UnityEngine.Mathf.Round(scorePoints);
    }

}
