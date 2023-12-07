using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviourPunCallbacks
{
    #region variables

    [Header("Gun type (1 is primary, 2 is secondary, 3 is melee weapon)")]
    public int weaponType;

    [Header("Gun details")]
    public bool semiAuto;
    public bool burst;
    public bool automaticGun;
    public int totalBurstShots;
    public float shootInterval;

    [Header("General conditions")]
    public int damage;
    public bool hasToDecrease;
    public float decreasingDistance;
    public float decreasingFactor;

    [Header("refrences")]
    public Transform endOfBarrel;

    [Header("bullet info")]
    public string bulletName;
    public float bulletSpeed;

    [Header("interactions")]
    public MagScript mag;

    //view
    PhotonView view;

    //check for shooting
    bool triggerInput;
    bool bulletIsShot;
    int burstShots;

    //timer
    float timer;

    Debugger debug;

    #endregion

    #region start and update

    public void Start()
    {
        debug = GameObject.Find("DebugTool").GetComponent<Debugger>();
        Refrences();
    }

    public void Update()
    {
        Shoot();
    }

    #endregion

    #region refrences

    public void Refrences()
    {
        view = GetComponent<PhotonView>();

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        grabbable.activated.AddListener(StartInput);
        grabbable.deactivated.AddListener(StopInput);
    }

    #endregion

    #region input code

    [PunRPC]
    public void StartInput(ActivateEventArgs arg)
    {
        triggerInput = true;
    }

    public void StopInput(DeactivateEventArgs arg)
    {
        triggerInput = false;
    }

    #endregion

    #region shoot code

    public void Shoot()
    {
        if (triggerInput && mag.bullets != 0)
        {
            if (semiAuto && !bulletIsShot)
            {
                view.RPC("Bullet", RpcTarget.All);
                bulletIsShot = true;
            }
            else if(burst)
            {
                timer -= Time.deltaTime;

                if(burstShots < totalBurstShots && timer <= 0)
                {
                    burstShots += 1;
                    timer = shootInterval;
                    view.RPC("Bullet", RpcTarget.All);
                }
            }
            else if (automaticGun)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = shootInterval;
                    view.RPC("Bullet", RpcTarget.All);
                }
            }
        }
        else
        {
            timer = 0;
            burstShots = 0;
            bulletIsShot = false;
        }
    }

    [PunRPC]
    public void Bullet()
    {
        debug.Print("shoot");

        mag.bullets -= 1;

        GameObject bullet = PhotonNetwork.Instantiate(bulletName, endOfBarrel.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        bullet.GetComponent<BulletScript>().damage = damage;
        bullet.GetComponent<BulletScript>().hasToDecrease = hasToDecrease;
        bullet.GetComponent<BulletScript>().decreasingDistance = decreasingDistance;
        bullet.GetComponent<BulletScript>().decreasingFactor = decreasingFactor;
    }

    #endregion
}
