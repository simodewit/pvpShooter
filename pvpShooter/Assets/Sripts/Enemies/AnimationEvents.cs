using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject attackingHand;
    public void AttackHitboxOn()
    {
        attackingHand.GetComponent<Collider>().enabled = true;
    }

    public void AttackHitboxOf()
    {
        attackingHand.GetComponent<Collider>().enabled = false;
    }

}
