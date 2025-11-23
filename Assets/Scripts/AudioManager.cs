using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootClip;
    [SerializeField][Range(0, 1)] float shootVolume;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0, 1)] float damageVolume;


    public void PlayShootingClip()
    {
        PlaySFX(shootClip, shootVolume);
    }

    public void PlayDamageSFX()
    {
        PlaySFX(damageClip, damageVolume);
    }

    public void PlaySFX(AudioClip clip,  float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
