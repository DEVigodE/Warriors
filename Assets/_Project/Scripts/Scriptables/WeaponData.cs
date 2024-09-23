using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptables/Weapon", order = 1)]
public class WeaponData : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float knockback;
}