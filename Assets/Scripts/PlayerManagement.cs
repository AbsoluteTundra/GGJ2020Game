using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    bool waterNear;
    bool needsWaterNear;
    
    float takingToolTimer = 3;
    float repairingTimer = 3;
    public GameObject gameManager;

    public List<string> toolsOwned = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waterNear && Input.GetKey("joystick button 0"))
        {
            takingToolTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, (3 - takingToolTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            if (takingToolTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                print ("Has tool");
                toolsOwned.Add("Water");
                GameObject.Find("PlayerModel").GetComponent<Animator>().Play("Gather_Water");
            }
        }
        else
        {
            takingToolTimer = 3;
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.identity;
        }

        if (needsWaterNear && toolsOwned.Contains("Water") && Input.GetKey("joystick button 0"))
        {
            repairingTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, (3 - repairingTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            if (repairingTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                print ("Got repaired");
                gameManager.GetComponent<GameManager>().numberOfRepairs += 1;
                toolsOwned.Remove("Water");
                GameObject.Find("PlayerModel").GetComponent<Animator>().Play("ReleaseWater");
            }
        }

        if (toolsOwned.Contains("Water"))
        {
            transform.GetChild(2).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            transform.GetChild(2).GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
        }

        if (toolsOwned.Contains("Wood"))
        {
            transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
        }

        if (toolsOwned.Contains("Stone"))
        {
            transform.GetChild(4).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            transform.GetChild(4).GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Water"))
        {
            print ("Water near");
            waterNear = true;
        } 
        else if (other.CompareTag("NeedsWater") && other.GetComponent<Item>().hasBeenDestroyed)
        {
            print ("Broken near");
            needsWaterNear = true;
        }
    }
    
    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Water"))
        {
            print ("Tool not near");
            waterNear = false;
        }
        else if (other.CompareTag("NeedsWater"))
        {
            print ("Broken not near");
            needsWaterNear = false;
        }
    }
}
