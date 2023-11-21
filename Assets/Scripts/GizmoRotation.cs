using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GizmoRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject targetGO;
    private List<GameObject> children = new List<GameObject>();
    [SerializeField]
    public bool isGrabbed = false;


    private void Start()
    {
        transform.rotation = Quaternion.identity;
        foreach(Transform child in transform)
        {
            children.Add(child.gameObject);
        }
    }
    private void FixedUpdate()
    {
        if(targetGO!= null)
        targetGO.transform.rotation = transform.rotation;
    }

    public void ResetAxis()
    {
        foreach (GameObject gameObject in children)
        {
            gameObject.GetComponent<RotationAxis>().ResetRotation();
        }
    }

    public void SetIsGrabbed(bool isBeingGrabbed)
    {
        isGrabbed = isBeingGrabbed;
    }

    private void OnTriggerExit(Collider other)
    {
        SetIsGrabbed(false);
        
    }
    public void SetTargetGO(GameObject target)
    {
        Transform targetTransform = target.transform;
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
        ResetAxis();
        targetGO = target;
    }
}
