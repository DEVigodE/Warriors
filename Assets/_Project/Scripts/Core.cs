using UnityEngine;

public class Core : MonoBehaviour
{
    public static Core Instance;
    public GameManager gameManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
