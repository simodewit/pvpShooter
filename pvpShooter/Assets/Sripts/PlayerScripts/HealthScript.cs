using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int hp;
    public bool isPlayer, isHealing;
    public GameObject deathEffects, hitEffects;
    public Slider healthBar;

    public int healingAmount;
    public float healingInterval;
    private float timeStamp;

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
                print("Player Died at " + Time.time);
                //GameOver
            }
            else
            {
                FindAnyObjectByType<SpawnEnemy>().enemies.Remove(gameObject);

                Destroy(gameObject);
            }
            Instantiate(deathEffects, transform.position, transform.rotation);
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
