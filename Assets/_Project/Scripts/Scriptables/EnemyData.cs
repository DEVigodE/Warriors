using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptables/Enemy", order = 2)]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public Sprite enemyPortrait;

    public GameObject prefab;

    public float targetUpdateDelay;
    public float moveSpeed;
    public float maxHealth;
    public float damage;
    public int xp;

    public float knockbackWeakeness;

    public float attackSpeed;

}
