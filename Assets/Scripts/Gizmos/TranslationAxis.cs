using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationAxis : MonoBehaviour
{
    [SerializeField]
    private int axis;
    private MoveAxisConstraint[] constraints;
    static bool isGizmoGrabbed = false;
    protected void Start()
    {
        constraints = transform.parent.GetComponents<MoveAxisConstraint>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (isGizmoGrabbed) return;
        for(int i = 0; i < constraints.Length; i++)
        {
            constraints[i].enabled = i == axis;
        }
    }

    public void SetIsGizmoGrabbed(bool grabbed)
    {
        isGizmoGrabbed = grabbed;
    }


}
