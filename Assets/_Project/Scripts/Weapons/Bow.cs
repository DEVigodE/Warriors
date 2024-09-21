using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private PlayerController playerController;
    private Vector2 shotDirection;

    [SerializeField] private GameObject projectile;  // Expor variáveis no Inspector
    [SerializeField] private float arrowSpeed = 10f;
    [SerializeField] private float delayAttack = 0.5f;
    [SerializeField] private Transform arrowPivot;

    private Coroutine bowCoroutine;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        shotDirection = Vector2.right;

        // Iniciar a Coroutine para o ataque
        bowCoroutine = StartCoroutine(IEBow());
    }

    void FixedUpdate()
    {
        // Atualizar a direção do disparo baseada no movimento do player, normalizado
        Vector2 moveDirection = playerController.GetMoveDirection();
        if (moveDirection.sqrMagnitude > 0)
        {
            shotDirection = moveDirection.normalized;
        }
    }

    IEnumerator IEBow()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayAttack);
            ShotArrow();
        }
    }

    private void ShotArrow()
    {
        // Captura a direção de tiro no momento do disparo
        Vector2 currentShotDirection = shotDirection;

        // Calcular a rotação da flecha com base na direção do disparo
        float angle = Mathf.Atan2(currentShotDirection.y, currentShotDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Instanciar a flecha
        GameObject arrow = Instantiate(projectile, arrowPivot.position, rotation);
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();

        // Iniciar o movimento da flecha usando a direção capturada
        StartCoroutine(MoveArrow(arrowRb, currentShotDirection));

        // Destruir a flecha após 2 segundos
        Destroy(arrow, 2f);
    }

    private IEnumerator MoveArrow(Rigidbody2D arrowRb, Vector2 currentShotDirection)
    {
        float timeElapsed = 0f;

        while (timeElapsed < 2f) // Mantemos o movimento por 2 segundos
        {
            // Calcular a nova posição com MovePosition para movimentação suave
            Vector2 newPosition = arrowRb.position + (currentShotDirection * arrowSpeed * Time.fixedDeltaTime);
            arrowRb.MovePosition(newPosition);

            timeElapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDisable()
    {
        // Parar a Coroutine quando o objeto for desativado
        if (bowCoroutine != null)
        {
            StopCoroutine(bowCoroutine);
        }
    }

    // Método opcional para flipar, se necessário
    private void Flip(Transform t)
    {
        t.localScale = new Vector3(-t.localScale.x, t.localScale.y, t.localScale.z);
    }
}
