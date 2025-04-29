using UnityEngine;

public class MouseMark : MonoBehaviour
{
    private Material originalMaterial;
    private Renderer cubeRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalMaterial = cubeRenderer.material;
        SetChildrenActive(false);
        SetTransparency(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        SetChildrenActive(true);
        // 鼠标进入时设为半透明
        SetTransparency(0.5f);
    }

    void OnMouseExit()
    {
        SetChildrenActive(false);
        // 鼠标离开时设为完全透明（隐藏）
        SetTransparency(0f);
    }

    private void SetChildrenActive(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }

    private void SetTransparency(float alpha)
    {
        Color color = cubeRenderer.material.color;
        color.a = alpha;
        cubeRenderer.material.color = color;
    }
}
