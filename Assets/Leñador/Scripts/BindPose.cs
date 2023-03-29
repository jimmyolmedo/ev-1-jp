using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformJoints
{
    public Vector3 posicion;
    public Vector3 rotacion;
    public Vector3 escala;

    public TransformJoints(Vector3 p, Vector3 r, Vector3 e)
    {
        posicion = p;
        rotacion = r;
        escala = e;
    }

    public void ResetPose(Transform joint)
    {
        joint.localPosition = posicion;
        joint.localEulerAngles = rotacion;
        joint.localScale = escala;
    }
}

[CreateAssetMenu(menuName = "Personaje/BindPose")]
public class BindPose : ScriptableObject
{
    public List<TransformJoints> joints = new List<TransformJoints>();

    public void SaveBindPose(Transform _rootTransform)
    {
        joints.Clear();
        Transform[] childs = _rootTransform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childs.Length; i++)
        {
            joints.Add(new TransformJoints(childs[i].localPosition, childs[i].localEulerAngles, childs[i].localScale));
        }
    }

    public void ResetBindPose(Transform _rootTransform)
    {
        Transform[] childs = _rootTransform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childs.Length; i++)
        {
            joints[i].ResetPose(childs[i]);
        }
    }

}
