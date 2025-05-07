using UnityEngine;

public class ChangcheLiZi : MonoBehaviour
{
    public ParticleSystem collisionParticles; // 拖入粒子系统
    public float destroyDelay = 2f; // 粒子系统存在时间
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter(Collider other){
        Debug.Log("检测到 other: " + other.name);
          // 播放粒子
            collisionParticles.Play();
      }
}
