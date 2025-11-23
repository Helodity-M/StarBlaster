using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;

    [SerializeField] bool useShakeEffect = false;
    [SerializeField] ParticleSystem HitParticlePrefab;
    ScreenShake shakeEffect;
    AudioManager audioPlayer;

    private void Awake()
    {
        shakeEffect = Camera.main.GetComponent<ScreenShake>();
        audioPlayer = FindAnyObjectByType<AudioManager>();
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
        audioPlayer.PlayDamageSFX();
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
