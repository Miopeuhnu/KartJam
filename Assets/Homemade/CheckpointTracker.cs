using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour
{
    public List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        nextCheckpointSingleIndex = 0;
    }
    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            //Correct Checkpoint
            Debug.Log("Correct");
            checkpointSingleList[nextCheckpointSingleIndex].OnCollect();
            nextCheckpointSingleIndex++;
        }
        else
        {
            //Wrong Checkpoint
            Debug.Log("Inorrect");
        }
    }
}
