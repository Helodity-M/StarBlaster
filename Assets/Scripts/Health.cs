using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
        }
    }


    void TakeDamage(int amt)
    {
        Debug.Log($"damage {amt}");
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
