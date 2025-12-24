using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HeroScriptableObject))]
public class HeroEditor : Editor
{
    public override void OnInspectorGUI()
    {
        HeroScriptableObject heroData = (HeroScriptableObject)target;

        heroData.heroName = EditorGUILayout.TextField("Hero Name", heroData.heroName);
        heroData.heroType = (HerroType)EditorGUILayout.EnumPopup("Hero Type", heroData.heroType);
        heroData.heroLevel = EditorGUILayout.IntSlider("Hero Level", heroData.heroLevel, 1, 6);
        heroData.heroHealth = EditorGUILayout.IntField("Hero Health", heroData.heroHealth);
        heroData.heroPrefab = (GameObject)EditorGUILayout.ObjectField("Hero Prefab", heroData.heroPrefab, typeof(GameObject), true);

        if(heroData.heroType != HerroType.Collector)
        {
            heroData.heroPowerDamage = EditorGUILayout.IntField("Hero Power Damage", heroData.heroPowerDamage);
            heroData.heroAttackSpeed = EditorGUILayout.Slider("Hero Attack Speed", heroData.heroAttackSpeed, 0f, 1f);
            heroData.heroAttackRange = EditorGUILayout.IntField("Hero Attack Range", heroData.heroAttackRange);
            heroData.heroCost = EditorGUILayout.IntField("Hero Cost", heroData.heroCost);
            heroData.hasUltemateAbility = EditorGUILayout.Toggle("Has Ultimate Ability", heroData.hasUltemateAbility);
        }
        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(heroData);
        }
    }
}
