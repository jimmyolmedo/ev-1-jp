using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindPoseCharacter : MonoBehaviour
{
    public Transform rootTransform;
    public BindPose bindPose;

    [ContextMenu("Save Bind Pose")]
    public void SaveBindPose()=> bindPose.SaveBindPose(rootTransform);


    [ContextMenu("Reset Bind Pose")]
    public void ResetBindPose()=> bindPose.ResetBindPose(rootTransform);

}
