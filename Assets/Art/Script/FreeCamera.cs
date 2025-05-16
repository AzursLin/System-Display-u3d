using UnityEngine;

public class FreeCamera : MonoBehaviour
{

    public float moveSpeed = 5.0f;      // 移动速度
    public float rotateSpeed = 3.0f;    // 旋转速度
    public float zoomSpeed = 10.0f;     // 缩放速度

    private float _rotateX, _rotateY;   // 存储旋转角度
    private Vector3 _moveDirection;     // 移动方向

    // 新增全局变量（私有属性+公有getter）
    public static bool IsLeftMouseHeld  = false; // 外部只读访问
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 在旋转逻辑前更新状态
        UpdateMouseState();
        // 1. WASD 移动
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(_moveDirection * moveSpeed * Time.deltaTime);

        // 2. 鼠标右键旋转视角
        if (Input.GetMouseButton(0)) // 右键
        {
            _rotateX += Input.GetAxis("Mouse X") * rotateSpeed;
            _rotateY -= Input.GetAxis("Mouse Y") * rotateSpeed;
            _rotateY = Mathf.Clamp(_rotateY, -90f, 90f); // 限制垂直旋转角度
            transform.rotation = Quaternion.Euler(_rotateY, _rotateX, 0);
        }

        // 3. 鼠标滚轮缩放
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * zoomSpeed;
    }

    // 专用方法更新鼠标状态
    void UpdateMouseState()
    {
        if (Input.GetMouseButtonDown(0)) 
            IsLeftMouseHeld = true;
        else if (Input.GetMouseButtonUp(0)) 
            IsLeftMouseHeld = false;
    }
}
