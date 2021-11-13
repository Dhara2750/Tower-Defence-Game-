using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float spped = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start() {
        target = Waypoints.points[0];    
    }
    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * spped * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= .2f) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}   
