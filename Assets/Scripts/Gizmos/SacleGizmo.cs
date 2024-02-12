using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SacleGizmo : ObjectControlWidget
{
    //If the container is rotated to macth the target = local scaling (Also rotate widget)
    //else global
    private Vector3 targetCurrentScale;
    private List<GameObject> children = new List<GameObject>();
    [SerializeField]
    public bool isGrabbed = false;
    public Transform centerTransform;
    private Vector3 initialScale;
    private GameObject container;

    public GameObject TargetGO { get => targetGO; }
    public GameObject Container { get => container; }

    private void Awake()
    {
        //Extra object to simplify scaling
        container = new GameObject("ScaleContainer");
    }
    private void Start()
    {
        //Save the initial state of the widget
        initialScale = transform.localScale;
        //Ensure correct orientation of the widget
        transform.rotation = Quaternion.identity;
        //Access to the transform of the axis
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
            if (child.GetComponent<ScaleCenter>())
                centerTransform = child.transform;
        }
    }
    private void FixedUpdate()
    {
        //Debug.Log(centerTransform.localScale);
        if (targetGO != null && isGrabbed)
        {
            container.transform.localScale = (centerTransform.localScale - Vector3.one) + targetCurrentScale;
        }
    }
    new public void SetTarget(GameObject target)
    {
        targetGO = target;
        SetUpContainer(IsGlobal);
    }

    private void SetUpContainer(bool isGlobal)
    {
        if (targetGO == null)
        {
            gameObject.SetActive(false);
            return;
        }
        if (container == null)
            container = new GameObject("ScaleContainer");
        container.transform.localScale = Vector3.one;
        container.transform.rotation = isGlobal ? Quaternion.identity : targetGO.transform.rotation;
        container.transform.position = targetGO.transform.position;
        transform.position = container.transform.position;
        transform.rotation = container.transform.rotation;
        targetGO.transform.SetParent(Container.transform, true);
        Transform targetTransform = Container.transform;
        SetTargetInChildren();
        //ResetAxis();
        Debug.Log("Scale set target");
    }

    private void SetTargetInChildren()
    {
        foreach (ScaleAxis item in GetComponentsInChildren<ScaleAxis>())
        {
            item.SetTarget();
        }
    }

    public void SetIsGrabbed(bool isBeingGrabbed)
    {
        isGrabbed = isBeingGrabbed;
        if (isBeingGrabbed)
        {
            targetCurrentScale = container.transform.localScale;
        }
    }
    public void ResetAxis()
    {
        foreach (GameObject gameObject in children)
        {
            if (gameObject.GetComponent<ScaleCenter>())
                gameObject.GetComponent<ScaleCenter>().ResetScale();
        }
        transform.localScale = initialScale;
        targetCurrentScale = container.transform.localScale;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered big sphere");
    }

    private void OnEnable()
    {
        SetUpContainer(IsGlobal);
        //StartCoroutine(LocalGlobalChange());
    }

    private void OnDisable()
    {
        //StopCoroutine(LocalGlobalChange());
        DetachContainer();
    }

    private IEnumerator LocalGlobalChange()
    {
        bool oldState = IsGlobal;
        while (true)
        {
            yield return new WaitUntil(() => IsGlobal != oldState);
            DetachContainer();
            yield return new WaitUntil(() => container == null);
            SetUpContainer(IsGlobal);
            oldState = IsGlobal;
        }
    }

    private void DetachContainer()
    {
        Debug.Log("Before detach "+targetGO.transform.lossyScale);
        targetGO.transform.SetParent(null, true);
        Debug.Log("After detach" + targetGO.transform.lossyScale);
        Destroy(container);
        Debug.Log("After destruction " + targetGO.transform.lossyScale);
    }
}

/*
 * 
 */

