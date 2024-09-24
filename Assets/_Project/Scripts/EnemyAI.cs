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
    private float knockbackFactor = 1f;

    public GameObject hitArea;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(IETargetUpdate));
        StartCoroutine(nameof(IEAttack));
        currentHealth = enemyData.maxHealth;
        hitArea.GetComponent<MobHitArea>().data = enemyData;
    }

    // Update is called once per frame
    void Update()
    {
        if(knockbackTime > 0) {
            knockbackFactor = enemyData.knockbackWeakeness;
            knockbackTime -= Time.deltaTime;
        }
        else
        {
            knockbackFactor = 1;
        }

        if(moveDirection.x > 0 && isLookLeft)
        {
            Flip();
        }
        else if (moveDirection.x < 0 && !isLookLeft)
        {
            Flip();
        }

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

    IEnumerator IEAttack()
    {
        while (true)
        {
            hitArea.SetActive(true);
            yield return new WaitForSeconds(enemyData.attackSpeed);
            hitArea.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void TakeDamage(float damage, float knockback)
    {
        currentHealth -= damage;
        knockbackTime = knockback;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Flip()
    {
        isLookLeft = !isLookLeft;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
