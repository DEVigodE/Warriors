using UnityEngine;

public class WeaponAreaEffect : MonoBehaviour
{
    public WeaponData data;
    public float lifeTime;
    public bool isTemporary;

    private void Start()
    {
        if (isTemporary)
            Invoke(nameof(Disable), lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IDamageable damageable = collision.GetComponent<IDamageable>();
        //if (damageable != null)
        //{
        //    damageable.TakeDamage(data.damage, data.knockback);
        //}


        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(data.damage,data.knockback);
        }
    }

    private void Disable()
    { 
        Destroy(this);
    }
}
