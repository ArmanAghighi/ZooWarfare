using UnityEngine;

public enum HerroType
{
    Warrior,
    Archer,
    Giant,
    Collector
}

public abstract class Hero 
{
    public Hero(HeroScriptableObject heroData)
    {
        heroName = heroData.heroName;
        herroType = heroData.heroType;
        heroLevel = heroData.heroLevel;
        heroHealth = heroData.heroHealth;
        heroPowerDamage = heroData.heroPowerDamage;
        heroAttackSpeed = heroData.heroAttackSpeed;
        heroAttackRange = heroData.heroAttackRange;

    }

    protected string heroName { get; set; }
    protected HerroType herroType { get; set; }
    protected int heroLevel { get; set; }
    protected int heroHealth { get; set; }
    protected int heroPowerDamage { get; set; }
    protected float heroAttackSpeed { get; set; }
    protected int heroAttackRange { get; set; }
    protected GameObject heroPrefab;

    protected abstract void Attack(int power);
    protected abstract void GetDamaged(int damage);
    protected abstract void LevelUp();
}   
