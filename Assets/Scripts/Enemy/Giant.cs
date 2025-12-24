using System;
using UnityEngine;

public class Giant : IEnemyInfo , IWalker , ILevelManager
{

    private const int _speed = 10;
    private int _price;

    string IEnemyInfo.enemyName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int IEnemyInfo.enemyLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int IEnemyInfo.enemyHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int IEnemyInfo.enemyPowerDamage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    float IEnemyInfo.enemyAttackSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    int IEnemyInfo.enemyAttackRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    GameObject IEnemyInfo.enemyPrefab { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public event Action<int> OnLevelUpRequest;
    public event Action<int> OnDecreaseWealth;

    public Giant(EnemyScriptableObject giantData)// : base(giantData)
    {
        _price = giantData.enemyCost;
    }

/*
    protected override void Attack(int power)
    {
        
    }

    protected override void GetDamaged(int damage)
    {
        
    }
*/
    public void Move()
    {
        
    }

    void ILevelManager.LevelUp(int wealth)
    {
        if(wealth >= _price)
        {
            OnLevelUpRequest?.Invoke(_price);
            OnDecreaseWealth?.Invoke(_price);  
        }
    }

    void IEnemyInfo.Attack(int power)
    {
        throw new NotImplementedException();
    }

    void IEnemyInfo.GetDamaged(int damage)
    {
        throw new NotImplementedException();
    }
}
