using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoarseflitersSystemXunHuanGuanOutline : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private RectTransform tooltipImage; // 要显示的Image的RectTransform
    private Canvas canvas;
    private RectTransform canvasRect;
    [SerializeField] private Vector2 offset = new Vector2(300, -200); // 右下方的偏移量

    private TMP_Text uiInfoTextAuto;
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
        outline.enabled = true; // 鼠标移入时启用描边
        tooltipImage.gameObject.SetActive(true);
        uiInfoTextAuto  = tooltipImage.Find("UIInfoText1").GetComponent<TMP_Text>();
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
        uiInfoTextAuto.text = gameObject.name;
    }


    void OnMouseExit()
    {
        outline.enabled = false; // 鼠标移出时禁用描边
        tooltipImage.gameObject.SetActive(false);
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
