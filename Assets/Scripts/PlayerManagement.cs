using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour
{
    bool waterNear;
    bool needsWaterNear;
    
    bool woodNear;
    bool needsWoodNear;
    
    bool stoneNear;
    bool needsStoneNear;
    
    float takingToolTimer = 3;
    float repairingTimer = 3;
    public GameObject gameManager;

    public List<string> toolsOwned = new List<string>();

    GameObject repairing;
    bool flag;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (waterNear && (Input.GetKey("joystick button 0") || Input.GetKey(KeyCode.E)) && !toolsOwned.Contains("Water"))
        {
            takingToolTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, (3 - takingToolTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            player.GetComponent<Animator>().Play("Gather_Water");
            if (takingToolTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                toolsOwned.Add("Water");
                GameObject.Find("PlayerModel").GetComponent<Animator>().Play("Gather_Water");
            }
        }
        else if (woodNear && (Input.GetKey("joystick button 0") || Input.GetKey(KeyCode.E)) && !toolsOwned.Contains("Wood"))
        {
            takingToolTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, (3 - takingToolTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            player.GetComponent<Animator>().Play("GatherStone&Wood");
            if (takingToolTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                toolsOwned.Add("Wood");
            }
        }
        else if (stoneNear && (Input.GetKey("joystick button 0") || Input.GetKey(KeyCode.E)) && !toolsOwned.Contains("Stone"))
        {
            takingToolTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, (3 - takingToolTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;            
            player.GetComponent<Animator>().Play("GatherStone&Wood");
            if (takingToolTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                toolsOwned.Add("Stone");
            }
        }
        else
        {
            takingToolTimer = 3;
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.identity;
            flag = true;
        }

        if (needsWaterNear && toolsOwned.Contains("Water") && (Input.GetKey("joystick button 0") || Input.GetKey(KeyCode.E)))
        {
            repairingTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, (3 - repairingTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            player.GetComponent<Animator>().Play("ReleaseWater");
            if (repairingTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                gameManager.GetComponent<GameManager>().numberOfRepairs += 1;
                toolsOwned.Remove("Water");
                repairing.GetComponentInParent<Item>().hasBeenDestroyed = false;
            }
        }
        else if (needsWoodNear && toolsOwned.Contains("Wood") && (Input.GetKey("joystick button 0") || Input.GetKey(KeyCode.E)))
        {
            repairingTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, (3 - repairingTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            player.GetComponent<Animator>().Play("Repair_Stone&Wood");
            if (repairingTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                gameManager.GetComponent<GameManager>().numberOfRepairs += 1;
                toolsOwned.Remove("Wood");
                repairing.GetComponentInParent<Item>().hasBeenDestroyed = false;
            }
        } 
        else if (needsStoneNear && toolsOwned.Contains("Stone") && (Input.GetKey("joystick button 0") || Input.GetKey(KeyCode.E)))
        {
            repairingTimer -= Time.deltaTime;
            transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, (3 - repairingTimer) * 360 / 3);
            transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true;
            player.GetComponent<Animator>().Play("Repair_Stone&Wood");
            if (repairingTimer < 0)
            {
                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                gameManager.GetComponent<GameManager>().numberOfRepairs += 1;
                toolsOwned.Remove("Stone");
                repairing.GetComponentInParent<Item>().hasBeenDestroyed = false;
            }
        }
        else
        {
            repairingTimer = 3;            
            if (flag)
            {
                if (!transform.GetComponent<PlayerMovementScript>().moving)
                {
                    player.GetComponent<Animator>().Play("Idle");
                }

                transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;
                transform.GetChild(1).GetChild(0).rotation = Quaternion.identity;
                flag = false;
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
        if (other.CompareTag("Water") && !toolsOwned.Contains("Water"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            print ("Water near");
            waterNear = true;
        } 
        else if (other.CompareTag("NeedsWater") && other.transform.parent.GetComponent<Item>().hasBeenDestroyed)
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            print ("Water broken near");
            needsWaterNear = true;
            repairing = other.gameObject;
        }

        if (other.CompareTag("Wood") && !toolsOwned.Contains("Wood"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            print ("Wood near");
            woodNear = true;
        } 
        else if (other.CompareTag("NeedsWood") && other.transform.parent.GetComponent<Item>().hasBeenDestroyed)
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            print ("Wood broken near");
            needsWoodNear = true;
            repairing = other.gameObject;
        }

        if (other.CompareTag("Stone") && !toolsOwned.Contains("Stone"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            print ("Stone near");
            stoneNear = true;
        } 
        else if (other.CompareTag("NeedsStone") && other.transform.parent.GetComponent<Item>().hasBeenDestroyed)
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            print ("Stone broken near");
            needsStoneNear = true;
            repairing = other.gameObject;
        }
    }
    
    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Water"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            print ("Water not near");
            waterNear = false;
        }
        else if (other.CompareTag("NeedsWater"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            print ("Broken that needs water not near");
            needsWaterNear = false;
        }
        if (other.CompareTag("Wood"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            print ("Wood not near");
            woodNear = false;
        }
        else if (other.CompareTag("NeedsWood"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            print ("Broken that needs wood not near");
            needsWoodNear = false;
        }
        if (other.CompareTag("Stone"))
        {
            other.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            print ("Stone not near");
            stoneNear = false;
        }
        else if (other.CompareTag("NeedsStone"))
        {
            other.transform.GetChild(06).GetComponent<Renderer>().enabled = false;
            print ("Broken that needs stone not near");
            needsStoneNear = false;
        }
    }
}
