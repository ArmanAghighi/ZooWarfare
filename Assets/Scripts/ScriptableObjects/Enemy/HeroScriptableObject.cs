using UnityEngine;

[CreateAssetMenu(fileName = "HeroScriptableObject", menuName = "ScriptableObjects/Hero")]
public class HeroScriptableObject : ScriptableObject
{
    public string heroName;
    public HerroType heroType;
    [Range(1, 6)] public int heroLevel;
    public int heroHealth;
    public int heroPowerDamage;
    [Range(0, 1)] public float heroAttackSpeed;
    public int heroAttackRange;
    public int heroCost;
    public bool hasUltemateAbility;
    public GameObject heroPrefab;
}
