using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigSO", menuName = "Scriptable Objects/WaveConfigSO")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Pathfinding[] EnemyPrefabs;
    [SerializeField] Transform pathPrefab;
    public float enemyMoveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 0.5f;
    [SerializeField] float enemySpawnVariance = 0.05f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return EnemyPrefabs.Length;
    }
    public Pathfinding GetEnemyPrefab(int idx)
    {
        return EnemyPrefabs[idx];
    }
    public float GetRandomSpawnDelay()
    {
        return timeBetweenEnemySpawns + Random.Range(-enemySpawnVariance, enemySpawnVariance);
    }
}
