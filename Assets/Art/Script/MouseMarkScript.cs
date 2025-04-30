using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables; 

public class MouseMark : MonoBehaviour
{
    private Material originalMaterial;
    private Renderer cubeRenderer;

    private float doubleClickTime = 0.3f;
    private float lastClickTime;
    private Camera mainCamera;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private float originalFOV;

    public PlayableDirector director;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalMaterial = cubeRenderer.material;
        cubeRenderer.enabled = false;
        SetTransparency(0f);
        SetAllActive(false);

          //相机初始化
        mainCamera = Camera.main;
        originalPosition = mainCamera.transform.position;
        originalRotation = mainCamera.transform.rotation;
        originalFOV = mainCamera.fieldOfView;

        //获取动画对象
        // 通过名称查找
        Debug.Log("director: " + director);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if(!CubeInteractionManager.IsAnyCubeZoomed) {
            cubeRenderer.enabled = true;
            SetAllActive(true);
            // 鼠标进入时设为半透明
            SetTransparency(0.5f);
        }
    }

    void OnMouseExit()
    {
        if(!CubeInteractionManager.IsAnyCubeZoomed) {
            cubeRenderer.enabled = false;
            // 鼠标离开时设为完全透明（隐藏）
            // SetTransparency(0f);
            SetAllActive(false);
        }
    }

    private void SetTransparency(float alpha)
    {
        Color color = cubeRenderer.material.color;
        color.a = alpha;
        cubeRenderer.material.color = color;
    }

    private void SetAllActive(bool active) {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
    //检测双击
    void OnMouseDown()
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if (timeSinceLastClick <= doubleClickTime)
        {
            // 这是双击
           Debug.Log("双击了Cube: " + gameObject.name);
           if (gameObject.name == "Cube1")
           {
            // 拉近到这个Cube
            Camera.main.transform.DOMove(new Vector3(-10.02f,7.84f,-9f),1f);
            Camera.main.transform.DORotate(new Vector3(34.377f,-16.508f,0f),1f);
            CubeInteractionManager.SetZoomState(true);
            cubeRenderer.enabled = false;
            SetAllActive(false);
           } else if(gameObject.name == "Cube2") {
            // 拉近到这个Cube
            Camera.main.transform.DOMove(new Vector3(16.15f,11.64f,-9.7f),1f);
            Camera.main.transform.DORotate(new Vector3(34.377f,-16.508f,0f),1f);
            CubeInteractionManager.SetZoomState(true);
            cubeRenderer.enabled = false;
            SetAllActive(false);
           } else if(gameObject.name == "Cube3") {
            // 拉近到这个Cube
            Camera.main.transform.DOMove(new Vector3(35.15f,9.7f,-12.11f),1f);
            Camera.main.transform.DORotate(new Vector3(50f,17.3f,0f),1f);
            CubeInteractionManager.SetZoomState(true);
            cubeRenderer.enabled = false;
            SetAllActive(false);
           } else if(gameObject.name == "Cube4") {
            // 拉近到这个Cube
            Camera.main.transform.DOMove(new Vector3(-3.9f,9.7f,-21.87f),1f);
            Camera.main.transform.DORotate(new Vector3(50f,15.3f,0f),1f);
            CubeInteractionManager.SetZoomState(true);
            cubeRenderer.enabled = false;
            SetAllActive(false);
           } else if(gameObject.name == "Cube5") {
            // 拉近到这个Cube
            Camera.main.transform.DOMove(new Vector3(17.4f,15.36f,-23f),1f);
            Camera.main.transform.DORotate(new Vector3(57f,-15.3f,0f),1f);
            CubeInteractionManager.SetZoomState(true);
            cubeRenderer.enabled = false;
            SetAllActive(false);
            director.Play();
           } else if(gameObject.name == "Cube6") {
            // 拉近到这个Cube
            Camera.main.transform.DOMove(new Vector3(32.21f,17.42f,7.84f),1f);
            Camera.main.transform.DORotate(new Vector3(57f,-15.3f,0f),1f);
            CubeInteractionManager.SetZoomState(true);
            cubeRenderer.enabled = false;
            SetAllActive(false);
           }
        }
        
        lastClickTime = Time.time;
    }
}
