using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private WaveConfigSO _waveConfigSo;
    private List<Transform> _waypoints;
     int _wayPointIndex = 0;
    void Start()
    {
        _waypoints = _waveConfigSo.GetWayPoints();
        foreach (Transform child in _waypoints)
        {
            Debug.Log("TRANS: "+child.transform);
        }
        transform.position = _waypoints[_wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (_wayPointIndex < _waypoints.Count)
        {
            Vector3 _targetPosition = _waypoints[_wayPointIndex].position;
            float speed = _waveConfigSo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, speed);
            if (transform.position == _targetPosition)
            {
                _wayPointIndex++;
                Debug.Log("Index: "+_wayPointIndex);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
