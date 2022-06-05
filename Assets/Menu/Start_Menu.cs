using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Menu : MonoBehaviour
{
    public Canvas hud, pauseMenu;


    public SpriteRenderer hud1;
    public SpriteRenderer hud2;
    public SpriteRenderer hud3;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        pauseMenu.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    
    public void StartGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
        hud1.enabled = true;
        hud2.enabled = true;
        hud3.enabled = true;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
