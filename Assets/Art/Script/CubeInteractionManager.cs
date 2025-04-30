using UnityEngine;

public class CubeInteractionManager : MonoBehaviour
{
    public static bool IsAnyCubeZoomed { get; private set; }
    
    public static void SetZoomState(bool zoomed)
    {
        IsAnyCubeZoomed = zoomed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
