using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp;
    PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Health(int damage)
    {
        if (!view.IsMine)
        {
            return;
        }

        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
