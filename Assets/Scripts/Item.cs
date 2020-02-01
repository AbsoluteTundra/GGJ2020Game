using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool hasBeenDestroyed;
    public float timeLeftToRepair = 20;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenDestroyed)
        {
            timeLeftToRepair -= Time.deltaTime;
            gameManager.GetComponent<GameManager>().worldPopulation -= 1;
            if (timeLeftToRepair < 0)
            {
                gameManager.GetComponent<GameManager>().worldPopulation -= 1000;
            }
        }
    }

    void LostGame()
    {
        print ("You Lost");
    }
}
