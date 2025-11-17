using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveList;
    [SerializeField] int currentWaveIndex;
    [SerializeField] float timeBetweenWaveSpawns;
    [SerializeField] bool isLooping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }


    IEnumerator SpawnEnemies()
    {
        while(isLooping)
        {
            foreach (WaveConfigSO wave in waveList)
            {
                for (int i = 0; i < wave.GetEnemyCount(); i++)
                {
                    Pathfinding newPath = Instantiate(
                        wave.GetEnemyPrefab(i),
                        wave.GetStartingWaypoint().position,
                        Quaternion.identity
                    );
                    newPath.SetWaveConfig(wave);
                    yield return new WaitForSeconds(wave.GetRandomSpawnDelay());
                }
                yield return new WaitForSeconds(timeBetweenWaveSpawns);
            }
        }
    }
    public WaveConfigSO GetCurrentWave()
    {
        return waveList[currentWaveIndex];
    }
}
