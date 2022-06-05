using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numberOfRepairs = 0;
    public int worldPopulation = 5000;

    public Text population;
    public Text youLostText;
    
    public GameObject player;

    public List<GameObject> planetHexagonPrefabs;
    public List<GameObject> planetPentagonPrefabs;

    public bool lost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (population)
        {
            population.text = worldPopulation + "";
        }

        if (lost)
        {
            lost = false;
            youLostText.enabled = true;
            print (youLostText.text);
            youLostText.text = youLostText.text.Replace("x", numberOfRepairs + "");
            player.GetComponent<PlayerMovementScript>().enabled = false;
            player.GetComponent<PlayerManagement>().enabled = false;
        }
    }
}
