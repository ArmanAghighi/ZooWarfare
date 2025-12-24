using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWaveGenerator : MonoBehaviour
{
    [SerializeField] private List<StageScriptableObject> stages;

    private int _currentStageIndex;
    private int _currentWaveIndex;

    private void Start()
    {
        if (stages == null || stages.Count == 0)
        {
            Debug.LogError("No stages assigned.");
            return;
        }

        _currentStageIndex = 0;
        _currentWaveIndex = 0;

        StartCoroutine(RunStage());
    }

    private IEnumerator RunStage()
    {
        while (_currentStageIndex < stages.Count)
        {
            var stage = stages[_currentStageIndex];

            while (_currentWaveIndex < stage.Waves.Count)
            {
                yield return StartCoroutine(GenerateWave(stage.Waves[_currentWaveIndex]));
                _currentWaveIndex++;
            }

            _currentWaveIndex = 0;
            _currentStageIndex++;
        }
    }

    private IEnumerator GenerateWave(Stage wave)
    {
        if (wave.HasGenerated)
            yield break;

        yield return new WaitForSeconds(wave.WaveStartDelayTime);
        GameObject _instantiatedEnemy;
        foreach (var enemy in wave.Enemy)
        {
            _instantiatedEnemy = Instantiate(
                enemy.Enemy,
                gameObject.transform.position + enemy.EnemyPosition,
                Quaternion.identity
            );

            _instantiatedEnemy.transform.SetParent(gameObject.transform);
            
            if (enemy.RespawnTimeDelay > 0)
                yield return new WaitForSeconds(enemy.RespawnTimeDelay);
        }

        wave.HasGenerated = true;
    }
}
