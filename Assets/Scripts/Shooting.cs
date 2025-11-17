using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] protected float fireRate;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected Rigidbody2D BulletPrefab;

    float timeSinceLastFire;

    protected void Update()
    {
        timeSinceLastFire += Time.deltaTime;
    }
    protected bool CanFire()
    {
        return timeSinceLastFire > fireRate;
    }
    protected GameObject CreateBullet(float rotation)
    {
        timeSinceLastFire = 0;
        Rigidbody2D bulletRB = Instantiate(BulletPrefab, transform.position, Quaternion.Euler(new Vector3(0,0,rotation)));
        bulletRB.linearVelocity = -bulletRB.transform.up * bulletSpeed;
        return bulletRB.gameObject;
    }
}
