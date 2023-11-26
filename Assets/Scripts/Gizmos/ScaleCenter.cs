using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCenter : MonoBehaviour
{
    public bool isGrabbed = false;

    public void SetIsGrabbed(bool grabbing)
    {
        isGrabbed = grabbing;
    }
    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }
}
