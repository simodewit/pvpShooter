using Photon.Pun;
using UnityEngine;

public class HealthScript : MonoBehaviourPunCallbacks
{
    public int hp;
    PhotonView view;

    public void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void Health(int damage)
    {
        view.RPC("Code", RpcTarget.All, damage);
    }

    [PunRPC]
    public void Code(int damage)
    {
        if (!view.IsMine)
        {
            return;
        }

        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
