using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Conditions")]
    public float moveSpeed;
    public float sensitivity;
    public float jumpStrength;
    public float maxRotationUpAndDown;

    [Header("Refrences")]
    public Camera cam;
    public Rigidbody rb;
    public JumpCheck jumpCheckOnEmpty;
    public PhotonView view;

    //private variables
    Vector3 walkMovement;
    Vector3 moveCharacter;
    Vector3 moveCamera;
    
    public void Update()
    {
        if (!view.IsMine)
            return;

        WalkingMovement();
        Jumping();
        MouseMovement();
    }

    public void WalkingMovement()
    {
        walkMovement.x = Input.GetAxis("Horizontal");
        walkMovement.z = Input.GetAxis("Vertical");

        rb.AddRelativeForce(walkMovement * moveSpeed, ForceMode.Impulse);
    }

    public void Jumping()
    {
        if(!Input.GetButtonDown("Jump"))
            return;

        if (jumpCheckOnEmpty.isJumping)
            return;

        Vector3 jump = new Vector3(0, jumpStrength, 0);
        rb.AddForce(jump, ForceMode.VelocityChange);

        jumpCheckOnEmpty.isJumping = true;
    }

    public void MouseMovement()
    {
        moveCharacter.y = Input.GetAxis("Mouse X");
        transform.Rotate(moveCharacter * sensitivity);

        float rotate = -Input.GetAxis("Mouse Y");
        moveCamera.x += rotate * sensitivity;

        moveCamera.x = Mathf.Clamp(moveCamera.x, -maxRotationUpAndDown, maxRotationUpAndDown);
        cam.transform.localRotation = Quaternion.Euler(moveCamera);
    }
}
