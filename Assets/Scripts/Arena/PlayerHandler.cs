using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    public float speed;
    Vector2 moveDirection;
    Vector2 aimDirection;
    bool toolNear;
    bool brokenNear;
    bool hasTool;
    float takingToolTimer = 3;
    float repairingTimer = 3;

    private void Update()
    {
        this.transform.position += new Vector3(moveDirection.x,0, moveDirection.y) * speed *  Time.deltaTime;

        if (toolNear && Input.GetKey(KeyCode.E))
        {
            takingToolTimer -= Time.deltaTime;
            if (takingToolTimer < 0)
            {
                hasTool = true;
            }
        }
        else
        {
            takingToolTimer = 3;
        }

        if (brokenNear && hasTool && Input.GetKeyDown(KeyCode.E))
        {
            repairingTimer -= Time.deltaTime;
            if (repairingTimer < 0)
            {
                
            }
        }
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void OnAim(InputValue value)
    {
        if (value.Get<Vector2>().magnitude > 0.75)
        {
            aimDirection = value.Get<Vector2>();
            this.transform.rotation = Quaternion.LookRotation(new Vector3(aimDirection.x, 0, aimDirection.y));
        }
    }

    private void OnFire()
    {
        Debug.Log("Fire");
    }

    public void OnCancel()
    {
        Debug.Log("Test");
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Tool"))
        {
            toolNear = true;
        } 
        else if (other.CompareTag("Broken"))
        {
            brokenNear = true;
        }
    }
    
    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Tool"))
        {
            toolNear = false;
        }
        else if (other.CompareTag("Broken"))
        {
            brokenNear = false;
        }
    }
}
