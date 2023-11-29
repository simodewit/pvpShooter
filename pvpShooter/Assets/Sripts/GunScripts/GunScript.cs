using Photon.Pun;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviour
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

    [Header("interactions")]
    public int ammo;
    public MagScript mag;

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

    PhotonView view;

    bool canShoot;
    bool hasShot;
    int totalShots;

    float timer;

    #endregion

    #region start and update

    public void Start()
    {
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

    #region shoot code

    [PunRPC]
    public void StartInput(ActivateEventArgs arg)
    {
        canShoot = true;
    }

    public void StopInput(DeactivateEventArgs arg)
    {
        canShoot = false;
    }
    
    public void Shoot()
    {
        if (canShoot)
        {
            if (mag == null)
            {
                return;
            }
            if(mag.bullets == 0)
            {
                return;
            }

            if (semiAuto)
            {
                if (!hasShot)
                {
                    Bullet();
                    hasShot = true;
                }

            }
            else if(burst)
            {
                timer -= Time.deltaTime;

                if(totalShots < totalBurstShots && timer <= 0)
                {
                    totalShots += 1;
                    timer = shootInterval;
                    Bullet();
                }
            }
            else if (automaticGun)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = shootInterval;
                    Bullet();
                }
            }
        }
        else
        {
            timer = 0;
            totalShots = 0;
            hasShot = false;
        }
    }

    public void Bullet()
    {
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
