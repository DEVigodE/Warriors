using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
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
}
