using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class HealthScript : MonoBehaviour
{
    public VolumeProfile volume;
    private ColorAdjustments colorAdjustments;

    public int hp;
    public bool isPlayer, isHealing, playerdied;
    public GameObject deathEffects, hitEffects;
    public Slider healthBar;
    private WinGameScript winGame;

    public int healingAmount;
    public float healingInterval;
    private float timeStamp;

    public void Start()
    {
        playerdied = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
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
        if (playerdied == true)
        {
            Invoke("ReturnToMainMenu", 5);
            playerdied = false;
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
                playerdied = true;
            }
            else
            {
                winGame.numbKills += 1;
                winGame.OnKill();
                //RaycastHit hit;
                //Vector3 spawnPos = transform.position;
                //if(Physics.Raycast(transform.position + Vector3.up,-Vector3.up, out hit, 10)){
                //    spawnPos = hit.point;
                //}
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
