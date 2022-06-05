using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    float timeLeft = 10;
    float destructionNumber = 0;
    public GameObject world;
    public GameObject cube;

    public List<GameObject> destructableThings = new List<GameObject>();

    public ParticleSystem thunder;
    public ParticleSystem explosion;
    public ParticleSystem meteor;

    public List<GameObject> destroyedThings = new List<GameObject>();

    public Sprite forest;
    public Sprite fence;
    public Sprite house;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0)
        {
            CreateDestruction();
            destructionNumber += 1;
            timeLeft = 10 - destructionNumber * 0.1f; 
        }
    }

    
    void CreateDestruction ()
    {
        GameObject destroyedThing = null;
        int index;
        while (destroyedThing == null)
        {
            index = Random.Range(0, destructableThings.Count);
            if (!destructableThings[index].GetComponent<Item>().hasBeenDestroyed)
            {
                destroyedThing = destructableThings[index];
            }
        }
        
        if (destroyedThing)
        {
            destroyedThing.transform.GetComponent<AudioSource>().Play();
            destroyedThing.transform.GetChild(2).GetComponentInChildren<ParticleSystem>().Play();
            if (destroyedThing.transform.GetChild(1).CompareTag("NeedsWater"))
            {
                destroyedThing.transform.GetChild(3).GetComponent<meteor>().start = true;
            }
            foreach (Renderer r in destroyedThing.transform.GetChild(0).GetComponentsInChildren<Renderer>()) 
            {
               r.enabled = false;
            }
            foreach (Renderer r in destroyedThing.transform.GetChild(1).GetComponentsInChildren<Renderer>()) 
            {
                if (!r.transform.CompareTag("Highlight"))
                    r.enabled = true;
            }
            foreach (Collider c in destroyedThing.transform.GetChild(1).GetComponentsInChildren<Collider>()) 
            {
                c.enabled = true;
            }
            transform.position = destroyedThing.transform.position;
            print (destroyedThing.name);
            destroyedThing.GetComponent<Item>().hasBeenDestroyed = true;

            int i= 0;
            for (i= 0; i < destroyedThings.Count; i++)
            {
                if (destroyedThings[i].GetComponent<SpriteRenderer>().enabled == false)
                {
                    break;
                }
            }

            if (i < destroyedThings.Count)
            {
                if (destroyedThing.transform.GetChild(1).CompareTag("NeedsWater"))
                {
                    destroyedThings[i].GetComponent<SpriteRenderer>().enabled = true;
                    destroyedThings[i].GetComponent<SpriteRenderer>().sprite = forest;
                }
                else if (destroyedThing.transform.GetChild(1).CompareTag("NeedsWood"))
                {
                    destroyedThings[i].GetComponent<SpriteRenderer>().enabled = true;
                    destroyedThings[i].GetComponent<SpriteRenderer>().sprite = fence;
                }
                else if (destroyedThing.transform.GetChild(1).CompareTag("NeedsStone"))
                {
                    destroyedThings[i].GetComponent<SpriteRenderer>().enabled = true;
                    destroyedThings[i].GetComponent<SpriteRenderer>().sprite = house;
                }
            }

        }
    }
}
