using System;
using UnityEngine;

public enum WidgetEnum
{
    Translation = 0,
    Rotation = 1,
    Scalation = 2,
    None = 3
}

public static class Extensions
{
    public static Vector3 GetVectorForEnum(Transform go, WidgetEnum widget)
    {
        switch(widget){
            case WidgetEnum.Translation:
                return go.position;
            case WidgetEnum.Rotation:
                return go.rotation.eulerAngles;
            case WidgetEnum.Scalation:
                return go.localScale;
            default:
                return Vector3.zero;
        }
    }

    public static void SetValueOnVector(Transform go, WidgetEnum widget, float value, int index)
    {
        Debug.Log("SetValueOnVector Widget: " + widget);
        switch (widget)
        {
            case WidgetEnum.Translation:
                go.position = UpdateVector(go.position, value, index);
                break;
            case WidgetEnum.Rotation:
                Debug.Log("SetValueOnVector rotation pre: " + go.rotation);
                GameObject.FindObjectOfType<GizmoRotation>(true).transform.rotation = Quaternion.Euler(UpdateVector(go.rotation.eulerAngles, value, index));
                GameObject.FindObjectOfType<GizmoRotation>(true).GetComponent<GizmoRotation>().ResetAxis();
                Debug.Log("SetValueOnVector rotation post: " + go.rotation);
                break;
            case WidgetEnum.Scalation:
                break;
            default:
                break;
        }
    }

    private static Vector3 UpdateVector(Vector3 vector, float value, int index)
    {
        float[] temp = { vector.x, vector.y, vector.z };
        temp[index] = value;
        return new Vector3(temp[0], temp[1], temp[2]);
    }
}