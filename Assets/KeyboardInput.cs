using MixedReality.Toolkit.UX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    InteractionManager manager;
    private int targetCoordinate;
    private void OnEnable()
    {
        manager = GameObject.FindObjectOfType<InteractionManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TestOnValueEnter();
            Debug.Log("Caca");
        }
    }

    public void OnEnterValue()
    {
        Transform selectedGo =
            manager.SelectedGameObject.transform;
        WidgetEnum selectedWidget = 
            manager.SelectedWidget;
        GameObject[] widgets = manager.Widgets;
        foreach (GameObject item in widgets)
        {
            item.SetActive(false);
        }

        string text = GetComponent<KeyboardPreview>().PreviewText.text;
        float inputNumber = 0.0f;
        float.TryParse(text, out inputNumber);
        Debug.Log("Selected widget: "+ selectedWidget);
        Debug.Log("Input number: "+ inputNumber);
        Extensions.SetValueOnVector(selectedGo, selectedWidget, inputNumber, targetCoordinate);

        manager.ActivateWidget((int)selectedWidget);
    }

    public void SetTargetCoordinate(int i)
    {
        targetCoordinate = i;
    }


    #region test functions
    private void TestOnValueEnter()
    {
        Transform selectedGo =
            manager.SelectedGameObject.transform;
        WidgetEnum selectedWidget = WidgetEnum.Rotation;
        GameObject[] widgets = manager.Widgets;
        foreach (GameObject item in widgets)
        {
            item.SetActive(false);
        }
        float inputNumber = Random.Range(0.0f,100.0f);
        Debug.Log("Input test number: " + inputNumber);
        Extensions.SetValueOnVector(selectedGo, selectedWidget, inputNumber, targetCoordinate);

        manager.ActivateWidget((int)WidgetEnum.Rotation);
    }
    #endregion
}


