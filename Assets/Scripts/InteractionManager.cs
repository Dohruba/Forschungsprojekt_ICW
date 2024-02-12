using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] //Serialize for testing
    private int sceneCount = 0;
    [SerializeField]
    private GameObject[] importedSceneObjects;
    public bool ScanNewScene = false;

    [SerializeField]
    private GameObject selectedGameObject;

    [SerializeField]
    private GameObject[] widgets;

    [SerializeField]
    private WidgetEnum selectedWidget = WidgetEnum.None;
    [SerializeField]
    private TextMeshPro transformUItext;

    public GameObject SelectedGameObject { get => selectedGameObject;}
    public WidgetEnum SelectedWidget { get => selectedWidget;}
    public GameObject[] Widgets { get => widgets;}

    private void Awake()
    {
        selectedWidget = WidgetEnum.None;
    }
    // Start is called before the first frame update
    void Start()
    {
        sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            Debug.Log(SceneManager.GetSceneAt(i).name);
        }
        StartCoroutine(GetNewScene());
        StartCoroutine(UpdateTransformUI());
        //keyboard = new TouchScreenKeyboard("")
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TryGetNewScene();
        }
    }
    public void ScanImportedSceneObjects()
    {
        int updatedSceneCount = SceneManager.sceneCount;
        //if (updatedSceneCount == sceneCount) return; //uncomment when connection works
        int index = sceneCount - 1;
        importedSceneObjects = SceneManager.GetSceneAt(index).GetRootGameObjects();
    }


    public void SetSelectedGameObject(GameObject go)
    {
        selectedGameObject = go;
        UpdateWidgetTargert(go);
        Debug.Log(go.name);
    }

    public void SetUpNewGameObject(GameObject _go)
    {
        if (!_go.tag.Equals("Widget") && !_go.GetComponent<ObjectManipulator>())
        {
            _go.AddComponent<ObjectManipulator>();
            _go.AddComponent<ImportedObject>();
            _go.GetComponent<ObjectManipulator>().AllowedManipulations = MixedReality.Toolkit.TransformFlags.None;
        }
    }
    public void UpdateWidgetTargert(GameObject _go)
    {
        foreach (ObjectControlWidget item in FindObjectsOfType<ObjectControlWidget>(true))
        {
            item.SetTarget(_go);
        }
    }

    public void ActivateWidget(int type)
    {
        if (selectedGameObject == null) return;
        foreach (GameObject go in Widgets)
        {
            Debug.Log((WidgetEnum)type);
            bool isType = go.GetComponent<ObjectControlWidget>().WidgetType == (WidgetEnum) type;
            go.SetActive(isType);
            selectedWidget = (WidgetEnum)type;
        }
    }

    public void SetTransformUI()
    {
        Transform info = selectedGameObject.transform;
        Vector3 relevantInfo = Vector3.zero;
        switch (selectedWidget)
        {
            case WidgetEnum.Translation:
                relevantInfo = info.position;
                break;
            case WidgetEnum.Rotation:
                relevantInfo = info.rotation.eulerAngles;
                break;
            case WidgetEnum.Scalation:
                relevantInfo = info.lossyScale;
                break;
            default:
                relevantInfo = Vector3.zero;
                break;
        }
        transformUItext.text = relevantInfo.ToString();
    }

    private IEnumerator UpdateTransformUI()
    {
        while (true)
        {
            yield return new WaitUntil(() => selectedWidget != WidgetEnum.None);
            yield return new WaitForSecondsRealtime(0.02f); // refresh 50 times per second
            SetTransformUI();
        }
    }

    private IEnumerator GetNewScene()
    {
        yield return new WaitUntil(() => ScanNewScene);
        ScanImportedSceneObjects();
        ScanNewScene = false;
        if (importedSceneObjects.Length > 0)
            MakeIncomingObjectsSelectable();
    }

    public void TryGetNewScene()
    {
        ScanNewScene = true;
    }

    private void MakeIncomingObjectsSelectable()
    {
        foreach (GameObject _go in importedSceneObjects)
        {
            SetUpNewGameObject(_go);
        }
    }


    #region Testing Functions

    private IEnumerator TestObjectsOfNewScene()
    {
        foreach (GameObject go in importedSceneObjects)
        {
            Debug.Log(go.name);
            go.SetActive(false);
        }
        yield return new WaitForSeconds(3);
        foreach (GameObject go in importedSceneObjects)
        {
            Debug.Log(go.name);
            go.SetActive(true);
        }
    }

    #endregion

 

}
