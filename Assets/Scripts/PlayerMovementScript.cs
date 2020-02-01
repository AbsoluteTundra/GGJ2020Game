using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float playerRotateSpeed = 5;

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

        if (new Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical")).magnitude > 0.5f)
        {
            float heading = Mathf.Atan2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
            GameObject.Find("Player_PH").transform.localRotation = Quaternion.Lerp(GameObject.Find("Player_PH").transform.localRotation,Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0),Time.smoothDeltaTime * playerRotateSpeed);
        }
    }
}
