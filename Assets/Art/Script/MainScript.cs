using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    [DllImport(dllName:"__Internal")]
    private static extern void SendInitedToWeb(string content);

    private void Awake(){
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name + " Start");
        // AdjustAspectRatio();
        SendInitedToWeb("inited");
         Screen.SetResolution(1400, 1200, true);
         
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(this.gameObject.name + " Update");
        // AdjustAspectRatio();
    }

    private void AdjustAspectRatio()
    {
        float targetAspect = 16f / 9f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Camera.main.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Camera.main.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }
}
