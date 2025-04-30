using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraReturnButton : MonoBehaviour
{
    Transform cameraTransform; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 获取按钮组件并添加点击事件
        Button returnButton = GetComponent<Button>();
        returnButton.onClick.AddListener(ReturnCameraToOriginalPosition);
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnCameraToOriginalPosition()
    {
        // 停止所有正在进行的摄像机动画
        DOTween.Kill(cameraTransform);
        Camera.main.transform.DOMove(new Vector3(21.7f,30f,-27f),1f);
        Camera.main.transform.DORotate(new Vector3(46.8f,-19.5f,-8.368f),1f);
        CubeInteractionManager.SetZoomState(false);
    }
}
