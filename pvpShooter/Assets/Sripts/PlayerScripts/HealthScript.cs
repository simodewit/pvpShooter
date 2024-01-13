using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp;
    public bool isPlayer, isHealing;
    public GameObject deathEffects;

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
        if (hp <= 0)
        {
            if (isPlayer)
            {
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
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (isPlayer == true && other.GetComponent<PointSystem>())
        {
            isHealing = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isPlayer == true && other.GetComponent<PointSystem>())
        {
            isHealing = false;
        }
    }
}
