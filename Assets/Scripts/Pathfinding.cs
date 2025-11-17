using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    WaveConfigSO waveConfigSO;
    Transform[] waypoints;
    int waypointIndex = 0;

    public void SetWaveConfig(WaveConfigSO waveConfigSO)
    {
        this.waveConfigSO = waveConfigSO;
        waypoints = waveConfigSO.GetWaypoints();
        transform.position = waypoints[0].position;
        waypointIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveConfigSO)
            FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveAmt = waveConfigSO.enemyMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveAmt);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
