using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    public bool isJumping;

    private void OnTriggerEnter(Collider other)
    {
        isJumping = false;
    }
}
