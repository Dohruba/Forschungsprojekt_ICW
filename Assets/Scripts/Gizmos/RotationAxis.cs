using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RotationAxis : MonoBehaviour
{

    Quaternion startRotation;
    //[SerializeField]
    //private int axis;
    //private RotationAxisConstraint[] constraints;

    private void Start()
    {
        startRotation = transform.rotation;
        //constraints = transform.parent.GetComponents<RotationAxisConstraint>();
    }

    public void ResetRotation()
    {
        transform.rotation = startRotation;
    }

    public void OnTriggerEnter()
    {
        Debug.Log("Hovering: " + gameObject.name);
        //if (transform.parent.GetComponent<GizmoRotation>().isGrabbed) return;
        //for (int i = 0; i < constraints.Length; i++)
        //{
        //    constraints[i].enabled = i == axis;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaving: " + gameObject.name);
        GameObject parent = transform.parent.gameObject;
    }

}


