using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptables/Enemy", order = 2)]
public class EnemyData : ScriptableObject
{
    public float targetUpdateDelay;
    public float moveSpeed;
}
