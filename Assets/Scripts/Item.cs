using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool hasBeenDestroyed;
    public float timeLeftToRepair = 30;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenDestroyed)
        {
            timeLeftToRepair -= Time.deltaTime;
            // if (timeLeftToRepair%5==0)
            // {
                // gameManager.GetComponent<GameManager>().worldPopulation -= 1;
            // }
            if (timeLeftToRepair < 0)
            {
                gameManager.GetComponent<GameManager>().lost = true;
                hasBeenDestroyed = false;
                // gameManager.GetComponent<GameManager>().worldPopulation -= 1000;
            }
        }
        else
        {
            transform.GetComponent<AudioSource>().Stop();
            transform.GetChild(2).GetComponentInChildren<ParticleSystem>().Stop();
            timeLeftToRepair = 30;
            foreach (Renderer r in transform.GetChild(1).GetComponentsInChildren<Renderer>()) 
            {
                r.enabled = false;
            }
            foreach (Renderer r in transform.GetChild(0).GetComponentsInChildren<Renderer>()) 
            {
                r.enabled = true;
            }
            foreach (Collider c in transform.GetChild(1).GetComponentsInChildren<Collider>()) 
            {
                c.enabled = false;
            }
        }
    }
}
