using Photon.Pun;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region variables

    [Header("Conditions")]
    public float moveSpeed;
    public float runSpeed;
    public float sensitivity;
    public float jumpStrength;
    public float maxRotationUpAndDown;

    [Header("Refrences")]
    public Camera cam;
    public Rigidbody rb;
    public JumpCheck jumpCheckOnEmpty;

    //private variables
    Vector3 walkMovement;
    Vector3 moveCharacter;
    Vector3 moveCamera;
    PhotonView view;

    #endregion

    #region update

    public void Update()
    {
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            cam.enabled = false;
            return;
        }

        WalkingMovement();
        Jumping();
        MouseMovement();
    }

    #endregion

    #region walking movement

    public void WalkingMovement()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            walkMovement.x = Input.GetAxis("Horizontal");
            walkMovement.z = Input.GetAxis("Vertical");

            rb.AddRelativeForce(walkMovement * runSpeed, ForceMode.Impulse);
        }
        else
        {
            walkMovement.x = Input.GetAxis("Horizontal");
            walkMovement.z = Input.GetAxis("Vertical");

            rb.AddRelativeForce(walkMovement * moveSpeed, ForceMode.Impulse);
        }
    }

    public void Jumping()
    {
        if(!Input.GetButtonDown("Jump"))
        {
            return;
        }

        if (jumpCheckOnEmpty.isJumping)
        {
            return;
        }

        Vector3 jump = new Vector3(0, jumpStrength, 0);
        rb.AddForce(jump, ForceMode.VelocityChange);

        jumpCheckOnEmpty.isJumping = true;
    }

    #endregion

    #region camera movement

    public void MouseMovement()
    {
        moveCharacter.y = Input.GetAxis("Mouse X");
        transform.Rotate(moveCharacter * sensitivity);

        float rotate = -Input.GetAxis("Mouse Y");
        moveCamera.x += rotate * sensitivity;

        moveCamera.x = Mathf.Clamp(moveCamera.x, -maxRotationUpAndDown, maxRotationUpAndDown);
        cam.transform.localRotation = Quaternion.Euler(moveCamera);
    }

    #endregion
}
