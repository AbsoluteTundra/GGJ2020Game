using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Menu : MonoBehaviour
{
    public Canvas hud, pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        pauseMenu.gameObject.SetActive(false);
        hud.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
        

      

    public void StartGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
