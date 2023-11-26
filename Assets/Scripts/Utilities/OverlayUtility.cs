using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayUtility : MonoBehaviour
{
    public string customSortingLayerName = "Overlay";
    public int customSortingLayerID = 1;
    public int sortingOrder = 1;

    void Start()
    {
        //Debug.Log(GetComponent<MeshRenderer>().sortingLayerID);
        ////GetComponent<Renderer>().sortingLayerName = customSortingLayerName;
        //GetComponent<MeshRenderer>().sortingLayerID = customSortingLayerID;
        //GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        //Debug.Log(GetComponent<MeshRenderer>().sortingLayerID);
    }

    private void Update()
    {
        //GetComponent<Renderer>().sortingLayerID = customSortingLayerID;
        //GetComponent<Renderer>().sortingOrder = sortingOrder;
    }

}
