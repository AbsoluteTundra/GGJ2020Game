using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool hasBeenDestroyed;
    public float timeLeftToRepair = 20;

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
            if (timeLeftToRepair < 0)
            {
                
            }
        }
    }

    void LostGame()
    {
        print ("You Lost");
    }
}
