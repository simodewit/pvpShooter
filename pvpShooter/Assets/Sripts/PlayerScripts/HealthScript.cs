using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int hp;
    public bool isPlayer, isHealing;
    public GameObject deathEffects, hitEffects;
    public Slider healthBar;
    private WinGameScript winGame;

    public int healingAmount;
    public float healingInterval;
    private float timeStamp;

    public void Start()
    {
        winGame = GameObject.FindWithTag("Win").GetComponent<WinGameScript>();
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
            Instantiate(hitEffects, transform.position, transform.rotation);
        }
        else
        {
            healthBar.value = hp;
        }
        if (hp <= 0)
        {
            if (isPlayer)
            {
                //GameOver
            }
            else
            {
                winGame.numbKills += 1;
                winGame.OnKill();
                FindAnyObjectByType<SpawnEnemy>().enemies.Remove(gameObject);
                Instantiate(deathEffects, transform.position, transform.rotation);
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

}
