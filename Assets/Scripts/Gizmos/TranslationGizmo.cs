using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationGizmo : ObjectControlWidget
{
    //For local set moveaxisconstraint uselocalspaceforconstaraint to true
    private void Start()
    {
        if(targetGO != null)
        SetTarget(targetGO);
    }

    private void FixedUpdate()
    {
        if (targetGO != null)
        {
            targetGO.transform.position = transform.position;
        }
    }
    public void SetTarget(GameObject target)
    {
        Transform targetTransform = target.transform;
        transform.position = targetTransform.position;
        targetGO = target;
        Debug.Log("Trans set target");

    }
}
