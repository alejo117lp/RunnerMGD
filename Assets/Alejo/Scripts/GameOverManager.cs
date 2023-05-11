using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreScreen;
    [SerializeField] private RecordScoreController _recordScoreController;

    public void GameOver()
    {
        Time.timeScale = 0f;
        _recordScoreController.ShowScores();
        scoreScreen.SetActive(true);
    }
}
