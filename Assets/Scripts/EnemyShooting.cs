using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooting : Shooting
{
    protected new void Update()
    {
        base.Update();
        if (CanFire())
        {
            CreateBullet(0);
        }
    }
}
