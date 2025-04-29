using UnityEngine;

public class CubeHoverEffect : MonoBehaviour
{
    private Material originalMaterial;
    private Renderer cubeRenderer;
    private bool isTransparent = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalMaterial = cubeRenderer.material;
        
        // 初始状态设为完全透明（隐藏）
        SetTransparency(0f);
    }

        void OnMouseEnter()
    {
        // 鼠标进入时设为半透明
        SetTransparency(0.5f);
        isTransparent = true;
    }

    void OnMouseExit()
    {
        // 鼠标离开时设为完全透明（隐藏）
        SetTransparency(0f);
        isTransparent = false;
    }

    private void SetTransparency(float alpha)
    {
        Color color = cubeRenderer.material.color;
        color.a = alpha;
        cubeRenderer.material.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
