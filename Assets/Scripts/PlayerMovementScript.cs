using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float playerRotateSpeed = 5;

    private Vector3 moveDirection;
    private float heading;

    public GameObject player;

    public bool moving;

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(moveDirection.magnitude > 0)
        {
<<<<<<< HEAD
            player.GetComponent<Animator>().Play("Fly");
=======
            GameObject.Find("PlayerModel").GetComponent<Animator>().SetBool("isFlying", true);
>>>>>>> d59a43fcec3af6500e98c320f7fca14752f21fb8
            this.GetComponent<AudioSource>().volume = Mathf.Lerp(this.GetComponent<AudioSource>().volume, 1,Time.deltaTime*5);
            moving = true;
        }
        else
        {
<<<<<<< HEAD
            moving = false;
=======
            GameObject.Find("PlayerModel").GetComponent<Animator>().SetBool("isFlying", false);
>>>>>>> d59a43fcec3af6500e98c320f7fca14752f21fb8
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
        
<<<<<<< HEAD
        player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0), Time.smoothDeltaTime * playerRotateSpeed);
=======
        GameObject.Find("PlayerModel").transform.localRotation = Quaternion.Lerp(GameObject.Find("PlayerModel").transform.localRotation, Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0), Time.smoothDeltaTime * playerRotateSpeed);
>>>>>>> d59a43fcec3af6500e98c320f7fca14752f21fb8
    }
}
