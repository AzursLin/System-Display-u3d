using UnityEngine;
using UnityEngine.Playables; 

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     // 播放Timeline
    public void PlayTimeline()
    {
        if (director != null)
        {
            director.Play();
        }
        else
        {
            Debug.LogError("PlayableDirector未分配或找不到!");
        }
    }
    
    // 暂停Timeline
    public void PauseTimeline()
    {
        if (director != null)
        {
            director.Pause();
        }
    }
    
    // 停止Timeline
    public void StopTimeline()
    {
        if (director != null)
        {
            director.Stop();
        }
    }
    
    // 从指定时间开始播放
    public void PlayFromTime(double timeInSeconds)
    {
        if (director != null)
        {
            director.time = timeInSeconds;
            director.Play();
        }
    }
}
