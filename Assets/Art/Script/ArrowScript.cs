using UnityEngine;
using DG.Tweening;
public class ArrowScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AnimateTextureFlow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnimateTextureFlow()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        DOTween.To(
            () => lineRenderer.material.mainTextureOffset.x,
            x => lineRenderer.material.mainTextureOffset = new Vector2(-x, 0),
            0.2f, // UV 横向偏移量
            2f  // 动画时长
        )
        .SetEase(Ease.Linear) // 使用线性缓动确保匀速运动
        .SetLoops(-1, LoopType.Incremental); // 使用增量循环模式
    }
}
