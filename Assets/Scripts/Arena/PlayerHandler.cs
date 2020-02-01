using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
   public GameObject planetCenter;
   public float distanceFromPlanet;

    public float speed;
    Vector2 moveDirection;

    private void Start()
    {
        this.transform.position -= new Vector3(0, 0, distanceFromPlanet);
    }

    private void Update()
    {
        planetCenter.transform.Rotate(new Vector3(moveDirection.y, moveDirection.x, 0));
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void OnFire()
    {
        Debug.Log("Fire");
    }

    public void OnCancel()
    {
        Debug.Log("Test");
    }
}
