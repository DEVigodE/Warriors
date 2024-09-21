using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public Transform pivotTransform;

    private void Start()
    {
        transform.parent = null;
    }

    private void Update()
    {
        transform.position = Core.Instance.gameManager.player.position;
        pivotTransform.Rotate(0,0, rotationSpeed * Time.deltaTime);
    }
}
