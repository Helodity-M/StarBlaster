using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;

    [SerializeField] bool useShakeEffect = false;
    ScreenShake shakeEffect;
    
    private void Awake()
    {
        shakeEffect = Camera.main.GetComponent<ScreenShake>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }


    void TakeDamage(int amt)
    {
        if (useShakeEffect)
        {
            shakeEffect.Play();
        }
        Debug.Log($"damage {amt}");
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
