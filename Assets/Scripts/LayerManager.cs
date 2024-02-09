using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    void Start()
    {
        SetGameLayerRecursive(gameObject, 7);
    }

    private void SetGameLayerRecursive(GameObject _go, int _layer)
    {
        _go.layer = _layer;
        foreach (Transform child in _go.transform)
        {
            child.gameObject.layer = _layer;
            SetGameLayerRecursive(child.gameObject, _layer);

        }
    }

}
