using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControlWidget: MonoBehaviour
{
    [SerializeField]
    protected GameObject targetGO;

    [SerializeField]
    private bool isGlobal = true;

    [SerializeField]
    private WidgetEnum widgetType;
    public bool IsGlobal { get => isGlobal; set => isGlobal = value; }
    public WidgetEnum WidgetType { get => widgetType; }

    private void OnEnable()
    {
        transform.position = targetGO.transform.position;
    }

    public void SetTarget(GameObject go)
    {
        targetGO = go;
    }
}
