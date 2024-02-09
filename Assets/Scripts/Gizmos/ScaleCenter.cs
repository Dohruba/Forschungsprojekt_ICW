using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCenter : MonoBehaviour
{
    private SacleGizmo scaleGizmo;
    private Vector3 initialScale;
    public bool isGrabbed = false;


    private void Start()
    {
        scaleGizmo = transform.parent.GetComponent<SacleGizmo>();
        initialScale = transform.localScale;
    }
    void Update()
    {
        ScaleOnCenterGrabbed();
    }

    public void SetIsGrabbed(bool grabbing)
    {
        isGrabbed = grabbing;
    }
    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }
    internal void ResetScale()
    {
        transform.localScale = initialScale;
    }

    private void ScaleOnCenterGrabbed()
    {
        if (scaleGizmo.isGrabbed)
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y,
                scaleGizmo.centerTransform.localScale.z
                );
    }
}
