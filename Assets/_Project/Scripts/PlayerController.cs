using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HeroData hero;
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private bool isLookLeft = false;
    private bool isWalking = false;

    // Cached input to avoid frequent GetAxis calls in Update
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 moveDirection;

    void Awake()
    {
        // Cache components and hero prefab instance
        playerRb = GetComponent<Rigidbody2D>();
        hero = Core.Instance.gameManager.selectedHero;

        GameObject heroInstance = Instantiate(hero.prefab, transform.position, Quaternion.identity, transform);
        playerAnim = heroInstance.GetComponent<Animator>();

        Instantiate(hero.weapon.prefab, this.transform);
    }

    void Update()
    {
        // Read player input and normalize the direction
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

         moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        // Flip the character based on movement direction
        if (moveDirection.x < 0 && !isLookLeft)
        {
            Flip();
        }
        else if (moveDirection.x > 0 && isLookLeft)
        {
            Flip();
        }

        // Update walking animation
        isWalking = moveDirection != Vector2.zero;
        playerAnim.SetBool("isWalking", isWalking);
    }

    void FixedUpdate()
    {
        // Move player in FixedUpdate for smooth physics interactions
        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;
        playerRb.MovePosition(playerRb.position + moveDirection * hero.speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        isLookLeft = !isLookLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public bool GetIsLookLeft()
    {
        return isLookLeft;
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }
}
