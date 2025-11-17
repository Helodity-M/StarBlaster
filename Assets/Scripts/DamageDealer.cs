using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;
    public int GetDamage()
    {
        return damage;
    }
}
