using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenü : MonoBehaviour
{
    public GameObject PauseMenü;
    public bool istPausiert;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenü.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (istPausiert)
            {
                Resume();
            }
            else
            {
                SpielPausieren();
            }
        }
    }
    public void SpielPausieren()
    {
        PauseMenü.SetActive(true);
        Time.timeScale = 0f;
        istPausiert = true;
    }
    public void Resume()
    {
        PauseMenü.SetActive(false);
        Time.timeScale = 1f;
        istPausiert = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
