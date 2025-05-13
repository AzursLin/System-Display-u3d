using UnityEngine;
using UnityEngine.Playables;
using System.Collections; 

public class TimelineRepeater : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public float repeatInterval = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         if (timelineDirector == null)
        {
            timelineDirector = GetComponent<PlayableDirector>();
        }
        
        StartCoroutine(RepeatTimeline());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private IEnumerator RepeatTimeline()
    {
        while (true)
        {
            timelineDirector.Play();
            yield return new WaitForSeconds(repeatInterval);
        }
    }
}
