using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp;
    public bool isPlayer;

    public void Health(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if (isPlayer)
            {
                Destroy(gameObject);
            }
            else
            {
                FindAnyObjectByType<SpawnEnemy>().enemies.Remove(gameObject);

                Destroy(gameObject);
            }
        }
    }
}
