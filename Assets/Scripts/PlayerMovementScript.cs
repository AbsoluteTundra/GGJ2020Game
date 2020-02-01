using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;

    private Vector3 moveDirection;

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(moveDirection.magnitude > 0)
        {
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(this.GetComponent<AudioSource>().volume, 1,Time.deltaTime*5);
        }
        else
        {
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(this.GetComponent<AudioSource>().volume, 0, Time.deltaTime*5);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
