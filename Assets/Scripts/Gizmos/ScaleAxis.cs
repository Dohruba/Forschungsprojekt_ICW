using MixedReality.Toolkit.SpatialManipulation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAxis : MonoBehaviour
{
    public float modificator = 10;
    [SerializeField]
    private bool isGrabbed = false;
    [SerializeField]
    private Vector3 originalPos;
    private Vector3 originalPosB;
    [SerializeField]
    private Transform targetGo;
    static Vector3 currentScale;

    private void FixedUpdate()
    {
        if (targetGo != null && isGrabbed)
        {
            IncreaseScaleInAxis();
        }
    }
    public void SetIsGrabbed(bool grabbed)
    {
        isGrabbed = grabbed;
        if (isGrabbed)
        {
            originalPos = transform.position;
            originalPosB = transform.localPosition;
        }
    }

    private void IncreaseScaleInAxis()
    {
        targetGo.transform.localScale =
            currentScale + modificator * (transform.localPosition - originalPosB);
    }

    public void ResetPosition()
    {
        currentScale = targetGo.transform.localScale;
        transform.position = originalPos;
    }


    public void SetTarget()
    {
        SacleGizmo parent = transform.parent.GetComponent<SacleGizmo>();
        targetGo = parent.IsGlobal ? parent.Container.transform : parent.TargetGO.transform;
        currentScale = targetGo.transform.localScale;
    }
}
