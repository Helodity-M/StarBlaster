using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : Shooting
{
    InputAction shootAction;
    // Update is called once per frame
    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Attack");
    }

    protected new void Update()
    {
        base.Update();
        if (shootAction.IsPressed())
        {
            if (CanFire())
            {
                CreateBullet(180);
            }
        }
    }
}
