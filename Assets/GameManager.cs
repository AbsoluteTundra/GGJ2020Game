using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int numberOfRepairs;
    public int worldPopulation = 5000;

    public Text population;
    public Text youLostText;
    
    public GameObject player;

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

        if (worldPopulation == 0)
        {
            youLostText.enabled = true;
            GameObject.Destroy(player);
        }
    }
}
