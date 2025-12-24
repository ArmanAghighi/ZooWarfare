using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyScriptableObject))]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EnemyScriptableObject enemyData = (EnemyScriptableObject)target;

        enemyData.enemyName = EditorGUILayout.TextField("enemy Name", enemyData.enemyName);
        enemyData.enemyType = (EnemyType)EditorGUILayout.EnumPopup("enemy Type", enemyData.enemyType);
        enemyData.enemyLevel = EditorGUILayout.IntSlider("enemy Level", enemyData.enemyLevel, 1, 6);
        enemyData.enemyHealth = EditorGUILayout.IntField("enemy Health", enemyData.enemyHealth);
        enemyData.enemyPrefab = (GameObject)EditorGUILayout.ObjectField("enemy Prefab", enemyData.enemyPrefab, typeof(GameObject), true);

        enemyData.enemyPowerDamage = EditorGUILayout.IntField("enemy Power Damage", enemyData.enemyPowerDamage);
        enemyData.enemyAttackSpeed = EditorGUILayout.Slider("enemy Attack Speed", enemyData.enemyAttackSpeed, 0f, 1f);
        enemyData.enemyAttackRange = EditorGUILayout.IntField("enemy Attack Range", enemyData.enemyAttackRange);
        enemyData.enemyCost = EditorGUILayout.IntField("enemy Cost", enemyData.enemyCost);
        enemyData.hasUltemateAbility = EditorGUILayout.Toggle("Has Ultimate Ability", enemyData.hasUltemateAbility);
    
        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(enemyData);
        }
    }
}
