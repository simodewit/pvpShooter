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

    [Header("General conditions")]
    public int damage;
    public bool hasToDecrease;
    public float decreasingDistance;
    public float decreasingFactor;

    [Header("refrences")]
    public Transform endOfBarrel;
    public Collider meshCollider;
    public Collider grabCollider;
    public XRGrabInteractable interactable;
    public TMPro.TMP_Text ammoScreen;
    public ParticleSystem shootParticle;
    public GameObject shootSfx;

    [Header("bullet info")]
    public GameObject bulletPrefab;
    public float bulletSpeed;

    [Header("interactions")]
    public MagScript mag;
    public bool isChambered;

    //check for shooting
    bool triggerInput;
    bool bulletIsShot;
    int burstShots;

    //timer
    float timer;

    bool hasSwitched;

    #endregion

    #region start and update

    public void Start()
    {
        Refrences();
        ammoScreen.text = "0";
    }

    public void Update()
    {
        Shoot();
        CheckMag();
        if (interactable.isSelected && hasSwitched)
        {
            hasSwitched = false;
            meshCollider.enabled = false;
            grabCollider.enabled = false;
        }
        else if(!interactable.isSelected && !hasSwitched)
        {
            hasSwitched = true;
            meshCollider.enabled = true;
            grabCollider.enabled = true;
        }
    }

    #endregion

    #region refrences

    public void Refrences()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        grabbable.activated.AddListener(StartInput);
        grabbable.deactivated.AddListener(StopInput);
    }

    #endregion

    #region input code

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
        if (mag == null && isChambered && triggerInput)
        {
            Bullet();
            return;
        }
        else if (mag == null)
        {
            return;
        }

        if (triggerInput && isChambered)
        {
            if (semiAuto && !bulletIsShot)
            {
                Bullet();
                bulletIsShot = true;
            }
            else if(burst)
            {
                timer -= Time.deltaTime;

                if(burstShots < totalBurstShots && timer <= 0)
                {
                    burstShots += 1;
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
            burstShots = 0;
            bulletIsShot = false;
        }
    }

    public void CheckMag()
    {
        if (isChambered)
        {
            if (mag == null)
            {
                ammoScreen.text = "1";
            }
            else
            {
                ammoScreen.text = (mag.bullets + 1).ToString();
            }
        }
        else
        {
            if (mag == null)
            {
                ammoScreen.text = "0";
            }
            else
            {
                ammoScreen.text = mag.bullets.ToString();
            }
        }
    }

    public void Bullet()
    {
        shootParticle.Play();
        Instantiate(shootSfx, endOfBarrel.position, endOfBarrel.rotation);
        if (mag == null)
        {
            isChambered = false;
        }
        else
        {
            if (mag.bullets == 0)
            {
                isChambered = false;
            }
            else
            {
                mag.bullets -= 1;
            }
        }

        GameObject bullet = Instantiate(bulletPrefab, endOfBarrel.position, transform.rotation);


    }

    #endregion
}
