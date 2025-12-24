using UnityEngine;

public interface IEnemyInfo
{
    string enemyName { get; }
    int enemyLevel { get; set; }
    int enemyHealth { get; set; }
    int enemyPowerDamage { get; set; }
    float enemyAttackSpeed { get; set; }
    int enemyAttackRange { get; set; }
    GameObject enemyPrefab { get; set; }
}
/*
public abstract class EnemyInfo
{
    public EnemyInfo(EnemyScriptableObject enemyData)
    {
        enemyName = enemyData.enemyName;
        enemyLevel = enemyData.enemyLevel;
        enemyHealth = enemyData.enemyHealth;
        enemyPowerDamage = enemyData.enemyPowerDamage;
        enemyAttackSpeed = enemyData.enemyAttackSpeed;
        enemyAttackRange = enemyData.enemyAttackRange;
        enemyPrefab = enemyData.enemyPrefab;
    }

    
}   
*/