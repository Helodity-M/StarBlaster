using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    [SerializeField] bool isPlayer = false;
    [SerializeField] bool useShakeEffect = false;
    [SerializeField] int scoreValue = 50;
    [SerializeField] ParticleSystem HitParticlePrefab;
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

    void PlayHitParticles()
    {
        if(HitParticlePrefab != null)
        {
            ParticleSystem sys = Instantiate(HitParticlePrefab, transform.position, Quaternion.identity);
            Destroy(sys, sys.main.startLifetime.constantMax);
        }
    }

    void TakeDamage(int amt)
    {
        PlayHitParticles();
        AudioManager.Instance.PlayDamageSFX();
        if (useShakeEffect)
        {
            shakeEffect.Play();
        }
        Debug.Log($"damage {amt}");
        health -= amt;
        if (health <= 0)
        {
            if (isPlayer)
            {
                FindFirstObjectByType<LevelManager>().LoadGameOver();
            }
            ScoreTracker.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
