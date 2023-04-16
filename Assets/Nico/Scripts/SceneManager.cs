using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel, optionsPanel;
    [SerializeField] UnityEvent onOptions, onBackOptions;

    private void Awake() {
        menuPanel.SetActive(true); optionsPanel.SetActive(false);
    }

    public void OnPlayButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play"); Debug.Log("Disfruta el juego");
    }

    public void OnOptionsButton() {
        onOptions.Invoke();
    }

    public void OnBackButton() {
        onBackOptions.Invoke();
    }

    public void OnExitButton() {
        Application.Quit(); Debug.Log("Hasta la próxima");
    }


}
