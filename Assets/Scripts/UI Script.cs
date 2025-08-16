using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    // Spiel starten
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    // Spiel beenden
    public void QuitGame()
    {
        Application.Quit();
    }
}
