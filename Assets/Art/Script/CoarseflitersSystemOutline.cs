using UnityEngine;
using TMPro;
public class CoarseflitersSystemOutline : MonoBehaviour
{
    private Outline outline;
      public ParticleSystem collisionParticles; // 拖入粒子系统
    [SerializeField] private RectTransform tooltipImage; // 要显示的Image的RectTransform
    private Canvas canvas;
    private RectTransform canvasRect;
    [SerializeField] private Vector2 offset = new Vector2(300, -200); // 右下方的偏移量

    private TMP_Text uiInfoTextAuto;
    private TMP_Text uiInfoTextAuto2;

    private float lastMouseEnterTime = 0f;
    public float debounceInterval = 1f; // 防抖间隔1秒
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         // 预先添加Outline组件并初始化
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 5f;
        outline.enabled = false; // 默认关闭

        // 初始隐藏tooltip
        tooltipImage.gameObject.SetActive(false);
        canvas = tooltipImage.GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();

         collisionParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (tooltipImage.gameObject.activeInHierarchy)
        {
            // 如果tooltip可见，持续更新位置
            UpdateTooltipPosition(Input.mousePosition);

        }
    }

    void OnMouseEnter()
    {
        if(FreeCamera.IsLeftMouseHeld) return;
        outline.enabled = true; // 鼠标移入时启用描边
        tooltipImage.gameObject.SetActive(true);
        uiInfoTextAuto  = tooltipImage.Find("UIInfoText1").GetComponent<TMP_Text>();
        uiInfoTextAuto2  = tooltipImage.Find("UIInfoText2").GetComponent<TMP_Text>();
       // 遍历所有直接子对象
        // foreach (Transform child in tooltipImage)
        // {
        //     Debug.Log("找到子对象: " + child.name);
            
        //     // 获取子对象上的特定组件
        //     TMP_Text childImage = child.GetComponent<TMP_Text>();
        //     Text childText = child.GetComponent<Text>();
            
        //     if (childImage != null)
        //         Debug.Log(child.name + " 上有Image组件");
                
        //     if (childText != null)
        //         Debug.Log(child.name + " 上有Text组件");
        // }
        string[] parts = gameObject.name.Split(new[] { '-' }, 2); 
        uiInfoTextAuto.text = parts.Length > 1 ? parts[1] : parts[0];
        uiInfoTextAuto2.text = parts[0];

        //防抖动
         if (Time.time - lastMouseEnterTime < debounceInterval)
        {
            return; // 如果距离上次触发不到1秒，则忽略
        }
        lastMouseEnterTime = Time.time;

        // 播放粒子
        collisionParticles.Play();

    }


    void OnMouseExit()
    {
        outline.enabled = false; // 鼠标移出时禁用描边
        tooltipImage.gameObject.SetActive(false);

        // 停止粒子
        collisionParticles.Stop();
    }

       private void UpdateTooltipPosition(Vector2 screenPosition)
    {
        // 将鼠标位置转换为Canvas局部坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, 
            screenPosition, 
            canvas.worldCamera, 
            out Vector2 localPoint);
        
        // 计算目标位置（鼠标位置 + 偏移量）
        Vector2 targetPosition = localPoint;
        
        // 确保tooltip不会超出Canvas边界
        Vector2 clampedPosition = ClampToCanvas(targetPosition, tooltipImage.sizeDelta);
        
        // 设置tooltip位置
        tooltipImage.localPosition = targetPosition + offset;
    }

    private Vector2 ClampToCanvas(Vector2 targetPosition, Vector2 tooltipSize)
    {
        // 获取Canvas边界
        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;
        
        // 计算tooltip边界
        float minX = -canvasWidth / 2 + tooltipSize.x / 2;
        float maxX = canvasWidth / 2 - tooltipSize.x / 2;
        float minY = -canvasHeight / 2 + tooltipSize.y / 2;
        float maxY = canvasHeight / 2 - tooltipSize.y / 2;
        
        // 限制位置在边界内
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);
        
        return targetPosition;
    }
}
