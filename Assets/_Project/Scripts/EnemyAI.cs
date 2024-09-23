using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public EnemyData enemyData;
    private Vector3 target;
    private bool isLookLeft;
    private Rigidbody2D _rigidbody2D;
    private Vector2 moveDirection;

    private float currentHealth;
    private float knockbackTime;
    private int knockbackFactor = 1;

    public GameObject hitArea;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(IETargetUpdate));
        currentHealth = enemyData.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.linearVelocity = moveDirection * enemyData.moveSpeed * knockbackFactor;
    }

    IEnumerator IETargetUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyData.targetUpdateDelay);
            target = Core.Instance.gameManager.player.position;
            moveDirection = (target - transform.position).normalized;
        }
    }

    public void TakeDamage(float damage, float knockback)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
