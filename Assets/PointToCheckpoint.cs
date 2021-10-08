using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCheckpoint : MonoBehaviour
{
    Transform target;
    public List<Transform> checkpointTransformList;
    private int nextCheckpointTransformIndex;
  
    
    public void CPGone()
    {
        if (checkpointTransformList[nextCheckpointTransformIndex] == null)
        {
            nextCheckpointTransformIndex++;
        }
        
    }
    private void Update()
    {
        target = checkpointTransformList[nextCheckpointTransformIndex];
        CPGone();
        if(nextCheckpointTransformIndex >= 4)
        {
            this.gameObject.SetActive(false);
        }
        Vector3 direction = checkpointTransformList[nextCheckpointTransformIndex].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
