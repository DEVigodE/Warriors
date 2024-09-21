using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject projectile;
    public float delayAttack;
    public Transform slashPivot;


    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        StartCoroutine(nameof(IESwordSlash));
    }


    IEnumerator IESwordSlash()
    {
        Debug.Log(delayAttack);
        while (true)
        {
            yield return new WaitForSeconds(delayAttack);
            GameObject slash = Instantiate(projectile, slashPivot.position, slashPivot.rotation);
            if (playerController.GetIsLookLeft())
            {
                Flip(slash.transform);
            }
            Destroy(slash, 0.5f);
        }
    }

    private void Flip(Transform t)
    {
        t.localScale = new Vector3(t.localScale.x * -1, t.localScale.y, t.localScale.z);
    }
}

