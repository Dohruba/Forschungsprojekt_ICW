using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAxis : MonoBehaviour
{

    [SerializeField]
    private int axis;
    private SacleGizmo scaleGizmo;

    private void Start()
    {
        scaleGizmo = transform.parent.GetComponent<SacleGizmo>();
    }
    // Update is called once per frame
    void Update()
    {
        if (scaleGizmo.isGrabbed)
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y,
                scaleGizmo.centerTransform.localScale.z
                );
    }
}
