using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigSO", menuName = "Scriptable Objects/WaveConfigSO")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] Transform pathPrefab;
    public float enemyMoveSpeed = 5f;

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
    public GameObject GetEnemyPrefab(int idx)
    {
        return EnemyPrefabs[idx];
    }
}
