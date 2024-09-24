using UnityEngine;

public class MobHitArea : MonoBehaviour
{
    [HideInInspector]
    public EnemyData data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Core.Instance.gameManager.playerHealth.SetHealth(data.damage);
        }
    }
}
