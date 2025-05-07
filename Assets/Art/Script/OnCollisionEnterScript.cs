using UnityEngine;

public class OnCollisionEnterScript : MonoBehaviour
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

     void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞强度是否足够
        if (collision.relativeVelocity.magnitude > 1f)
        {
            // 在碰撞点生成粒子
            ContactPoint contact = collision.contacts[0];
            Vector3 collisionPoint = contact.point;
            
            // 实例化粒子系统
            ParticleSystem particles = Instantiate(collisionParticles, collisionPoint, Quaternion.identity);
            
            // 设置粒子发射方向（可选）
            particles.transform.forward = contact.normal;
            
            // 播放粒子
            particles.Play();
            
            // 延迟销毁粒子系统
            Destroy(particles.gameObject, destroyDelay);
        }
    }
}
