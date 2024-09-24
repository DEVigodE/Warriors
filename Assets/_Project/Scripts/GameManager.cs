using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HeroData selectedHero;
    public Transform player;
    [HideInInspector] public PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }
}
            