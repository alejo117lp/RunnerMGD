using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecordScoreController : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI recordScoreText;

    private void Start()
    {
        recordScoreText.text = "Record Score: " + Mathf.Round(PlayerPrefs.GetFloat("RecordScore", 0));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) ShowScores();
    }

    public void ShowScores()
    {
        scoreText.text = "Current Score: " + Mathf.Round(_scoreManager.scorePoints);

        if (_scoreManager.scorePoints > PlayerPrefs.GetFloat("RecordScore", 0))
        {
            PlayerPrefs.SetFloat("RecordScore", _scoreManager.scorePoints);
            recordScoreText.text = "Record Score: " + Mathf.Round(_scoreManager.scorePoints);
        }
        
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("RecordScore");
        recordScoreText.text = "Record Score: 0";
    }
}
