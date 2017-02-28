using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class MoveCharacter : MonoBehaviour
{
    private float jumpSpeed = 8f;
    private float gravity = 20f;
    private float runSpeed = 50f;
    private float walkSpeed = 15f;
    private float rotateSpeed = 150f;

    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking = false;
    private string moveStatus = "idle";
    private bool jumping = false;
    private float moveSpeed = 0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3((Input.GetMouseButton(1) ? Input.GetAxis("Horizontal") : 0), 0, Input.GetAxis("Vertical"));

            if (Input.GetMouseButton(1) || Input.GetAxis("Horizontal") != 0 ||  Input.GetAxis("Vertical") != 0) {
                moveDirection *= .7f;
            }

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= isWalking ? walkSpeed : runSpeed;

            moveStatus = "idle";
            if (moveDirection != Vector3.zero)
                moveStatus = isWalking ? "walking" : "running";

            // Jump!
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }
        else
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
            Screen.lockCursor = true;
        else
            Screen.lockCursor = false;

        // Toggle walking/running with the T key
        //if (Input.GetAxis("Run") == 1)
        //    isWalking = !isWalking;
        isWalking = true;

        //Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //Move controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    float GetSpeed()
    {
        if (moveStatus == "idle")
            moveSpeed = 0;
        if (moveStatus == "walking")
            moveSpeed = walkSpeed;
        if (moveStatus == "running")
            moveSpeed = runSpeed;
        return moveSpeed;
    }

    bool IsJumping()
    {
        return jumping;
    }

    float GetWalkSpeed()
    {
        return walkSpeed;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCharacter : MonoBehaviour
{
    public float turnSpeed = 10f;
    public float moveSpeed = 10f;
    public float mouseTurnMultiplier = 1;

    private float x;
    private float z;
    void Update()
    {
        // x is used for the x axis.  set it to zero so it doesn't automatically rotate
        x = 0;

        // check to see if the W or S key is being pressed.  
        z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Move the character forwards or backwards
        transform.Translate(0, 0, z);

        // Check to see if the A or S key are being pressed
        if (Input.GetAxis("Horizontal") != 0)
        {
            // Get the A or S key (-1 or 1)
            x = Input.GetAxis("Horizontal");
        }

        // Check to see if the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Get the difference in horizontal mouse movement
            x = Input.GetAxis("Mouse X") * turnSpeed * mouseTurnMultiplier;
        }

        // rotate the character based on the x value
        transform.Rotate(0, x, 0);
    }
}
*/
