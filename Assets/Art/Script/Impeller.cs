using UnityEngine;
using DG.Tweening;

public class impeller : MonoBehaviour
{
    [Header("旋转设置")]
    [Tooltip("旋转速度（度/秒）")]
    public float rotationSpeed = 90f;
    [Tooltip("旋转方向 (1=顺时针, -1=逆时针)")]
    public int direction = 1;
    [Tooltip("单次旋转角度（仅限Single模式使用）")]
    public float singleRotationAngle = 90f;
    [Tooltip("单次旋转持续时间（秒）")]
    public float singleRotationDuration = 1f;
    [Tooltip("是否在开始时自动旋转")]
    public bool autoStart = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Tweener rotationTweener = transform.DORotate(
        //         new Vector3(0, 0, 360 * direction), 
        //         360f / rotationSpeed, 
        //         RotateMode.FastBeyond360)
        //         .SetEase(Ease.Linear)
        //         .SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,  rotationSpeed * direction * Time.deltaTime);
    }
}
