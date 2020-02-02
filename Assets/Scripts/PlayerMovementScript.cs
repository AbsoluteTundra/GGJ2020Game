using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float playerRotateSpeed = 5;

    private Vector3 moveDirection;
    private float heading;

    

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(moveDirection.magnitude > 0)
        {
            GameObject.Find("PlayerModel").GetComponent<Animator>().Play("Fly");
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(this.GetComponent<AudioSource>().volume, 1,Time.deltaTime*5);
        }
        else
        {
            GameObject.Find("PlayerModel").GetComponent<Animator>().Play("Idle");
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(this.GetComponent<AudioSource>().volume, 0, Time.deltaTime*5);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

        playerRotateSpeed = Mathf.Clamp( (new Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical")).magnitude)*10 , 3.5f, 8.0f);

        if (new Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical")).magnitude > 0.1f)
        {
            heading = Mathf.Atan2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
            
        }
        
        GameObject.Find("PlayerModel").transform.localRotation = Quaternion.Lerp(GameObject.Find("PlayerModel").transform.localRotation, Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0), Time.smoothDeltaTime * playerRotateSpeed);
    }
}
