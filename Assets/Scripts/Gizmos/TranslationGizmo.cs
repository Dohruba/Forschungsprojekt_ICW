using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationGizmo : MonoBehaviour
{

    [SerializeField]
    private GameObject targetGO;


    private void Start()
    {
        SetTargetGO(targetGO);
    }

    private void FixedUpdate()
    {
        if (targetGO != null)
        {
            targetGO.transform.position = transform.position;
        }
    }
    public void SetTargetGO(GameObject target)
    {
        Transform targetTransform = target.transform;
        transform.position = targetTransform.position;
        targetGO = target;
    }
}
