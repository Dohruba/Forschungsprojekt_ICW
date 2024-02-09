using MixedReality.Toolkit.SpatialManipulation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ImportedObject : MonoBehaviour
{
    [SerializeField]
    private InteractionManager interactionManager;
    private ObjectManipulator manipulator;
    // Start is called before the first frame update
    void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>(true);
        StartCoroutine(ActionsSetup());
    }

    private IEnumerator ActionsSetup()
    {
        yield return new WaitUntil(() => GetComponent<ObjectManipulator>());
        manipulator = GetComponent<ObjectManipulator>();
        manipulator.firstSelectEntered.AddListener(ObjectIsSelected);
    }

    void ObjectIsSelected(SelectEnterEventArgs arg0)
    {
        interactionManager.SetSelectedGameObject(gameObject);
    }

    #region test functions

    #endregion
}
