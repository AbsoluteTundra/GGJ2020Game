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
    Vector2 aimDirection;


// alante 0, 1 - atras 0, -1 izquierda -1 0, der 1 0
    // private void Start()
    // {
    //     this.transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * speed *  Time.deltaTime;

    //     this.transform.position -= new Vector3(0, 0, distanceFromPlanet);
    // }

    private void Update()
    {
        planetCenter.transform.Rotate(new Vector3(-moveDirection.y, -moveDirection.x, 0));
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void OnFire()
    {

    }

    public void OnCancel()
    {
        
    }
}
