using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float currentHealth;
    void Start()
    {
        currentHealth = Core.Instance.gameManager.selectedHero.maxHealth;
    }

    public void SetHealth(float value, bool recovery = false)
    {
        if (recovery)
        {
            currentHealth += value;
            if (currentHealth > Core.Instance.gameManager.selectedHero.maxHealth)
            {
                currentHealth = Core.Instance.gameManager.selectedHero.maxHealth;
            }
        }
        else
        {
            currentHealth -= value;
            if (currentHealth <= 0)
            {
                print("morreu");
            }
        }
    }
}
