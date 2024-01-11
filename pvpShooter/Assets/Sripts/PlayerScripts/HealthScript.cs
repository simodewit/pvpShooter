using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp;

    public void Health(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
