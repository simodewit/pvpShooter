using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class HealthScript : MonoBehaviour
{
    public VolumeProfile volume;
    private ColorAdjustments colorAdjustments;
    bool isLost = false;

    public int hp;
    public bool isPlayer, isHealing;
    public GameObject deathEffects, hitEffects;
    public Slider healthBar;
    private WinGameScript winGame;
    public AudioSource lost;

    public int healingAmount;
    public float healingInterval;
    private float timeStamp;

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            lost = GameObject.FindWithTag("Lost").GetComponent<AudioSource>();
            winGame = GameObject.FindWithTag("Win").GetComponent<WinGameScript>();
        }
        if (isPlayer)
        {
            if (volume != null)
            {
                volume.TryGet(out colorAdjustments);
                {
                    colorAdjustments.saturation.value = 0;
                }
            }
        }
    }

    public void Update()
    {
        if (isHealing == true)
        {
            HealPlayer();
        }
    }
    public void Health(int damage)
    {
        hp -= damage;
        if (isPlayer == false)
        {
            Instantiate(hitEffects, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
        }
        else
        {
            healthBar.value = hp;
        }
        if (hp <= 0)
        {
            if (isPlayer)
            {
                volume.TryGet(out colorAdjustments);
                {
                    colorAdjustments.saturation.value = -100;
                }
                Invoke("ReturnToMainMenu", 5);
                if (isLost == false)
                {
                    lost.Play();
                    isLost = true;
                }
            }
            else
            {
                winGame.numbKills += 1;
                winGame.OnKill();
                Instantiate(deathEffects, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
                FindAnyObjectByType<SpawnEnemy>().enemies.Remove(gameObject);// gadverdamme!
                Destroy(gameObject);
            }
        }

    }
    public void HealPlayer()
    {
        if (timeStamp < Time.time)
        {
            if (hp + healingAmount >= 100)
            {
                hp = 100;
            }
            else
            {
                hp += healingAmount;
            }
            timeStamp = Time.time + healingInterval;
            healthBar.value = hp;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
