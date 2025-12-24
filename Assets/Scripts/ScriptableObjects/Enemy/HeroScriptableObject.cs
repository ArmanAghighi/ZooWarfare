using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public string enemyName;
    public EnemyType enemyType;
    [Range(1, 6)] public int enemyLevel;
    public int enemyHealth;
    public int enemyPowerDamage;
    [Range(0, 1)] public float enemyAttackSpeed;
    public int enemyAttackRange;
    public int enemyCost;
    public bool hasUltemateAbility;
    public GameObject enemyPrefab;
}
