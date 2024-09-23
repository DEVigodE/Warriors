using UnityEngine;

public class ProjectileEffect : MonoBehaviour
{

    public WeaponData data;
    public int hitAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(data.damage, data.knockback);
            hitAmount--;
            if (hitAmount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
