using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public Canvas hud;
    private bool isPaused = false, canToggle = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("TogglePause") && canToggle)
        {
            canToggle = false;
            TogglePause();
        }

        if (Input.GetButtonUp("TogglePause"))
        {
            canToggle = true;
        }
    }

    public void TogglePause()
    {
        if (isPaused != true)
        {
            isPaused = true;
            gameObject.GetComponent<Canvas>().enabled = true;
            hud.gameObject.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 0;
        }
            
        else if (isPaused == true)
        {
            isPaused = false;
            gameObject.GetComponent<Canvas>().enabled = false;
            hud.gameObject.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
