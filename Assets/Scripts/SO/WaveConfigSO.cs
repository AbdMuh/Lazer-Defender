
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/New Wave Config", fileName = "Wave Config")]
public class WaveConfigSO : ScriptableObject
{
 [SerializeField] Transform pathPrefab;
 [SerializeField] private float moveSpeed = 5f;

 public float GetMoveSpeed()
 {
  return moveSpeed;
 }

 public Transform GetStartingWaypoint()
 {
  return pathPrefab.GetChild(0);
 }

 public List<Transform> GetWayPoints()
 {
  List<Transform> waypoints = new List<Transform>();
  foreach (Transform child in pathPrefab)
  {
   waypoints.Add(child);
  }
  return waypoints;
 }
}
